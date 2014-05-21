function solve(args) {
    var variables = [];

    for (var i = 0; i < args.length; i++) {
        if (i < args.length - 1 && args[i].trim().substring(0, 4) !== 'def ') continue;
        var command = args[i].replace('def ', '').split('[').join(' [ ').trim();
        if (i < args.length - 1) {
            var property = command.substring(0, command.indexOf(' '));
            variables[property] = calc(command.substr(property.length).trim());
        }
        else return Math.floor(calc(command));
    }

    function calc(str, op) {
        if (str[0] === '[') {
            str = str.substring(1, str.length - 1);
            var result = [];
            var arr = takeNumbers(str.split(','));

            switch (op) {
                case 'min':
                    result.push(Math.min.apply(Math, arr));
                    break;
                case 'max':
                    result.push(Math.max.apply(Math, arr));
                    break;
                case 'sum':
                    result.push(arr.reduce(function (a, b) { return a + b }, 0));
                    break;
                case 'avg':
                    result.push(arr.reduce(function (a, b) { return a + b }, 0) / arr.length);
                    break;
                default:
                    result = arr;
                    break;
            }

            return result;
        }
        else {
            var operation = str.substring(0, 3);
            str = str.substr(operation.length).trim();

            return calc(str, operation);
        }
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