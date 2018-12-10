using ToDoList.Models;
using ToDoListApp;
using ToDoList = ToDoListApp.ToDoList;

namespace ToDoListApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDoListContext context)
        {
               context.ToDoLists.AddOrUpdate(
                   new ToDoListApp.ToDoList
                   {
                       Name = "Groceries",
                       Items =
                       {
                           new Item { Name = "Milk"},
                           new Item { Name = "Sugar"},
                           new Item { Name = "Coffee"},
                       }
                   },
                   new ToDoListApp.ToDoList
                   {
                       Name = "Hardware"
                   }
                   );
        }
    }
}
