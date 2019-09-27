class column{
    constructor(numbersoffloors, numbersofelevators){
        this.numbersoffloors = numbersoffloors;
        this.numbersofelevators = numbersofelevators;
        this.callbutton = [];
        this.numbersofcallbutton = ((numbersoffloors*2)-2);
        this.elevatorlist = [];
    
        for (let i=0; i < numbersofelevators; i++){
            let elevator = new Elevator(i, "IDLE", 1, null, "CLOSED")
            this.elevatorlist.push(elevator)
        }
        console.log('Column created', this);
    }
}
class controller {
    constructor(numbersoffloors, numbersofelevators){
        console.log('controllercreated with : ', numbersoffloors, numbersofelevators);
        this.column = new column(NumberOfFloors, NumberOfElevators);
    }
    requestelevator(floornumber, direction){             
        console.log('requestelevator', floornumber, direction);
        let elevator = this.FindElevator(floornumber, direction);
        elevator.sendRequest(FloorNumber);
        return elevator;
    } 
    requestfloor(elevator, requestedfloor){
        elevator.sendrequest(requestedfloor);
    }  

    findbestelevator(floornumber, direction){ 
        for(let i = 0; i < this.column.elevator_list.length; i++){
            let elevator = this.column.elevator_list[i];
            if (elevator.Status == "STOPPED" && elevator.Floor == FloorNumber && elevator.direction == direction) {
                return bestelevator(elevator, direction, floornumber)
            }
            else if (elevator.Status === "IDLE" && elevator.floor === floornumber){
                return bestelevator(elevator, direction, floornumber)
            }
            else if (elevator.Floor < FloorNumber && (elevator.Status === "MOVING" || "STOPPED") && elevator.Direction === Direction){  
                return bestelevator(elevator, direction, floornumber)
            }
            else if (elevator.Floor > FloorNumber && (elevator.Status === "MOVING" || "STOPPED") && elevator.Direction === Direction){
                return bestelevator(elevator, direction, floornumber)
            }
            else if (elevator.Status === "IDLE"){
                return this.bestelevator(elevator, firection, floornumber);
            }
        }
    }
}
class Elevator {
    constructor (elevatorNumber, status, floor, direction, Doorstatus){
    this.elevatornumber = elevatorbumber;
    this.status = status;
    this.floor = floor;
    this.floorList = [];
    this.direction = direction;
    this.doorStatus = doorStatus;
    this.maxweight = 1600;
    this.requestfloorbutton = []
    }

    sendRequest(floornumber){
        console.log('send request', floornumber);
        this.floorList.push(floorNumber);
        this.sort_FloorList();
        this.controlelevator(floorNumber); 
    }

    organizefloorlist(FloorList){
        console.log("Entered FloorList in elevator");
        if (this.Direction === "UP") {
            this.FloorList.sort(); 
        } 
        else if (this.Direction === "DOWN") {
            this.FloorList.sort().reverse();
        }
    let organizedfloorlist = FloorList;
    return organizedfloorlist;
    }

    
    controlelevator(requestedfloor){
        while (this.floorlist.length > 0){
            if (requestedfloor === this.Floor){
                this.OpenDoor();
                this.FloorList.shift()
                this.CloseDoor();
            }
            else if (requestedfloor > this.floor){;
                this.elevatorup(requestedfloor);
                this.floorlist.shift()
                this.openclosedoor();
            }
            else if (requestedfloor < this.floor){
                this.elevatordown(requestedfloor);
                this.FloorList.shift()
                this.openclosedoor();
            }
        }
        if (this.floorlist.length === 0){
            this.status = "IDLE";
            this.direction = null;
        }
    }
    elevatorup (requestedfloor){
        while (requestedfloor !== this.floor){
            sleep(1);
            if (this.status == "IDLE" || this.status == "STOPPED"){
                this.status == "MOVING";
                this.direction == "UP";
                this.floor += 1; 
            }
            console.log(this.Floor);
        }
        this.status == "STOPPED"
        console.log("Arrived at floor ")
        this.openclosedoor();
    }
    elevatordown (requestedfloor){
        while (requestedfloor !== this.floor){
            sleep(1);
            if (this.status == "IDLE" || this.status === "STOPPED"){
                this.status == "MOVING";
                this.direction == "DOWN";
                this.floor -= 1; 
            }
            console.log(this.Floor);
        }
        this.status == "STOPPED"
        console.log("Arrived at floor ")
        this.openclosedoor();
    }
    openclosedoor(){
        console.log("Elevator"+ this.elevatorNumber + ":DOOR IS OPENING");
        if (this.Status == "IDLE" || this.Status == "STOPPED"){
            sleep(3);
            this.DoorStatus = "OPENED";
        }
        console.log("DOOR IS OPENED");
    
        console.log("Elevator"+ this.elevatorNumber + ":DOOR IS CLOSING");
        if (this.Status == "IDLE" || this.Status == "STOPPED"){
            timer(7);
            this.DoorStatus = "CLOSED";
        }
        console.log("DOOR IS CLOSED");
    }
}


function timer(seconds) {
   var start = new Date().getTime();
   for (var b = 0; b < 1e7; b++) {
     if ((new Date().getTime() - start) > seconds){
       break;
     }
   }
 }

function initcontroller(numberOffloors, numberOfelevators) {
    let controller = new controller(numberOffloors, numberOfelevators);
    return controller;
   }
   function test(){

    console.log('-------USER1 FLOOR 1 GOING FLOOR 6, USER2 FLOOR 3 GOING FLOOR 5, USER3 FLOOR 9 GOING FLOOR 2 and ELEVATOR[0]=FLOOR 10 ELEVATOR[1]=FLOOR 3')
    controller = InitController(10, 2);
    controller.column.elevator_list[0].Floor = 10
    controller.column.elevator_list[1].Floor = 3
    var elevator = controller.RequestElevator(4, "UP");
    controller.RequestFloor(elevator,6);
    var elevator = controller.RequestElevator(2, "UP");
    controller.RequestFloor(elevator,5);
    var elevator = controller.RequestElevator(9, "DOWN");
    controller.RequestFloor(elevator,2);
    console.log('----------------TEST 1 DONE')
}