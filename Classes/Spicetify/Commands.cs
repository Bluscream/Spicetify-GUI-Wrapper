using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spicetify.Attributes;

namespace Spicetify
{
    internal class Commands
    {
        [Command("backup", "Start backup and preprocessing app files.", Chainable = true)]
        public string Backup { get; set; }

        [Command("apply", "Apply customization.", Chainable = true)]
        public string Apply { get; set; }

        [Command("update", "On default, update theme CSS and colors.\nUse with flag \"-e\" to update extensions.", Chainable = true)]
        public string Update { get; set; }

        [Command("restore", "Restore Spotify to original state.", Chainable = true)]
        public string Restore { get; set; }

        [Command("clear", "Clear current backup files.", Chainable = true)]
        public string Clear { get; set; }

        [Command("enable-devtool", "Enable Spotify's developer tools.\nHit Ctrl + Shift + I in the client to start using.", Chainable = true)]
        public string EnableDevtool { get; set; }

        [Command("disable-devtool", "Disable Spotify's developer tools.", Chainable = true)]
        public string DisableDevtool { get; set; }

        [Command("watch", "Enter watch mode.\nOn default, update CSS on color.ini or user.css's changes.\nUse with flag \"-e\" to update extensions on changes.", Chainable = true)]
        public string Watch { get; set; }

        [Command("restart", "Restart Spotify client.", Chainable = true)]
        public string Restart { get; set; }

        [Command("config", "Print path of color, css, extension file or\ncustom app directory and quit.\n1. Print all theme's assests:\nspicetify path\n2. Print theme's color.inc path:\nspicetify path color\n3. Print theme's user.css path:\nspicetify path css\n4. Print theme's assets path:\nspicetify path assets\n5. Print all extensions path:\nspicetify -e path\n6. Print extension <name> path:\nspicetify -e path <name>\n7. Print all custom apps path:\nspicetify -a path\n8. Print custom app <name> path:\nspicetify -a path <name>", Chainable = false)]
        public string Config { get; set; }

        [Command("path", "1. Print all config fields and values:\nspicetify config\n\n2. Print one config field's value:\nspicetify config <field>\n\nExample usage:\nspicetify config color_scheme\nspicetify config custom_apps\n\n3. Change value of one or multiple config fields.\nspicetify config <field> <value> [<field> <value> ...]\n\n\"extensions\" and \"custom_apps\" fields are arrays of values,\nso <value> will be appended to those fields' current value.\nTo remove one of array's values, postfix \"-\" to <value>.\n\nExample usage:\n- Enable \"disable_sentry\" preprocess:\nspicetify config disable_sentry 1\n- Add extension \"myFakeExt.js\" to current extensions list:\nspicetify config extensions myFakeExt.js\n- Remove extension \"wrongname.js\" from extensions list:\nspicetify config extensions wrongname.js-\n- Disable \"inject_css\" and enable \"song_page\"\nspicetify config inject_css 0 song_page 1", Chainable = false)]
        public string Path { get; set; }

        [Command("color", "1. Print all color fields and values.\nspicetify color\n\nColor boxes require 24-bit color (True color) supported\nterminal to show colors correctly.\n\n2. Change theme's one or multiple color values.\nspicetify color <field> <value> [<field> <value> ...]\n\n<value> can be in hex or decimal (rrr,ggg,bbb) format.\n\nExample usage:\n- Change main_bg to ff0000\nspicetify color main_bg ff0000\n- Change slider_bg to 00ff00 and pressing_fg to 0000ff\nspicetify color slider_bg 00ff00 pressing_fg 0000ff", Chainable = false)]
        public string Color { get; set; }
    }
}