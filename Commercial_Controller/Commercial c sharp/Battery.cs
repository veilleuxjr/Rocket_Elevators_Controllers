using System;
using System.Collections.Generic;
using System.Text;

namespace Commercial_Controller
{
    public class Battery
    {
        public int NumberOfColumns;
        public List<Column> ColumnList;
        public int NumberOfElevators;
        public char ColumnNumber;
        public Battery(int NumberOfColumns, int NumberOfElevators, int NumberOfFloors)
        {
            NumberOfColumns = NumberOfColumns;
            ColumnList = new List<Column>();
            char letter = 'A';

            for (int i = 0; i < NumberOfColumns; i++, letter++)
            {
                Column column = new Column(letter, 5, 85);
                column.ColumnNumber = letter;
                ColumnList.Add(column);
            }
        }

        public Column FindColumn(int RequestedFloor)
        {
            Column selected = null;
            foreach (Column column in ColumnList)
            {
                if (RequestedFloor >= -6 && RequestedFloor <= 17 || RequestedFloor == 1)
                {
                    selected = ColumnList[0];
                }
                else if (RequestedFloor >= 17 && RequestedFloor <= 33 || RequestedFloor == 1)
                {
                    selected = ColumnList[1];
                }
                else if (RequestedFloor >= 33 && RequestedFloor <= 50 || RequestedFloor == 1)
                {
                    selected = ColumnList[2];
                }
                else if (RequestedFloor >= 50 && RequestedFloor <= 60 || RequestedFloor == 1)
                {
                    selected = ColumnList[3];
                }
            }
            return selected;
        }
    }
}
