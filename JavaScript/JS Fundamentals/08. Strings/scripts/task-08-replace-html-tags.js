//Task 8. Write a function that replaces in a HTML document given as string all the tags
//<a href="...">...</a> with corresponding tags [URL=...]...[/URL].

function replaceHTMLTags(str) {
    return str.replace(/<a href="(.*?)">(.*?)<\/a>/g, '[URL=$1]$2[/URL]')
}