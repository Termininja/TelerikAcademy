//Task 4. You are given a text. Write a function that changes the text in all regions:
//<upcase>text</upcase> to uppercase; <lowcase>text</lowcase> to lowercase; and
//<mixcase>text</mixcase> to mix casing (random); Regions can be nested.

function changeTextCase(str) {
    String.prototype.toMixCase = function () {
        var result = '';
        for (var i = 0; i < this.length; i++) {
            result += (Math.floor(Math.random() * 2) === 1) ?
                this[i].toUpperCase() : this[i].toLowerCase();
        }

        return result
    }

    return str
        .replace(/<upcase>(.*?)<\/upcase>/g, function (_, match) { return match.toUpperCase(); })
        .replace(/<lowcase>(.*?)<\/lowcase>/g, function (_, match) { return match.toLowerCase(); })
        .replace(/<mixcase>(.*?)<\/mixcase>/g, function (_, match) { return match.toMixCase(); });
}