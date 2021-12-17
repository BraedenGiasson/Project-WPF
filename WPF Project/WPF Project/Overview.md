# Programming 3 - Project



## Team Information

- Braeden Giasson (2043670)
- Justus Weidemann (2061692)

## Project Description

Our plan is to create an inventory tracker for cars. 

## **Member Contributions**

**Braeden Giasson**

- I will work on the WPF UI for now.

**Justus Weidemann**

- I will for on the backend for now (implementation of classes).

**Together**

- Overview
- UML diagram

## **Classes** 

- *Model* class (acts as Car)
  - Name (of model)
  - Color
  - Horsepower
  - Torque
  - Number of seats
  - Trunk volume
  - Width of Vehicle
  - Height of Vehicle
  - Length of Vehicle
  - Fuel Type (enum)
  - Body Type (enum) 
  - Parking Spots
- *Make* class
  - Name (Audi)
  - Country (Deutschland)
  - Category (Sports car)
- *ParkingSpace* class
  - parkingSpots
  - Get Available Spots
  - Get First Available Spot
  - Set Parking Spot
- *Inventory* class
  - Add item
  - Remove item
  - Update item
  - Shopping List
  - General Report
  - Load items
  - Save items
  - Max Quantity

## Interface

- int AvailableQuantity();
- int MinimimQuantity();
- bool CheckQuantity();
  - Can't go pass 0

## Development Approach 

1. **Understanding the problem.** 

   We want to build an inventory tracker for a car dealership. 

2. **Formulating the problem.** 

   Input: The car the person wants

   Output: A list of cars available at the dealership

3. **Developing the application .** 

   See UML diagram for further details on the application.

4. **Implementing the application.** 

   We will be using WPF and C# to implement our application.

5. **Testing.** 

   (will add later)

## Future Work
We want to be able to have a list to be able to create your own car (customize).