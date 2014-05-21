function solve(args) {
    var NMJ = args[0].split(' ');
    var N = parseInt(NMJ[0]);
    var M = parseInt(NMJ[1]);
    var RC = args[1].split(' ');
    var R = parseInt(RC[0]);
    var C = parseInt(RC[1]);

    var field = [];
    for (var i = 0; i < N; i++) {
        field[i] = [];
    }

    var jumps = 0;
    var sum = R * M + C + 1;
    while (true) {
        for (var i = 2; i < args.length; i++) {
            var jump = args[i].split(' ');
            R += +jump[0];
            C += +jump[1];
            if (R >= 0 && R < N && C >= 0 && C < +M) {
                if (field[R][C] !== '*') {
                    sum += R * M + C + 1;
                    jumps++;
                    field[R][C] = '*';
                }
                else return 'caught ' + jumps;
            }
            else return 'escaped ' + sum;
        }
    }
}