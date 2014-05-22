function solve(args) {
    var s = args[0];
    var count = 0;
    for (var i = 0; i <= s / 4; i++) {
        for (var j = 0; j <= s / 10; j++) {
            for (var k = 0; k <= s / 3; k++) {
                if (i * 4 + j * 10 + k * 3 == s) count++;
            }
        }
    }

    console.log(count)
}