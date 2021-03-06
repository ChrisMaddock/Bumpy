﻿using System;
using System.Diagnostics;

namespace Bumpy
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                PrintInfo();
                var parser = new CommandParser();
                var arguments = parser.Parse(args);
                var runner = new CommandRunner(new FileUtil(), Console.WriteLine, arguments);
                runner.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Environment.ExitCode = 1;
            }

#if DEBUG
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
#endif
        }

        private static void PrintInfo()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Bumpy v{versionInfo.FileVersion}");
            Console.ResetColor();
        }
    }
}
