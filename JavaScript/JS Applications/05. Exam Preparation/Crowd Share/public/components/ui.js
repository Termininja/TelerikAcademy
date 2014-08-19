define(function () {
    var UI = (function () {
        function buildChat(data) {
            var result = [];
            for (var i = data.length - 1; i >= 0; i--) {
                var div = document.createElement('div');
                div.innerHTML = data[i].title + ': "' + data[i].body + '" by ' + data[i].user.username;
                result.push(div);
            }

            $('#posts').html(result);
        }

        return {
            buildChat: buildChat
        }
    }());

    return UI;
});