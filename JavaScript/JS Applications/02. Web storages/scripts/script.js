var array = [1, 2, 3, 4, 5, 6];
var result = _.filter(array, function (n) {
    return n % 2 === 0;
});
console.log(result);