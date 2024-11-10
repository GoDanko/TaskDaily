using System;
using System.Net.Mime;
using System.Net.Security;

namespace MyApp
{
    internal class Program {
        static void Main(string[] args)
        {
            // CreateFile task1 = new CreateFile("First Task", "savings", "Neh, Nana Nah!");
            // CreateFile task2 = new CreateFile("Second Task", "savings");

            for (int i = 0; i < 99; i++) {
                new TextEditorWindow(132, 36);
            }
            
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

    public class TextEditorWindow {
        public int Width {get; set;}
        public int Heigth {get; set;}

        public TextEditorWindow(int width, int heigth) {
            Width = width;
            Heigth = heigth;
            Console.SetCursorPosition(0, 0);
            DrawEditor();
        }

        void DrawEditor() {
            for (int y = 0; y <= this.Heigth; y++) {
                Console.SetCursorPosition(0, y);
                
                for (int x = 0; x <= this.Width; x++) {
                    Console.Write(DrawEditorlayout(x, y));
                }
            }
        }

        char DrawEditorlayout(int x, int y) {
            if (y == 0 || y == this.Heigth) {
                return '-';
            } else if (x == 0 || x == this.Width) { 
                return '|';
            }
            return 'x';
        }
    }

    // public class Pointer { // tracking and manipulating pointer's position
    //     public int Xposition {get; set;}
    //     public int Yposition {get; set;}
    //     public char PointerSemblance {get; set;}

    //     public Pointer() {

    //     }
    // }

    // public class LayoutManager { // making sure that each element has it's own state
    
    //     public LayoutManager() {
             
    //     }
    // }
}
