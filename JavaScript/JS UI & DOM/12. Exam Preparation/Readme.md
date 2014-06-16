## Exam Preparation

####Task 1. Web Control with Vanilla JavaScript
Create a calendar using pure (vanilla) JavaScript.
   * Given the HTML file (***index.html***) create a JavaScript function called createCalendar(selector, events)
      * selector is a string object that contains a DOM selector ('***.class***', '***#id***', '***#parent .item***')
      * Events is an array of objects, following the structure:
   * Events should be added into the 'day box' for the day in the event.day property

```js
var events = [{
	title: 'JavaScript UI & DOM exam", 	//a regular string
	date: 17, 							//a number between 1 and 30 inclusive
	time: '10:00', 						//a string in the format "HH:MM"
	duration: 360  						//a positive number less than 1440 (24 hours * 60 minutes)
}, {
	…
}];
```

   * The createCalendar() function should add the calendar into the control given as selector
   * As a result you should produce the following HTML

![img](https://raw.githubusercontent.com/Termininja/TelerikAcademy/master/JavaScript/JS%20UI%20&%20DOM/12.%20Exam%20Preparation/Task%201.%20Vanilla%20JavaScript/calendar.png)

   * Constraints:
      * ***No CSS allowed***, all the styles should be applied with JavaScript
      * The calendar is always for ***June 2014***
      * There will be no more than a ***single event for a date***

   * The calendar should support the following functionality:
      * Hover on a day changes the background of the title
      * Click on a day changes the color of the whole day element
         * Only one element can be selected at once
   * Example:

![img](https://raw.githubusercontent.com/Termininja/TelerikAcademy/master/JavaScript/JS%20UI%20&%20DOM/12.%20Exam%20Preparation/Task%201.%20Vanilla%20JavaScript/example.png)
	  
####Task 2. jQuery Plugin
Create a tabs control using jQuery and wrap it into a plugin.
   * Your are given HTML code in the index.html file
      * And a CSS file, that you must use
   * Using your plugin, transform the HTML into a tabs control like the following:
![img](https://raw.githubusercontent.com/Termininja/TelerikAcademy/master/JavaScript/JS%20UI%20&%20DOM/12.%20Exam%20Preparation/Task%202.%20jQuery%20Plugin/task2.png)

####Task 3. Handlebars Templates
Given the HTML (***index.html***), CSS (***styles.css***) and JavaScript (***scripts.js***) build a template that produces the HTML in ***result.html***.
   * You should only fill the templates in the elements with ids `'books-list-template'` and `'book-details-template'`.