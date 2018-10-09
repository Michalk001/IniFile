
using IniFile.Models;
using System;
using System.Collections.Generic;
using System.Text;
u


namespace IniFile.Interfaces
{
    public interface IIniFile
    {
        void Add(SectionIni sectionIni);
        void Add(List<SectionIni> sectionIni);
        void Save();
        SectionIni Get(string name);
        List<SectionIni> Get();
    }
}
