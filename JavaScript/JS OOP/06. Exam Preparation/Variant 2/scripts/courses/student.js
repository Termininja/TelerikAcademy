define(function () {                // module
    'use strict';
    var Student;
    Student = (function () {        // class
        //var studentID = 0;
        function Student(info) {
            this.name = info.name;
            this.exam = info.exam;
            this.homework = info.homework;
            this.attendance = info.attendance;
            this.teamwork = info.teamwork;
            this.bonus = info.bonus;

            //this._id = ++studentID;
        }

        return Student;
    })();
    return Student;
});