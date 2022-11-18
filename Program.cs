// Данный файл может послужить стартом для создания библиотеки функций
// Предлагаю здесь детализировать, описывать и хранить наш опыт в создании функций
// Заодно отработаем командную работу с Git 
// Сделайте Fork, создай Clone уже из своего репозитория (именно git clone)
// Создайте ветку с собственным именем и все исправления делайте именно в ней
// Присылайте свои Pull-Requst, при необходимости я обсужу с автором изменения
// И буду обновлять это хранилище
// Давайте покажем настоящий класс!!!

// ===================== СТАРТ ПРОГРАММЫ ========================================

void ProgInit() // Подготовительные процедуры
{
    System.Console.Clear(); // Очищаем экран
    // const int A = 0; // Объявляем константы
}

void Execute() // Основное тело программы - вызываем Execute();
{
    ProgInit();
    // ... остальной текст программы
}

// ==============================================================================

// ===================== ВВОД ДАННЫХ ПОЛЬЗОВАТЕЛЕМ ==============================

int PromptInt(string strDescription) // Ввод целого числа, в параметры функции передается сопроводительный текст strDescription, который выводится на экран перед вводом значения
{
    System.Console.Write(strDescription);
    int intTemp = int.Parse(System.Console.ReadLine());
    return intTemp;
}

(double, double, double) Prompt3DCoords (string strMessage) // Ввод 3-х координат через пробел
{
    System.Console.Write(strMessage);
    string strTemp = System.Console.ReadLine();
    var Coords = strTemp.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    double dblX = Convert.ToDouble(Coords[0]);
    double dblY = Convert.ToDouble(Coords[1]);
    double dblZ = Convert.ToDouble(Coords[2]);
    return (dblX, dblY, dblZ);
}

int[] PromptNumbers(int intN) // Ввод массива по элементу заданой размерности
{
    int[] tempArray = new int[intN];
    for (int i = 0; i<intN; i++)
    {
        System.Console.Write($"Введите {i+1}-ое число: ");
        tempArray[i] = int.Parse(System.Console.ReadLine());
    }
    return tempArray;
}

// ==============================================================================

// ===================== ВЫВОД ДАННЫХ  ==========================================

void printArray(int[] intArray) // Вывод на экран одномерного массива целых чисел
{
    System.Console.Write($"{intArray[0]}");
    for (int i = 1; i < intArray.Length; i++)
    {
        System.Console.Write($", {intArray[i]}");
    }
}

void PrintCountOfEven(int[] intArray) // Подсчет и вывод количества четных чисел в одномерном массиеве, потребуется функция проеврки на четность
{
    int intCouter = 0;
    for (int i = 0; i < intArray.Length; i++)
    {
        if (IsEven(intArray[i])) intCouter++;
    }
    System.Console.Write("В массиве [");
    printArray(intArray: intArray);
    System.Console.Write($"] {intCouter} число(-а,-ел) являются четными.");
}

void PrintSumOfEven(int[] intArray, int intEven) // Считает сумму четных или нечетных элементов массива, вторым параметром передаем позицию четных (0) или нечетных (1)
 {
    int intSum = 0;
    for (int i = intEven; i < intArray.Length; i += 2)
    {
        intSum += intArray[i];
    }
    System.Console.Write("В массиве [");
    printArray(intArray: intArray);
    string tempStr = "четных";
    if (intEven == 1) tempStr = "нечетных";
    System.Console.Write($"] cумма чисел на {tempStr} позициях равна {intSum}.");
}

void printArrayOfDouble(double[] dblArray) // Вывод на экран одномерного массива вещественных чисел
{
    System.Console.Write($"{dblArray[0]}");
    for (int i = 1; i < dblArray.Length; i++)
    {
        System.Console.Write($", {dblArray[i]}");
    }
}

void PrintMinMaxDifferenceArrayOfDouble (double[] dblArray) // Выводить разницу между максимальным и минимальным элементом массива, нужна функция FindMinMaxArrayOfDouble
{
double dblMin = 0;
double dblMax = 0;
(dblMin, dblMax) = FindMinMaxArrayOfDouble(dblArray);
System.Console.Write("Разница между максимальным и минимальным элементом массива [");
printArrayOfDouble(dblArray);
System.Console.WriteLine($"] составляет {((double)((int)((dblMax - dblMin) * 100))) / 100}");
}

void PrintCountOfPositive(int[] intArray) // Вывод количества положительных не нулевых элементов массива
{
    int counter = 0;
    for (int i = 0; i < intArray.Length; i++)
    {
        if (intArray[i] > 0) counter++;
    }
    System.Console.Write("Среди чисел ");
    printArray(intArray);
    System.Console.Write($" - {counter} чисел больше 0");
}

// ==============================================================================

// ===================== ГЕНЕРАЦИЯ ДАННЫХ =======================================

