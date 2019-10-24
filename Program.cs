using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;

namespace Spicetify_GUI_Wrapper
{
    internal static class Program
    {
        public static Options Arguments = new Options();

        public class Options
        {
            [Option('c', "console", Required = false, HelpText = "Enable console")]
            public bool ConsoleEnabled { get; set; }

            [Option('q', "quiet", Required = false, HelpText = "Quiet mode (no output). Be careful, dangerous operations like clear backup, restore will proceed without prompting permission.")]
            public string Quiet { get; set; }

            [Option('e', "extension", Required = false, HelpText = "Use with \"update\", \"watch\" or \"path\" command to focus on extensions.")]
            public bool Extension { get; set; } = false;

            [Option('a', "app", Required = false, HelpText = "Use with \"path\" to focus on custom apps.")]
            public bool App { get; set; } = false;

            [Option('c', "config", Required = false, HelpText = "Print config file path and quit")]
            public bool Config { get; set; } = false;

            [Option('h', "help", Required = false, HelpText = "Print this help text and quit")]
            public bool Help { get; set; } = false;

            [Option('v', "version", Required = false, HelpText = "Print version number and quit")]
            public bool Version { get; set; } = false;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(o => Arguments = o).WithNotParsed(o => Logger.Error("Unable to parse arguments: {0}", o.First().Tag));
#if !DEBUG
            if (Arguments.ConsoleEnabled)
#else
            ExternalConsole.InitConsole();
#endif
            var assembly = System.Reflection.Assembly.GetEntryAssembly().GetName();
            Logger.Debug("{0} v{1} ({2}) with args: {3}", assembly.Name, assembly.Version, assembly.ProcessorArchitecture, string.Join(" ", args));
            Logger.Debug("Current Date and Time: {0} (UTC: {1})", DateTime.Now, DateTime.UtcNow);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            Logger.Debug("Ended");
        }

        private static void onParseError()
        {
        }
    }
}