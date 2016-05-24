using System.Collections.Generic;

namespace DataBase
{
    public class TableControl
    {
        public Table CurrentTable { get; set; }

        public void SetTable(Table table)
        {
            CurrentTable = table;
        }

        public bool Update(string fieldName, string fieldValue, List<string> recordValue)
        {
            int fieldIndex = -1;

            for (int i = 0; i < CurrentTable.RowNames.Count; i++)
            {
                if (CurrentTable.RowNames[i] == fieldName)
                    fieldIndex = i;
            }
                
            if (fieldIndex == -1)
                return false;

            for (int i = 0; i < CurrentTable.Data.Count; i++)
            {
                if (CurrentTable.Data[i][fieldIndex] == fieldValue)
                    CurrentTable.Data[i] = recordValue;
            }

            return true;
        }

        public bool Delete(string fieldName, string fieldValue)
        {
            int fieldIndex = -1;

            for (int i = 0; i < CurrentTable.RowNames.Count; i++)
                if (CurrentTable.RowNames[i] == fieldName)
                    fieldIndex = i;

            if (fieldIndex == -1)
                return false;

            for (int i = 0; i < CurrentTable.Data.Count; i++)
            {
                if (CurrentTable.Data[i][fieldIndex] == fieldValue)
                    CurrentTable.Data.RemoveAt(i);
            }

            return true;
        }
    }
}
