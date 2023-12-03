#include <stdio.h>

void main() {
    int number, reversedNumber = 0, remainder;
    printf("Enter a number: ");
    scanf("%d", &number);
    while (number != 0) {
        remainder = number % 10;
        reversedNumber = reversedNumber * 10 + remainder;
        number /= 10;
    }
    printf("Reversed number: %d\n", reversedNumber);
}
