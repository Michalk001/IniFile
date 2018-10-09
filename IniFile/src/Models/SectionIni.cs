using System;
using System.Collections.Generic;
using System.Text;
using IniFile.Interfaces;

namespace IniFile.Models
{
    public class SectionIni : ISectionIni
    {
        public string Name { get; set; }
        public Dictionary<string, string> Attribute { get; set; }

    }
}