int RandomInt (int intCapacity) // Генерация случайного числа с заданой разрядностью (1 -> 0 .. 9, 2 -> 10 .. 99 и т.д.)
{
    if (intCapacity <= 0)
    {
        System.Console.WriteLine("Разрядность при вызове функции RandomInt указана неверно, ожидается натуральное число (1, 2, 3 ..). Сгенерировано число с разрадностью 1.");
        intCapacity = 1;
    }
    double dblPower = Convert.ToDouble(intCapacity);
    return new Random().Next(Convert.ToInt16(Math.Pow(10.0, dblPower - 1)), Convert.ToInt16(Math.Pow(10.0, dblPower)));
}

int[] CreateArray(int Length, int Min, int Max) // Создаем целочисленный одномерный массив с заданой размерностью и границами генерации случайных чисел
{
    int[] tempArray = new int[Length];
    for (int i = 0; i < Length; i++)
    {
        tempArray[i] = new Random().Next(Min, Max+1);
    }
    return tempArray;
}

double[] CreateArrayOfDouble(int intLength, int intMin, int intMax) // Создаем целочисленный одномерный массив с заданой размерностью и границами генерации случайных вещественных чисел
{
    double[] tempArray = new double[intLength];
    for (int i = 0; i < intLength; i++)
    {
        tempArray[i] = GenerateRandomDouble(intMin, intMax);
    }
    return tempArray;
}

double GenerateRandomDouble(int intMin, int intMax) // Генерирует случайное вещественное число в заданных границах.
{
    double temp = new Random().Next(intMin, intMax+1);
    if (temp > 0) temp -= new Random().NextDouble();
        else temp += new Random().NextDouble();
    temp = ((double)((int)(temp * 100))) / 100; // Округляем
    return temp;
}

// ==============================================================================

// ===================== ДЕЙСТВИЯ НА ПЕРЕМЕННЫМИ ==============================

int TakeLastDigit(int intNumber) // Возвращает остаток деления целого числа на 10, то есть возвращает последнию цифру целого числа
{
    return Math.Abs((intNumber % 10));
}

int ReduceCapacity(int intNumber) // Уменьшает разрядность целого числа на 1, то есть откидывает последнюю цифру целого числа
{
    return (intNumber / 10);
}

int WhatDigitCapacity(int intNumber) // Определение количества разрядов числа
{
    if (intNumber == 0)
    {
        return 0;
    }
    else
    {
        intNumber = Math.Abs(intNumber);
        int count = 0;
        while (intNumber > 0)
        {
            intNumber = ReduceCapacity(intNumber);
            count++;
        }
        return count;
    }
}

int ReverseNumber(int intN) // Разворачиваем число, полный проход по числу
{
    int intTemp = 0;
    while (intN >0)
    {
        intTemp = intTemp * 10 + intN % 10;
        intN = intN / 10;
    }
    return intTemp;
}

int CustomPower(int intBase, int intPower) // Возведение числа в степень
{
    if (intPower == 0) return 1; // Частный случай для степени 0
    if (IsNegative(intPower)) intPower *= -1;
    if (IsEven(intPower))
    {
        int Result = CustomPower(intBase, intPower/2);
        return Result * Result;
    }
    else return intBase * CustomPower(intBase, intPower-1);
}

void SumOfDigits(int intN) // Сумма цифр внутри целого числа
{
    System.Console.Write($"Cумма цифр числа {intN} равна ");
    if (IsNegative(intN)) intN *= -1;
    int result = 0;
    while (intN > 0)
    {
        result += intN % 10;
        intN /= 10;
    }
    System.Console.WriteLine(result);
}

// ==============================================================================

// ===================== ПРОВЕРКА НА СООТВЕТСТВИЕ ===============================

bool IsDigitCapacityRight(int intNumber, int intCapacity) // Проверка количества разрядов. На вход подается число и количество разрядов, которое от него ожидаем. На выход true или false/
// Например, (123, 3) -> true или (8888, 2) -> false
{
    int intTemp = Math.Abs(intNumber);
    if (intCapacity > 0)
    {
        double dblPower = Convert.ToDouble(intCapacity);
        return (intTemp >= Math.Pow(10.0, dblPower - 1) && intTemp < Math.Pow(10.0, dblPower));
    }
    else
    {
        System.Console.WriteLine($"Разрядность при вызову функции isDigitCapacityRight указана неверно, ожидается натуральное число (1, 2, 3 ..), а указано {intCapacity}");
        return false;
    }
}

bool IsDayIsWeekend(int intNumberOfDay) // Проверка номера дня недели (1 .. 7, где 1 - пн, а сб, вс - выходные) на выходной
{
    if (intNumberOfDay < 1 || intNumberOfDay >7)
    {
        System.Console.Write("Введено некорректное значение дня недели.");
        return false;
    }
    else if (intNumberOfDay < 6)
    {
        System.Console.WriteLine("Нет, это рабочий день.");
        return false;
    }
    else
    {
        System.Console.WriteLine("Да! Это выходной!");
        return true;
    }
}

