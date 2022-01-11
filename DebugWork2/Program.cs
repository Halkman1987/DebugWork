using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
class BinaryExperiment
{
    const string SettingsFileName = "Settings.cfg";
    
    static void Main()
    {
        ReadBin();
        // Пишем
       /* WriteValues();
        // Считываем
        ReadValues();*/
    }

    static void WriteValues()
    {
        // Создаем объект BinaryWriter и указываем, куда будет направлен поток данных
        string SetF = @"C:\Users\User\Desktop\BinaryFile.bin";
        using (BinaryWriter writer = new BinaryWriter(File.Open(SetF, FileMode.Append))) 
        {
            // записываем данные в разном формате
            writer.Write(DateTime.Now);

        }
    }

    static void ReadValues()
    {

        string StringValue;


        if (File.Exists(SetFileNew))
        {
            // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
            using (BinaryReader reader = new BinaryReader(File.Open(SetFileNew, FileMode.Open)))
            {
                // Применяем специализированные методы Read для считывания соответствующего типа данных.

                StringValue = reader.ReadString();

            }

            Console.WriteLine("Из файла считано:");

            Console.WriteLine("Дробь: " + FloatValue);
            Console.WriteLine("Строка: " + StringValue);
            Console.WriteLine("Целое: " + IntValue);
            Console.WriteLine("Булево значение " + BooleanValue);
        }
    }

    static void ReadBin()
    {
        
        string SetFileNew = @"C:\Users\User\Desktop\BinaryFile.bin";
        if (File.Exists(SetFileNew))
        {
            string StringValue;
            using (BinaryReader reader = new BinaryReader(File.Open(SetFileNew, FileMode.Open)))
            {
                StringValue = reader.ReadString();
            }
            Console.WriteLine(StringValue);
        }
        
        
    }
}
