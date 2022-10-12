using MyLibrary;

Console.WriteLine(@"Введите номер задачи:
1 - задача54;
2 - задача56;
3 - задача58;
4 - дополнительная задача1;
5 - дополнительная задача2");
string answer = Console.ReadLine();
switch(answer){
    case "1": Task54(); break;
    case "2": Task56(); break;
    case "3": Task58(); break;
    case "4": starTask(); break;
    case "5": doubleStarTask(); break;
    default: Console.WriteLine("Вы ввели неверное значение."); break;
} 
/*Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы
 каждой строки двумерного массива.
*/
void Task54(){
    int[,] array = Library.FillIntArray(1, 10);
    Console.WriteLine("До");
    Library.PrintArray(array);
    Console.WriteLine();
    
    for (int i = 0; i < array.GetLength(0); i++){
        int counter = 0;
            while (counter != array.GetLength(1))
            {
                for (int j = 0; j < array.GetLength(1) - 1 - counter; j++)
                {
                    if (array[i,j] < array[i, j + 1])
                    {
                        int temp = array[i, j + 1];
                        array[i, j + 1] = array[i, j];
                        array[i, j] = temp;
                    }
                }
                counter++;
            }
    }
    Console.WriteLine("После");
    Library.PrintArray(array);
}

/*Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
*/
void Task56(){
    int[,] array = Library.FillIntArray(1, 5);
    Library.PrintArray(array);
    int minSum = 0;
    int numberRow = 0;
    for (int i = 0; i < array.GetLength(0); i++){
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++){
            sum+=array[i,j];
        }
        if (i == 0) minSum = sum;
        else if (minSum > sum)
        {
            minSum = sum;
            numberRow = i;
        }
    }
    Console.WriteLine($"Наименьшая сумма элементов находится в строке номер {numberRow}");
}

/*Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
*/
void Task58(){
    int[,] matrix1 = Library.FillIntArray(1, 10);
    int[,] matrix2 = Library.FillIntArray(1, 10);
    if(matrix1.GetLength(1) != matrix2.GetLength(0)){
        Console.WriteLine("Матрицы не согласованы, их переумножение невозможно.");  
        return;
    }
    int[,] multiMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    int element = 0;
    int k = 0;
    for (int i = 0; i < matrix2.GetLength(1); i++)
    {
        for (int j = 0; j < matrix1.GetLength(0); j++)
        {
            while (k != matrix1.GetLength(1))
            {
                element += matrix1[j, k] * matrix2[k, i];
                k++;
            }
            multiMatrix[j, i] = element;
            k = 0;
            element = 0;
        }
    }  
    Console.WriteLine("Первая матрица:");   
    Library.PrintArray(matrix1); 
    Console.WriteLine("Вторая матрица:");    
    Library.PrintArray(matrix2); 
    Console.WriteLine("Произведение матриц равно:");
    Library.PrintArray(multiMatrix);
}

/*Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.*/
void starTask(){
    Console.WriteLine("Введите количество строк в массиве.");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите количество столбцов в массиве.");
    int columns = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите количество слоев в массиве.");
    int layers = Convert.ToInt32(Console.ReadLine());
    if (rows * columns * layers > 90){
        Console.WriteLine("Превышено количество неповторяющихся двузначных чисел");
        return;
    } 
    int[] contentArray = new int[rows * columns * layers];
    int index = 0;
    int element = new Random().Next(10, 100);
    int[,,] threeDimArray = new int[rows, columns, layers]; 
    for (int l = 0; l < threeDimArray.GetLength(2); l++){
        for (int r = 0; r < threeDimArray.GetLength(0); r++){
            for (int c = 0; c < threeDimArray.GetLength(1); c++){
                while(FindElement(contentArray, element, index)){
                    element = new Random().Next(10, 100);
                }
                contentArray[index++] = element;
                threeDimArray[r, c, l] = element;
                Console.Write($"{element}({r}, {c}, {l}) ");
            }
            Console.WriteLine();
        }
    }

    bool FindElement(int[] array, int element, int size){
        for (int i = 0; i <= size; i++){
            if (array[i] == element) return true;
        }
        return false;
    }
}

//Напишите программу, которая заполнит спирально массив.
void doubleStarTask(){
    Console.WriteLine("Введите размер квадратного массива");
    int size = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[size,size];
    int startRow = 0;
    int startCol = 0;
    int endRow = array.GetLength(0) - 1;
    int endCol = array.GetLength(1) - 1;
    int number = 0;
    while(startRow != endRow && startRow < endRow){
        for (int i = startCol; i < endCol; i++)
        {
            array[startRow, i] = ++number;
        }    
        for (int j = startRow; j < endRow; j++)
        {
            array[j, endCol] = ++number;
        }
        for (int i = endCol; i > startCol; i--)
        {
            array[endRow, i] = ++number;
        }
        for (int j = endRow; j > startRow; j--)
        {
            array[j, startCol] = ++number;
        }
        startRow++;
        startCol++;
        endRow--;
        endCol--;
    } 
    if (startRow == endRow) array[startRow, startCol] = ++number;
    Library.PrintArray(array);  
}
