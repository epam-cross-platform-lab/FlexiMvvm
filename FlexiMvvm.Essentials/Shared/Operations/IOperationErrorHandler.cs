using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    internal interface IOperationErrorHandler
    {
        [NotNull]
        Func<OperationError, CancellationToken, Task> Handler { get; }

        bool CanHandle([NotNull] Exception ex);
    }
}
