define(function () {
    console.log('');
    console.info(
        'Task 01. Write a method that from a given array of students finds ' +
        'all students whose first name is before its last name alphabetically. ' +
        'Print the students in descending order by full name. Use Underscore.js.'
    );

    // Finds all students whose first name is before its last name
    var filteredStudents = filterStudentsByName(students);

    // Sort the students in descending order by first and last name
    var sortedInDescendingOrder = _.sortBy(filteredStudents, function (student) {
        return student.firstName + ' ' + student.lastName;
    }).reverse();

    // Print the sorted students
    _.each(sortedInDescendingOrder, function (student) {
        console.log(student.firstName + ' ' + student.lastName);
    })

    function filterStudentsByName(students) {
        var result = _.filter(students, function (student) {
            return student.firstName < student.lastName;
        });

        return result;
    }
});