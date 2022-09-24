using System;

namespace UnitTests
{
    public class ConsoleIO
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        public string ReadLine()
        {
            return Console.ReadLine()!;
        }
    }
}