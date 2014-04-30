function Task7(input) {
    var number = parseInt(input);

    if (isInt(number)) {
        if (number >= 0) {
            var isPrime = true;

            // Looks for all prime numbers
            if (number > 1) {
                for (var n = 2; n < number; n++) {
                    isPrime = number % n !== 0;
                    if (!isPrime) break;
                }
            }
            else isPrime = false;

            // Prints the result
            display.value += "The number " + number + (isPrime ? " is" : " is not") + " prime!\n\n";
        }
        else display.value += "The number is not positive!\n\n";
    }
    else display.value += "This is not a number!\n\n";
}