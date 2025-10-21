using Sys🧩 Practice Brief: Vehicle Management Console App
1️⃣ Overview
Build a simple Vehicle Management System as a C# console application.
The system should allow users to create and display different types of vehicles (e.g., Car, Motorcycle, Truck), demonstrating inheritance, polymorphism, and interface usage.

2️⃣ Learning Goals
By completing this task, learners will:
Understand class inheritance and method overriding.
Apply interfaces to define common behavior across unrelated types.
Practice runtime polymorphism using base class and interface references.
Use collections (e.g., List<T>) to manage multiple objects.
Improve code organization using abstraction and encapsulation.

3️⃣ Requirements
Create a base class Vehicle with:
Properties: Brand, Model, Year.
Method: StartEngine() (virtual) → prints "The vehicle engine starts.".
Create at least three derived classes:
Car: adds NumberOfDoors and overrides StartEngine() → "The car engine starts with a key.".
Motorcycle: adds HasSidecar and overrides StartEngine() → "The motorcycle engine starts with a button.".
Truck: adds CargoCapacity and overrides StartEngine() → "The truck engine rumbles to life.".
Define an interface IDriveable with:
Method Drive() → void, no parameters.
Make all vehicle types implement IDriveable:
Each class should provide a specific Drive() implementation (e.g., "The car is driving on the road.").
In Program.cs:
Create a List<Vehicle> and add different vehicle types.
Loop through the list and:
Call StartEngine() (shows polymorphism).
Check if the vehicle implements IDriveable and call Drive().
Allow user input:
A simple menu to add new vehicles (Car, Motorcycle, Truck).
Ask for details via Console.ReadLine().
Add to the list dynamically.
When the user chooses “List Vehicles”, show:
Vehicle type
Brand, Model, Year
Any specific properties (e.g., Doors, Sidecar, Capacity)
The program exits when user selects “Exit”.

4️⃣ Architecture & Patterns
Pattern:
Inheritance for shared attributes and methods.
Interface for cross-cutting behavior (IDriveable).
Polymorphism to execute derived behavior from base references.

Structure:
VehicleManagement/
├── Models/
│   ├── Vehicle.cs
│   ├── Car.cs
│   ├── Motorcycle.cs
│   └── Truck.cs
├── Interfaces/
│   └── IDriveable.cs
└── Program.cs

6️⃣ Acceptance Criteria
1	The app runs	User selects “Add Car”	Car object is created and added to the list
2	Vehicle list is non-empty	User selects “List Vehicles”	Each vehicle type shows type-specific StartEngine() and Drive() messages
3	All vehicle types implement IDriveable	User loops through vehicles	Drive() method outputs correct message
4	User selects “Exit”	—	Program terminates gracefully

7️⃣ Evaluation Rubric (Total 10 points)
Correctness	Classes and interface implemented correctly	3
OOP Concepts	Proper inheritance, overriding, and polymorphism	3
Code Quality	Readable structure, naming conventions, no duplication	2
User Interaction	Menu and input handling work properly	1
Console Output	Clear and meaningful output	1

8️⃣ Extensions (Optional Stretch Goals)
Add ElectricCar with battery range and override StartEngine() differently.
Implement an IRefuelable interface for Truck.
Serialize and deserialize vehicles to JSON using System.Text.Json.
Add filtering by vehicle type before listing.

9️⃣ Deliverables & Constraints
Runtime: .NET 8  or 9 Console App
Namespace: VehicleManagement
No external packages (only System namespaces)
Nullable reference types: Enabled
Timebox: ~1 day

✅ What the Reviewer Should Look For
Inheritance chain (Vehicle → derived classes) is correct.
Method overriding demonstrates polymorphism.
Interface (IDriveable) is used correctly and implemented by all vehicles.
Code compiles, runs, and handles user input without crashes.
Output clearly differentiates vehicle behaviors.

