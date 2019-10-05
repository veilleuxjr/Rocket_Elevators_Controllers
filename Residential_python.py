import time

class Column:
    def __init__(self, numbersfloors, numberselevator):
        self.numbersfloors = numbersfloors
        self.numberselevator = numberselevator
        self.elevatorlist= []
        
        i=0                                                                       
        while i < self.numberselevator:
            self.elevatorlist.append(Elevator(i, "IDLE", 1, None, "CLOSED"))     
            i+=1


class Controller:
    def __init__(self,numbersfloors, numberselevator):
        print('Controller created with : ', numbersfloors, numberselevator,)
        self.Column = Column(numbersfloors, numberselevator)

    def findbestelevator (self, direction, currentfloor):
        bestelevator = None
        for elevator in self.Column.elevatorlist:
            if elevator.status =="STOPPED" and elevator.floor == currentfloor and direction == direction:
                bestelevator = elevator
            elif elevator.status =="IDLE" and elevator.floor == currentfloor:
                bestelevator = elevator
            elif elevator.floor < currentfloor and elevator.status =="MOVING" or "STOPPED" and elevator.direction == direction:
                bestelevator = self.closestElevator (elevator, direction, currentfloor)
            elif elevator.floor > currentfloor and elevator.status =="MOVING" or "STOPPED" and elevator.direction == direction:
                bestelevator = self.closestElevator (elevator, direction, currentfloor)
            elif elevator.status =="IDLE":
                bestelevator = self.closestElevator (elevator, direction, currentfloor)
        return bestelevator 

    def closestElevator (self, elevator, direction, currentfloor):                                
        userDistance = elevator.floor - currentfloor                                              
        smallestDistance = abs(userDistance)                                                      
        closestChoice = elevator                                                                  
        for elevator in self.Column.elevatorlist:                                                  
            if elevator.direction == direction or elevator.direction == None:
                distance = elevator.floor - currentfloor
                distance = abs(distance)
                if distance < smallestDistance:
                    smallestDistance = abs(distance)
                    closestChoice = elevator
        return closestChoice


    def requestelevator (self, floornumber, direction):
        print("resquestelevator, floornumber, direction")
        elevator = self.findbestelevator(floornumber, direction)
        elevator.sendrequest(floornumber)
        return elevator
        


class Elevator:
    def __init__(self, elevatornumber, status, floor, direction, elevatordoor):
        self.elevatornumber = elevatornumber
        self.status = status
        self.floor = floor
        self.direction = direction
        self.elevatordoor = elevatordoor
        self.maxweight = 1600 
        self.floorlist = []     



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

 
 
    def elevatorup (self, requestedfloor):
        while requestedfloor != self.floor:
            time.sleep(1)
            if self.status =="IDLE" or self.status =="STOPPED":
                self.status =="MOVING"
                self.direction =="UP"
                self.floor +=1
            print(self.floor)
        self.status =="STOPPED"
        print("Arrived At Floor")
            openclosedoor

    

    def elevatordown (self, requestedfloor):
        while requestedfloor != self.floor:
            time.sleep(1)
            if self.status =="IDLE" or self.status =="STOPPED":
                self.status =="MOVING"
                self.direction =="DOWN"
                self.floor -=1
            print(self.floor)
        self.status =="STOPPED"
        print("Arrived At Floor")
            return openclosedoor


    def openclosedoor (self, elevator):
        print (str(self.elevatornumber) + "DOOR OPENING")
        if self.status =="STOPPED":
            self.elevatordoor =="OPEN"
            time.sleep(7)
        elif self.elevatordoor =="BLOCKED":
            print("DOOR IS CLOSING")
            self.elevatordoor =="CLOSE"

    def overweight (self, openclosedoor, elevator):
        for elevator in self.Column.elevatorlist:
            if self.maxweight > self.maxweight:
                return openclosedoor

    
