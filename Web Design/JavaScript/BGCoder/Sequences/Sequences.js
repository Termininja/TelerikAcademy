function solve(args) {
    var count = 1;
    for (var i = 1; i < args.length - 1; i++) {
        if (+args[i] > +args[i + 1]) count++;
    }

    return count;
}