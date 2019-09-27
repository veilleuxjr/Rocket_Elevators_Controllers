import time

class Column:
    def __init__(self, numbersfloors, numberselevator):
        self.numbersfloors = numbersfloors
        self.numberselevator = numberselevator
        self.elevatorlist= []
        
        i=0                                                                       
        while i < self.numberselevator:
            self.elevatorlist.append(elevator(i, "IDLE", 1, None, "CLOSED"))     
        i+=1

class internalbutton:
   def __init__(self, floor):
     self.floor = floor
     self.light = "OFF" is False

class elevator:
    def __init__(self, elevatornumber, status, floor, direction, elevatordoor):
        self.elevatornumber = elevatornumber
        self.status = status
        self.floor = floor
        self.direction = direction
        self.elevatordoor = elevatordoor
        self.maxweight = 1600        


def requestelevator (self, floornumber, direction):
    print("resquestelevator, floornumber, direction")
    elevator = self.findbestelevator(floornumber, direction)
    elevator.sendrequest(floornumber)
    return elevator

def requestfloor (self, elevator, requestedfloor):
    elevator.sendrequest(requestedfloor)

def organizefloorlist (self, floorlist, direction):
    print("entered floorlist in elevator")
    if self.direction =="UP":
        self.floorlist.sort() 
    elif self.direction =="DOWN":
        self.floorlist.sort().reverse()
    organizedfloorlist = self.floorlist
    return organizedfloorlist


def controlelevator(self, requestedelevator, requestedfloor):
    while len(self.floorlist) > 0:
        if requestedfloor == self.floor:
            self.floorlist.pop()
            self.openclosedoor
        elif requestedfloor > self.floor:
            self.floorlist.pop()
            self.openclosedoor
        elif requestedfloor < self.floor:
            self.floorlist.pop()
            self.openclosedoor
        if len(self.floorlist) == 0:
            self.restmode


def findbestelevator (self, direction, currentfloor):
    for elevator in self.column.elevatorlist:
        if elevator.status =="STOPPED" and elevator.floor == currentfloor and direction == direction:
            return self.bestelevator (elevator, direction, currentfloor)
        elif elevator.status =="IDLE" and elevator.floor == currentfloor:
            return self.bestelevator (elevator, direction, currentfloor)
        elif elevator.floor < currentfloor and elevator.status =="MOVING" or "STOPPED" and elevator.direction == direction:
            return self.bestelevator (elevator, direction, currentfloor)
        elif elevator.floor > currentfloor and elevator.status =="MOVING" or "STOPPED" and elevator.direction == direction:
            return self.bestelevator (elevator, direction, currentfloor)
        elif elevator.status =="IDLE":
            return self.bestelevator (elevator, direction, currentfloor)


def elevatorup (self, requestedfloor): 
    while requestedfloor != self.floor:
        time.sleep(1)
        if self.status =="IDLE" or self.status =="STOPPED":
            self.status =="MOVING"
            self.direction =="UP"
            self.floor += 1
        print(self.floor)
    self.status =="STOPPED"
    print("Arrived At Floor")
    self.openclosedoor ()


def elevatordown (self, requestedfloor):
    while requestedfloor != self.floor:
        time.sleep(1)
        if self.status =="IDLE" or self.status =="STOPPED":
            self.status =="MOVING"
            self.direction =="DOWN"
            self.floor +=1
        print(self.floor)
    self.status =="STOPPED"
    print("Arrived At Floor")
    self.openclosedoor()


def openclosedoor (self, elevator):
    print (self.elevatornumber, "DOOR OPENING")
    if elevator.status =="STOPPED":
        self.door.status =="OPEN"
        time.sleep(7)
    elif self.door.status =="BLOCKED":
        print("DOOR IS CLOSING")
        self.door.status =="CLOSE"



def overweight (self, openclosedoor, elevator):
   for elevator in self.column.elevatorlist:
      if self.elevator.maxweight > self.maxweight:
          return openclosedoor(self)


def restmode(self):
    if self.floorlist =="EMPTY":
        self.intialpoint


def test():
#     USER FLOOR 1 and ELEVATOR FLOOR 1 and IDLE, EXPECTED : OPEN DOOR and CLOSE DOOR
#     print('----------------USER FLOOR 1 and ELEVATOR FLOOR 1 and IDLE, EXPECTED : OPEN DOOR and CLOSE DOOR')
#     column = InitColumn(10, 2)
#     column.RequestElevator(1, "UP")
#     column.RequestFloor(Column.column.elevator_list[0],8)
#     print('----------------TEST 1 DONE')

    print('-------USER1 FLOOR 1 GOING FLOOR 6, USER2 FLOOR 3 GOING FLOOR 5, USER3 FLOOR 9 GOING FLOOR 2 and ELEVATOR[0]=FLOOR 10 ELEVATOR[1]=FLOOR 3')
    column =column(10, 2)
    column.column.elevator_list[0].Floor = 10
    column.column.elevator_list[1].Floor = 3
    elevator = column.RequestElevator(2, "UP")
    column.RequestFloor(elevator,6)
    elevator = column.RequestElevator(4, "UP")
    column.RequestFloor(elevator,5)
    elevator = column.RequestElevator(9, "DOWN")
    column.RequestFloor(elevator,2)
    print('----------------TEST 2 DONE')
