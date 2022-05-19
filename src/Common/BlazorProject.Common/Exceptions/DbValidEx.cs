using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Common.Exceptions
{
    public class DbValidEx : Exception
    {
        public DbValidEx()
        {
        }

        public DbValidEx(string message) : base(message)
        {
        }

        public DbValidEx(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbValidEx(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
