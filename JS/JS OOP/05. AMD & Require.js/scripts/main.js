(function () {
    require.config({
        shim: {
            'libs/handlebars.min': {
                exports: 'Handlebars'
            }
        }
    });

    require(['comboBox'], function (ComboBox) {
        var comboBox = new ComboBox({
            people: [
                {
                    id: 1,
                    name: "Doncho Minkov",
                    age: 18,
                    avatarUrl: "images/doncho.jpg"
                },
                {
                    id: 2,
                    name: "Todor Stoyanov",
                    age: 21,
                    avatarUrl: "images/todor.jpg"
                },
                {
                    id: 3,
                    name: "Ivaylo Kenov",
                    age: 20,
                    avatarUrl: "images/ivo.jpg"
                },
                {
                    id: 4,
                    name: "Nikolay Kostov",
                    age: 21,
                    avatarUrl: "images/niki.jpg"
                }
            ]
        });

        document.body.appendChild(comboBox.render('comboBox'));
    });
}());