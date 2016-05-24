using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataBase
{
    public class Table
    {
        public string TableName { get; set; }

        public List<string> RowNames;

        public List<List<string>> Data;

        public Table(string name)
        {
            RowNames = new List<string>();
            Data = new List<List<string>>();
            TableName = name;
        }

        public void AddColumm(string name)
        {
            RowNames.Add(name);
        }

        public bool AddRecord(List<string> values)
        {
            if (values.Count != RowNames.Count)
                return false;

            Data.Add(values);

            return true;
        }

        public void Save()
        {
            string directoryName = TableName + "\\";

            if (Directory.Exists(directoryName))
            {
                List<string> t = Directory.GetFiles(directoryName).ToList();

                foreach (var file in t)
                {
                    File.Delete(file);
                }
                    
                Directory.Delete(directoryName);
            }

            Directory.CreateDirectory(directoryName);

            File.WriteAllText(directoryName + "structure.txt", String.Join(":", RowNames));

            File.WriteAllText(directoryName + "info.txt", Data.Count.ToString());

            for (int i = 0; i < Data.Count(); i++)
            {
                File.WriteAllText(directoryName + i.ToString() + "_line.txt", String.Join(":", Data[i]));
            }
        }

        public void Read()
        {
            string directoryName = TableName + "\\";

            RowNames = File.ReadAllText(directoryName + "structure.txt").Split(':').ToList();

            int count = Convert.ToInt32(File.ReadAllText(directoryName + "info.txt"));

            for (int i = 0; i < count; i++)
            {
                Data.Add(File.ReadAllText(directoryName + i.ToString() + "_line.txt").Split(':').ToList());
            }
        }
    }
}
