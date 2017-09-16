## Using Objects ([Demo](https://cdn.rawgit.com/Termininja/TelerikAcademy/8ce035c8/JS/07.%20Using%20Objects/index.html))

**Task 01.** Write functions for working with shapes in standard Planar coordinate system.
* Points are represented by coordinates `P(X,Y)`.
* Lines are represented by two points, marking their beginning and ending `L(P1(X1,Y1),P2(X2,Y2))`.
* Calculate the distance between two points.
* Check if three segment lines can form a triangle.

**Task 02.** Write a function that removes all elements with a given value
```js
	var arr = [1,2,1,4,1,3,4,1,111,3,2,1,"1"];
	arr.remove(1); //arr = [2,4,3,4,111,3,2,"1"];
```

* Attach it to the array class
* Read about `prototype` and how to attach methods

**Task 03.** Write a function that makes a deep copy of an object.
* The function should work for both primitive and reference types

**Task 04.** Write a function that checks if a given object contains a given property.
```js
	var obj = ...;
	var hasProp = hasProperty(obj, "length");
```

**Task 05.** Write a function that finds the youngest person in a given array of persons and prints his/hers full name.
* Each person have properties `firstname`, `lastname` and `age`, as shown:
```js
	var persons = [
		{firstname : "Gosho", lastname: "Petrov", age: 32}, 
		{firstname : "Bay", lastname: "Ivan", age: 81},
		...];
```

**Task 06.** Write a function that groups an array of persons by age, first or last name. The function must return an associative array, with keys - the groups, and values -arrays with persons in this groups.
* Use function overloading (i.e. just one function)
```js
	var persons = {...};
	var groupedByFname = group(persons, "firstname");
	var groupedByAge = group(persons, "age");
```