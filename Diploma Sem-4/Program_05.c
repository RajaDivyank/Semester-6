#include <stdio.h>

void printFibonacci(int n)
{
    int a = 0, b = 1, next;
    printf("Fibonacci Series (first %d numbers): ", n);
    for (int i = 0; i < n; i++)
    {
        printf("%d, ", a);
        next = a + b;
        a = b;
        b = next;
    }
}

void main()
{
    int n;
    printf("Enter the number of Fibonacci numbers to print: ");
    scanf("%d", &n);
    if (n <= 0)
    {
        printf("Please enter a positive integer.\n");
    }
    else
    {
        printFibonacci(n);
    }
}
