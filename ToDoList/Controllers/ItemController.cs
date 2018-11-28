using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace ToDoListApp.Controllers
{
    public class ItemController : ApiController
    {
        // POST: api/Item
        public IHttpActionResult Post([FromBody]Item item)
        {
            ToDoList toDoList = ToDoListController.toDoLists
                .Where(s => s.Id == item.ToDoListId)
                .FirstOrDefault();

            if (toDoList == null)
            {
                return NotFound();
            }

            item.Id = toDoList.Items.Max(i => i.Id) + 1;
            toDoList.Items.Add(item);

            return Ok(toDoList);
        }

        // PUT: api/Item/5
        public IHttpActionResult Put(int id, [FromBody]Item item)
        {
            ToDoList toDoList = ToDoListController.toDoLists
                .Where(s => s.Id == item.ToDoListId)
                .FirstOrDefault();

            if (toDoList == null)
            {
                return NotFound();
            }

            Item changedItem = toDoList.Items
                .Where(i => i.Id == id)
                .FirstOrDefault();

            if (changedItem == null)
            {
                return NotFound();
            }

            changedItem.Checked = item.Checked;

            return Ok(toDoList);
        }

        // DELETE: api/Item/5
        public IHttpActionResult Delete(int id)
        {
            ToDoList toDoList = ToDoListController.toDoLists[0];

            Item item = toDoList.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            toDoList.Items.Remove(item);

            return Ok(toDoList);
        }
    }
}
