function Solve(args) {
    var NMJ = args[0].split(' ');
    var N = parseInt(NMJ[0]);
    var M = parseInt(NMJ[1]);
    var J = parseInt(NMJ[2]);

    var RC = args[1].split(' ');
    var R = parseInt(RC[0]);
    var C = parseInt(RC[1]);

    var jumps = [];
    for (var j = 0; j < J; j++) {
        var input = args[2 + j].split(' ');
        jumps[j] = [parseInt(input[0]), parseInt(input[1])];
    }

    var field = new Array(N);
    for (var i = 0; i < N; i++) {
        field[i] = new Array(M);
    }

    var count = 0;
    var sum = R * M + C + 1;

    while (true) {
        for (var j = 0; j < jumps.length; j++) {
            R += jumps[j][0];
            C += jumps[j][1];
            if (R >= 0 && R < N && C >= 0 && C < M) {
                if (field[R][C] !== '*') {
                    count++;
                    sum += R * M + C + 1
                    field[R][C] = '*';
                }
                else return 'caught ' + count;
            }
            else return 'escaped ' + sum;
        }
    }
}