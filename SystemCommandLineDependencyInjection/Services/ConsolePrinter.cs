namespace SystemCommandLineTest.Services
{
    /// <summary>
    /// Concrete service implementation that "prints" to the console.
    /// </summary>
    internal class ConsolePrinter : IPrinter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
