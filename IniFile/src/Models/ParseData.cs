using System;
using System.Collections.Generic;
using System.Text;
using IniFile.Interfaces;

namespace IniFile.Models
{
    public class ParseData : IParseData
    {
        public List<SectionIni> CreateListSection(List<string> data)
        {
            SectionIni sectionIni = null;
            List<SectionIni> listSectionIni = new List<SectionIni>();
            foreach (var item in data)
            {
                if (item[0] == '[')
                {
                    if (sectionIni != null)
                    {
                        listSectionIni.Add(sectionIni);
                        sectionIni = new SectionIni();
                    }
                    sectionIni = new SectionIni
                    {
                        Attribute = new Dictionary<string, string>(),
                        Name = item.TrimStart('[').TrimEnd(']')
                    };
                    continue;
                }
                var tmp = item.Replace(" ", "").Split('=');

                sectionIni.Attribute.Add(tmp[0], tmp[1]);
            }
            listSectionIni.Add(sectionIni);
            return listSectionIni;
        }
        public List<string> RemoveComment(List<string> data)
        {
            List<string> data2 = new List<string>();
            foreach (var item in data)
            {
                if (item.IndexOf(';') > 0)
                {
                    data2.Add(item.Remove(item.IndexOf(';')).Trim(' '));

                }
                else
                    data2.Add(item);
            }
            return data2;
        }
    }
}
