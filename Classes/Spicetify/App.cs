using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spicetify_GUI_Wrapper;
using HtmlAgilityPack;

namespace Spicetify.Classes
{
    public partial class App
    {
        public DirectoryInfo Directory;
        public bool Enabled;
        public string Name;
        public string RawVersion;
        public Version Version => Version.Parse(RawVersion);
        public string Author;
        public string Description;
        public Manifest AppManifest;
        public string GitHash;
        private Regex lineRegex = new Regex(@"^\/\/\s+(.*):\s+(.*)$");

        public App(DirectoryInfo directory)
        {
            Directory = directory;
            AppManifest = JsonConvert.DeserializeObject<Manifest>(Directory.CombineFile("manifest.json").ReadAllText());
            Name = AppManifest.AppName.en;
            Description = AppManifest.AppDescription.en;
            RawVersion = AppManifest.BundleVersion;
            GitHash = AppManifest.GitRevision;
            var indexHTML = Directory.CombineFile("index.html");
            if (indexHTML.Exists)
            {
                try
                {
                    var doc = new HtmlDocument();
                    doc.Load(indexHTML.FullName);
                    // var comments = doc.CreateComment().OfType<XComment>();
                    var comment =
                        doc.DocumentNode.SelectSingleNode(
                            "//comment()[contains(., '//')]");
                    foreach (var commentline in comment.InnerHtml.SplitToLines())
                    {
                        var match = lineRegex.Match(commentline);
                        if (match.Success)
                        {
                            var val = match.Groups[2].Value;
                            switch (match.Groups[1].Value.ToUpperInvariant())
                            {
                                case "NAME":
                                    Name = val;
                                    break;

                                case "VERSION":
                                    RawVersion = val;
                                    break;

                                case "AUTHOR":
                                    Author = val;
                                    break;

                                case "DESCRIPTION":
                                    Description = val;
                                    break;

                                default:
                                    Logger.Warn("Unknown AppInfo DataType: %s", match.Groups[1].Value);
                                    break;
                            }
                        }
                    }
                }
                catch (Exception ex) { Logger.Warn("Unable to read %s: %s", indexHTML.FullName, ex.Message); }
            }
            // Version.TryParse(RawVersion, out Version);
        }

        public override string ToString()
        {
            return $"{Name} v{RawVersion} by {Author}";
        }
    }
}