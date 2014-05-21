function solve(args) {
    var rc = args[0].split(' ');
    var r = parseInt(rc[0]);
    var c = parseInt(rc[1]);

    var field = [];
    for (var i = 0; i < r; i++) {
        field[i] = args[i + 1].split(' ');
    }

    var row = 0;
    var col = 0;

    var sum = 0;
    while (true) {
        var direction = field[row][col];
        sum += Math.pow(2, row) + col;
        field[row][col] = '*';

        switch (direction) {
            case 'dr': row++; col++; break;
            case 'ur': row--; col++; break;
            case 'dl': row++; col--; break;
            case 'ul': row--; col--; break;
            default: return 'failed at (' + row + ', ' + col + ')';
        }

        if (col < 0 || col > c - 1 || row < 0 || row > r - 1) {
            return 'successed with ' + sum;
        }
    }
}