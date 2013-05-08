using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class Feature
    {
        private string name;
        private string description;
      
        public Feature(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        public Feature()
        {
            this.name = "";
            this.description = "";
        }

        public string getName()
        {
            return name;
        }
        public string getDescription()
        {
            return description;
        }
       
        public override string ToString()
        {
            return this.name;
        }
    }
}
