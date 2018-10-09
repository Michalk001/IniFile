using IniFile.Models;
using IniFile.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IniFile
{
    public sealed class IniFile : IIniFile
    {
        private List<SectionIni> listSectionIniAdd;
        private List<SectionIni> listSectionIniRead;
        private FileOperation fileIni;

        public IniFile(string path)
        {
            listSectionIniAdd = new List<SectionIni>();
            fileIni = new FileOperation
            {
                Path = path
            };
            fileIni.Open();
        }
        public IniFile(List<SectionIni> listSectionIni, string path)
        {
            this.listSectionIniAdd = listSectionIni;
            fileIni = new FileOperation
            {
                Path = path
            };
            fileIni.Open();
        }

        public void Add(SectionIni sectionIni)
        {
            try
            {
                listSectionIniAdd.Add(sectionIni);
            }
            catch
            {
                throw;
            }
        }
        public void Add(List<SectionIni> sectionIni)
        {
            try
            {
                foreach (var item in sectionIni)
                {
                    listSectionIniAdd.Add(item);
                }
            }
            catch
            {
                throw;
            }
        }
        public void Save()
        {
            try
            {
                fileIni.Save(listSectionIniAdd);
            }
            catch
            {
                throw;
            }

        }

        public SectionIni Get(string name)
        {
            if (listSectionIniRead == null)
                listSectionIniRead = fileIni.Read();
            return listSectionIniRead.Find(x => x.Name == name);
        }
        public List<SectionIni> Get()
        {
            if (listSectionIniRead == null)
                listSectionIniRead = fileIni.Read();
            return listSectionIniRead;
        }
    }
}
