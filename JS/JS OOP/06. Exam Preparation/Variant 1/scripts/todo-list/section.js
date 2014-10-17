define(['todo-list/item'], function (Item) {
    'use strict';
    var Section;
    Section = (function () {
        function Section(title) {
            this._items = [];
            this._title = title;
        }

        Section.prototype.add = function (item) {
            if (!item) {
                throw new Error('Item is not defined!');
            }

            if (!(item instanceof Item)) {
                throw new Error('This is not instance of Item!');
            }

            this._items.push(item);
            return this;
        };

        Section.prototype.getData = function () {
            var copiedArray, i, len, item;
            copiedArray = [];
            for (i = 0, len = this._items.length; i < len; i += 1) {
                item = this._items[i];
                copiedArray.push(item.getData());
            }

            return {
                title: this._title,
                items: copiedArray
            };
        };

        return Section;
    }());
    return Section;
});