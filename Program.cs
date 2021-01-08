using System;
using System.Text.Json;
using Core;

namespace Factory_Starter_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var level = new Level();
            var message = level.ChangeSize(10, 10);
            Console.WriteLine(message);
        }
    }
}