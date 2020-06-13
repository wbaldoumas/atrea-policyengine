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
  * [Examples](#examples)
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

Once you've implemented your [input policies](#input-policies), [processors](#processors), and [output policies](#output-policies), you can build your policy engine using the [`PolicyEngineBuilder<T>`](https://github.com/itabaiyu/atrea-policyengine/blob/itabaiyu_usage_documentation/src/Atrea.PolicyEngine/Builders/PolicyEngineBuilder.cs). In the example below we are configuring a policy engine which performs translations between natural languages.

```cs
var engine = PolicyEngineBuilder<TranslatableItem>
    .Configure()
    .WithInputPolicies(
        // For this engine, we only want it to translate items which have not
        // yet been translated, and are translations from US English to UK English.
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

Input policies can be thought of as the gatekeepers that guard the rest of a policy engine's processing and post-processing steps. They should be used to check whether a given item that has entered the policy engine should be processed by it or not. The [`IInputPolicy<T>`](https://github.com/itabaiyu/atrea-policyengine/blob/master/src/Atrea.PolicyEngine/Policies/Input/IInputPolicy.cs) interface is implemented by a given input policy, whose `ShouldProcess(T item)` method can return one of three [`InputPolicyResult`](https://github.com/itabaiyu/atrea-policyengine/blob/master/src/Atrea.PolicyEngine/Policies/Input/InputPolicyResult.cs) values: `Continue`, `Accept`, and `Reject`. How the policy engine handles these input policy results is described below.


| **Value** | **Behavior** |
| --------- | ------------ |
| `Continue` | Accept the item by this specific input policy - continue evaluating remaining input policies, or begin processing the item if this is the last input policy evaluated.
| `Accept` | Accept the item for processing - skip evaluation of any remaining input policies, and begin processing the item.
| `Reject` | Reject the item for processing - skip evaulation of any remaining input policies, do not process the item with the engine's processors nor apply post-processing with the engine's output policies.

:warning: When input policies are configured to run in parallel, all input policies are run and there is no meaningful difference between InputPolicyResult.Continue and `InputPolicyResult.Accept`.

<a name="implementing-input-policies"/>

#### Implementing Input Policies

<a name="compound-input-policies/>

#### Compound Input Policies

<a name="processors"/>

### Processors

<a name="output-policies"/>

### Output Policies

<a name="asynchronous-and-parallel-processing"/>

### Asynchronous and Parallel Processing

Async and parallel processing is also supported in a myriad of configurations by implementing the [`IAsyncInputPolicy<T>`](https://github.com/itabaiyu/atrea-policyengine/blob/master/src/Atrea.PolicyEngine/Policies/Input/IAsyncInputPolicy.cs), [`IAsyncProcessor<T>`](https://github.com/itabaiyu/atrea-policyengine/blob/master/src/Atrea.PolicyEngine/Processors/IAsyncProcessor.cs), and [`IAsyncOutputPolicy<T>`](https://github.com/itabaiyu/atrea-policyengine/blob/master/src/Atrea.PolicyEngine/Policies/Output/IAsyncOutputPolicy.cs) interfaces and using the [`AsyncPolicyEngineBuilder<T>`](https://github.com/itabaiyu/atrea-policyengine/blob/master/src/Atrea.PolicyEngine/Builders/AsyncPolicyEngineBuilder.cs). Here we configure async input policies to be awaited in order, processors to be run in parallel, and output policies to be run in parallel.


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

<a name="examples"/>

### Examples

---

<a name="related-projects"/>

#### Related Projects:

* [Atrea.Extensions](https://github.com/itabaiyu/atrea-extensions)
* [Atrea.Utilities](https://github.com/itabaiyu/atrea-utilities)

**Show your support by contributing or starring the repo!** :star::star::star::star::star: 
