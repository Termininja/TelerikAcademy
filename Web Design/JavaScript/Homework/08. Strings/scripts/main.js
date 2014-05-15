var inputText = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
var inputTextRegions = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>ANYthing</lowcase> else.";
var inputHtmlText = "<html><head><title>Sample site </title></head><body><div>text <div>more text</div> and more...</div> in body</body></html>";
var inputHtmlLinkText = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
var inputUrlText = "http://www.devbg.org/forum/index.php";
var inputEmailText = "Pesho's email is pesho88@abv.bg and Ivan's email is ivan.ivanov@yahoo.com. Mimi has mimi_z@gmail.com email.";
var inputPalindromeText = "My mom love ABBA. Ivan is on level 8.";
var inputPlaceholderText = "This is string with placeholders: '{0}' '{1}' and {0} {1} {2} {3} and {8}-{7}-{6}";

window.onload = function () {
    document.getElementById('input31').value = inputText;
    document.getElementById('input4').value = inputTextRegions;
    document.getElementById('input5').value = inputText;
    document.getElementById('input6').value = inputHtmlText;
    document.getElementById('input7').value = inputUrlText;
    document.getElementById('input8').value = inputHtmlLinkText;
    document.getElementById('input9').value = inputEmailText;
    document.getElementById('input10').value = inputPalindromeText;
    document.getElementById('input11').value = inputPlaceholderText;
    document.getElementById('input12').value =
        document.getElementById("list-item").innerHTML;

    loadTask1();
    loadTask2();
    loadTask3();
    loadTask4();
    loadTask5();
    loadTask6();
    loadTask7();
    loadTask8();
    loadTask9();
    loadTask10();
    loadTask11();
    loadTask12();
}

function loadTask1() {
    var input = document.getElementById('input1').value;
    document.getElementById('result1').innerHTML =
       (input == "") ? '' : ('Reversed string: ' + reverseString(input));
}

function loadTask2() {
    var input = document.getElementById('input2').value;
    document.getElementById('result2').innerHTML =
       (input == "") ? '' : (checkBrackets(input) ?
       'The brackets are put correctly!' :
       'The brackets are not put correctly!');
}

function loadTask3() {
    var text = document.getElementById('input31').value;
    var word = document.getElementById('input32').value;
    document.getElementById('result3').innerHTML =
       (text == '' || word == '') ? '' :
       (searchForSubstring(text, word) + ' times');
}

function loadTask4() {
    var text = document.getElementById('input4').value;
    document.getElementById('result4').innerHTML =
       (text == '') ? '' : changeTextCase(text);
}

function loadTask5() {
    var text = document.getElementById('input5').value;
    document.getElementById('result5').innerHTML =
       (text == '') ? '' : replaceWhiteSpaces(text);
}

function loadTask6() {
    var text = document.getElementById('input6').value;
    document.getElementById('result6').innerHTML =
        (text == '') ? '' : htmlToText(text);
}

function loadTask7() {
    var text = document.getElementById('input7').value;
    var value = parseURL(text);

    document.getElementById('result7').innerHTML = (text == '') ?
        '' : ('protocol: ' + value.protocol + '<br />server: ' +
        value.server + '<br />resource: ' + value.resource);
}

function loadTask8() {
    var text = document.getElementById('input8').value;
    document.getElementById('result8').innerHTML =
        (text == '') ? '' : replaceHTMLTags(text);
}

function loadTask9() {
    var text = document.getElementById('input9').value;
    var result = document.getElementById('result9');
    result.innerHTML = '';
    if (text != '') {
        extractEmails(text).forEach(function (email) {
            result.innerHTML += email + '<br />';
        });
    }
}

function loadTask10() {
    var text = document.getElementById('input10').value;
    document.getElementById('result10').innerHTML =
        (text == '') ? '' : ('Palindromes: ' + extractPalindromes(text));
}

function loadTask11() {
    var ph0 = document.getElementById('ph0').value;
    var ph1 = document.getElementById('ph1').value;
    var ph2 = document.getElementById('ph2').value;
    var ph3 = document.getElementById('ph3').value;
    var ph4 = document.getElementById('ph4').value;
    var ph5 = document.getElementById('ph5').value;
    var ph6 = document.getElementById('ph6').value;
    var ph7 = document.getElementById('ph7').value;
    var ph8 = document.getElementById('ph8').value;

    document.getElementById('result11').innerHTML =
        stringFormat(document.getElementById('input11').value,
        ph0, ph1, ph2, ph3, ph4, ph5, ph6, ph7, ph8);
}

function loadTask12() {
    var name1 = document.getElementById('name1').value;
    var age1 = document.getElementById('age1').value;
    var name2 = document.getElementById('name2').value;
    var age2 = document.getElementById('age2').value;
    var name3 = document.getElementById('name3').value;
    var age3 = document.getElementById('age3').value;
    var name4 = document.getElementById('name4').value;
    var age4 = document.getElementById('age4').value;
    var name5 = document.getElementById('name5').value;
    var age5 = document.getElementById('age5').value;
    var name6 = document.getElementById('name6').value;
    var age6 = document.getElementById('age6').value;

    var people = [
        { name: name1, age: age1 },
        { name: name2, age: age2 },
        { name: name3, age: age3 },
        { name: name4, age: age4 },
        { name: name5, age: age5 },
        { name: name6, age: age6 }
    ];

    var template = document.getElementById('input12').value;
    var peopleList = generateList(people, template);

    document.getElementById('result121').innerHTML =
        (checkPerson(people, false)) ? peopleList : '';

    document.getElementById('result122').innerHTML = checkPerson(people, true) ?
            '<span class="red">Press F12 and go to "Console" to check HTML UL in plain text</span>' : '';

    console.clear();
    console.info(peopleList);

    function checkPerson(object, all) {
        for (var i in object) {
            if ((all && (people[i].name == '' || people[i].age == '')) ||
                (!all && (people[i].name != '' && people[i].age != ''))) {
                return !all;
            }
        }

        return all;
    }
}