using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace WebAPI.Helpers
{
    [Serializable]
    public class AppException :  Exception
    {
        public AppException() : base() { }
        protected AppException(SerializationInfo info, StreamingContext context): base(info, context) { }
        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
