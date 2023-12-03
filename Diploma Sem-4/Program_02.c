#include <stdio.h>
void main()
{
    int start, end, even = 0, odd = 0;
    printf("Enter the start of the range: ");
    scanf("%d", &start);

    printf("Enter the end of the range: ");
    scanf("%d", &end);
    for (int i = start; i <= end; i++)
    {
        if (i % 2 == 0)
        {
            even = even + 1;
        }
        else
        {
            odd = odd + 1;
        }
    }
    printf("Even = %d and Odd = %d",even,odd);
}