function createCalendar(selector, events) {
    var calendar = document.querySelector(selector);
    calendar.style.width = '900px';

    var boxes = [];
    var fragment = document.createDocumentFragment();

    var dayBox = document.createElement('div');
    dayBox.style.width = '120px';
    dayBox.style.height = '120px';
    dayBox.style.display = 'inline-block';
    dayBox.style.border = '1px solid black';
    dayBox.style.margin = '0px';

    var dayTitle = document.createElement('div');
    dayTitle.style.textAlign = 'center';
    dayTitle.style.color = 'white';
    dayTitle.style.fontSize = '14px';
    dayTitle.style.borderBottom = '1px solid black';
    dayTitle.style.background = 'lightgray';

    var dayContent = document.createElement('div');
    dayContent.innerHTML = '&nbsp;';

    dayBox.appendChild(dayTitle);
    dayBox.appendChild(dayContent);

    for (var i = 1; i <= 30; i++) {
        dayTitle.innerHTML = new Date(2014, 5, i).toString().substr(0, 3) + " " + i + " June 2014";
        var box = dayBox.cloneNode(true)
        fragment.appendChild(box);
        boxes.push(box);

        box.addEventListener('mouseover', function (e) {
            this.style.cursor = 'pointer';
            for (var j = 0; j < boxes.length; j++) {
                if (!hasClass(boxes[j], 'clicked') && !hasClass(this, 'clicked')) {
                    this.style.background = 'lightgray';
                }
            }
        });
        box.addEventListener('mouseout', function (e) {
            for (var j = 0; j < boxes.length; j++) {
                if (!hasClass(boxes[j], 'clicked')) {
                    boxes[j].style.background = 'white';
                }
            }
        });
        box.addEventListener('click', function (e) {
            for (var j = 0; j < boxes.length; j++) {
                if (hasClass(boxes[j], 'clicked')) {
                    boxes[j].classList.remove('clicked');
                    boxes[j].style.background = 'white';
                }
            }

            this.classList.add('clicked');
            this.style.background = 'gray';
        });
    }

    calendar.appendChild(fragment);

    for (var e = 0; e < events.length; e++) {
        boxes[events[e].date - 1].lastElementChild.innerHTML = events[e].hour + " " + events[e].title;
    }

    function hasClass(element, theClass) {
        var result = (' ' + element.className + ' ').indexOf(' ' + theClass + ' ') !== -1;

        return result;
    }
}