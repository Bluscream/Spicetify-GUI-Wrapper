using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicetify.Classes
{
    public partial class App
    {
        public class AppDescription
        {
            public string en { get; set; }
            public string cs { get; set; }
            public string de { get; set; }
            public string el { get; set; }
            public string es { get; set; }
            public string es_419 { get; set; }
            public string fi { get; set; }
            public string fr { get; set; }
            public string fr_CA { get; set; }
            public string hu { get; set; }
            public string id { get; set; }
            public string it { get; set; }
            public string ja { get; set; }
            public string nl { get; set; }
            public string pl { get; set; }
            public string pt_br { get; set; }
            public string sv { get; set; }
            public string th { get; set; }
            public string tr { get; set; }
            public string vi { get; set; }
            public string zh_hant { get; set; }
            public string zsm { get; set; }
        }

        public class AppName
        {
            public string en { get; set; }
            public string cs { get; set; }
            public string de { get; set; }
            public string el { get; set; }
            public string es { get; set; }
            public string es_419 { get; set; }

            public string fi { get; set; }
            public string fr { get; set; }
            public string fr_ca { get; set; }
            public string hu { get; set; }
            public string id { get; set; }
            public string it { get; set; }
            public string ja { get; set; }
            public string nl { get; set; }
            public string pl { get; set; }
            public string pt_br { get; set; }
            public string sv { get; set; }
            public string th { get; set; }
            public string tr { get; set; }
            public string vi { get; set; }
            public string zh_hant { get; set; }
            public string zsm { get; set; }
        }

        public class ProvidedFeatures
        {
            public bool clientStorage { get; set; }
        }

        public class BridgeDependencies
        {
            public string bridge_desktop { get; set; }
            public string bridge_web { get; set; }
            public string bridge_zelda { get; set; }
        }

        public class Dependencies
        {
            public string api { get; set; }
        }

        public class Manifest
        {
            public string BundleIdentifier { get; set; }
            public string BundleType { get; set; }
            public string BundleVersion { get; set; }
            public string VendorIdentifier { get; set; }
            public bool UserInstallable { get; set; }
            public AppDescription AppDescription { get; set; }
            public AppName AppName { get; set; }
            public List<string> SupportedLanguages { get; set; }
            public List<string> SupportedDeviceClasses { get; set; }
            public ProvidedFeatures ProvidedFeatures { get; set; }
            public BridgeDependencies BridgeDependencies { get; set; }
            public Dependencies Dependencies { get; set; }
            public bool InjectScripts { get; set; }
            public bool InjectStylesheets { get; set; }
            public bool SkipLanguageValidation { get; set; }
            public bool SkipUnrequireValidation { get; set; }
            public bool SpmApp { get; set; }
            public string GitRevision { get; set; }
        }
    }
}