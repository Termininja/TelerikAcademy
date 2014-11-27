(function () {
    var resourceUrl = 'http://localhost:3000/students';

    var getStudents = function () {
        var deferred = Q.defer();
        $.ajax({
            url: resourceUrl,
            type: "GET",
            success: function (data) {
                console.log(data)
                deferred.resolve(data);
            },
            error: function (err) {
                deferred.reject(err);
            }
        });

        return deferred.promise;
    };

    var addStudent = function (student) {
        var deferred = Q.defer();
        $.ajax({
            url: resourceUrl,
            type: 'POST',
            data: JSON.stringify(student),
            contentType: "application/json",
            success: function (data) {
                deferred.resolve(data);
                getStudents();
            },
            error: function (error) {
                deferred.resolve(error);
            }
        });

        return deferred.promise;
    };

    var removeStudent = function (id) {
        return $.ajax({
            url: resourceUrl + '/' + id,
            type: 'POST',
            timeout: 1000,
            data: { _method: 'delete' },
            success: function (data) {
                getStudents();
            }
        });
    };

    $(function () {
        getStudents();
        $('#btn-add-student').on('click', function () {
            var student;
            student = {
                name: $('#tb-name').val(),
                grade: $('#tb-grade').val()
            };
            addStudent(student);
        });
        $('#btn-delete-student').on('click', function () {
            var id = $('#id').val();
            removeStudent(id);
        });
    });
}());