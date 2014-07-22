define(function () {
    console.log('');
    console.info(
        'Task 02. Write function that finds the first name and last name ' +
        'of all students with age between 18 and 24. Use Underscore.js.'
    );

    // Finds all students with age between 18 and 24
    var filteredStudents = filterStudentsByAge(students);

    // Print the filtered students
    _.each(filteredStudents, function (student) {
        console.log(student.firstName + ' ' + student.lastName + ' : ' + student.age);
    })

    function filterStudentsByAge(students) {
        var result = _.filter(students, function (student) {
            return student.age >= 18 && student.age <= 24;
        });

        return result;
    }
});