(function () {
    require([
        'task-01-filter-students-by-name',
        'task-02-filter-students-by-age',
        'task-03-filter-students-by-marks',
        'task-04-group-and-sort-animals',
        'task-05-get-total-number-of-legs',
        'task-06-most-popular-author',
        'task-07-most-common-name'
    ]);
})();

var students = [
    { firstName: 'Ivan', lastName: 'Petrov', age: 27, marks: [2, 2, 3, 5] },
    { firstName: 'Ivan', lastName: 'Todorov', age: 24, marks: [6, 5, 4, 4] },
    { firstName: 'Maria', lastName: 'Todorova', age: 25, marks: [6, 6, 3, 4] },
    { firstName: 'Pesho', lastName: 'Peshev', age: 26, marks: [2, 2, 2, 2] },
    { firstName: 'Sasho', lastName: 'Rumenov', age: 18, marks: [5, 5, 5, 3] },
    { firstName: 'Katya', lastName: 'Ivanova', age: 20, marks: [6, 6, 6, 5] },
    { firstName: 'Ivan', lastName: 'Ivanov', age: 17, marks: [4, 2, 5, 6] },
    { firstName: 'Maria', lastName: 'Petrova', age: 18, marks: [2, 5, 5, 4] },
    { firstName: 'Gosho', lastName: 'Stoyanov', age: 23, marks: [5, 5, 3, 4] },
    { firstName: 'Vanya', lastName: 'Mitrova', age: 28, marks: [3, 3, 3, 3] }
];

var animals = [
    { phylum: 'Chordata', species: 'Bombina variegata', legs: 4 },
    { phylum: 'Chordata', species: 'Bubo bubo', legs: 2 },
    { phylum: 'Arthropoda', species: 'Pieris brassicae', legs: 6 },
    { phylum: 'Chordata', species: 'Vulpes cana', legs: 4 },
    { phylum: 'Chordata', species: 'Gypaetus barbatus', legs: 2 },
    { phylum: 'Chordata', species: 'Cervus nippon', legs: 4 },
    { phylum: 'Arthropoda', species: 'Atrax robustus', legs: 8 },
    { phylum: 'Chordata', species: 'Elephas maximus', legs: 4 },
    { phylum: 'Arthropoda', species: 'Tettigonia viridissima', legs: 6 },
    { phylum: 'Chordata', species: 'Panthera leo', legs: 4 }
];

var books = [
    { name: 'The Chimes', author: 'Charles Dickens' },
    { name: 'The Dead Zone', author: 'Stephen King' },
    { name: 'The Casual Vacancy', author: 'J. K. Rowling' },
    { name: 'The Sun Also Rises', author: 'Ernest Hemingway' },
    { name: 'A Tramp Abroad', author: 'Mark Twain' },
    { name: 'The Battle of Life', author: 'Charles Dickens' },
    { name: 'Death in the Afternoon', author: 'Ernest Hemingway' },
    { name: 'Carrie', author: 'Stephen King' },
    { name: 'Hard Times', author: 'Charles Dickens' },
    { name: 'The Black Cat', author: 'Edgar Allan Poe' }
];

var people = [
    { firstName: 'Ivan', lastName: 'Petrov' },
    { firstName: 'Ivan', lastName: 'Todorov' },
    { firstName: 'Pesho', lastName: 'Ivanov' },
    { firstName: 'Ivan', lastName: 'Rumenov' },
    { firstName: 'George', lastName: 'Todorov' },
    { firstName: 'Kalin', lastName: 'Stoyanov' },
    { firstName: 'Ivan', lastName: 'Ivanov' },
    { firstName: 'Miro', lastName: 'Petrov' },
    { firstName: 'George', lastName: 'Ivanov' },
    { firstName: 'Ivan', lastName: 'Mitrov' }
];

printArray(students, 'Students:');
printArray(animals, 'Animals:');
printArray(books, 'Books:');
printArray(people, 'People:');

function printArray(array, name) {
    console.log('');
    console.warn(name);
    _.each(array, function (obj) {
        console.log(JSON.stringify(obj));
    });
}