#include <stdio.h>

int factorial(int n)
{
    if (n == 0 || n == 1)
    {
        return 1;
    }
    else
    {
        return n * factorial(n - 1);
    }
}

void main()
{
    int number, result = 1;
    printf("Enter a non-negative integer: ");
    scanf("%d", &number);
    if (number < 0)
    {
        printf("Factorial is not defined for negative numbers.\n");
    }
    else
    {
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        printf("Factorial of %d is : %d", number, result);
        // printf("Factorial of %d is: %d\n", number, factorial(number));
    }
}
