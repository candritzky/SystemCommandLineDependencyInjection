namespace SystemCommandLineTest.Commands
{
    using System.CommandLine;
    using System.CommandLine.NamingConventionBinder;

    using SystemCommandLineTest.Services;

    /// <summary>
    /// The second sample command.
    /// </summary>
    internal class SecondCommand : CommandBase
    {
        public SecondCommand(IPrinter printer) : base("second", "The second command.", printer)
        {
            this.AddOption(new Option<string>(new[] { "--param-1", "-p1" })
            {
                Description = "The first arg.",
                IsRequired = true
            });

            this.AddOption(new Option<string>(new[] { "--param-2", "-p2" })
            {
                Description = "The second arg.",
                IsRequired = false
            });

            this.Handler = CommandHandler.Create<SecondCommandArgs>(this.HandleCommand);
        }

        private int HandleCommand(SecondCommandArgs options)
        {
            return base.HandleCommand(options);
        }

        public class SecondCommandArgs : CommonArgs
        {
            public string Param1 { get; set; }
            public string Param2 { get; set; }
        }
    }
}
