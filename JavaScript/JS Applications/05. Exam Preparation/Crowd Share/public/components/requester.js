define(['jquery', 'q-promise'], function ($, Q) {
    var HttpRequest = (function () {
        var register = function (url, data) {
            var deferred = Q.defer();
            $.ajax({
                url: url + '/user',
                type: "POST",
                data: data,
                success: function (dataInfo) {
                    deferred.resolve(dataInfo);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });

            return deferred.promise;
        }

        var login = function (url, data) {
            var deferred = Q.defer();
            $.ajax({
                url: url + '/auth',
                type: "POST",
                data: data,
                success: function (dataInfo) {
                    deferred.resolve(dataInfo);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });

            return deferred.promise;
        }

        var logout = function (url, sessionKey) {
            var deferred = Q.defer();
            $.ajax({
                url: url + '/user',
                type: "PUT",
                headers: {
                    'x-sessionkey': sessionKey
                },
                success: function (dataInfo) {
                    deferred.resolve(dataInfo);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });

            return deferred.promise;
        }

        var get = function (url) {
            var deferred = Q.defer();
            $.ajax({
                url: url + '/post',
                type: "GET",
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });

            return deferred.promise;
        };

        var post = function (url, data, sessionKey) {
            var deferred = Q.defer();
            $.ajax({
                url: url + '/post',
                type: "POST",
                headers: {
                    'x-sessionkey': sessionKey
                },
                data: data,
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
            register: register,
            login: login,
            logout: logout,
            get: get,
            post: post
        }
    }());

    return HttpRequest;
});