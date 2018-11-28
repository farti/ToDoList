using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ToDoListApp.Controllers
{
    public class ToDoListController : ApiController
    {
        public static List<ToDoList> toDoLists = new List<ToDoList>()
        {
            new ToDoList() { Id = 0 , Name = "Groceries", Items =
            {
                    new  Item {Id = 0, Name = "Milk", ToDoListId = 0},
                    new  Item {Id = 1, Name = "Water", ToDoListId = 0},
                    new  Item {Id = 2, Name = "Tomato", ToDoListId = 0}
            }},
            new ToDoList() { Id = 1 , Name = "Hardware"}
        };

        // GET: api/ToDoList/5
        public IHttpActionResult Get(int id)
        {
            ToDoList result = toDoLists.FirstOrDefault(s => s.Id == id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/ToDoList
        public IEnumerable Post([FromBody]ToDoList newList)
        {
            newList.Id = toDoLists.Count;
            toDoLists.Add(newList);

            return toDoLists;
        }
    }
}
