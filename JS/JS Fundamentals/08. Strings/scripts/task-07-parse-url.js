//Task 7. Write a script that parses an URL address given in the format:
//[protocol]://[server]/[resource] and extracts from it the [protocol],
//[server] and [resource] elements. Return the elements in a JSON object.

function parseURL(url) {
    return {
        protocol: url.substring(0, url.indexOf(':')),
        server: url.substring(url.indexOf('//') + 2, url.search(/\w\//) + 1),
        resource: url.substr(url.search(/\w\//) + 1)
    };
}