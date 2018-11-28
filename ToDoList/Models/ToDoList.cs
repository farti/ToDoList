using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoListApp
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }

        public ToDoList()
        {
            Id = 0;
            Name = String.Empty;
            Items = new List<Item>();
        }

    }
}