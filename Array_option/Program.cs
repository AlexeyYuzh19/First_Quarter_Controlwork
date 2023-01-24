/*
Задача
Написать программу, которая из имеющегося массива строк формирует массив строк, длина которых меньше либо равна 3 символа.

Примеры:
["hello", "2", "world", ":-)"] -> ["2", ":-)"];
["1234", "1567", "-2", "computer science"] -> ["-2"];
["Russia", "Iran", "Cuba"] -> [].
*/

// Вариант 2 кода - с применением и обработкой массивов

// М Е Т О Д Ы

void Color(int color)
{
    switch (color)
    {
        case 1:
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            break;
        case 2:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            break;
        case 3:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            break;
        case 4:
            Console.ForegroundColor = ConsoleColor.DarkGray;
            break;
        case 5:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            break;
        case 6:
            Console.ForegroundColor = ConsoleColor.Blue;
            break;
        case 7:
            Console.ForegroundColor = ConsoleColor.Black;
            break;
        default:
            Console.ResetColor();
            break;
    }
}

int CheckInputNumber(string Text)
{
    int number;
    string text;

    while (true)
    {
        Color(1);
        Console.Write(Text);
        text = Console.ReadLine();

        if (int.TryParse(text, out number)) break;

        Color(5);
        Console.WriteLine("Заданное значение числа не соответствует критерию, попробуйте еще раз.");
        Color(0);
    }
    Color(0);
    return number;
}

int CheckSize(string text)
{
    int size;
    while (true)
    {
        size = CheckInputNumber(text);

        if (size < 0)
        {
            Color(5);
            Console.WriteLine("Задано отрицательное значение, попробуйте еще раз.");
            Color(0);
        }
        else if (size == 0)
        {
            Color(5);
            Console.WriteLine("Задано нулевое значение, попробуйте еще раз.");
            Color(0);
        }
        else break;
    }

    return size;
}

string[] ArCopy(string[] array, int Length)
{
    string[] Copy = new string[Length];
    for (int i = 0; i < Length; i++)
    {
        Copy[i] = array[i];
    }
    return Copy;
}

string[] EnterArray(string info, string action)
{
    int Len = CheckSize("Задайте предполагаемое количество элементов массива : ");
    Color(1);
    Console.Write(info);
    Color(2);
    Console.WriteLine("< stop >.");
    Color(1);
    Console.WriteLine(action);

    string[] EnArr = new string[Len];
    string text;
    int pos = 0;

    do
    {
        while (true)
        {
            Color(3);
            Console.Write($"элемент {pos + 1}: ");
            text = Console.ReadLine();

            if (text == "stop")
            {
                Color(0);
                break;
            }
            else
            {
                if (string.IsNullOrEmpty(text))
                {
                    Color(5);
                    Console.WriteLine("элемент массива не задан (нажата клавиша <Enter>) - повторите ввод.");
                    Color(0);
                    break;
                }
                if (string.IsNullOrWhiteSpace(text))
                {
                    Color(6);
                    Console.WriteLine("введена пустая строка подтведите ввод нажатием клавиши <Enter>, для отмены нажмите любую клавишу");
                    Color(0);
                    if (Console.ReadKey(true).Key != ConsoleKey.Enter) break;
                }
                EnArr[pos] = text;
                pos++;
                break;
            }
        }
    }
    while (text != "stop" && pos < Len);

    string[] EnArray = ArCopy(EnArr, pos);
    Color(0);
    return EnArray;
}

string[] SortArray(string[] Array)
{
    int count = 1;

    foreach (string res in Array)
    {
        if (res.Length <= 3) count++;
    }

    string[] ResArray = new string[count - 1];
    int index = 0;

    foreach (string res in Array)
    {
        if (res.Length <= 3)
        {
            ResArray[index] = res;
            index++;
        }
    }

    return ResArray;
}

void PrintArray1D(string[] array, string text)
{
    Color(1);
    if (array.Length != 0) Console.WriteLine($"\n {text} сформирован текстовый массив из {array.Length} элементов :\n");
    else Console.WriteLine($"\n {text} массив не сформирован - элементы отсутствуют.\n");

    for (int i = 0; i < array.Length; i++)
    {
        var ar = String.Format("{0,2}", array[i]);
        if (string.IsNullOrWhiteSpace(ar))
        {
            Color(7);
            foreach (char f in ar) Console.Write("_");
        }
        else
        {
            Color(1);
            Console.Write(ar);
        }
        Color(4);
        if (i < array.Length - 1) Console.Write(" | ");
    }
    Color(0);
    Console.WriteLine();
}

// К О Д   

Console.Clear();

string[] Arr = EnterArray("Задайте одномерный массив из строк (набора символов) - для окончании ввода наберите кодовое слово ",
                          "По запросу наберите текст (символы) и подтвердите ввод клавишей <Enter>.");

if (Arr.Length != 0)
{
    PrintArray1D(Arr, "Итого");
    string[] ResArr = SortArray(Arr);
    PrintArray1D(ResArr, "По критерию количество символов в элементе не более трех");
}
else
{
    Color(5);
    Console.WriteLine("Массив не задан.");
    Color(0);
}

Console.WriteLine();

