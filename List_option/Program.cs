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

    List<string> EnArray = new List<string>();
    string text;
    int pos = 1;

    do
    {
        while (true)
        {
            Color(3);
            Console.Write($"элемент {pos}: ");
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
                EnArray.Add(text);
                pos++;
                break;
            }
        }
    }
    while (text != "stop");

    Color(0);
    return EnArray;
}

List<string> SortArray(List<string> Array)
{
    List<string> ResArray = new List<string>();

    foreach (string res in Array)
    {
        if (res.Length <= 3 && res != "[Ent]" && res != "[-]") ResArray.Add(res);
    }

    return ResArray;
}

void PrintArray1D(List<string> Array, string text)
{
    Color(1);
    if (Array.Count != 0) Console.WriteLine($"\n {text} сформирован текстовый массив из {Array.Count} элементов :\n");
    else Console.WriteLine($"\n {text} массив не сформирован - элементы отсутствуют.");

    for (int i = 0; i < Array.Count; i++)
    {
        var ar = String.Format("{0,2}", Array[i]);
        Color(1);
        Console.Write(ar);
        Color(4);
        if (i < Array.Count - 1) Console.Write(" | ");
    }
    Color(0);
    Console.WriteLine();
}

// К О Д   

Console.Clear();

List<string> Arr = EnterArray("Задайте одномерный массив из строк (набора символов) - для окончании ввода наберите кодовое слово ",
                          "По запросу наберите текст (символы) и подтвердите ввод клавишей <Enter>.");

if (Arr.Count != 0)
{
    PrintArray1D(Arr, "Итого");
    List<string> ResArr = SortArray(Arr);
    PrintArray1D(ResArr, "По критерию количество символов в элементе не более трех");
}
else
{
    Color(5);
    Console.WriteLine("Массив не задан.");
    Color(0);
}

Console.WriteLine();
