define(['todo-list/section'], function (Section) {
    'use strict';
    var Container;
    Container = (function () {
        function Container() {
            this._sections = [];
        }

        Container.prototype.add = function (section) {
            if (!section) {
                throw new Error('Section is not defined!');
            }

            if (!(section instanceof Section)) {
                throw new Error('This is not instance of Section!');
            }

            this._sections.push(section);
            return this;
        };

        Container.prototype.getData = function () {
            var copiedArray, i, len, section;
            copiedArray = [];
            for (i = 0, len = this._sections.length; i < len; i += 1) {
                section = this._sections[i];
                copiedArray.push(section.getData());
            }

            return copiedArray;
        };

        return Container;
    }());
    return Container;
});