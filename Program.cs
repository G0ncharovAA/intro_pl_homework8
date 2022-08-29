/*
* Урок 8. Как не нужно писать код. Часть 2
*
* Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит
* по убыванию элементы каждой строки двумерного массива.
* Например, задан массив:
*
* 1 4 7 2
* 5 9 2 3
* 8 4 2 4
* 
* В итоге получается вот такой массив:
* 
* 7 4 2 1
* 9 5 3 2
* 8 4 4 2
*
* Решение:
*/

void fillMatrixWithRandomPositiveIntegers(int[,] matrix)
{
    Random rnd = new Random();
    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
    {
        for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
        {
            matrix[rowIndex, columnIndex] = rnd.Next(0, 10);
        }
    }
}

void printMatrixOfIntegersToConsole(int[,] matrix)
{
    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
    {
        Console.Write("\n");
        for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
        {
            Console.Write($"  {matrix[rowIndex, columnIndex]}");
        }
    }
    Console.Write("\n");
}

Console.WriteLine("Введите количество строк матрицы");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов матрицы");
int n = Convert.ToInt32(Console.ReadLine());

if (m < 1 || n < 1)
{
    Console.WriteLine("Некорректные значения");
}
else
{
    int[,] matrix = new int[m, n];
    fillMatrixWithRandomPositiveIntegers(matrix);
    printMatrixOfIntegersToConsole(matrix);

    // insertion sort
    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
    {
        int columnCount = matrix.GetLength(1);
        if (columnCount < 2)
        {
            break;
        }
        if (matrix[rowIndex, 0] < matrix[rowIndex, 1])
        {
            int temp = matrix[rowIndex, 0];
            matrix[rowIndex, 0] = matrix[rowIndex, 1];
            matrix[rowIndex, 1] = temp;
        }
        for (int unsorted = 2; unsorted < columnCount; unsorted++)
        {
            for (int sorted = 0; sorted < unsorted; sorted++)
            {
                if (matrix[rowIndex, unsorted] > matrix[rowIndex, sorted])
                {
                    int temp = matrix[rowIndex, unsorted];
                    matrix[rowIndex, unsorted] = matrix[rowIndex, sorted];
                    matrix[rowIndex, sorted] = temp;
                }
            }
        }
    }
    Console.WriteLine("Матрица отсортированных строк:");
    printMatrixOfIntegersToConsole(matrix);
}

/*
* Задача 56: Задайте прямоугольный двумерный массив. Напишите программу,
* которая будет находить строку с наименьшей суммой элементов.
*
* Например, задан массив:
*
* 1 4 7 2
* 5 9 2 3
* 8 4 2 4
* 5 2 6 7
*
* Программа считает сумму элементов в каждой строке и выдаёт
* номер строки с наименьшей суммой элементов: 1 строка
*
* Решение:
*/

Console.WriteLine("Введите количество строк матрицы");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов матрицы");
int n = Convert.ToInt32(Console.ReadLine());

if (m < 1 || n < 1)
{
    Console.WriteLine("Некорректные значения");
}
else
{
    int[,] matrix = new int[m, n];
    fillMatrixWithRandomPositiveIntegers(matrix);
    printMatrixOfIntegersToConsole(matrix);

    int minSumm = int.MaxValue;
    int minIndex = 0;
    for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
    {
        int summ = 0;
        for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
        {
            summ += matrix[rowIndex, columnIndex];
        }
        if (summ < minSumm)
        {
            minSumm = summ;
            minIndex = rowIndex;
        }
    }
    Console.WriteLine("Номер строки с наименьшей суммой элементов: " + (minIndex + 1));
}

/*
* Задача 58: Задайте две матрицы. Напишите программу, 
* которая будет находить произведение двух матриц.
* 
* Например, даны 2 матрицы:
* 2 4 | 3 4
* 3 2 | 3 3
* Результирующая матрица будет:
* 18 20
* 15 18
*
* Решение:
*/

int[,] multiply(int[,] matrixA, int[,] matrixB)
{

    int rowsA = matrixA.GetLength(0);
    int columnsA = matrixA.GetLength(1);

    int rowsB = matrixB.GetLength(0);
    int columnsB = matrixB.GetLength(1);

    int temp = 0;
    int[,] output = new int[rowsA, columnsB];

    for (int rowAIndex = 0; rowAIndex < rowsA; rowAIndex++)
    {
        for (int columnBIndex = 0; columnBIndex < columnsB; columnBIndex++)
        {
            temp = 0;
            for (int columnAIndex = 0; columnAIndex < columnsA; columnAIndex++)
            {
                temp += matrixA[rowAIndex, columnAIndex] * matrixB[columnAIndex, columnBIndex];
            }
            output[rowAIndex, columnBIndex] = temp;
        }
    }

    return output;
}

