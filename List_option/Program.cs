/*
Задача
Написать программу, которая из имеющегося массива строк формирует массив строк, длина которых меньше либо равна 3 символа.

Примеры:
["hello", "2", "world", ":-)"] -> ["2", ":-)"];
["1234", "1567", "-2", "computer science"] -> ["-2"];
["Russia", "Iran", "Cuba"] -> [].
*/

// Вариант 1 кода - с применением коллекции - Список List<T>

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

List<string> EnterArray(string info, string action)
{
    Color(1);
    Console.Write(info);
    Color(2);
    Console.WriteLine("< stop >.");
    Color(1);
    Console.WriteLine(action);

    List<string> enArray = new List<string>();
    string text;
    int pos = 1;

    do
    {
        while (true)
        {
            Color(3);
            Console.Write($"элемент {pos}: ");
            text = Convert.ToString(Console.ReadLine());

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
                    Console.WriteLine("элемент массива не задан (нажата клавиша <Enter>) - повторите ввод");
                    Color(0);
                    break;
                }
                if (string.IsNullOrWhiteSpace(text))
                {
                    Color(6);
                    Console.WriteLine("введена пустая строка подтведите ввод нажатием клавиши <Enter>, для отмены нажмите любую клавишу");
                    Color(0);
                    if (Console.ReadKey(true).Key != ConsoleKey.Enter) break;
                    if (text == " ") text = "_";
                }
                enArray.Add(text);
                pos++;
                break;
            }
        }
    }
    while (text != "stop");

    Color(0);
    return enArray;
}

List<string> SortArray(List<string> array)
{
    List<string> resArray = new List<string>();

    const int sortLength = 3;

    foreach (string res in array)
    {
        if (res.Length <= sortLength) resArray.Add(res);
    }

    return resArray;
}

void PrintArray1D(List<string> array, string comment)
{
    Color(1);
    if (array.Count != 0)
    {
        Console.WriteLine($"\n {comment} сформирован текстовый массив из {array.Count} элементов :\n");

        for (int i = 0; i < array.Count; i++)
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
            if (i < array.Count - 1) Console.Write(" | ");
        }
    }
    else Console.WriteLine($"\n {comment} массив не сформирован - элементы отсутствуют.");
    Color(0);
    Console.WriteLine();
}

// К О Д   

Console.Clear();

List<string> array = EnterArray("Задайте одномерный массив из строк (набора символов) - для окончании ввода наберите кодовое слово ",
                          "По запросу наберите текст (символы) и подтвердите ввод клавишей <Enter>.");

if (array.Count != 0)
{
    PrintArray1D(array, "Итого");
    List<string> resArray = SortArray(array);
    PrintArray1D(resArray, "По критерию количество символов в элементе не более трех");
}
else
{
    Color(5);
    Console.WriteLine("Массив не задан.");
    Color(0);
}

Console.WriteLine();
