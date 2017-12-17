namespace ConsoleApplication1
{
    internal partial class Parser
    {
        private static class ByteHelper
        {
            public static bool IsNumber(this byte number)
            {
                return number <= 57 && number >= 48;
            }
        
            public bool IsOperation(byte operation)
            {
                return _operatorsAsciiKeys.Contains(operation);
            } 
        }
    }
}