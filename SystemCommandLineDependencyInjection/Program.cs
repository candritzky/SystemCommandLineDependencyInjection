using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

using Microsoft.Extensions.DependencyInjection;

using SystemCommandLineTest.Commands;
using SystemCommandLineTest.Services;

// Setup the dependency injection container
var services = new ServiceCollection();
services.AddSingleton<IPrinter, ConsolePrinter>();
services.AddSingleton<Command, FirstCommand>();
services.AddSingleton<Command, SecondCommand>();
var serviceProvider = services.BuildServiceProvider();

// Build the commands from what's registered in the DI container
var rootCommand = new RootCommand();
foreach (Command command in serviceProvider.GetServices<Command>())
{
    rootCommand.AddCommand(command);
}

var commandLineBuilder = new CommandLineBuilder(rootCommand);
Parser parser = commandLineBuilder.UseDefaults().Build();

// Invoke the command line parser which then invokes the respective command handlers
return parser.Invoke(args);