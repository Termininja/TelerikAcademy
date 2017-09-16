define(['jquery', 'q-promise'], function ($, Q) {
    var HttpRequest = (function () {
        var get = function (url, headers) {
            var deferred = Q.defer();
            $.ajax({
                url: url,
                headers: headers,
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

        var post = function (url, data, headers) {
            var deferred = Q.defer();
            $.ajax({
                url: url,
                headers: headers,
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