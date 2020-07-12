using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Transactions;

namespace CH11_Transactions.Attributes
{
    [PSerializable]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RequiresTransactionAttribute : OnMethodBoundaryAspect
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
