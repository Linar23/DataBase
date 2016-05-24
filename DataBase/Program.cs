using System;
using System.Collections.Generic;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create
            Table table = new Table("Cathedras");
            table.AddColumm("name");
            table.AddColumm("teachers");
            table.AddColumm("subjects");

            List<string> first_line = new List<string>();
            first_line.Add("КТП");
            first_line.Add("Бухараев");
            first_line.Add("Информатика,Матлогика");
            table.AddRecord(first_line);

            List<string> second_line = new List<string>();
            second_line.Add("КТП");
            second_line.Add("Мубаракзянов");
            second_line.Add("Информатика,Дискретка");
            table.AddRecord(second_line);

            table.Save();

            // Update and delete
            TableControl th = new TableControl();
            th.SetTable(table);

            List<string> first_line_updated = new List<string>();
            first_line_updated.Add("КСАИТ");
            first_line_updated.Add("Ямалеев");
            first_line_updated.Add("Инфобез");
            th.Update("name", "КТП", first_line_updated);

            th.Delete("name", "КСАИТ");

            table.Save();

            // Read
            Table table2 = new Table("Test");
            table2.Read();

            Console.ReadKey();
        }
    }
}