using IniFile.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IniFile.Models
{
    public class FileOperation : IFileOperation
    {
        private StreamReader FileRead { get; set; }
        private StreamWriter FileWrite { get; set; }
        private FileStream FileStream { get; set; }


        public string Path { get; set; }


        public void Open()
        {
            FileStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileRead = new StreamReader(FileStream, Encoding.UTF8);
            FileWrite = new StreamWriter(FileStream, Encoding.UTF8);
        }
        public void Save(List<SectionIni> listSectionIni)
        {
            foreach (var item in listSectionIni)
            {
                FileWrite.WriteLine($"[{item.Name}]");
                FileWrite.Flush();
                foreach (var itemA in item.Attribute)
                {
                    FileWrite.WriteLine($"{itemA.Key}={itemA.Value}");
                    FileWrite.Flush();

                }
                FileWrite.WriteLine("\n");
                FileWrite.Flush();
            }
        }


        private List<string> ReadRawData()
        {
            List<string> data = new List<string>();
            while (!FileRead.EndOfStream)
            {
                string tmpData = FileRead.ReadLine();
                if (tmpData != "")
                    data.Add(tmpData);
            }
            return data;

        }


        public List<SectionIni> Read()
        {

            ParseData parseData = new ParseData();
            return parseData.CreateListSection(parseData.RemoveComment(ReadRawData()));


        }
    }
}
