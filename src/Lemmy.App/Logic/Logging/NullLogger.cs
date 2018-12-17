namespace Lemmy.App.Logic.Logging
{
    class NullLogger : ILogger
    {
        public void Log(string message) { }
    }
}
