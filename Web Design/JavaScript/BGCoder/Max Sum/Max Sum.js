function solve(args) {
    var maxSum = -Infinity;
    for (var i = 1; i < args.length; i++) {
        var sum = 0;
        for (var j = i; j < args.length; j++) {
            sum += +args[j];
            if (sum > maxSum) maxSum = sum
        }
    }

    return maxSum;
}