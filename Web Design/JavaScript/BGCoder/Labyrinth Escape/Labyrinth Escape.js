function solve(args) {
    var NM = args[0].split(' ');
    var N = parseInt(NM[0]);
    var M = parseInt(NM[1]);

    var RC = args[1].split(' ');
    var R = parseInt(RC[0]);
    var C = parseInt(RC[1]);

    var field = [];
    for (var i = 0; i < N; i++) {
        field[i] = args[i + 2].split('');
    }

    var sum = 0;
    var moves = 0;
    while (true) {
        var direction = field[R][C];
        sum += R * M + C + 1;
        field[R][C] = '*';

        if (direction === 'l') C--;
        else if (direction === 'r') C++;
        else if (direction === 'u') R--;
        else if (direction === 'd') R++;
        else return 'lost ' + moves;

        moves++;
        if (C < 0 || C > M - 1 || R < 0 || R > N - 1) {
            return "out " + sum;
        }
    }
}