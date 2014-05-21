function solve(args) {
    var rc = args[0].split(' ');
    var r = parseInt(rc[0]);
    var c = parseInt(rc[1]);

    var field = [];
    for (var i = 0; i < r; i++) {
        field[i] = args[i + 1].split('');
    }

    var row = r - 1;
    var col = c - 1;

    var sum = 0;
    var jumps = 0;
    while (true) {
        var direction = field[row][col];
        sum += Math.pow(2, row) - col;
        field[row][col] = '*';

        switch (direction) {
            case '1': row -= 2; col++; break;
            case '8': row -= 2; col--; break;

            case '2': row--; col += 2; break;
            case '3': row++; col += 2; break;

            case '4': row += 2; col++; break;
            case '5': row += 2; col--; break;

            case '6': row++; col -= 2; break;
            case '7': row--; col -= 2; break;

            default: return 'Sadly the horse is doomed in ' + jumps + ' jumps';
        }

        jumps++;
        if (col < 0 || col > c - 1 || row < 0 || row > r - 1) {
            return 'Go go Horsy! Collected ' + sum + ' weeds';
        }
    }
}
