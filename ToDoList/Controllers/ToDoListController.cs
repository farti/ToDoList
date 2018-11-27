using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList = ToDoListApp.Models.ToDoList;

namespace ToDoListApp.Controllers
{
    public class ToDoListController : ApiController
    {
        List<ToDoList> toDoLists = new List<ToDoList>()
        {
            new ToDoList() { Id = 0 , Name = "Groceries"},
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
        public void Post([FromBody]string value)
        {
        }
    }
}
