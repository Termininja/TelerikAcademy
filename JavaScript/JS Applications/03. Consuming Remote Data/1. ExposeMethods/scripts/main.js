define(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.0.2',
            'q-promise': 'libs/q-promise',
        }
    });

    require(['script'], function (HttpRequest) {
        var url = 'http://crowd-chat.herokuapp.com/posts';

        HttpRequest.postJSON(url, { user: 'Ivan', text: 'Hello' }).then(function (data) {
            console.log(data);
        });

        HttpRequest.getJSON(url).then(function (data) {
            console.log(data[data.length - 1]);
        });
    });
});