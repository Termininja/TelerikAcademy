define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store
    Store = (function () {
        function Store(name) {
            if (name.length < 6 || name.length > 30) {
                throw new Error('The store name has to be between 6 and 30-characters-long!');
            }
            else {
                this._name = name;
            }

            this._items = [];
        }

        Store.prototype.addItem = function (item) {
            if (!item) {
                throw new Error('The item is not defined!');
            }
            else if (!(item instanceof Item)) {
                throw new Error('The input is not instance of Item!');
            }

            this._items.push(item);
            return this;
        }

        Store.prototype.getAll = function () {
            var sortedItems = SortLexicographically(this._items);

            return sortedItems;
        }

        Store.prototype.getSmartPhones = function () {
            return FilterBy(this._items, '_type', 'smart-phone');
        }

        Store.prototype.getMobiles = function () {
            return FilterBy(this._items, '_type', 'smart-phone', 'tablet');
        }

        Store.prototype.getComputers = function () {
            return FilterBy(this._items, '_type', 'pc', 'notebook');
        }

        Store.prototype.filterItemsByType = function (type) {
            return FilterBy(this._items, '_type', type);
        }

        Store.prototype.filterItemsByPrice = function (options) {
            var min = (options) ?
                ((options.min) ? options.min : 0) : 0;
            var max = (options) ?
                ((options.max) ? options.max : Number.MAX_VALUE) : Number.MAX_VALUE;

            var newItems = this._items.filter(function (item) {
                if (item._price >= min && item._price <= max) {
                    return item;
                }
            });

            var sortedItems = newItems.sort(function (first, second) {
                return first._price - second._price;
            });

            return sortedItems;
        }

        Store.prototype.filterItemsByName = function (partOfName) {
            var newItems = this._items.filter(function (item) {
                if (item._name.toLowerCase().indexOf(partOfName.toLowerCase()) >= 0) {
                    return item;
                }
            });

            var sortedItems = SortLexicographically(newItems);

            return sortedItems;
        }

        Store.prototype.countItemsByType = function () {
            var newItems = this._items;
            var result = {};

            for (var i = 0; i < newItems.length; ++i) {
                var type = newItems[i]._type;
                result[type] = (result[type] == undefined) ? 1 : result[type] + 1;
            }

            return result;
        }

        function SortLexicographically(array) {
            var newArray = array;
            newArray.sort(function (first, second) {
                return (first._name).localeCompare(second._name);
            });

            return newArray;
        }

        function FilterBy(array, property, option1, option2) {
            var newArray = array.filter(function (item) {
                if (item[property] === option1 || item[property] === option2) {
                    return item;
                }
            });

            var sortedArray = SortLexicographically(newArray);

            return sortedArray;
        }

        return Store;
    }());

    return Store;
});