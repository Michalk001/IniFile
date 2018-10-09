using System;
using System.Collections.Generic;
using System.Text;

namespace IniFile.Interfaces
{
    public interface ISectionIni
    {
        string Name { get; set; }
        Dictionary<string, string> Attribute { get; set; }

    }
}
