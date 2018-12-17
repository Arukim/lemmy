using System;
using System.IO;

namespace Lemmy.App.Logic.Logging
{
    class FileLogger : ILogger
    {
        private string name;

        public FileLogger(string name)
        {
            this.name = name;
        }

        public void Log(string message)
        {
            var msg = $"{DateTime.Now.ToShortTimeString()} | {name} | {message}";
            Console.WriteLine(msg);
            File.AppendAllText("log.txt", msg);
        }
    }
}
