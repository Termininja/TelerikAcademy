var familyMembers = [
       { mother: 'Maria Petrova', father: 'Georgi Petrov', children: ['Teodora Petrova', 'Peter Petrov'] },
       { mother: 'Petra Stamatova', father: 'Todor Stamatov', children: ['Maria Petrova'] },
       //...
];

window.onload = function Draw() {
    
        var stage = new Kinetic.Stage({
            container: 'kinetic',
            width: 1024,
            height: 1024
        });
        var layer = new Kinetic.Layer();
        var depth = 0;
        for (var i = 0; i < familyAll.length; i++) {
            depth += i + 50;
            var dotLabel = new Kinetic.Text({
                x: 50,
                y: depth,
                text: familyAll[i],
                stroke: 'green',
                fontSize: 20
            });
            var rect = new Kinetic.Rect({
                x: 30,
                y: depth - 10,
                width: dotLabel.getWidth() + 20,
                height: dotLabel.getHeight() + 20,
                stroke: 'green'
            });
            layer.add(dotLabel);
            layer.add(rect);
        }
        stage.add(layer);
    }
}