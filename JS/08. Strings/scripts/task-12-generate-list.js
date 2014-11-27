//Task 12. Write a function that creates a HTML UL using a template for every HTML LI.
//The source of the list should an array of elements. Replace all placeholders marked
//with -{...}- with the value of the corresponding property of the object.

function generateList(people, template) {
    var peopleList = '<ul>';
    for (var i = 0; i < people.length; i++) {
        peopleList += '\n\t<li>' +
            template.replace(/-{(.*?)}-/g, function (_, match) { return people[i][match]; }) +
            '</li>';
    }
    peopleList += '\n</ul>';

    return peopleList;
}