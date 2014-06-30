$(document).ready(function () {
    var specialConsole = (function () {
        function writeLine(message, placeHolders) {
            console.log(getMessage(message, placeHolders));
        }

        function writeError(message, placeHolders) {
            console.error(getMessage(message, placeHolders));
        }

        function writeWarning(message, placeHolders) {
            console.warn(getMessage(message, placeHolders));
        }

        function getMessage(message, placeHolders) {
            return (placeHolders) ? holders(message, arguments) : message;

            function holders(message, args) {
                for (var i = 0; i < args.length; i++) {
                    while (message.indexOf('{' + i + '}') != -1) {
                        message = message.replace('{' + i + '}', args[i + 1]);
                    }
                }

                return message;
            }
        }

        return {
            writeLine: writeLine,
            writeError: writeError,
            writeWarning: writeWarning
        };

    })();

    specialConsole.writeLine("Message: hello");

    //Logs to the console "Message: hello"
    specialConsole.writeLine("Message: {0}", "hello");

    //Logs to the console "Message: hello"
    specialConsole.writeError("Error: {0}", "Something happened");
    specialConsole.writeWarning("Warning: {0}", "A warning");
});