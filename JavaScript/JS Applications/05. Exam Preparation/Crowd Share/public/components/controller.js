define(['requester', 'ui', 'sha1'], function (HttpRequest, UI) {
    var Controller = (function () {
        var username;
        var password;

        var Controller = function (url) {
            this.url = url;
        };

        Controller.prototype.eventHandler = function () {
            var _this = this;

            //RegisterMain button event
            $('#wrapper').on('click', '#register-main', function () {
                $('#wrapper').load('components/view-templates/register.html');
            });

            //LoginMain button event
            $('#wrapper').on('click', '#login-main', function () {
                $('#wrapper').load('components/view-templates/login.html');
            });

            //Back button event
            $('#wrapper').on('click', '#back', function () {
                $('#wrapper').load('components/view-templates/main.html');
            });

            //Register button event
            $('#wrapper').on('click', '#register-button', function () {
                var errorMessage = 'The username is already taken or not correct!'
                username = $('#r-username').val();
                password = $('#r-password').val();
                $('#r-username').val('');
                $('#r-password').val('');
                if (isCorrectValue(username, password)) {
                    var authCode = CryptoJS.SHA1(password).toString();
                    HttpRequest.register(_this.url, {
                        'username': username,
                        'authCode': authCode
                    }).then(function (success) {
                        $('#wrapper').load('components/view-templates/login.html');
                        console.info('Correct data!');
                    }, function (err) {
                        alert(errorMessage);
                    });
                } else {
                    alert(errorMessage);
                }
            });

            //Login button event
            $('#wrapper').on('click', '#login-button', function () {
                username = $('#l-username').val();
                password = $('#l-password').val();
                $('#l-username').val('');
                $('#l-password').val('');
                if (isCorrectValue(username, password)) {
                    var authCode = CryptoJS.SHA1(password).toString();
                    HttpRequest.login(_this.url, {
                        'username': username,
                        'authCode': authCode
                    }).then(function (success) {
                        $('#wrapper').load('components/view-templates/chat.html');
                        console.info('Logged in!');
                        sessionStorage.setItem('sessionKey', success.sessionKey);
                    }, function (err) {
                        alert('Wrong username or password!');
                    });
                } else {
                    alert('Wrong username or password!');
                }
            });

            //Logout button event
            $('#wrapper').on('click', '#logout', function () {
                var sessionKey = sessionStorage.getItem('sessionKey');
                HttpRequest.logout(_this.url, sessionKey).then(function (success) {
                    $('#wrapper').load('components/view-templates/main.html');
                    sessionStorage.clear();
                    console.info('Logged out!');
                }, function (err) {
                    console.warn('Wrong session!');
                });
            });

            //Post message button event
            $('#wrapper').on('click', '#send', function () {
                var sessionKey = sessionStorage.getItem('sessionKey');
                var title = $('#title').val();
                var message = $('#message').val();
                if (title && message) {
                    HttpRequest.post(_this.url, {
                        'title': title,
                        'body': message
                    }, sessionKey).then(function () {
                        $('#message').val('');
                        $('#title').val('');
                    }, function (err) {
                        console.warn(err);
                    });
                }
            });
        };

        Controller.prototype.isLoggedIn = function () {
            return username != null && isCorrectUsername(username);
        };

        Controller.prototype.loadChat = function () {
            var _this = this;
            setInterval(function () {
                HttpRequest.get(_this.url)
                    .then(function (data) {
                        UI.buildChat(data);
                    });
            }, 1000);

            //$.get(url + '/post')
            //    .then(function (result) {
            //        var totalPosts = result.length;
            //        var $postsContainer = $('#posts');

            //        for (var i = 0; i < totalPosts; i++) {
            //            var currentPost = result[i];
            //            var well = $('<div />').addClass('well').text(currentPost.title + ': "' + currentPost.body + '" by ' + currentPost.user.username).appendTo('#posts');
            //        }
            //    });
        };

        function isCorrectValue(username, password) {
            if (username && 6 <= username.length && username.length <= 40 &&
                password && 6 <= password.length && password.length <= 40) {
                return true;
            } else {
                return false;
            }
        }

        return Controller;
    }());

    return Controller;
});