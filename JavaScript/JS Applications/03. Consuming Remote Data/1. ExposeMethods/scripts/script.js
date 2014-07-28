define(['jquery', 'q-promise'], function ($, Q) {
    var HttpRequest = (function () {
        var get = function (url) {
            var deferred = Q.defer();
            $.ajax({
                url: url,
                type: "GET",
                contentType: "application/json",
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });

            return deferred.promise;
        };

        var post = function (url, data) {
            var deferred = Q.defer();
            $.ajax({
                url: url,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                success: function (dataInfo) {
                    deferred.resolve(dataInfo);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });

            return deferred.promise;
        };

        return {
            getJSON: get,
            postJSON: post
        }
    }());

    return HttpRequest;
});