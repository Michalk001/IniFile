using IniFile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IniFile.Interfaces
{
    public interface IFileOperation
    {

        string Path { get; set; }
        void Open();
        void Save(List<SectionIni> listSectionIni);
        List<SectionIni> Read();

    }
}
