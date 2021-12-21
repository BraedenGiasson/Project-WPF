# Programming 3 - Project



## Team Information

- Braeden Giasson (2043670)
- Justus Weidemann (2061692)

## Project Description

Our plan is to create an inventory tracker for an Audi dealership. 

## **Member Contributions**

**Braeden Giasson**

- I worked on the WPF, implementing functionalities for Clicks, and some backend code.

**Justus Weidemann**

- I worked on the backend code, implementing the classes, interfaces, and edited some WPF code.

**Together**

- Overview
- UML diagram
- A little bit of backend and frontend WPF

## **Classes** 

- *Model* class (acts as Car)
  - Name (of model)
  - Horsepower
  - Torque
  - Number of seats
  - Width of Vehicle
  - Height of Vehicle
  - Length of Vehicle
  - FuelType
  - Body (enum) 
  - Engine (enum)
  - Color (enum)
  - See UML diagram for further details


- *Inventory* class
  - Max Quantity
  - quantity tracker
  - Add item()
  - Remove item()
  - Update item()
  - Shopping List()
  - Load items()
  - Save items()
  - See UML diagram for further details


## Interface

- bool MinimimQuantity(Model model);

## Development Approach 

1. **Understanding the problem.** 

   We want to build an inventory tracker for an Audi dealership. We except to be able to have functionality

   to add models to the inventory. We also except to be able to load models from a file.

2. **Formulating the problem.** 

   Input: Loading models from a file, and adding cars via the add button.

   Output: A list of Audi models currently in the inventory, displayed in a table format.

3. **Developing the application .** 

   See UML diagram for further developing details on the application.

4. **Implementing the application.** 

   We will be using WPF and C# to implement our application.

   WPF makes perfect to implement our application, since the UI is very powerful, and has great functionality for building small apps.

5. **Testing.** 

   We tested with data from loading from a file. We changed quantity fields, we inputted wrong values, we tried saving continuously, 
   
   we deleted rows, we tried clicking buttons when we couldn't. 
   
   All these tests that we performed, passed!

## Future Work
We want to be able to have a list to be able to create your own car (customize).
It is also possible to increase the size of the dealership later on or add more car models if new ones were to come out.