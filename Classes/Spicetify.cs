using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace Spicetify_GUI_Wrapper.Classes
{
    public partial class Spicetify
    {
        public const string BinaryName = "spicetify";
        public const string DirectoryName = "spicetify-cli";
        public DirectoryInfo MainDirectory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)).Combine(DirectoryName);
        public DirectoryInfo AppsDirectory => MainDirectory.Combine("CustomApps");

        public DirectoryInfo ExtensionsDirectory => MainDirectory.Combine("Extensions");
        public DirectoryInfo ThemesDirectory => MainDirectory.Combine("Themes");
        public List<App> Apps;
        public List<Extension> Extensions;
        public List<Theme> Themes;

        public static Options Arguments = new Options();

        public Spicetify(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(o => Arguments = o).WithNotParsed(o => Logger.Error("Unable to parse arguments: {0}", o.First().Tag));
        }

        public List<App> LoadApps()
        {
            Apps = new List<App>();
            foreach (var appDir in AppsDirectory.GetDirectories())
            {
                Apps.Add(new App(appDir));
            }

            return Apps;
        }

        public List<Extension> LoadExtensions()
        {
            Extensions = new List<Extension>();
            foreach (var extensionFile in ExtensionsDirectory.GetFiles())
            {
                Extensions.Add(new Extension(extensionFile));
            }

            return Extensions;
        }

        public List<Theme> LoadThemes()
        {
            Themes = new List<Theme>();
            foreach (var themeDir in ExtensionsDirectory.GetDirectories())
            {
                Themes.Add(new Theme(themeDir));
            }

            return Themes;
        }
    }
}