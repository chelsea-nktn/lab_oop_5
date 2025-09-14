
using System;                
using System.IO;             

class FileDetails
{
    static void Main(string[] args)
    {
        int i;
        string fileName = args[0]; //Присвоение fileName имени файла

        FileStream stream = new FileStream(fileName, FileMode.Open); //Создание потока, который позволяет читать данные с диска
        StreamReader reader = new StreamReader(stream); // Создаётся преобразователь из FileStream в символы с учетом кодировки

        long size = stream.Length; //Получение длины файла
        char[] contents = new char[size]; // Создания массива contents с размером size для хранения всех символов в файле 

        for (i = 0; i < size; i++) //В данном цикле происходит запись всех символов в файле в массив 
        {
            contents[i] = (char)reader.Read();
        }

        foreach (char symbol in contents) // Вывод всех символов в консоль
        {
            Console.Write(symbol);
        }

        reader.Close(); // Закрытие reader и освобождение ресурсов

        Console.WriteLine("FILE'S NAME: {0}", fileName); //Вывод имени файла
        Console.WriteLine("FILE'S  SIZE: {0}", size); //Вывод размера файла
        Summarize(contents); // Вызов статического метода Summarize

    }
    static void Summarize(char[] symbols) //Объявление метода Summarize, аргументом которого является массив символов
    {
        int vowels = 0, not_vowels = 0, lines = 0; //Объявление переменных, в которых будут храниться кол-ва гласных, согласных букв, а также кол-во строк
        foreach (char symbol in symbols)
        {
            if ("AEIOUaeiou".IndexOf(symbol) != -1 && symbol != '\n' && symbol != '\r') //Провекра на то, явлется ли символ гласной буквой
            {
                vowels++;
            }
            if ("BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz".IndexOf(symbol) != -1 && symbol != '\n' && symbol != '\r') // Проверка на то, является ли символ согласной буквой
            {
                not_vowels++;
            }
            if (symbol == '\n') // Проверка на то, является ли символ служебным, который переносит строку
            {
                lines++;
            }
        }
        Console.WriteLine("VOWELS: {0}", vowels); //Вывод кол-ва гласных букв
        Console.WriteLine("NOT VOWELS: {0}", not_vowels); //вывод кол-ва согласных букв
        Console.WriteLine("LINES: {0}", lines); // Вывод кол-ва строк
    }
}
