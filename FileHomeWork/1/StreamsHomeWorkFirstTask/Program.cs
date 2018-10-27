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
            string fileName = "file.txt";
            string driveName = "C:";
            string buf;            
            int count = 0;
            int yes;
            List<int> ches = new List<int>();
            

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

                Console.WriteLine("Хотите начать файл заново? \n 1)да \n 2)нет");

                int.TryParse(Console.ReadLine(),out yes);

                if (yes == 1)
                {
                    using (StreamWriter streamWriter = new StreamWriter(driveName + directoryPath + fileName))
                    {
                        streamWriter.Write("1 ");
                    }
                }
                else
                {
                    Console.WriteLine("Вывод данных из файла:");
                    using (StreamReader streamReader = new StreamReader(driveName + directoryPath + fileName))
                    {
                        buf = streamReader.ReadToEnd();
                        Console.WriteLine(buf);
                        int intPartOfTheText;
                        foreach (var partOfTheText in buf.Split(' '))
                        {
                            count++;
                            int.TryParse(partOfTheText, out intPartOfTheText);
                            if(intPartOfTheText != 0)
                            ches.Add(intPartOfTheText);      
                        }
                    }

                    using (StreamWriter streamWriter = new StreamWriter(driveName + directoryPath + fileName))
                    {
                        streamWriter.Write(buf);
                        int numberOfCycles = ches.Count;

                        for (int i = 0; i < numberOfCycles; i++)
                        {
                            if (ches.Count != 1) {
                                streamWriter.Write($"{ches[ches.Count - 1] + ches[ches.Count - 2]} ");
                                ches.Add(ches[ches.Count - 1] + ches[ches.Count - 2]);
                            }
                            else
                            {
                                streamWriter.Write($"{ches[ches.Count - 1] + ches[ches.Count - 1]} ");
                            }
                        }
                    }
                    using (StreamReader streamReader = new StreamReader(driveName + directoryPath + fileName))
                    {
                        Console.WriteLine(streamReader.ReadToEnd());
                    }
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }            
        }
    }
}