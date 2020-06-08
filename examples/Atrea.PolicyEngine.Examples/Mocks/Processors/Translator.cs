using System.Threading.Tasks;
using Atrea.PolicyEngine.Examples.Mocks.Domain;
using Atrea.PolicyEngine.Processors;

namespace Atrea.PolicyEngine.Examples.Mocks.Processors
{
    public interface ITranslator<in T> : IProcessor<T>, IAsyncProcessor<T> where T : TranslatableItem { }

    public class GoogleTranslator : ITranslator<TranslatableItem>
    {
        public void Process(TranslatableItem item)
        {
            // Implementation left to the imagination of the reader.
        }

        public async Task ProcessAsync(TranslatableItem item)
        {
            // Implementation left to the imagination of the reader.
            await Task.Run(() => { });
        }
    }

    public class MicrosoftTranslator : ITranslator<TranslatableItem>
    {
        public void Process(TranslatableItem item)
        {
            // Implementation left to the imagination of the reader.
        }

        public async Task ProcessAsync(TranslatableItem item)
        {
            // Implementation left to the imagination of the reader.
            await Task.Run(() => { });
        }
    }

    public class CacheTranslator : ITranslator<TranslatableItem>
    {
        public void Process(TranslatableItem item)
        {
            // Implementation left to the imagination of the reader.
        }

        public async Task ProcessAsync(TranslatableItem item)
        {
            // Implementation left to the imagination of the reader.
            await Task.Run(() => { });
        }
    }

    public class SingleWordTranslator : ITranslator<TranslatableItem>
    {
        public void Process(TranslatableItem item)
        {
            // Implementation left to the imagination of the reader.
        }

        public async Task ProcessAsync(TranslatableItem item)
        {
            // Implementation left to the imagination of the reader.
            await Task.Run(() => { });
        }
    }

    public class DictionaryTranslator : ITranslator<TranslatableItem>
    {
        public void Process(TranslatableItem item)
        {
            // Implementation left to the imagination of the reader.
        }

        public async Task ProcessAsync(TranslatableItem item)
        {
            // Implementation left to the imagination of the reader.
            await Task.Run(() => { });
        }
    }
}