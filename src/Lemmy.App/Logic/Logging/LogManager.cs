using System;

namespace Lemmy.App.Logic.Logging
{
    static class LogManager
    {
        static Lazy<string> env = new Lazy<string>(() => Environment.GetEnvironmentVariable("ENVIRONMENT"));
        public static ILogger GetLogger(string name) => env.Value.Equals("Local") ? new FileLogger(name) as ILogger : new NullLogger();
    }
}
