using System;
using System.Transactions;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace CrossCuttingConcerns.Transactions
{
    [PSerializable]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RequiresTransactionAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var transactionScope = new TransactionScope(TransactionScopeOption.Required);
            args.MethodExecutionTag = transactionScope;
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            var transactionScope = (TransactionScope)args.MethodExecutionTag;
            transactionScope.Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var transactionScope = (TransactionScope)args.MethodExecutionTag;
            transactionScope.Dispose();
        }
    }
}