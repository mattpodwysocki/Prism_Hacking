using System;

namespace PrismHacking.Common
{
    public class Guard
    {
        public static void ArgumentNotNull<T>(T obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName, $"{paramName} cannot be null");
            }
        }
    }
}
