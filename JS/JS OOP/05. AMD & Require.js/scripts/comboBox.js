define(['libs/handlebars.min'], function (Handlebars) {
    'use strict';
    var selectedItem = 1;

    var ComboBox = function (data) {
        this.data = data;
    };

    var event = function (container, id) {
        var items = container.getElementsByClassName('person');

        for (var i = 0; i < items.length; i++) {
            if (i === 0) {
                selectedItem = items[i];
                items[i].style.display = 'block';
            }
            else items[i].style.display = 'none';

            items[i].addEventListener('click', function () {
                if (selectedItem === this) {
                    selectedItem = null;
                    for (var i = 0; i < items.length; i++) {
                        items[i].style.display = 'block';
                    }
                }
                else if (selectedItem === null) {
                    selectedItem = this;
                    for (var i = 0; i < items.length; i++) {
                        if (items[i] === selectedItem) continue;
                        items[i].style.display = 'none';
                    }
                }
            });
        }
    };

    ComboBox.prototype.render = function (id) {
        var template = Handlebars.compile(document.getElementById(id).innerHTML);
        var container = document.createElement('div');
        container.innerHTML = template(this.data);
        event(container, this.id);

        return container;
    };

    return ComboBox;
});