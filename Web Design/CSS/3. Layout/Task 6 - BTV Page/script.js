window.onload = function () {
    MediaLink(1);
}

function MediaLink(link) {
    var image = document.getElementsByTagName('img');
    switch (link) {
        case 1: image[0].src = "images/image1.jpg"; break;
        case 2: image[0].src = "images/image2.jpg"; break;
        case 3: image[0].src = "images/image3.jpg"; break;
        case 4: image[0].src = "images/image4.jpg"; break;
        case 5: image[0].src = "images/image5.jpg"; break;
        default: break;
    }

    var element = document.getElementsByTagName("li");
    for (var i = 0; i < element.length; i++) {
        var subelement = element[i].getElementsByTagName("a");
        if (i == link - 1) {
            element[i].style.backgroundColor = 'rgb(0, 150, 140)';
            subelement[0].style.color = 'white';
        }
        else {
            element[i].style.backgroundColor = 'transparent';
            subelement[0].style.color = 'rgb(165, 175, 179)';
        }
    }
}