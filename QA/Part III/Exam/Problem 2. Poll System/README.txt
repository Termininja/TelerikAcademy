1. XSS

JS injection on http://localhost:62334/CreateNewPoll.aspx
Not escaped on http://localhost:62334/Polls.aspx

2. SQL injection

Create 1000000 fake votes for "Rakiya"
'; UPDATE PollAnswers SET Votes=1000000 WHERE Answer='Rakiya' --

3. URL Manipulation

Without login go to http://localhost:62334/CreateNewPoll.aspx and create new poll