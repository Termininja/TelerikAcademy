function Solve(params) {
    var N = parseInt(params[0]);

    var arr = [];
    for (var i = 0; i < params.length; i++) {
        arr.push(parseInt(params[i]));
    }

    var maxSum = Number.NEGATIVE_INFINITY;
    for (var i = 1; i <= N; i++) {
        for (var j = i; j <= N; j++) {
            var sum = 0;
            for (var p = i; p <= j; p++) {
                sum += arr[p];
            }

            if (sum > maxSum) maxSum = sum;
        }
    }

    return maxSum;
}