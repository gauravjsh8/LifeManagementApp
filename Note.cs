using System;
using System.IO;

namespace LifeManagementApp
{
    public class Note
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public static string NotesDirectory =>
            Path.Combine(FileSystem.AppDataDirectory, "notes");

        public static void Save(string text)
        {
            Directory.CreateDirectory(NotesDirectory);
            string filename = Path.Combine(NotesDirectory, $"{Path.GetRandomFileName()}.txt");
            File.WriteAllText(filename, text);
        }

        public static IEnumerable<Note> LoadAll()
        {
            Directory.CreateDirectory(NotesDirectory);
            var files = Directory.GetFiles(NotesDirectory, "*.txt");
            foreach (var file in files)
            {
                yield return new Note
                {
                    Filename = file,
                    Text = File.ReadAllText(file),
                    Date = File.GetLastWriteTime(file)
                };
            }
        }

        public void Delete()
        {
            if (File.Exists(Filename))
                File.Delete(Filename);
        }
    }
}