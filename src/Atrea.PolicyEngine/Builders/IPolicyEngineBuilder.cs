using Atrea.PolicyEngine.Policies.Input;
using Atrea.PolicyEngine.Policies.Output;
using Atrea.PolicyEngine.Processors;
using System.Collections.Generic;

namespace Atrea.PolicyEngine.Builders
{
    public interface IInputPolicyEngineBuilder<T>
    {
        IProcessorPolicyEngineBuilder<T> WithInputPolicies(IEnumerable<IInputPolicy<T>> inputPolicies);
    }

    public interface IProcessorPolicyEngineBuilder<T>
    {
        IOutputPolicyEngineBuilder<T> WithProcessors(IEnumerable<IProcessor<T>> processors);
    }

    public interface IOutputPolicyEngineBuilder<T>
    {
        IPolicyEngineBuilder<T> WithOutputPolicies(IEnumerable<IOutputPolicy<T>> outputPolicies);
    }

    public interface IPolicyEngineBuilder<in T>
    {
        IPolicyEngine<T> Build();
    }
}