Console.WriteLine("Введите количество строк первой матрицы");
int rowsA = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов первой матрицы");
int columnsA = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Введите количество строк второй матрицы");
int rowsB = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов второй матрицы");
int columnsB = Convert.ToInt32(Console.ReadLine());

if (rowsA < 1 || columnsA < 1 || rowsB < 1 || columnsB < 1 || columnsA != rowsB)
{
    Console.WriteLine("Некорректные значения");
}
else
{
    int[,] matrixA = new int[rowsA, columnsA];
    int[,] matrixB = new int[rowsB, columnsB];

    fillMatrixWithRandomPositiveIntegers(matrixA);
    Console.WriteLine("Первая матрица:");
    printMatrixOfIntegersToConsole(matrixA);

    fillMatrixWithRandomPositiveIntegers(matrixB);
    Console.WriteLine("Вторая матрица:");
    printMatrixOfIntegersToConsole(matrixB);

    int[,] output = multiply(matrixA, matrixB);
    Console.WriteLine("Произведение матриц:");
    printMatrixOfIntegersToConsole(output);
}

/*
* Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
* Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
*
* Массив размером 2 x 2 x 2
* 66(0,0,0) 25(0,1,0)
* 34(1,0,0) 41(1,1,0)
* 27(0,0,1) 90(0,1,1)
* 26(1,0,1) 55(1,1,1)
*
* Решение:
*/

// В условиях задачи отсутствует слово "случайных", что существенно упрощает генерацию значений.

Console.WriteLine("Введите x - первую размерность массива");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите y - вторую размерность массива");
int y = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите z - третью размерность массива");
int z = Convert.ToInt32(Console.ReadLine());

if (x < 1 || y < 1 || z < 1 || x * y * z > 180) // Учитываем и отрицательные двузначные числа тоже.
{
    Console.WriteLine("Некорректные значения");
}
else
{
    int[,,] matrix3 = new int[x, y, z];
    int value = 9;
    for (int zIndex = 0; zIndex < z; zIndex++)
    {
        for (int xIndex = 0; xIndex < x; xIndex++)
        {
            Console.Write("\n");
            for (int yIndex = 0; yIndex < y; yIndex++)
            {
                value++;
                if (value > 99)
                {
                    value = -99;
                }
                matrix3[xIndex, yIndex, zIndex] = value;
                Console.Write($"{matrix3[xIndex, yIndex, zIndex]}({xIndex}, {yIndex}, {zIndex}) ");
            }
        }
    }
}

/*
* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
* Например, на выходе получается вот такой массив:
*
* 01 02 03 04
* 12 13 14 05
* 11 16 15 06
* 10 09 08 07
*
* Решение:
*/

int[,] matrix = new int[4, 4];

for (int firstRowIndex = 0; firstRowIndex < 4; firstRowIndex++)
{
    Console.WriteLine($"Введите значение столбца {firstRowIndex + 1} первой строки");
    matrix[0, firstRowIndex] = Convert.ToInt32(Console.ReadLine());
}

for (int lastColumnIndex = 1; lastColumnIndex < 4; lastColumnIndex++)
{
    Console.WriteLine($"Введите значение строки {lastColumnIndex + 1} последнего столбца");
    matrix[lastColumnIndex, 3] = Convert.ToInt32(Console.ReadLine());
}

for (int lastRowIndex = 2; lastRowIndex >= 0; lastRowIndex--)
{
    Console.WriteLine($"Введите значение столбца {lastRowIndex + 1} последней строки");
    matrix[3, lastRowIndex] = Convert.ToInt32(Console.ReadLine());
}

for (int firstColumnIndex = 2; firstColumnIndex > 0; firstColumnIndex--)
{
    Console.WriteLine($"Введите значение строки {firstColumnIndex + 1} первого столбца");
    matrix[firstColumnIndex, 0] = Convert.ToInt32(Console.ReadLine());
}

for (int secondRowIndex = 1; secondRowIndex < 3; secondRowIndex++)
{
    Console.WriteLine($"Введите значение столбца {secondRowIndex + 1} второй строки");
    matrix[1, secondRowIndex] = Convert.ToInt32(Console.ReadLine());
}

for (int thirdRowIndex = 2; thirdRowIndex > 0; thirdRowIndex--)
{
    Console.WriteLine($"Введите значение столбца {thirdRowIndex + 1} третьей строки");
    matrix[2, thirdRowIndex] = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine("В итоге получилась матрица: ");
printMatrixOfIntegersToConsole(matrix);