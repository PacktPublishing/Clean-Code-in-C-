using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH01_CodingStandardsAndPrinciples.BadCode
{
    [Serializable]
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message) : base(message)
        {
        }

        public BusinessRuleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BusinessRuleException()
        {
        }

        protected BusinessRuleException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }
}
