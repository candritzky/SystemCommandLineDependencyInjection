namespace SystemCommandLineTest.Commands
{
    using System.CommandLine;
    using System.CommandLine.NamingConventionBinder;

    using SystemCommandLineTest.Services;

    /// <summary>
    /// The first sample command.
    /// </summary>
    internal class FirstCommand : CommandBase
    {
        public FirstCommand(IPrinter printer) : base("first", "The first command", printer)
        {
            this.AddOption(new Option<string>(new[] { "--param-1", "-p1" }, getDefaultValue: () => "p1-default")
            {
                Description = "The first param.",
                IsRequired = false
            });

            this.AddOption(new Option<string>(new[] { "--param-2", "-p2" })
            {
                Description = "The second param.",
                IsRequired = true
            });

            this.Handler = CommandHandler.Create<FirstCommandArgs>(this.HandleCommand);
        }

        private int HandleCommand(FirstCommandArgs options)
        {
            return base.HandleCommand(options);
        }

        public class FirstCommandArgs : CommonArgs
        {
            public string Param1 { get; set; }
            public string Param2 { get; set; }
        }
    }
}
