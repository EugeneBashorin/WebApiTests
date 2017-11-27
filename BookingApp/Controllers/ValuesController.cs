using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BookingApp.Controllers
{
    public class ValuesController : ApiController
    {
        BookContext db = new BookContext();

        //first variant
        //public IEnumerable<Book> GetBooks()
        //{
        //    return db.Books;
        //}
        //second variant
        //public HttpResponseMessage GetBooks()
        //{
        //  HttpResponseMessage books = Request.CreateResponse<IEnumerable<Book>>(HttpStatusCode.OK, db.Books);
        //  return books;
        //}
        //third variant
        public IHttpActionResult GetBooks()
        {
            return Ok(db.Books);
        }

        //public Book GetBook(int id)
        //{
        //    Book book = db.Books.Find(id);
        //    return book;
        //}
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //public string GetValue([FromUri]Book book,[FromUri]Author author)
        //{
        //    return book.Name + "("+ author.AuthorName +")";
        //}

        //first var
        //[HttpPost]
        //public void CreateBook([FromBody]Book book)
        //{
        //    db.Books.Add(book);
        //    db.SaveChanges();
        //}

        //second var
        //[HttpPost]
        //public HttpResponseMessage CreateBook([FromBody]Book book)
        //{
        //db.Books.Add(book);
        //db.SaveChanges();
        //  return new HttpResponseMessage(HttpStatusCode.Created);
        //}

        //thirdvar
        //[ResponseType(typeof(Book))]
        //public IHttpActionResult PostBook(Book book)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Books.Add(book);
        //    db.SaveChanges();
        //    return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        //}

        //WebApi valdation
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            //status code send
            if(book == null)
            {
                return BadRequest();
            }
            
            if(book.Year == 1984)
            {
                ModelState.AddModelError("book.Year","Year can't be equal 1984");
            }

            if(book.Name == "War & Peace")
            {
                ModelState.AddModelError("book.Name","Invalid book Name");
                ModelState.AddModelError("book.Name", "The name can not begin with a capital letter");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        [HttpPut]
        public void EditBook(int id, [FromBody]Book book)
        {
            if (id == book.Id)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
