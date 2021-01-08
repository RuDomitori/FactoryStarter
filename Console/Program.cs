using System;
using FactoryStarter.Core;

namespace FactoryStarter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var level = new Level();
            var message = level.ChangeSize(10, 10);
            System.Console.WriteLine(message);
        }
    }
}