define(function () {
    console.log('');
    console.info(
        'Task 04. Write a function that by a given array of animals, ' +
        'groups them by species and sorts them by number of legs.'
    );

    // Group and sort a given array of animals
    var groupedAndSortedAnimals = groupAndSortAnimals(animals);

    // Print the grouped and sorted animals
    _.each(groupedAndSortedAnimals, function (group) {
        console.log('Phylum group: ' + group[0].phylum)
        _.each(group, function (property) {
            console.log(JSON.stringify(property));
        });
    });

    function groupAndSortAnimals(animals) {
        // Sorts animals by number of legs
        var sortedAnimals = _.sortBy(animals, 'legs');

        // Groups animals by phylum
        var groupedAnimals = _.groupBy(sortedAnimals, 'phylum');

        return groupedAnimals;
    }
});