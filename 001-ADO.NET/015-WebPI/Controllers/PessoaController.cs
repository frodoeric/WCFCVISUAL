using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using _015_WebPI.Models;

namespace _015_WebPI.Controllers
{
    public class PessoaController : ApiController
    {
        private DBEntities db = new DBEntities();

        // GET api/Pessoa
        public IEnumerable<Pessoa> GetPessoas()
        {
            return db.PessoaSet.AsEnumerable();
        }

        // GET api/Pessoa/5
        public Pessoa GetPessoa(int id)
        {
            Pessoa pessoa = db.PessoaSet.Find(id);
            if (pessoa == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return pessoa;
        }

        // PUT api/Pessoa/5
        public HttpResponseMessage PutPessoa(int id, Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != pessoa.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(pessoa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Pessoa
        public HttpResponseMessage PostPessoa(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.PessoaSet.Add(pessoa);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, pessoa);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = pessoa.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Pessoa/5
        public HttpResponseMessage DeletePessoa(int id)
        {
            Pessoa pessoa = db.PessoaSet.Find(id);
            if (pessoa == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.PessoaSet.Remove(pessoa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, pessoa);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}