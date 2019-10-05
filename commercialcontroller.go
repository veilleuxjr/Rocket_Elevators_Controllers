package main

import (
	"fmt"
	"math"
	"sort"
	"time"
)

type controller struct {
	numbersOfCollumn   int
	numbersOfElevators int
	numbersOfFloors    int
	battery            Battery
}

type Battery struct {
	numbersOfCollumn   int
	numbersOfElevators int
	collumnNumber      int
	columnList         []Column
}

type Column struct {
	collumnNumber int
	elevatorList  []Elevator
}

type Elevator struct {
	elevatorNb    int
	status        string
	elevatorFloor int
	floorList     []int
	direction     string
	doorStatus    string
}

func newController(numbersOfCollumn int, numbersOfElevators int, numbersOfFloors int) *controller {
	s := new(controller)
	s.numbersOfCollumn = numbersOfCollumn
	s.numbersOfElevators = numbersOfElevators
	s.numbersOfFloors = numbersOfFloors

	s.battery = *newBattery(numbersOfCollumn, numbersOfElevators, numbersOfFloors)

	return s
}

func newBattery(numbersOfCollumn int, numbersOfElevators int, numbersOfFloors int) *Battery {
	b := new(Battery)
	b.numbersOfCollumn = numbersOfCollumn
	collumnNumber := 0

	for i := 0; i < numbersOfCollumn; i++ {
		collumnNumber++
		column := newColumn(collumnNumber, 5, 85)
		b.columnList = append(b.columnList, *column)
	}

	return b
}

func newColumn(collumnNumber int, numbersOfElevators int, numbersOfFloors int) *Column {
	c := new(Column)
	c.collumnNumber = collumnNumber

	for i := 0; i < numbersOfElevators; i++ {
		elevator := newElevator(i, numbersOfFloors)
		c.elevatorList = append(c.elevatorList, *elevator)
	}

	return c
}

func newElevator(elevatorNb int, numbersOfFloors int) *Elevator {
	e := new(Elevator)
	e.elevatorNb = elevatorNb
	e.elevatorFloor = 1
	e.status = "Idle"
	e.direction = "Up"

	return e
}

func (e *controller) chooseElevator(currentFloor int, requestedFloor int) Elevator {
	fmt.Println("Request elevator to floor : ", currentFloor)
	time.Sleep(300 * time.Millisecond)
	fmt.Println("Button Light On")
	column := e.battery.findColumn(currentFloor)
	elevator := column.findBestElevator(requestedFloor)
	elevator.requestElevator(currentFloor)
	elevator.requestElevator(requestedFloor)

	return elevator
}

func (e *controller) assignElevator(currentfloor int, requestedFloor int) Elevator {
	fmt.Println("Request elevator to floor : ", requestedFloor)
	time.Sleep(3 * time.Millisecond)
	fmt.Println("Button Light On")
	column := e.battery.findColumn(currentfloor)
	elevator := column.findBestElevator(requestedFloor)
	elevator.requestElevator(currentfloor)
	elevator.requestElevator(requestedFloor)

	return elevator
}

func (b *Battery) findColumn(requestedFloor int) Column {
	bestColumn := b.columnList[0]

	if requestedFloor >= 2 && requestedFloor <= 22 || requestedFloor == 1 {
		bestColumn = b.columnList[0]

	} else if requestedFloor >= 23 && requestedFloor <= 43 || requestedFloor == 1 {
		bestColumn = b.columnList[1]

	} else if requestedFloor >= 44 && requestedFloor <= 64 || requestedFloor == 1 {
		bestColumn = b.columnList[2]

	} else if requestedFloor >= 65 && requestedFloor <= 85 || requestedFloor == 1 {
		bestColumn = b.columnList[3]
	}

	return bestColumn
}

