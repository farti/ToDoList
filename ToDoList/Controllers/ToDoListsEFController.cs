using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToDoList.Models;
using ToDoListApp;

namespace ToDoList.Controllers
{
    public class ToDoListsEFController : ApiController
    {
        private ToDoListContext db = new ToDoListContext();

        // GET: api/ToDoListsEF
        public IQueryable<ToDoListApp.ToDoList> GetToDoLists()
        {
            return db.ToDoLists;
        }

        // GET: api/ToDoListsEF/5
        [ResponseType(typeof(ToDoListApp.ToDoList))]
        public IHttpActionResult GetToDoList(int id)
        {
            ToDoListApp.ToDoList toDoList = db.ToDoLists.Find(id);
            if (toDoList == null)
            {
                return NotFound();
            }

            return Ok(toDoList);
        }

        // PUT: api/ToDoListsEF/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToDoList(int id, ToDoListApp.ToDoList toDoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDoList.Id)
            {
                return BadRequest();
            }

            db.Entry(toDoList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ToDoListsEF
        [ResponseType(typeof(ToDoListApp.ToDoList))]
        public IHttpActionResult PostToDoList(ToDoListApp.ToDoList toDoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToDoLists.Add(toDoList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toDoList.Id }, toDoList);
        }

        // DELETE: api/ToDoListsEF/5
        [ResponseType(typeof(ToDoListApp.ToDoList))]
        public IHttpActionResult DeleteToDoList(int id)
        {
            ToDoListApp.ToDoList toDoList = db.ToDoLists.Find(id);
            if (toDoList == null)
            {
                return NotFound();
            }

            db.ToDoLists.Remove(toDoList);
            db.SaveChanges();

            return Ok(toDoList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToDoListExists(int id)
        {
            return db.ToDoLists.Count(e => e.Id == id) > 0;
        }
    }
}