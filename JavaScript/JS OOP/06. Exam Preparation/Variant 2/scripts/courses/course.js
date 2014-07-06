define(['courses/student'], function (Student) {                // module
    'use strict';
    var Course;
    Course = (function () {        // class
        function Course(title, formula) {
            this._students = [];
            this._title = title;
            this._scoreFormula = formula;
        }

        Course.prototype.addStudent = function (student) {
            if (!(student instanceof Student)) {
                throw {
                    message: 'The object is not instance of Student'
                };
            }

            this._students.push(student);
            return this;        //for chaining
        };

        Course.prototype.calculateResults = function () {
            var i, len, student;
            for (i = 0, len = this._students.length; i < len; i += 1) {
                student = this._students[i];
                student.totalResult = this._scoreFormula(student);
            }
        };

        Course.prototype.getTopStudentsByExam = function (count) {
            count = count || this._students.length;
            return sortStudents(this._students, count, 'exam');
        };

        Course.prototype.getTopStudentsByTotalScore = function (count) {
            return sortStudents(this._students, count, 'totalResult');
        };

        function sortStudents(students, count, sortBy) {
            var coppiedStudents = students.slice(0);
            coppiedStudents.sort(function (first, second) {
                return second[sortBy] - first[sortBy];
            });

            return coppiedStudents.slice(0, count);
        }

        return Course;
    })();
    return Course;
});