func (c *Column) findBestElevator(requestedFloor int) Elevator {
	var bestElevator = c.elevatorList[0]

	for _, e := range c.elevatorList {
		if e.status == "Stopped" && e.elevatorFloor == 1 {
			bestElevator = e
		} else if e.status == "Idle" && e.elevatorFloor > requestedFloor {
			bestElevator = c.closestElevator(requestedFloor)
		} else if e.status == "Stopped" || e.status == "Moving" && e.elevatorFloor > requestedFloor && e.direction == "Down" {
			bestElevator = c.closestElevator(requestedFloor)
		} else {
			bestElevator = c.closestElevator(requestedFloor)
		}
	}
	return bestElevator
}

func (c *Column) closestElevator(requestedFloor int) Elevator {
	var smallestDistance = math.Abs(float64(c.elevatorList[0].elevatorFloor) - float64(requestedFloor))
	var closestChoice = c.elevatorList[0]

	for _, e := range c.elevatorList {
		var distance = math.Abs(float64(e.elevatorFloor) - float64(requestedFloor))

		if distance <= smallestDistance {
			smallestDistance = distance
			closestChoice = e
		}
	}

	return closestChoice
}

func (e *Elevator) requestElevator(requestedFloor int) {
	e.floorList = append(e.floorList, requestedFloor)
	e.organizeFloorList(requestedFloor)
	e.moveElevator(requestedFloor)
}
func (e *Elevator) organizeFloorList(requestedFloor int) {

	if requestedFloor > e.elevatorFloor {

		sort.Ints(e.floorList)

	} else if requestedFloor < e.elevatorFloor {

		sort.Sort(sort.Reverse(sort.IntSlice(e.floorList)))
	}
}

func (e *Elevator) moveElevator(requestedFloor int) {

	for len(e.floorList) > 0 {

		if requestedFloor == e.elevatorFloor {
			e.openDoor()
			e.floorList = e.floorList[1:]
			e.closeDoor()

		} else if requestedFloor > e.elevatorFloor {

			e.moveUp(requestedFloor)
			e.floorList = e.floorList[1:]
			e.closeDoor()

		} else if requestedFloor < e.elevatorFloor {

			e.moveDown(requestedFloor)
			e.floorList = e.floorList[1:]
			e.closeDoor()
		}
	}
}

func (e *Elevator) moveUp(requestedFloor int) {
	fmt.Println(" Elevator : #", e.elevatorNb, " Current Floor :", e.elevatorFloor)
	for requestedFloor != e.elevatorFloor {
		e.elevatorFloor++
		if requestedFloor == e.elevatorFloor {
			time.Sleep(1 * time.Second)
			fmt.Println("---------------------------------------------------")
			fmt.Println(" Elevator : #", e.elevatorNb, " Arrived at destination floor : ", e.elevatorFloor)
		}
		time.Sleep(300 * time.Millisecond)
		fmt.Println(" Elevator : #", e.elevatorNb, " Floor : ", e.elevatorFloor)

	}
	e.openDoor()
}

func (e *Elevator) moveDown(requestedFloor int) {
	fmt.Println(" Elevator : #", e.elevatorNb, " Current Floor :", e.elevatorFloor)
	for requestedFloor != e.elevatorFloor {
		e.elevatorFloor--
		if requestedFloor == e.elevatorFloor {
			time.Sleep(1 * time.Second)
			fmt.Println("---------------------------------------------------")
			fmt.Println(" Elevator : #", e.elevatorNb, " Arrived at destination floor : ", e.elevatorFloor)
		}
		time.Sleep(300 * time.Millisecond)
		fmt.Println(" Elevator : #", e.elevatorNb, " Floor : ", e.elevatorFloor)
	}
	e.openDoor()
}

func (e *Elevator) openDoor() {

	fmt.Println("Door is opening")
	time.Sleep(1 * time.Second)
	fmt.Println("Door is opened")
	time.Sleep(7 * time.Second)
	fmt.Println("Button Light Off")
}

func (e *Elevator) closeDoor() {

	fmt.Println("Door is closing")
	time.Sleep(1 * time.Second)
	fmt.Println("Door is closed")
	time.Sleep(1 * time.Second)
}

func main() {
	controller := newController(4, 20, 85)
	fmt.Println(controller.battery.columnList)
	controller.assignElevator(1, 24)
	//	controller.chooseElevator(33, 1)
}
