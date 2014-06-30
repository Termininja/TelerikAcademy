$(document).ready(function () {
    var domModule = (function () {
        var buffer = [];

        //Add DOM element to parent element given by selector
        function appendChild(element, parentSelector) {
            $(parentSelector).append(element);
        }

        //Remove element from the DOM by given selector
        function removeChild(parentSelector, childSelector) {
            $(childSelector).remove()
        }

        //Attach event to given selector by given event type and event handler
        function addHandler(elementSelector, eventType, eventHandler) {
            $elements = $(elementSelector);
            for (var i = 0; i < $elements.length; i++) {
                $($elements[i]).on(eventType, eventHandler);
            }
        }

        //Add elements to buffer, which appends them to the DOM
        //when their count for some selector becomes 100
        function appendToBuffer(parentSelector, element) {
            if (!buffer[parentSelector]) {
                buffer[parentSelector] = [];
            }

            buffer[parentSelector].push(element);
            if (buffer[parentSelector].length == 100) {
                var parent = document.querySelector(parentSelector);
                for (var i = 0; i < buffer[parentSelector].length; i++) {
                    parent.appendChild(buffer[parentSelector][i]);
                }
                buffer[parentSelector] = [];
            }
        }

        //The module
        return {
            appendChild: appendChild,
            removeChild: removeChild,
            addHandler: addHandler,
            appendToBuffer: appendToBuffer
        };
    })();

    var div = document.getElementById('list');

    //Appends div to #wrapper
    domModule.appendChild(div, "#wrapper");

    //Removes li:first-child from ul
    domModule.removeChild("ul", "li:first-child");

    //Add handler to each a element with class button
    domModule.addHandler("a.button", 'click', function () { alert("Clicked") });

    //Add 100 cloned divs to the wrapper
    for (var i = 0; i < 100; i++) {
        domModule.appendToBuffer('#wrapper', div.cloneNode(true));
    }
});