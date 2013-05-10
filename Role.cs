﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Role
      
    {
        private string description;
        private string name;
        private FeatureSet features;
        public Role()
        {
            this.name = "";
            this.description = "";
            this.features = new FeatureSet();
        }
        public Role(string name,string description)
        {
            this.name = name;
            this.description = description;
            this.features = new FeatureSet();
        }
        public Role(string name, string description,FeatureSet features)
        {
            this.name = name;
            this.description = description;
            this.features = features;
        }
        public string getName()
        {
            return name;
        }
        public string getDescription()
        {
            return description;
        }
        public bool setDescription(string newDescription)
        {
            if (newDescription != "")
            {
                this.description = newDescription;
                return true;
            }
            else return false;

        }
        public FeatureSet getFeatures()
        {
            return features;
        }
    }
