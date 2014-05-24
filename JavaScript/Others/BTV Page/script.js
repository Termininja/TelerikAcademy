// The current page
var selectedPage = 2;

// Executed when page is loaded 
window.onload = function () {
    DisplayPage('1');
}

// Page Navigator
function DisplayPage(page) {
    selectedPage = page;
    var pages = document.getElementsByTagName('aside');
    for (var i = 1; i <= pages.length; i++) {

        // Tab styles in navigation bar
        var isSelected = i == page;
        var navElement = document.getElementById('nav' + i);
        navElement.style.background = isSelected ? 'transparent' : 'rgb(75, 95, 103)';
        navElement.style.color = isSelected ? 'white' : 'rgb(147, 172, 182)';
        navElement.style.cursor = isSelected ? 'default' : 'pointer';
        if (isSelected) navElement.style.textDecoration = 'none';

        // Display selected page and hide all others
        pages[i - 1].style.visibility =
            (pages[i - 1].id.substring(pages.length - 2) == page) ? 'visible' : 'hidden';
    }

    // The first link of the current page will be selected
    MediaLink(5 * selectedPage - 4);
}

// On mouse over functionality for navigation bar
function OnMouseOver(nav, action) {
    if (selectedPage != nav) {
        var element = document.getElementById('nav' + nav);
        element.style.textDecoration = action ? 'underline' : 'none';
    }
}

// Link functionality for each page
function MediaLink(n) {

    // Image of the link
    var images = document.getElementsByTagName('img');
    images[0].src = 'images/image' + n + '.jpg';

    // Link styles in navigation menu
    var element = document.getElementsByTagName("li");
    var lastLinkNumber = 5 * selectedPage;
    for (var i = lastLinkNumber - 4; i <= 5 * selectedPage; i++) {
        var subelement = element[i - 1].getElementsByTagName("a");
        subelement[0].style.color = (i == n) ? 'white' : 'rgb(165, 175, 179)';
        element[i - 1].style.backgroundColor = (i == n) ? 'rgb(0, 150, 140)' : 'transparent';
    }
}
