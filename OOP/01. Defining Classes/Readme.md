## [Defining Classes] (https://github.com/TelerikAcademy/Object-Oriented-Programming/tree/master/01.%20Defining%20Classes)

**Task 01.** Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). Define 3 separate classes (class `GSM` holding instances of the classes `Battery` and `Display`).

**Task 02.** Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it). Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with `null`.

**Task 03.** Add an enumeration `BatteryType` (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.

**Task 04.** Add a method in the `GSM` class for displaying all information about it. Try to override `ToString()`.

**Task 05.** Use properties to encapsulate the data fields inside the `GSM`, `Battery` and `Display` classes. Ensure all fields hold correct data at any given time.

**Task 06.** Add a static field and a property `IPhone4S` in the `GSM` class to hold the information about iPhone 4S.

**Task 07.** Write a class GSMTest to test the `GSM` class:
  * Create an array of few instances of the GSM class.
  * Display the information about the GSMs in the array.
  * Display the information about the static property `IPhone4S`.

**Task 08.** Create a class `Call` to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).

**Task 09.** Add a property `CallHistory` in the `GSM` class to hold a list of the performed calls. Try to use the system class `List<Call>`.

**Task 10.** Add methods in the `GSM` class for adding and deleting calls from the calls history. Add a method to clear the call history.

**Task 11.** Add a method that calculates the total price of the calls in the call history. Assume the price per minute is fixed and is provided as a parameter.

**Task 12.** Write a class `GSMCallHistoryTest` to test the call history functionality of the `GSM` class.
  * Create an instance of the `GSM` class.
  * Add few calls.
  * Display the information about the calls.
  * Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
  * Remove the longest call from the history and calculate the total price again.
  * Finally clear the call history and print it.

**Task 13.** Create a structure `Point3D` to hold a 3D-coordinate `{X, Y, Z}` in the Euclidian 3D space. Implement the `ToString()` to enable printing a 3D point.

**Task 14.** Add a private `static read-only field` to hold the start of the coordinate system – the point `O{0, 0, 0}`. Add a `static property` to return the point O.

**Task 15.** Write a `static class` with a `static method` to calculate the distance between two points in the 3D space.

**Task 16.** Create a class `Path` to hold a sequence of points in the 3D space. Create a static class `PathStorage` with static methods to save and load paths from a text file. Use a file format of your choice.

**Task 17.** Write a generic class `GenericList<T>` that keeps a list of elements of some parametric type `T`. Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and `ToString()`. Check all input parameters to avoid accessing elements at invalid positions.

**Task 18.** Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.

**Task 19.** Create generic methods `Min<T>()` and `Max<T>()` for finding the minimal and maximal element in the `GenericList<T>`. You may need to add a generic constraints for the type `T`.

**Task 20.** Define a class `Matrix<T>` to hold a matrix of numbers (e.g. integers, floats, decimals).

**Task 21.** Implement an indexer `this[row, col]` to access the inner matrix cells.

**Task 22.** Implement the operators `+` and `-` (addition and subtraction of matrices of the same size) and `*` for matrix multiplication. Throw an exception when the operation cannot be performed. Implement the `true` operator (check for non-zero elements).

**Task 23.** Create a `[Version]` attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format `major.minor` (e.g. `2.11`). Apply the version attribute to a sample class and display its version at runtime.
