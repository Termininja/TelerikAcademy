//Task 1. Write functions for working with shapes in standard Planar coordinate
//system. Points are represented by coordinates P(X,Y). Lines are represented by
//two points, marking their beginning and ending L(P1(X1,Y1),P2(X2,Y2)). Calculate
//the distance between two points. Check if three segment lines can form a triangle.

//Class for points
function Point(x, y) {
    this.x = x;
    this.y = y;
}

//Get the distance between two points
function getDistance(p1, p2) {
    return Math.sqrt(Math.pow(p1.x - p2.x, 2) + Math.pow(p1.y - p2.y, 2));
}

//Class for lines
function Line(point1, point2) {
    this.point1 = point1;
    this.point2 = point2;
}

//Checks if three segment lines can form a triangle
function checkForTriangle(s1, s2, s3) {
    return s1 + s2 > s3 && s2 + s3 > s1 && s1 + s3 > s2;
}