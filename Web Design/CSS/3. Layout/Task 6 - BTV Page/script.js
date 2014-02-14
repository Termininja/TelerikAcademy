window.onload = function () {
    MediaLink(1);
}

function MediaLink(link) {
    var image = document.getElementById('image');
    switch (link) {
        case 1: image.src = "images/image1.jpg"; break;
        case 2: image.src = "images/image2.jpg"; break;
        case 3: image.src = "images/image3.jpg"; break;
        case 4: image.src = "images/image4.jpg"; break;
        case 5: image.src = "images/image5.jpg"; break;
        default: break;
    }

    var element = document.getElementsByTagName("LI");
    for (var i = 0; i < element.length; i++) {
        var subelement = element[i].getElementsByTagName("A");
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