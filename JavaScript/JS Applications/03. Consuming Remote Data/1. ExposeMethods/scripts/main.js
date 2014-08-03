define(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.0.2',
            'q-promise': 'libs/q-promise',
        }
    });

    require(['script'], function (HttpRequest) {
        var url = 'http://crowd-chat.herokuapp.com/posts';
        var headers = {
            contentType: 'application/json',
            accept: 'application/json'
        };

        HttpRequest.postJSON(url, { user: 'Ivan', text: 'Hello' }, headers).then(function (data) {
            console.log(data);
        });

        HttpRequest.getJSON(url, headers).then(function (data) {
            console.log(data[data.length - 1]);
        });
    });
});