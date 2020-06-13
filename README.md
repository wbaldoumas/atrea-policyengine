# Atrea.PolicyEngine

A modular, composable policy engine for easy implementation of complex conditional processing pipelines.

[![GitHub Workflow Status](https://img.shields.io/github/workflow/status/itabaiyu/atrea-policyengine/.NET%20Core%20Build%20&%20Test)](https://github.com/itabaiyu/atrea-policyengine/actions?query=workflow%3A%22.NET+Core+Build+%26+Test%22)
[![Coverage Status](https://coveralls.io/repos/github/itabaiyu/atrea-policyengine/badge.svg?branch=master)](https://coveralls.io/github/itabaiyu/atrea-policyengine?branch=master)

[![NuGet Badge](https://buildstats.info/nuget/atrea.policyengine)](https://www.nuget.org/packages/atrea.policyengine/)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/atrea.policyengine)
[![Nuget](https://img.shields.io/nuget/dt/Atrea.PolicyEngine)](https://www.nuget.org/packages/Atrea.PolicyEngine)

![GitHub last commit](https://img.shields.io/github/last-commit/itabaiyu/atrea-policyengine) 
![GitHub commit activity](https://img.shields.io/github/commit-activity/w/itabaiyu/atrea-policyengine)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/itabaiyu/atrea-policyengine)
![GitHub commit activity](https://img.shields.io/github/commit-activity/y/itabaiyu/atrea-policyengine)

![Size](https://img.shields.io/github/repo-size/itabaiyu/atrea-policyengine)
[![GitHub](https://img.shields.io/github/license/itabaiyu/atrea-policyengine)](https://github.com/itabaiyu/atrea-policyengine/blob/master/LICENSE)

* [Installation](#installation)
* [Documentation](#installation)
  * [Basic Usage](#basic-usage)
  * [Input Policies](#input-policies)
  * [Processors](#processors)
  * [Output Policies](#output-policies)
  * [Asynchronous and Parallel Processing](#asynchronous-and-parallel-processing)
  * [Nesting Engines](#nesting-engines)
  * [Examples](#code-examples)
* [Related Projects](#related-projects)

<a name="installation"/>

## Installation

Package manager:
```
Install-Package Atrea.PolicyEngine -Version 2.1.0
```

.NET CLI:
```
dotnet add package Atrea.PolicyEngine --version 2.1.0
```

<a name="documentation"/>

## Documentation

<a name="basic-usage"/>

### Basic Usage

Once [input policies](#input-policies), [processors](#processors), and [output policies](#output-policies) have been implemented, a policy engine can be built using the `PolicyEngineBuilder<T>`. In the example below we configure a policy engine which performs translations between natural languages.

```cs
var engine = PolicyEngineBuilder<TranslatableItem>
    .Configure()
    .WithInputPolicies(
        // For this engine, we only want it to translate items which have not
        // yet been translated and are translations from US English to UK English.
        new IsNotYetTranslated(),
        new IsFromUsEnglish(),
        new IsToUkEnglish()
    ).WithProcessors(
        // Use the Google machine translation API and a proprietary single-word
        // translator to perform translations.
        new GoogleTranslator(),
        new SingleWordTranslator()
    ).WithOutputPolicies(
        // Once an item is translated, publish the translation to an event stream
        // and mark the item as translated.
        new PublishTranslation(),
        new MarkItemTranslated()
    ).Build();

var translatableItem = _repository.GetTranslatableItem();

// Process the item.
engine.Process(translatableItem);
```

<a name="input-policies"/>

### Input Policies

Input policies can be thought of as the gatekeepers that guard the rest of a policy engine's processing and post-processing steps. They should be used to check whether a given item that has entered the policy engine should be processed or not.

The `IInputPolicy<T>` interface is implemented by a given input policy, whose `ShouldProcess(T item)` method can return one of three `InputPolicyResult` values: `Continue`, `Accept`, or `Reject`. How the policy engine handles these input policy results is described below.

| **Value** | **Behavior** |
| --------- | ------------ |
| `InputPolicyResult.Continue` | Accept the item by this specific input policy - continue evaluating remaining input policies, or begin processing the item if this is the last input policy evaluated.
| `InputPolicyResult.Accept` | Accept the item for processing - skip evaluation of any remaining input policies, and begin processing the item.
| `InputPolicyResult.Reject` | Reject the item for processing - skip evaluation of any remaining input policies, do not process the item with the engine's processors nor apply post-processing with the engine's output policies.

Input policies are run in the order that they are passed to the `PolicyEngineBuilder<T>.WithInputPolicies(...)` or `AsyncPolicyEngineBuilder<T>.WithAsyncInputPolicies(...)` methods. 

:warning: Note that when an async policy engine is configured with `AsyncPolicyEngineBuilder<T>.WithParallelInputPolicies(...)`, all input policies are run in parallel and there is no meaningful difference between `InputPolicyResult.Continue` and `InputPolicyResult.Accept`.

<a name="implementing-input-policies"/>

#### Implementing Input Policies

Input policies should aim to follow the [Single-Responsibility Principle](https://en.wikipedia.org/wiki/Single-responsibility_principle) such that each input policy inspects just one facet of information about the item to be processed by the engine. This allows for a much more flexibly configurable engine as well as better reusability for the input policies themselves.

Here is an example of a **_poorly_** implemented input policy that is doing too much:

```cs
public class ShouldCanadianFrenchToUsEnglishEngineProcess : IInputPolicy<TranslatableItem>
{
    public InputPolicyResult ShouldProcess(TranslatableItem item)
    {
        if (item.IsTranslated)
        {
            return InputPolicyResult.Reject;
        }

        if (item.IsQueuedByUser)
        {
            return InputPolicyResult.Accept;
        }

        if (item.FromLanguage != LanguageCode.CaFr)
        {
            return InputPolicyResult.Reject;
        }

        if (item.ToLanguage != LanguageCode.UsEn)
        {
            return InputPolicyResult.Reject;
        }

        return InputPolicyResult.Continue;
    }
}
```

Here are just some of the problems with the input policy implementation above:

* It isn't reusable by other policy engines.
* It doesn't follow the [Single-Responsibility Principle](https://en.wikipedia.org/wiki/Single-responsibility_principle).
* It is hard to unit test all possible branches for this input policy.

This can be refactored into a cleaner implementation by breaking down each of the checks above into separate input policies:

```cs
public class IsNotYetTranslated : IInputPolicy<TranslatableItem>
{
    public InputPolicyResult ShouldProcess(TranslatableItem item)
    {
        if (item.IsTranslated)
        {
            return InputPolicyResult.Reject;
        }

        return InputPolicyResult.Continue;
    }
}
```

```cs
public class IsQueuedByUser : IInputPolicy<TranslatableItem>
{
    public InputPolicyResult ShouldProcess(TranslatableItem item)
    {
        if (item.IsQueuedByUser)
        {
            return InputPolicyResult.Accept;
        }

        return InputPolicyResult.Continue;
    }
}
```

```cs
public class IsFromCanadianFrench : IInputPolicy<TranslatableItem>
{
    public InputPolicyResult ShouldProcess(TranslatableItem item)
    {
        if (item.FromLanguage != LanguageCode.CaFr)
        {
            return InputPolicyResult.Reject;
        }

        return InputPolicyResult.Continue;
    }
}
```

```cs
public class IsToUsEnglish : IInputPolicy<TranslatableItem>
{
    public InputPolicyResult ShouldProcess(TranslatableItem item)
    {
        if (item.ToLanguage != LanguageCode.UsEn)
        {
            return InputPolicyResult.Reject;
        }

        return InputPolicyResult.Continue;
    }
}
```

Note that although this produces more code, classes, and source files, each input policy follows the Single-Responsibility Principal, is reusable within the context of other policy engines, and is extremely easy to unit test! :heavy_check_mark: :heavy_check_mark: :heavy_check_mark:

These can then be passed to the policy engine builder's `WithInputPolicies(...)` method as such:

```cs
var engine = PolicyEngineBuilder<TranslatableItem>
    .Configure()
    .WithInputPolicies(
        new IsNotYetTranslated(),
        new IsQueuedByUser(),
        new IsFromCanadianFrench(),
        new IsToUsEnglish()
    )
    .WithProcessors(...)
    .WithOutputPolicies(...)
    .Build();
```

#### Async Input Policies

If some input policies are more complex and have dependencies that perform `async` operations, the `IAsyncInputPolicy<T>` interface can be implemented instead. See more about [asynchronous and parallel processing](#asynchronous-and-parallel-processing) below.

<a name="compound-input-policies/>

#### Compound Input Policies

The Atrea.PolicyEngine library also provides a handful of useful compound input policies. These currently include `And<T>`, `Or<T>`, and `Xor<T>`.

These compound input policies can be created by passing other input policies constructor arguments:

```cs
var isFromCanadianFrenchAndToUsEnglish = new And<TranslatableItem>(
  new IsFromCanadianFrench(),
  new IsToUsEnglish();
)
```

or by using the built-in `IInputPolicy<T>` extension methods:

```cs
var isFromCanadianFrenchToUsEnglish = new IsFromCanadianFrench().And(new IsToUsEnglish());
```

Using these compound input policies allows for creation of complex input policies on the fly by composing together more granular input policies in an intuitive way.

```cs
var isFromCanadianFrench = new IsFromCanadianFrench();
var isToCanadianFrench = new IsToCanadianFrench();
var isFromUsEnglish = new IsFromUsEnglish();
var isToUsEnglish = new IsToUsEnglish();

var isFromCanadianFrenchToUsEnglish = isFromCanadianFrench.And(isToUsEnglish);
var isFromUsEnglishToCanadianFrench = isFromUsEnglish.And(isToCanadianFrench);

var isCanadianFrenchUsEnglishTranslation = isFromCanadianFrenchToUsEnglish.Xor(
    isFromUsEnglishToCanadianFrench
);
```

A `Not<T>` input policy is also available to easily reverse the output of any given input policy.

```cs
var isAlreadyTranslated = new Not<TranslatableItem>(new IsNotYetTranslated());
```

`Not<T>` is implemented in such a way that it produces the following `InputPolicyResult` values.

| **InputPolicyResult** | **Not\<T> InputPolicyResult**
| --- | --- |
| `InputPolicyResult.Continue` | `InputPolicyResult.Reject` 
| `InputPolicyResult.Accept` | `InputPolicyResult.Reject`
| `InputPolicyResult.Reject` | `InputPolicyResult.Continue`

Versions of these compound input policies that support `async` operations are also avaible with `AsyncAnd<T>`, `AsyncOr<T>`, `AsyncXor<T>`, and `AsyncNot<T>`.

<a name="processors"/>

### Processors

A policy engine's processors should be where a brunt of the complex processing of items takes place. A given processor should implement the `IProcessor<T>` or `IAsyncProcessor<T>` interface, whose respective `Process(T item)` or `ProcessAsync(T item)` method will be called by the policy engine when an item has been accepted for processing by the engine's input policies. In our example, this is where we are actually reaching out to external APIs or data stores to perform machine translation between natural languages.

```cs
public class GoogleTranslator : IProcessor<TranslatableItem>
{
    private readonly ITranslationClient _googleTranslationClient;

    public GoogleTranslator(ITranslationClient googleTranslationClient)
    {
        _googleTranslationClient = googleTranslationClient;
    }

    public void Process(TranslatableItem item)
    {
        var response = _googleTranslationClient.TranslateText(
            item.SourceText,
            item.FromLanguage,
            item.ToLanguage
        );

        item.TranslatedText = response.TranslatedText;
    }
}
```

Processors can be configured to run synchronously, asynchronously, and in parallel. See more about [asynchronous and parallel processing](#asynchronous-and-parallel-processing) below.

### Output Policies

A policy engine's output policies can be thought of as light post-processors that should be run after the engine's main processing step has been completed. They shouldn't be doing any heavy lifting. In our example we have an output policy that is pushing messages to an event stream.

```cs
public class PublishTranslation : IOutputPolicy<TranslatableItem>
{
    private readonly IKafkaProducer<TranslatableItemMessage> _messageProducer;

    public PublishTranslation(IKafkaProducer<TranslatableItemMessage> messageProducer)
    {
        _messageProducer = messageProducer;
    }

    public void Apply(TranslatableItem item)
    {
        var message = new TranslatableItemMessage(item);

        _messageProducer.Produce(message);
    }
}
```

Output policies can be configured to run synchronously, asynchronously, and in parallel. See more about [asynchronous and parallel processing](#asynchronous-and-parallel-processing) below.

### Asynchronous and Parallel Processing

Async and parallel processing is supported in a myriad of configurations by implementing the `IAsyncInputPolicy<T>`, `IAsyncProcessor<T>`, and `IAsyncOutputPolicy<T>` interfaces and using the `AsyncPolicyEngineBuilder<T>`. 

Here we configure async input policies to be awaited in order, processors to be run in parallel, and output policies to be run in parallel.

```cs
var engine = AsyncPolicyEngineBuilder<TranslatableItem>
    .Configure()
    .WithAsyncInputPolicies(
        // For this engine, we only want it to translate items which have not
        // yet been translated, and are translations from Canadian French to US English.
        new IsNotYetTranslated(),
        new IsFromCanadianFrench(),
        new IsToUsEnglish()
    ).WithParallelProcessors(
        // Use the Google and Microsoft machine translation APIs, and a proprietary cache-based
        // translator to perform translations.
        new GoogleTranslator(),
        new MicrosoftTranslator(),
        new CacheTranslator()
    ).WithParallelOutputPolicies(
        // Once an item is translated, publish the translation to an event stream
        // and mark the item as translated.
        new PublishTranslation(),
        new MarkItemTranslated()
    ).Build();

var translatableItem = _repository.GetTranslatableItem();

// Process the item.
await engine.ProcessAsync(translatableItem);
```

<a name="nesting-engines"/>

### Nesting Engines




<a name="code-examples"/>

### Code Examples

Full code examples can be found in this repository at the following links:

* [Simple `PolicyEngineBuilder<T>` usage](https://github.com/itabaiyu/atrea-policyengine/blob/itabaiyu_usage_documentation/examples/Atrea.PolicyEngine.Examples/Examples/SimplePolicyEngineExample.cs)
* [Simple `AsyncPolicyEngineBuilder<T>` usage](https://github.com/itabaiyu/atrea-policyengine/blob/itabaiyu_usage_documentation/examples/Atrea.PolicyEngine.Examples/Examples/SimpleAsyncPolicyEngineExample.cs)
* [`PolicyEngineBuilder<T>` usage with compound input policies](https://github.com/itabaiyu/atrea-policyengine/blob/itabaiyu_usage_documentation/examples/Atrea.PolicyEngine.Examples/Examples/PolicyEngineWithCompoundInputPoliciesExample.cs)
* [`AsyncPolicyEngineBuilder<T>` usage with compound input policies](https://github.com/itabaiyu/atrea-policyengine/blob/itabaiyu_usage_documentation/examples/Atrea.PolicyEngine.Examples/Examples/AsyncPolicyEngineWithCompoundInputPoliciesExample.cs)
* [Nested policy engine configuration](https://github.com/itabaiyu/atrea-policyengine/blob/itabaiyu_usage_documentation/examples/Atrea.PolicyEngine.Examples/Examples/NestedPolicyEngineExample.cs)
* [Nested async policy engine configuration](https://github.com/itabaiyu/atrea-policyengine/blob/itabaiyu_usage_documentation/examples/Atrea.PolicyEngine.Examples/Examples/NestedAsyncPolicyEngineExample.cs)

---

<a name="related-projects"/>

#### Related Projects:

* [Atrea.Extensions](https://github.com/itabaiyu/atrea-extensions)
* [Atrea.Utilities](https://github.com/itabaiyu/atrea-utilities)

**Show your support by contributing or starring the repo!** :star::star::star::star::star: 
