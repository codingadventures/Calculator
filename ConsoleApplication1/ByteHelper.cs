using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace ConsoleApplication1
{
    internal static class ByteHelper
    {
        private static readonly HashSet<byte> OperatorsAsciiKeys = new HashSet<byte> {45, 43, 42, 47, 37};

        public static bool IsNumber(this byte number)
        {
            return number <= 57 && number >= 48;
        }
        
        public static bool IsOperation(this byte operation)
        {
            return OperatorsAsciiKeys.Contains(operation);
        }

        public static bool IsDot(this byte dot)
        {
            return dot == 46;
        }

        public static bool IsEnter(this byte enter)
        {
            return enter == 10 || enter == 61;
        }
        
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            
            return value.ToString();
        }
    }
}