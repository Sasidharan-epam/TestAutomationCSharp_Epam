using System;
using System.IO;

namespace CSharpPractice
{
    class Logger
    {
        private readonly string _filepath;

        public Logger(string testName, string filePath)
        {
            _filepath = filePath;

            using (var log = File.CreateText(_filepath))
            {
                log.WriteLine($"Starting TimeStamp: {DateTime.Now.ToLocalTime()}");
                log.WriteLine($"Test: {testName}");
            }
        }
        private void Write(string text)
        {
            using (var log = File.AppendText(_filepath))
            {
                log.Write(text);
            }
        }

        private void WriteLine(string text)
        {
            using (var log = File.AppendText(_filepath))
            {
                log.WriteLine(text);
            }
        }
        public void Info(string message)
        {
            WriteLine($"INFO:{message}");
        }

        public void Warning(string message)
        {
            WriteLine($"WARNING:{message}");
        }
        public void Step(string message)
        {
            WriteLine($"STEP:{message}");
        }

        public void Error(string message)
        {
            WriteLine($"ERROR:{message}");
        }

        public void Fatal(string message)
        {
            WriteLine($"FATAL:{message}");
        }



    }
}

