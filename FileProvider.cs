using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CSharpProject.Models;

namespace CSharpProject
{
    public class ItemProvider
    {
        public List<Item> GetItems(string path)
        {
            var items = new List<Item>();

            var dirInfo = new DirectoryInfo(path);
            
            foreach (var directory in dirInfo.GetDirectories())
            {
                var item = new DirectoryItem
                {
                    Name = directory.Name,
                    Path = directory.FullName,
                    Items = GetItems(directory.FullName)
                };

                items.Add(item);
            }

            foreach (var file in dirInfo.GetFiles())
            {
                var item = new FileItem
                {
                    Name = file.Name,
                    Path = file.FullName
                };

                items.Add(item);
            }

            return items;
        }
        public async Task<List<Item>> GetItemsAsync(string path)
        {
            return await Task.Run(() => GetItems(path)); ;
        }
    }
}