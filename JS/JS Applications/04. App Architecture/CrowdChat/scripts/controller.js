define(['requester', 'ui'], function (HttpRequest, UI) {
    var Controller = (function () {
        var username;
        var Controller = function (url) {
            this.url = url;
        };

        Controller.prototype.isLoggedIn = function () {
            return username != null;
        };

        Controller.prototype.loadChat = function () {
            var _this = this;

            $.when(
                $.get('view-templates/chat.html', function (data) {
                    $('#main').html(data);
                    $('.username-box').html(username);

                    setInterval(function () {
                        HttpRequest.get(_this.url)
                            .then(function (data) {
                                $('#chat-screen').html(UI.buildChat(data));
                            });
                    }, 1000);
                }));
        };

        Controller.prototype.eventHandler = function () {
            var _this = this;

            $('#main').on('click', '#login-button', function () {
                username = $('#name').val();
                if (username && typeof username === 'string') {
                    window.location = '#/chat';
                }
            });

            $('#main').on('click', '#send', function () {
                var message = $('#message').val();
                if (message) {
                    HttpRequest.post(_this.url, {
                        user: username,
                        text: message
                    }).then(function () {
                        $('#message').val('');
                        $('#chat-screen').prepend(UI.buildMessage(username, message));
                    }, function (err) {
                        console.log(err);
                    });
                }
            });
        };

        return Controller;
    }());

    return Controller;
});