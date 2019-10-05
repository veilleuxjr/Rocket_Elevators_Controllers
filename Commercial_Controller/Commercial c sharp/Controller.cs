using System;
using System.Collections.Generic;
using System.Text;

namespace Commercial_Controller
{
    public class Controller
    {
        public int NumberOfFloors;
        public int NumberOfColumns;
        public int NumberOfElevators;
        public Battery battery;

        public Controller(int NumberOfFloors, int NumberOfColumns, int NumberOfElevators)
        {
            NumberOfColumns = NumberOfColumns;
            NumberOfElevators = NumberOfElevators;
            NumberOfFloors = NumberOfFloors;
            battery = new Battery(NumberOfColumns, NumberOfElevators, NumberOfFloors);

        }

        public Elevator RequestElevator(int FloorNumber, int RequestedFloor)
        {
            Console.WriteLine("Request elevator to floor : " + FloorNumber);
            Console.WriteLine("---------------------------------------------------");
            Column column = battery.FindColumn(FloorNumber);
            Elevator elevator = column.FindElevator(FloorNumber);
            Console.WriteLine("Column #:" + column.ColumnNumber);
            elevator.SendRequest(FloorNumber);
            Console.WriteLine("CurrentFloor");
            Console.WriteLine(elevator.CurrentFloor);
            elevator.SendRequest(RequestedFloor);
            return elevator;
        }

        public Elevator AssignElevator(int RequestedFloor)
        {
            Console.WriteLine("Requested floor : " + RequestedFloor);
            Console.WriteLine("---------------------------------------------------");
            var column = battery.FindColumn(RequestedFloor);
            var elevator = column.FindElevator(RequestedFloor);
            elevator.SendRequest(RequestedFloor);
            return elevator;
        }
    }
}
