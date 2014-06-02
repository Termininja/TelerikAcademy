//Task 3. Refactor the following examples to produce code with well-named identifiers in JavaScript

function checkBrowserName() {
    var currentWindow = window;
    var currentBrowser = currentWindow.navigator.appCodeName;
    var browserIsMozilla = currentBrowser === "Mozilla";

    alert((browserIsMozilla) ? "Yes" : "No");
}