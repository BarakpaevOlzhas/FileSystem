using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamsHomeWorkFirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"/HomeWork/";
            string fileName = "fileTwo.txt";
            string driveName = "C:";
            string buf;
            int count = 0;
            int firstNumber = 0, secondNumber = 0;


            if (!Directory.Exists(driveName + directoryPath))
            {
                Directory.CreateDirectory(driveName + directoryPath);
            }
            try
            {
                if (!File.Exists(driveName + directoryPath + fileName))
                {
                    File.Create(driveName + directoryPath + fileName);
                }
                               
                    Console.WriteLine("Вывод данных из файла:");
                    using (StreamReader streamReader = new StreamReader(driveName + directoryPath + fileName))
                    {
                        buf = streamReader.ReadToEnd();
                        Console.WriteLine(buf);
                    int inrPartOfTheText;
                        foreach (var partOfTheText in buf.Split(' '))
                        {
                        int.TryParse(partOfTheText,out inrPartOfTheText);
                        if (count == 0)
                        {
                            firstNumber = inrPartOfTheText;
                        }
                        else
                        {
                            secondNumber = inrPartOfTheText;
                        }
                        count++;
                        }
                    }

                    using (StreamWriter streamWriter = new StreamWriter(driveName + directoryPath + fileName))
                    {
                    streamWriter.Write($"{firstNumber + secondNumber}");
                    }
                    using (StreamReader streamReader = new StreamReader(driveName + directoryPath + fileName))
                    {
                        Console.WriteLine(streamReader.ReadToEnd());
                    }                
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}