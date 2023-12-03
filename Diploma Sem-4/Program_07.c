#include <stdio.h>
#include <stdbool.h>

bool isPrime(int num) {
    if (num <= 1) {
        return false;
    }

    for (int i = 2; i <= num/2; i++) {
        if (num % i == 0) {
            return false; 
        }
    }

    return true;
}

void main() {
    int number;
    printf("Enter a number: ");
    scanf("%d", &number);
    if (isPrime(number)) {
        printf("%d is a prime number.\n", number);
    } else {
        printf("%d is not a prime number.\n", number);
    }
}
