define(function () {
    console.log('');
    console.info(
        'Task 03. Write a function that by a given array ' +
        'of students finds the student with highest marks.'
    );

    // Finds all students with highest marks
    var filteredStudents = filterStudentsByMarks(students);

    // Print the filtered students
    _.each(filteredStudents, function (student) {
        console.log(student.firstName + ' ' + student.lastName + ' : ' + student.marks);
    })

    function filterStudentsByMarks(students) {
        var result = _.filter(students, function (student) {
            return _.filter(student.marks, function (mark) {
                return mark === 6;
            }).length > 0;
        });

        return result;
    }
});