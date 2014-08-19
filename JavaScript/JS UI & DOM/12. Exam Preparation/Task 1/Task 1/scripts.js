function createImagesPreviewer(selector, items) {
    var selectedName = (items.length > 0) ? items[0].title : '';
    var selectedImage = (items.length > 0) ? items[0].url : '';

    var gallery = document.querySelector(selector);
    gallery.style.margin = 'auto';
    gallery.style.width = '600px';
    gallery.style.height = '410px';
    gallery.style.textAlign = 'center';

    //Create imge screen
    var screen = document.createElement('section');
    screen.style.display = 'inline-block';

    var h1 = document.createElement('h1');
    h1.style.fontSize = '200%';
    h1.innerHTML = selectedName;

    var img = document.createElement('img');
    img.style.borderRadius = '15px';
    img.style.width = '390px';
    img.setAttribute('src', selectedImage);

    screen.appendChild(h1);
    screen.appendChild(img);

    //Create aside bar
    var aside = document.createElement('aside');
    aside.style.width = '180px';
    aside.style.height = '100%';
    aside.style.float = 'right';
    aside.style.overflowY = 'auto';

    var p = document.createElement('p');
    p.style.margin = '0';
    p.innerHTML = 'Filter';

    var input = document.createElement('input');
    input.style.width = '120px';
    input.style.height = '15px';
    input.style.fontSize = '80%';
    input.setAttribute('src', selectedImage);

    aside.appendChild(p);
    aside.appendChild(input);

    //Create thumbs
    var fragment = document.createDocumentFragment();
    var thumbs = [];
    for (var i = 0; i < items.length; i++) {
        var thumb = document.createElement('div');

        var pImgName = document.createElement('p');
        pImgName.style.margin = '0';
        pImgName.innerHTML = items[i].title;

        var img = document.createElement('img');
        img.style.width = '120px';
        img.style.borderRadius = '5px';
        img.setAttribute('src', items[i].url);

        thumb.appendChild(pImgName)
        thumb.appendChild(img)

        thumbs.push(thumb);

        fragment.appendChild(thumb);
    }

    aside.appendChild(fragment);
    gallery.appendChild(screen);
    gallery.appendChild(aside);

    //Mouseover event when hover some image from the aside bar
    aside.addEventListener('mouseover', function (e) {
        if (!e) e = window.event;
        var target = e.target;
        if (!(target instanceof HTMLImageElement)) {
            return;
        }
        target.parentElement.style.background = 'lightgray';
    }, false);

    //Mouseout event when the hover is removed from the image
    aside.addEventListener('mouseout', function (e) {
        if (!e) e = window.event;
        var target = e.target;
        if (!(target instanceof HTMLImageElement)) {
            return;
        }
        target.parentElement.style.background = '';
    }, false);

    //Click event for selecting some image from the aside bar
    aside.addEventListener('click', function (e) {
        if (!e) e = window.event;
        var target = e.target;
        if (!(target instanceof HTMLImageElement)) {
            return;
        }
        screen.lastElementChild.src = target.getAttribute('src');
        h1.innerHTML = target.previousElementSibling.innerHTML;
    }, false);

    //Oninput event for filtering the images
    input.addEventListener('input', function (e) {
        var text = this.value.toLocaleLowerCase();

        for (var i = 0; i < items.length; i++) {
            thumbs[i].style.display =
                (items[i].title.toLocaleLowerCase().indexOf(text) === -1) ?
                'none' : '';
        }
    }, false);
}
