//Task 5. Write a function that finds the youngest person in an array of persons and
//prints his/hers full name. Each person have properties firstname, lastname and age.

function findYoungest(persons) {
    var minAge = Number.POSITIVE_INFINITY;
    var youngestPerson = 'No person!';
    for (var person in persons) {
        var personAge = persons[person].age;
        if (personAge < minAge && personAge > 0) {
            minAge = personAge;
            youngestPerson = persons[person].firstname + ' ' + persons[person].lastname;
        }
    }

    return youngestPerson;
}
