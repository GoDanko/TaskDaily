using System;
using System.Net.Mime;

namespace MyApp
{
    internal class Program {
        static void Main(string[] args)
        {
            new FileManager();
        }
    }

    public class FileManager {
        static public string BasePath {get; set;} = AppDomain.CurrentDomain.BaseDirectory;
        static public string TitlePath {get; set;} = Path.Combine(BasePath, "TaskTitles");
        static public string DescriptionPath {get; set;} = Path.Combine(BasePath, "TaskDescriptions");
        public FileManager() {
            AddFile(AddDirectory("text1", "text2", "text3") + "TestDirectory");
        }

        static public string AddDirectory(string directoryName1, string? directoryName2 = null, string? directoryName3 = null) {
            string directoryPath = Path.Combine(BasePath, directoryName1);
            while(true) {
                if (!Directory.Exists(directoryPath)) {
                    Directory.CreateDirectory(directoryPath);
                }
                if (directoryName2 != null) {
                    directoryPath = Path.Combine(directoryPath, directoryName2);
                    directoryName2 = null;
                    continue;
                }
                if (directoryName3 == null) {
                    break;
                } else if (directoryName3 != null) {
                    directoryPath = Path.Combine(directoryPath, directoryName3);
                    directoryName3 = null;
                    continue;
                }
            }
            return directoryPath;
        }

        static public string AddFile(string fileName) {
            string filePath = Path.Combine(BasePath, fileName);
            if (!File.Exists(filePath)) {
                using (File.CreateText(filePath)) {}
            }
            return filePath;
        }

        static public void LogDirectory(string content, string filePath, bool removeExistingContent = false) {

        }
    }

    public class NewTask {
        public string Title {get; set;}
        static public int TaskCounter {get; set;}
        public string TicketPrefix {get; set;}

        public NewTask(string getTitle) {
            Title = getTitle;
        }
    }

}
