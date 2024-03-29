﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackupSystem
{
    internal class Backup
    {
        public static void BackupSystem()
        {
            Console.WriteLine("Input path to directory with files");
            var pathF = CheckPath();
            Console.WriteLine("Input path to directory in which you whant to save logs");
            var pathL = CheckPath();
            while (true)
            {
                Console.WriteLine("What you whant to do?\n" +
                    "1. Observe\n" +
                    "2. Restore\n" +
                    "0. Exit");
                if (!int.TryParse(Console.ReadLine(), out int mode))
                {
                    Console.WriteLine("Error. Please, try again.");
                    continue;
                }
                if (mode < 0 || mode > 2)
                {
                    Console.WriteLine("Error. Please, try again.");
                    continue;
                }
                switch (mode)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Observation enabled...");
                        var observer = new Logger(pathF, pathL);
                        observer.Run();
                        break;
                    case 2:
                        Console.WriteLine("Restorer enabled...");
                        var restorer = new Logger(pathF, pathL);
                        restorer.Run();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Error Please, try again.");
                        break;
                }
                Console.ReadLine();
            }
        }
        public static string CheckPath()
        {
            while (true)
            {
                var path = Console.ReadLine();
                if (Directory.Exists(path))
                    return path;
                Console.WriteLine("Error, this directory does not exist! Try again.");
            }
        }
    }
}
