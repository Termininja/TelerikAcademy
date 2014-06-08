function queryInOlderBrowsers() {
    Document.prototype.querySelectorForOlderBrowsers = function (q) {
        return document.getElementById(q.substr(1));
    }

    Document.prototype.querySelectorAllForOlderBrowsers = function (q) {
        switch (q[0]) {
            case '#': return document.getElementById(q.substr(1));
            case '.': return document.getElementsByClassName(q.substr(1));
            default: return document.getElementsByTagName(q);
        }
    }

    console.info('document.querySelectorAllForOlderBrowsers("header")');
    console.log(document.querySelectorAllForOlderBrowsers('header'));

    console.info('document.querySelectorForOlderBrowsers("#task4")');
    console.log(document.querySelectorForOlderBrowsers('#task4'));

    console.info('document.querySelectorAllForOlderBrowsers(".center")');
    console.log(document.querySelectorAllForOlderBrowsers('.center'));

    document.getElementById('output4').innerHTML = 'Press F12 and go to Console.';
}