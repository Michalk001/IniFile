using IniFile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IniFile.Interfaces
{
    public interface IParseData
    {
        List<SectionIni> CreateListSection(List<string> data);
        List<string> RemoveComment(List<string> data);
    }
}
