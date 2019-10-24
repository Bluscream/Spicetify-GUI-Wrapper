using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace Spicetify_GUI_Wrapper.Classes
{
    public partial class Spicetify
    {
        public class Options
        {
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
    }
}