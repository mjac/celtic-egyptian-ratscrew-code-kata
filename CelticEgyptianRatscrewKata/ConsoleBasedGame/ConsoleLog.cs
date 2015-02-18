using System;
using CelticEgyptianRatscrewKata;

namespace ConsoleBasedGame
{
    public class ConsoleLog : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}