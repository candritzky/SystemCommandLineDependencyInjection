namespace SystemCommandLineTest.Commands
{
    using System.CommandLine;

    using SystemCommandLineTest.Services;

    /// <summary>
    /// Abstract base class for commands showing how to share common logic.
    /// </summary>
    internal abstract class CommandBase : Command
    {
        private readonly IPrinter printer;

        protected CommandBase(string name, string description, IPrinter printer) : base(name, description)
        {
            this.printer = printer ?? throw new ArgumentNullException(nameof(printer));
            this.AddOption(
                new Option<string>(
                    aliases: new[] { "--common", "-c" },
                    description: "Some common arg.")
                { IsRequired = true });
        }

        protected int HandleCommand(CommonArgs options)
        {
            this.printer.Print($"{this.GetType().Name} {options}");
            return 0;
        }
    }
}
