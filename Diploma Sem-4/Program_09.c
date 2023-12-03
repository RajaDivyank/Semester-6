#include <stdio.h>

void printArray(int arr[], int size) {
    for (int i = 0; i < size; i++) {
        printf("%d ", arr[i]);
    }
    printf("\n");
}

void main() {

    int myArray[6] = {1, 2, 3, 4, 5};

    int size = 6;
    int index = 2;
    int number = 10;

    printf("Original array: ");
    printArray(myArray, size);

    for (int i = size - 1; i > index; i--) {
        myArray[i] = myArray[i - 1];
    }

    myArray[index] = number;

    printf("Array after insertion: ");
    printArray(myArray, size);
}
