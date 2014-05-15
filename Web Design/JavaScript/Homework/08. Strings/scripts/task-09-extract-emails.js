//Task 9. Write a function for extracting all email addresses from given text.
//All substrings that match the format <identifier>@<host>.<domain> should be
//recognized as emails. Return the emails as array of strings.

function extractEmails(str) {
    return str.match(/\w*\.?\w+@\w+\.\w+/g);
}