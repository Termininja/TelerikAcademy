define(function () {
    'use strict';
    var Item
    Item = (function () {
        function Item(type, name, price) {
            if (!isCorrectType(type)) {
                throw new Error('The type of the item is not correct!');
            }
            else if (name.length < 6 || name.length > 40) {
                throw new Error('The item name has to be between 6 and 40-characters-long!');
            }
            else if (!isFloat(price)) {
                throw new Error('The price for the item is not decimal floating-point number!');
            }

            this._type = type;
            this._name = name;
            this._price = price;
        }

        function isCorrectType(type) {
            var types = {
                Accessory: 'accessory',
                SmartPhone: 'smart-phone',
                Notebook: 'notebook',
                PC: 'pc',
                Tablet: 'tablet'
            };
            var isCorect = false;
            for (var i in types) {
                if (types[i] === type) {
                    isCorect = true;
                    break;
                }
            }

            return isCorect;
        }

        function isFloat(number) {
            return number === +number && number !== (number | 0);
        }

        return Item;
    }());

    return Item;
});