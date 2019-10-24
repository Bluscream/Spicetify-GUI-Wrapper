using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicetify.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class CommandAttribute : Attribute
    {
        private string name;
        private string description;
        private bool chainable;

        public CommandAttribute(string name, string description)
        {
            this.name = name;
            this.description = description;
            this.chainable = false;
        }
        public virtual string Name => name;
        public virtual string Description => description;

        public virtual bool Chainable {
            get { return chainable; }
            set { chainable = value; }
        }
    }
}