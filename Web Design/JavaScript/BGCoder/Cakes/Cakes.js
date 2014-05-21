function solve(args) {
    var s = args[0];
    var c1 = args[1];
    var c2 = args[2];
    var c3 = args[3];

    var maxPay = 0;
    for (var i = 0; i <= s / c1; i++) {
        var c1pay = i * c1;
        for (var j = 0; j <= s / c2; j++) {
            var c2pay = j * c2;
            for (var k = 0; k <= s / c3; k++) {
                var c3pay = k * c3;
                var pay = c1pay + c2pay + c3pay;
                if (pay <= s && pay > maxPay) {
                    maxPay = pay;
                }
            }
        }
    }

    console.log(maxPay)
}