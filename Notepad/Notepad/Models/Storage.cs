using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace Notepad.Models
{
    public class Storage
    {
        private static Storage storage;
        private static string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static DirectoryInfo directoryInfo = new DirectoryInfo(docsPath);

        public static Storage GetInstance()
        {
            if (storage == null)
            {
                storage = new Storage();
            }

            return storage;
        }

        private Storage()
        {

        }

        public async Task WriteNote(Note note)
        {
            string content = JsonConvert.SerializeObject(note);
            var path = Path.Combine(docsPath, note.ID);
            using var writer = File.CreateText(path);
            await writer.WriteAsync(content);

        }

        public ObservableCollection<Note> GetCollection()
        {
            var collection = new ObservableCollection<Note>();

            foreach (FileInfo file in directoryInfo.EnumerateFiles())
            {
                string content = File.ReadAllText(Path.Combine(file.DirectoryName, file.Name));
                Note note = JsonConvert.DeserializeObject<Note>(content);
                collection.Add(note);
            }

            return collection;
        }

        public void ClearStorage()
        {
            foreach (FileInfo file in directoryInfo.EnumerateFiles())
            {
                file.Delete();
            }

        }

        public void DeleteNote(Note note)
        {
            foreach (FileInfo file in directoryInfo.EnumerateFiles())
            {
                if (file.Name == note.ID)
                {
                    file.Delete();
                }
            }

        }
    }
}
