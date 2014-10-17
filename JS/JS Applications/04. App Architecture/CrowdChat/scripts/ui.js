define(function () {
    var UI = (function () {
        var div = document.createElement('div');
        var element = document.createElement('span');
        div.appendChild(element);

        function buildMessage(sender, message) {
            element.innerHTML = sender + ": " + message;
            return div.cloneNode(true);
        }

        function buildChat(data) {
            var result = [];
            for (var i = data.length - 1; i > data.length - 100 ; i--) {
                result.push(buildMessage(data[i].by, data[i].text));
            }

            return result;
        }

        return {
            buildMessage: buildMessage,
            buildChat: buildChat
        }
    }());

    return UI;
});