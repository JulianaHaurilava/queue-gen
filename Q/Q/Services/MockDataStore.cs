﻿using Q.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Services
{
    public class MockDataStore : IDataStore<Queue>
    {
        readonly List<Queue> items;

        public MockDataStore()
        {
            items = new List<Queue>()
            {
                new Queue { Id = Guid.NewGuid().ToString(), Name = "First item", Description="This is an item description." },
                new Queue { Id = Guid.NewGuid().ToString(), Name = "Second item", Description="This is an item description." },
                new Queue { Id = Guid.NewGuid().ToString(), Name = "Third item", Description="This is an item description." },
                new Queue { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description="This is an item description." },
                new Queue { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description="This is an item description." },
                new Queue { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Queue item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Queue item)
        {
            var oldItem = items.Where((Queue arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Queue arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Queue> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Queue>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}