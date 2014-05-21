function solve(args) {
    var variables = [];
    for (var i = 0; i < args.length; i++) {
        var command = args[i].trim();
        command = command.substring(1, command.length - 1).trim();
        if (i < args.length - 1 && command.substring(0, 4) === 'def ') {
            command = command.substr(4).trim().split('(').join(' ( ');
            var varName = command.substring(0, command.indexOf(' ')).trim();
            variables[varName] = calc(command.substr(varName.length).trim());
            if (Math.abs(variables[varName]) === Infinity) return 'Division by zero! At Line:' + (i + 1);
        }
        else if (i === args.length - 1) {
            var result = calc(command);
            return (Math.abs(result) === Infinity) ? 'Division by zero! At Line:' + (i + 1) : result;
        }
    }

    function calc(com) {
        com = com.replace('(', '').replace(')', '').trim();
        var op = com[0];
        var array = com.substr(1).split(' ').filter(String);
        array = takeNumbers(array);

        return (op == '+' || op == '-' || op == '*' || op == '/') ?
            (Math.floor(array.reduce(function (a, b) {
                return (op == '+') ? a + b : ((op == '-') ? a - b : ((op == '*') ? a * b : a / b))
            }))) : takeNumbers([com]);
    }

    function takeNumbers(arr) {
        for (var i = 0; i < arr.length; i++) {
            if (isNaN(parseInt(arr[i]))) {
                var newArray = [i, 1].concat(variables[arr[i].trim()]);
                arr.splice.apply(arr, newArray);
                i += newArray.length - 3;
            }
        }

        return arr.map(Number);
    }
}