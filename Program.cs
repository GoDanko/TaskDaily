using System;
using System.Net.Mime;
using System.Net.Security;

namespace MyApp
{
    internal class Program {
        static void Main(string[] args)
        {
            CreateFile task1 = new CreateFile("First Task", "savings", "Neh, Nana Nah!");

            CreateFile task2 = new CreateFile("Second Task", "savings");
        }
    }

    public class CreateFile {
        static public string BasePath {get; set;} = AppDomain.CurrentDomain.BaseDirectory;
        static public int Counter {get; set;} = 0;
        public string FileName {get; set;}
        public string FilePath {get; set;}
        public string FileContent {get; set;}
        
        public CreateFile(string targetName, string? targetDirectory = null, string content = "Hello World!") {
            FileName = targetName;
            Console.WriteLine("targetName: " + this.FileName );

            Counter++;
            Console.WriteLine("Files Created: " + Counter);

            if (targetDirectory != null) {
                FilePath = Path.Combine(BasePath, targetDirectory, targetName);
                this.AddDirectory(Path.Combine(BasePath, targetDirectory));
                Console.WriteLine("Within directory: " + targetDirectory + "\ncreated Path: " + this.FilePath);
            } else {
                FilePath = Path.Combine(BasePath, targetName);
                Console.WriteLine("created Path: " + this.FilePath);
            }

            this.AddFile(this.FilePath);
            Console.WriteLine("File Created");

            FileContent = content;
            this.LogDirectory(this.FileContent, true);
            Console.WriteLine("Content: " + this.FileContent);
        }

        string AddDirectory(string path) {
            path = Path.Combine(BasePath, path);
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        string AddFile(string path) {
            if (!File.Exists(path)) {
                using (File.CreateText(path)) {}
            }
            return path;
        }

        public string LogDirectory(string content, bool removeExistingContent = false) {
            if (!removeExistingContent) {
                using (StreamWriter text = File.AppendText(this.FilePath)) {
                    text.Write(content);
                }
            } else if (removeExistingContent) {
                File.AppendAllText(this.FilePath, content);
            }
            return content;
        }
    }
}
