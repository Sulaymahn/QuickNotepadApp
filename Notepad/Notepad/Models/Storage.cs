using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Linq;


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

            ObservableCollection<Note> collection = new ObservableCollection<Note>();

            foreach (FileInfo file in directoryInfo.GetFiles().OrderBy(p => p.CreationTime).Reverse().ToArray())
            {
                string content = File.ReadAllText(file.FullName);
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
