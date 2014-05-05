function Solve(args) {
    var MN = args[0].split(' ');
    var N = parseInt(MN[0]);
    var M = parseInt(MN[1]);

    var RC = args[1].split(' ');
    var R = parseInt(RC[0]);
    var C = parseInt(RC[1]);

    var labyrinth = [];
    for (var n = 0; n < N; n++) {
        labyrinth[n] = args[n + 2].split('');
    }

    var count = 0;
    var sum = 0;
    while (true) {
        var direction = labyrinth[R][C];
        sum += R * M + C + 1;
        labyrinth[R][C] = '*';

        if (direction == 'l') C--;
        else if (direction == 'r') C++;
        else if (direction == 'u') R--;
        else if (direction == 'd') R++;
        else {
            return "lost " + count;
            break;
        }

        count++;
        if (C < 0 || C > M - 1 || R < 0 || R > N - 1) {
            return "out " + sum;
            break;
        }
    }
}