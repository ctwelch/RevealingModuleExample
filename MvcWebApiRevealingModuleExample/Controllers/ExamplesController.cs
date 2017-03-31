using MvcWebApiRevealingModuleExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWebApiRevealingModuleExample.Controllers
{
    
    //[Authorize]
    public class ExamplesController : ApiController
    {
        private ExampleDb db;

        public ExamplesController()
        {
            db = new ExampleDb();
            // ProxyCreation is for change tracking and lazy loading
            // but for an Api we want to grab data, serialize it and transmit to the client
            // or vise-versa. So we don't need change tracking or lazy loading
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/values
        public IEnumerable<Example> GetAllExamples()
        {
            return db.Examples;
        }

        // GET api/values/5
        public Example Get(int id)
        {
            var example = db.Examples.Find(id);
            
            if(example == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return example;
        }

        // POST api/examples
        public HttpResponseMessage PostExample(Example example)
        {
            if(ModelState.IsValid)
            {
                db.Examples.Add(example);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, example);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = example.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/examples/5
        // MVC looks for primitive types in the url, and complex types in the body
        public HttpResponseMessage PutExample(int id, Example example)
        {
            if(ModelState.IsValid && id == example.Id)
            {
                db.Entry(example).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified); // closest we can get to letting user know update failed
                }

                return Request.CreateResponse(HttpStatusCode.OK, example);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/examples/5
        public HttpResponseMessage DeleteExample(int id)
        {
            Example example = db.Examples.Find(id);

            if(example == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Examples.Remove(example);

            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, example);
        }
    }
}
