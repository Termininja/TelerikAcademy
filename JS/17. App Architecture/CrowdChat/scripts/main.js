define(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.0.2',
            'q-promise': 'libs/q.min',
            'sammy': 'libs/sammy',
            'controller': 'controller',
            'requester': 'requester',
            'ui': 'ui'
        }
    });

    require(['controller', 'jquery', 'sammy', ], function (Controller, $, Sammy) {
        var controller = new Controller('http://crowd-chat.herokuapp.com/posts');
        controller.eventHandler();

        var app = Sammy('#main', function () {
            this.get("#/login", function () {
                $('#main').load('view-templates/login.html');
            });

            this.get("#/chat", function () {
                controller.loadChat();
            });
        });

        app.run('#/login');
    });
});