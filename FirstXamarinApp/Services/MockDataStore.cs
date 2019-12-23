using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstXamarinApp.Models;

namespace FirstXamarinApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Read Book",
                    Description="This is an item description.",
                    Course = new Course { Name = "Introduction to Xamarin Forms" }
                },
                new Item {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Drink a coffee",
                    Description="This is an item description.",
                    Course = new Course { Name = "Advanced Xamarin Forms"}
                },
                new Item {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Go to bed",
                    Description="This is an item description.",
                    Course = new Course { Name = "Plugging React Native to Xamarin Forms" }
                },
                new Item {
                    Id = Guid.NewGuid().ToString(),
                    Text = "Read tutorial in Xamarin.Forms",
                    Description="This is an item description.",
                    Course = new Course { Name = "Advanced Xamarin Forms" }
                },
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}