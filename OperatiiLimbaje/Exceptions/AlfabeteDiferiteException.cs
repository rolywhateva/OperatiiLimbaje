using System;
using System.Runtime.Serialization;

namespace OperatiiLimbaje.Exceptions
{
    [Serializable]
    internal class AlfabeteDiferiteException : Exception
    {
        public AlfabeteDiferiteException()
        {
        }

        public AlfabeteDiferiteException(string message) : base(message)
        {
        }

        public AlfabeteDiferiteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlfabeteDiferiteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}