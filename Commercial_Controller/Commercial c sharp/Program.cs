using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;


namespace Commercial_Controller
{
    class Program
    {
        public static void Main(string[] args)
        {
            Controller controller = new Controller(66, 4, 12);
            controller.battery.ColumnList[1].ElevatorList[0].CurrentFloor = 1;  // going down to -6
            controller.battery.ColumnList[1].ElevatorList[0].Status = "MOVING";
            controller.battery.ColumnList[1].ElevatorList[0].Direction = "DOWN";
            controller.battery.ColumnList[1].ElevatorList[0].FloorList.Add(-6);

            controller.battery.ColumnList[1].ElevatorList[1].CurrentFloor = 23; // going up to 33
            controller.battery.ColumnList[1].ElevatorList[1].Status = "MOVING";
            controller.battery.ColumnList[1].ElevatorList[1].Direction = "UP";
            controller.battery.ColumnList[1].ElevatorList[1].FloorList.Add(33);

            controller.battery.ColumnList[1].ElevatorList[2].CurrentFloor = 33; // going up to 50
            controller.battery.ColumnList[1].ElevatorList[2].Status = "MOVING";
            controller.battery.ColumnList[1].ElevatorList[2].Direction = "DOWN";
            controller.battery.ColumnList[1].ElevatorList[2].FloorList.Add(50);

            controller.battery.ColumnList[1].ElevatorList[3].CurrentFloor = 60; // going up to 60 then down 1
            controller.battery.ColumnList[1].ElevatorList[3].Status = "MOVING";
            controller.battery.ColumnList[1].ElevatorList[3].Direction = "UP";
            controller.battery.ColumnList[1].ElevatorList[3].FloorList.Add(60);
            controller.battery.ColumnList[1].ElevatorList[3].Status = "MOVING";
            controller.battery.ColumnList[1].ElevatorList[3].Direction = "DOWN";
            controller.battery.ColumnList[1].ElevatorList[3].FloorList.Add(1);


            controller.battery.ColumnList[1].ElevatorList[4].CurrentFloor = 42; // going down to 1
            controller.battery.ColumnList[1].ElevatorList[4].Status = "MOVING";
            controller.battery.ColumnList[1].ElevatorList[4].Direction = "DOWN";
            controller.battery.ColumnList[1].ElevatorList[4].FloorList.Add(1);
            controller.AssignElevator(10);

        }

    }
}

 

  


  