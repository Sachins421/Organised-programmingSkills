using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileDirectories
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            string filePath = "C:\\Polling\\filename.txt";
            string dummyLines = "Hello this is system generated file" + Environment.NewLine + "and this is new line.";
            File.WriteAllText(filePath, dummyLines);

            string readText = File.ReadAllText(filePath);
            Console.WriteLine(readText);

            File.AppendAllText(filePath, "string was added later");
            DateTime dateTime = File.GetLastWriteTime(filePath);
            Console.WriteLine(dateTime);

            FileStream fs = File.Open(filePath, FileMode.OpenOrCreate);

            String fileRootPath = @"C:\Temp\Demo";

            string[] dir = Directory.GetDirectories(fileRootPath, "*.*", SearchOption.AllDirectories);

            foreach (string dirPath in dir)
            {
                Console.WriteLine(dirPath);
            }

            var filepath = Directory.GetFiles(fileRootPath, "*.*", SearchOption.AllDirectories);

            foreach (string dirPath in filepath)
            {
                Console.WriteLine($"{Path.GetFileName(dirPath)} : {dirPath.Length} bytes");
                Console.WriteLine(Path.GetFileNameWithoutExtension(dirPath));
                Console.WriteLine(Path.GetFullPath(dirPath));
            }

            bool dirExist =  Directory.Exists(fileRootPath); 

            if (dirExist)
            {
                Console.WriteLine("directory exist.");
            }
            else 
            { 
                Console.WriteLine("not exist, but now created");
                Directory.CreateDirectory(fileRootPath);    
            }
        }
}
}
