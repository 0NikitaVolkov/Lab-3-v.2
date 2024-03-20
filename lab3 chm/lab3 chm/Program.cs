using System;
using System.IO;
using Newtonsoft.Json;

class TwoVariables
{
    public int Zminna1;
    public int Zminna2;

    // Конструктор класу
    public TwoVariables(int var1, int var2)
    {
        Zminna1 = var1;
        Zminna2 = var2;
    }

    // Виведення змінних на екран
    public void Display()
    {
        Console.WriteLine("Змiнна 1: " + Zminna1);
        Console.WriteLine("Змiнна 2: " + Zminna2);
    }

    // Зміна значень змінних
    public void Change(int var1, int var2)
    {
        Zminna1 = var1;
        Zminna2 = var2;
        Console.WriteLine("Змiннi було змiнено.");
    }

    // Сума значень змінних
    public int SumOfVariables()
    {
        return Zminna1 + Zminna2;
    }

    // Наайбільше значення змінної
    public int MaxVariable()
    {
        return Math.Max(Zminna1, Zminna2);
    }

    public void SerializeToJsonOnDesktop(string fileName)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, fileName);
        string json = JsonConvert.SerializeObject(this);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Данi збережено у JSON файлi на робочому столi: " + filePath);
    }

    // Метод для десеріалізації об'єкту з JSON файлу
    public static TwoVariables DeserializeFromJsonFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        TwoVariables obj = JsonConvert.DeserializeObject<TwoVariables>(json);
        return obj;
    }
}

class Program
{
    static void Main()
    {
        TwoVariables instance = new TwoVariables(10, 20);

        instance.Display();
        Console.WriteLine("Сума змiнних: " + instance.SumOfVariables());
        Console.WriteLine("Найбiльше значення: " + instance.MaxVariable());

        Console.WriteLine("Введiть нове значення для змiнної 1:");
        int newVar1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введiть нове значення для змiнної 2:");
        int newVar2 = Convert.ToInt32(Console.ReadLine());
        instance.Change(newVar1, newVar2);

        instance.SerializeToJsonOnDesktop("myObject.json");
        Console.WriteLine("Об'єкт серiалiзовано та збережено");


        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "myObject.json");
        TwoVariables deserializedInstance = TwoVariables.DeserializeFromJsonFile(filePath);

        Console.WriteLine("\nРезультати десерiалiзацiї:");
        deserializedInstance.Display();
        Console.WriteLine("Сума змiнних: " + deserializedInstance.SumOfVariables());
        Console.WriteLine("Найбiльше значення: " + deserializedInstance.MaxVariable());

        Console.ReadKey();
    }
}