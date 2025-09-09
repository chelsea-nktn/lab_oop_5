
using System;                // Console
using System.IO;             // FileStream, FileReader

class FileDetails
{
    static void Main(string[] args)
    {
        int i;
        string fileName = args[0];
        FileStream stream = new FileStream(fileName, FileMode.Open);
        StreamReader reader = new StreamReader(stream);


        //TODO: Add code here
        long size = stream.Length;
        char[] contents = new char[size];

        for (i = 0; i < size; i++)
        {
            contents[i] = (char)reader.Read();
        }

        /*foreach (char letter in contents)
        {
            Console.Write(letter);
        }
        */
        reader.Close();
        Console.WriteLine("FILE'S NAME: {0}", fileName);
        Console.WriteLine("FILE'S  SIZE: {0}", size);
        Summarize(contents);

    }
    static void Summarize(char[] symbols)
    {
        int vowels = 0, not_vowels = 0, lines = 1;
        foreach (char symbol in symbols)
        {
            if ("AEIOUaeiou".IndexOf(symbol) != -1)
            {
                vowels++;
            }
            else
            {
                not_vowels++;
            }
            if (symbol == '\n')
            {
                lines++;
            }
        }
        Console.WriteLine("VOWELS: {0}", vowels);
        Console.WriteLine("NOT VOWELS: {0}", not_vowels);
        Console.WriteLine("LINES: {0}", lines);
    }
}
