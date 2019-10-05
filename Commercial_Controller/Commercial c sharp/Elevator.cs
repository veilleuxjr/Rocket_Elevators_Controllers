using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Commercial_Controller
{
    public class Elevator
    {
        public int ElevatorNumber;
        public int CurrentFloor;
        public string Status;
        public List<int> FloorList;
        public string Direction;
        public int Maxweight = 3500;
        public string ElevatorWeight;
        public string WeightSensor;

        public Elevator(int ElevatorNumber, int NumberOfFloors)
        {
            ElevatorNumber = ElevatorNumber;
            Status = "IDLE";
            CurrentFloor = 1;
            FloorList = new List<int>();
            Direction = "UP";
        }

        public void SendRequest(int RequestedFloor)
        {
            Console.WriteLine("Send request");
            Console.WriteLine(RequestedFloor);
            FloorList.Add(RequestedFloor);
            if (RequestedFloor > CurrentFloor)
            {
                FloorList.Sort((a, b) => a.CompareTo(b));
            }
            else if (RequestedFloor < CurrentFloor)
            {
                FloorList.Sort((a, b) => -1 * a.CompareTo(b));
            }
            OperateElevator(RequestedFloor);
        }


        public void OperateElevator(int RequestedFloor)
        {
            while (FloorList.Count > 0)
            {
                if (RequestedFloor == CurrentFloor)
                {
                    OpenCloseDoor();
                    FloorList.RemoveAt(0);

                }
                else if (RequestedFloor > CurrentFloor)
                {
                    ElevatorUp(RequestedFloor);
                    FloorList.RemoveAt(0);
                    OpenCloseDoor();
                }
                else if (RequestedFloor < CurrentFloor)
                {
                    ElevatorDown(RequestedFloor);
                    FloorList.RemoveAt(0);
                    OpenCloseDoor();
                }
            }
        }

        public void ElevatorUp(int RequestedFloor)
        {
            Console.WriteLine(" Elevator : #" + ElevatorNumber + "  Floor : " + CurrentFloor);
            while (RequestedFloor != CurrentFloor)
            {
                Status = "MOVING";
                Thread.Sleep(500);
                CurrentFloor += 1;
                Console.WriteLine(" Elevator : #" + ElevatorNumber + "  Floor : " + CurrentFloor);
            }
            Console.WriteLine("Arrived at floor ");
            Status = "STOPPED";
            OpenCloseDoor();
        }

        public void ElevatorDown(int RequestedFloor)
        {
            Console.WriteLine(" Elevator : #" + ElevatorNumber + "  Floor : " + CurrentFloor);
            while (RequestedFloor != CurrentFloor)
            {
                Status = "MOVING";
                Thread.Sleep(500);
                CurrentFloor -= 1;
                Console.WriteLine(" Elevator : #" + ElevatorNumber + "  Floor : " + CurrentFloor);
            }
            Console.WriteLine("Arrived at floor ");
            Status = "STOPPED";
            OpenCloseDoor();
        }

        public void OpenCloseDoor()
        {
            Console.WriteLine(" Elevator : #" + ElevatorNumber + "  Floor : " + CurrentFloor + " DOOR IS OPENING");
            if (Status == "IDLE" || Status == "STOPPED")
            {
                Thread.Sleep(500);
            }
            Console.WriteLine("DOOR IS OPENED");
            Thread.Sleep(700);
            Console.WriteLine("DOOR IS CLOSING");
            Thread.Sleep(700);
            Console.WriteLine("DOOR IS CLOSED");
        }
        public void OverWeight(int WeightSensor)
        {
            Console.WriteLine(" Elavator Is Too Heavy");
            OpenCloseDoor();

        }
    }
}