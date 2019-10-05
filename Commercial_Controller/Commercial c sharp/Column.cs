using System;
using System.Collections.Generic;
using System.Text;

namespace Commercial_Controller
{
    public class Column
    {
        public List<Elevator> ElevatorList;
        public int ColumnNumber;

        public Column(char ColumnNumber, int NumberOfElevators, int NumberOfFloors)
        {
            ColumnNumber = ColumnNumber;
            ElevatorList = new List<Elevator>();

            for (int i = 0; i < NumberOfElevators; i++)
            {
                Elevator elevator = new Elevator(i, NumberOfFloors);
                ElevatorList.Add(elevator);
            }
        }


        public Elevator FindElevator(int RequestedFloor)
        {
            foreach (Elevator elevator in ElevatorList)
            {
                if (elevator.Status == "STOPPED" && elevator.CurrentFloor == 1)
                {
                    return elevator;
                }
                else if (elevator.Status == "IDLE" && elevator.CurrentFloor > RequestedFloor)
                {
                    return BestElevator(RequestedFloor);
                }
                else if (elevator.Status == "STOPPED" || elevator.Status == "MOVING" && elevator.CurrentFloor > RequestedFloor && elevator.Direction == "DOWN")
                {
                    return BestElevator(RequestedFloor);
                }
                else
                {
                    return BestElevator(RequestedFloor);
                }
            }
            return null;
        }

        public Elevator BestElevator(int RequestedFloor)
        {
            var refgap = Math.Abs(ElevatorList[0].CurrentFloor - RequestedFloor);
            var refElevator = ElevatorList[0];

            foreach (Elevator elevator in ElevatorList)
            {
                if (elevator.Direction == "DOWN")
                {
                    var gap = Math.Abs(elevator.CurrentFloor - RequestedFloor);

                    if (gap <= refgap)
                    {
                        refgap = gap;
                        refElevator = elevator;

                    }

                }

            }
            return refElevator;
        }

    }
}
