define(function () {
    console.log('');
    console.info(
        'Task 07. By an array of people find the most ' +
        'common first and last name. Use underscore.js.'
    );

    // Find the most popular author
    console.log('Most common first name: ' + getMostCommonName(people, 'firstName'));
    console.log('Most common last name: ' + getMostCommonName(people, 'lastName'));

    function getMostCommonName(people, property) {
        return _.chain(people).groupBy(property).sortBy(function (group) {
            return group.length;
        }).reverse().value()[0][0][property];
    }
});