define(function () {
    require.config({
        paths: {
            'jquery': '../libs/jquery-2.1.1.min',
            'q-promise': '../libs/q.min',
            'controller': 'controller',
            'ui': 'ui',
            'requester': 'requester',
            'sha1': 'http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1'
        }
    });

    require(['controller', 'jquery'], function (Controller, $) {
        $('#wrapper').load('components/view-templates/main.html');
        var url = 'http://localhost:3000';
        var controller = new Controller(url);
        controller.eventHandler();
        controller.loadChat();
    });
});