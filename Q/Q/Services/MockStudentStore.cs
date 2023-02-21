using Q.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.Services
{
    public class MockStudentStore : IDataStore<Student>
    {
        readonly List<Student> students;

        public MockStudentStore()
        {
            students = new List<Student>();
        }

        public async Task<bool> AddItemAsync(Student student)
        {
            students.Add(student);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Student student)
        {
            var oldItem = students.Where((Student arg) => arg.Id == student.Id).FirstOrDefault();
            students.Remove(oldItem);
            students.Add(student);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = students.Where((Student arg) => arg.Id == id).FirstOrDefault();
            students.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Student> GetItemAsync(string id)
        {
            return await Task.FromResult(students.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Student>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(students);
        }
    }
}
