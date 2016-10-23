/**
 * @(#) Logger.cs
 */

using System;
using System.IO;

namespace OP_LetterLabyrinth
{
    public class Logger
    {
        private const string LoggerFileLocation = "logger.txt";
        private static Logger _instance;

        private Logger()
        {
            if (File.Exists(LoggerFileLocation))
            {
                File.Delete(LoggerFileLocation);
            }
        }

        public static Logger GetInstance()
        {
            return _instance ?? (_instance = new Logger());
        }

        public void Log(string tag, string message)
        {
            try
            {
                if (File.Exists(LoggerFileLocation))
                {
                    using (StreamWriter w = File.AppendText(LoggerFileLocation))
                    {
                        w.WriteLine($"{DateTime.Now:s} {tag,-8} {message}");
                    }
                }
                else
                {
                    using (StreamWriter w = File.CreateText(LoggerFileLocation))
                    {
                        w.WriteLine($"{DateTime.Now:s} {tag,-8} {message}");
                    }
                }
            }
            catch (IOException e)
            {

                Console.WriteLine("Cannot access file: " + e);
            }

        }

    }
}




