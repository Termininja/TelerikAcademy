//Task 1. Write functions for working with shapes in standard Planar coordinate system.
//Points are represented by coordinates P(X,Y).
//Lines are represented by two points, marking their beginning and ending L(P1(X1,Y1),P2(X2,Y2)).
//Calculate the distance between two points.
//Check if three segment lines can form a triangle.
function planar() {
    //Points
    {
        //Class for points
        function point(x, y) {
            this.x = x;
            this.y = y;
        }

        //Get the distance between two points
        function getDistance(p1, p2) {
            return Math.sqrt(Math.pow(p1.x - p2.x, 2) + Math.pow(p1.y - p2.y, 2));
        }

        var P1 = new point(0, 0);
        var P2 = new point(10, 0);
        var P3 = new point(0, 0);
        var P4 = new point(0, 10);
        var P5 = new point(15, 0);
        var P6 = new point(0, 0);
    }

    //Lines
    {
        //Class for lines
        function line(point1, point2) {
            this.point1 = point1;
            this.point2 = point2;
        }

        //Check if three segment lines can form a triangle
        function checkForTriangle(s1, s2, s3) {
            return (s1 + s2 > s3 && s2 + s3 > s1 && s1 + s3 > s2) ? true : false;
        }

        var L1 = new line(P1, P2);
        var L2 = new line(P3, P4);
        var L3 = new line(P5, P6);

        var segment1 = getDistance(P1, P2);
        var segment2 = getDistance(P3, P4);
        var segment3 = getDistance(P5, P6);
    }



    return checkForTriangle(segment1, segment2, segment3);
}


//Task 2. Write a function that removes all elements with a given value
//var arr = [1,2,1,4,1,3,4,1,111,3,2,1,"1"];
//arr.remove(1); //arr = [2,4,3,4,111,3,2,"1"];

//Attach it to the array class
//Read about prototype and how to attach methods

//Task 3. Write a function that makes a deep copy of an object.
//The function should work for both primitive and reference types

//Task 4. Write a function that checks if a given object contains a given property.
//var obj = ...;
//var hasProp = hasProperty(obj, "length");

//Task 5. Write a function that finds the youngest person in a given array of persons and prints his/hers full name.
//Each person have properties firstname, lastname and age, as shown:
//var persons = [
//	{firstname : "Gosho", lastname: "Petrov", age: 32}, 
//	{firstname : "Bay", lastname: "Ivan", age: 81},
//	...];

//Task 6. Write a function that groups an array of persons by age, first or last name. The function must return an associative array, with keys - the groups, and values -arrays with persons in this groups.
//Use function overloading (i.e. just one function)
//var persons = {...};
//var groupedByFname = group(persons, "firstname");
//var groupedByAge = group(persons, "age");



window.onload = function () {
    alert(planar());
}

//Generate an array of random integers
function arrayGenerator(len, start, count) {
    var array = [];
    for (var i = 0; i < len; i++) {
        array[i] = Math.floor(Math.random() * count + start);
        document.writeln(array[i]);
    }
    return array;
}