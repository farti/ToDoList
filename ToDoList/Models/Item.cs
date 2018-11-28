using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoListApp
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
        public int ToDoListId { get; set; }

        public Item()
        {
            Id = 0;
            Name = String.Empty;
            Checked = false;
            ToDoListId = -1;
        }
    }
}