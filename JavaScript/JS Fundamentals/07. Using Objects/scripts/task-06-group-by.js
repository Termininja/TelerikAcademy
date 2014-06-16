//Task 6. Write a function that groups an array of persons by age, first or last name.
//The function must return an associative array, with keys (the groups), and values
//(arrays with persons in this groups). Use function overloading.

function groupBy(persons, key) {
    var groupedPersons = {};

    for (var person in persons) {
        var groupName = persons[person][key];
        if (!groupedPersons[groupName]) {
            groupedPersons[groupName] = [];
        }
        groupedPersons[groupName].push(persons[person]);
    }

    return groupedPersons;
}
