define(function () {
    console.log('');
    console.info(
        'Task 05. By a given array of animals, find the total number ' +
        'of legs. Each animal can have 2, 4, 6, 8 or 100 legs.'
    );

    // Find the total number of legs of all animals
    console.log('Total Number of Legs: ' + getTotalNumberOfLegs(animals));

    function getTotalNumberOfLegs(animals) {
        var count = 0;
        _.each(animals, function (animal) {
            return count += animal.legs;
        });

        return count;
    }
});