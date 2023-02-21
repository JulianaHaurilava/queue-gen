using System;
using System.Collections.Generic;

namespace Q.Models
{
    public class Queue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Student> SortedStudents { get; set; }
        public Queue()
        {
            SortedStudents = new List<Student>();
        }
    }
}