bool ValidateFiveDigit(int intN) // Проверка, что число на входе пятизначное
{
    if (intN / 100000 == 0 && intN / 10000 > 0) return true;
    else return false;
}

bool IsPalindrome(int intN) // Проверка на числа на палиндром, потребуется функция разворота числа
{
    if (intN == ReverseNumber(intN)) return true;
    else return false;
}

bool IsEven(int N) // Проверка числа на четность
{
    if (N % 2 == 0) return true;
    return false;
}

bool IsNegative(int N) // Проверка положительное или отрицательное число
{
    if (N < 0) return true;
    return false;
}

// ==============================================================================

double DistanceBetweenTwo (double X1, double Y1, double Z1, double X2, double Y2, double Z2) // Поиск расстояния между двумя точками в 3Д пространстве
{
    return Math.Sqrt(Math.Pow(X2-X1,2) + Math.Pow(Y2-Y1,2) + Math.Pow(Z2-Z1,2));
}

(double, double) FindMinMaxArrayOfDouble (double[] dblArray) // Возвращает минимальное и максимальное значение в одномерном массиве
{ 
    double dblMin = dblArray[0];
    double dblMax = dblArray[0];
    for (int i = 1; i < dblArray.Length; i++)
    {
        if (dblArray[i]>dblMax) dblMax = dblArray[i];
            else if (dblArray[i]<dblMin) dblMin = dblArray[i];
    }
    return (dblMin, dblMax);
}

void PrintInRecursion(int intN) // Пример вывода через рекурсию для 3 выведет 1 2 2 3 3 3, для 4 - 1 2 2 3 3 3 4 4 4 4
{
    if (intN > 0)
    {   
        int temp = intN - 1;
        PrintInRecursion(temp);
        for (int i = 0; i<intN; i++)
        {
            System.Console.Write($"{intN} ");
        }
    }
}

string Findintersection (int intB1, int intK1, int intB2, int intK2) // Ищет точку пересечения двух прямых y = k1 * x + b1, y = k2 * x + b2
{
    if (intB1==intB2 && intK1==intK2) return "Прямые совпадают, бесконечное число общих точек.";
    if (intK1==intK2) return "Прямые параллельны, нет точек пересечения.";
    double dblX =  Math.Round((double)(intB2 - intB1) / (double)(intK1 - intK2),2);
    double dblY = Math.Round(intK1 * dblX + intB1,2);
    return $"Прямые пересекутся в точке({dblX}, {dblY}).";
}

// ДВУМЕРНЫЕ МАССИВЫ

void PrintArray (int[,] arrNums) // Вывод двумерного массива на экран
{
    for (int i=0; i<arrNums.GetLength(0); i++)
    {
        System.Console.Write($"{arrNums[i, 0]}");
        for (int j=1; j<arrNums.GetLength(1); j++)
        {
            System.Console.Write($" {arrNums[i, j]}");
        }
        System.Console.WriteLine("");    
    }
}

int[,] FillArray(int m, int n) // Заполнение массива по формуле Aₘₙ = m+n
{
    int[,] array = new int[m,n];
    for (int i=0; i<array.GetLength(0); i++)
    {
        for (int j=0; j<array.GetLength(1); j++)
        {
            array[i, j] = i + j;
        }
    }
    return array;   
}

int FindSumOfMax (int[,] arrNums, int rows, int cols) // Обход строк и подсчет суммы максимальных элементов в каждой строке
{
    int intSum = 0;
    System.Console.Write("Сумма максимумов: ");
    for (int i=0; i<rows; i++)
    {
        if (i>0) System.Console.Write("+");
        int temp = FindMaxInRow(arrNums, i, cols);
        System.Console.Write(temp);
        intSum += temp;
    }
    System.Console.WriteLine($"={intSum}");
    return intSum;
}

int FindMaxInRow (int[,] arrNums, int row, int cols) // Поиск максимального в строке
{
    int intMax = arrNums[row, 0];
    for (int j=1; j<cols; j++)
    {
        if (arrNums[row,j]>intMax) intMax = arrNums[row,j];
    }
    return intMax;
}

int FindSumOfMin (int[,] arrNums, int rows, int cols) // Обход столбцов и поиск суммы минимальных элементов каждого столбца
{
    int intSum = 0;
    System.Console.Write("Сумма минимумов: ");
    for (int j=0; j<cols; j++)
    {
        if (j>0) System.Console.Write("+");
        int temp = FindMinInCol(arrNums, rows, j);
        System.Console.Write(temp);
        intSum += temp;
    }
    System.Console.WriteLine($"={intSum}");
    return intSum;
}

int FindMinInCol (int[,] arrNums, int rows, int col) // Поиск минимального в столбце
{
    int intMin = arrNums[0, col];
    for (int i=1; i<rows; i++)
    {
        if (arrNums[i,col]<intMin) intMin = arrNums[i,col];    
    }
    return intMin;    
}