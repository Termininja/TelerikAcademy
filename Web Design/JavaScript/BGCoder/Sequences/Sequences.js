function Solve(params) {
    var N = parseInt(params[0]);
    var count = 1;
    for (var i = 2; i <= N; i++) {
        if (parseInt(params[i]) < parseInt(params[i - 1])) count++;
    }

    return count;
}