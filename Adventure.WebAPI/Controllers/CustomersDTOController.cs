using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using Adventure.EFCodeFirst.Models;
using AutoMapper;

namespace Adventure.WebAPI.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using Adventure.EFCodeFirst.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<CustomerDTO>("CustomerDTO");
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CustomersDTOController : ODataController
    {
        private AdventureEntities db = new AdventureEntities();

        private IMapper _mapper;
        public CustomersDTOController(IMapper mapper) { _mapper = mapper; }
        
        // GET: odata/CustomerDTO
        [EnableQuery(PageSize = 50)]
        public IQueryable<CustomerDTO> GetCustomersDTO()
        {
            ///
            var result = (from customers in db.Customers
                          select new CustomerDTO
                          {
                              CustomerID = customers.CustomerID,
                              LastName = customers.LastName,
                              FirstName = customers.FirstName,
                              MiddleName = customers.MiddleName,
                              Title = customers.Title,
                              Suffix = customers.Suffix,
                              CompanyName = customers.CompanyName,
                              EmailAddress = customers.EmailAddress
                          });

            return result.AsQueryable();                    

            //return db.CustomersDTO;
        }

        //// GET: odata/CustomerDTO(5)
        //[EnableQuery]
        //public SingleResult<CustomerDTO> GetCustomerDTO([FromODataUri] int key)
        //{
        //    return SingleResult.Create(db.CustomersDTO.Where(customerDTO => customerDTO.CustomerID == key));
        //}

        //// PUT: odata/CustomerDTO(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<CustomerDTO> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    CustomerDTO customerDTO = db.CustomersDTO.Find(key);
        //    if (customerDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(customerDTO);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerDTOExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(customerDTO);
        //}

        //// POST: odata/CustomerDTO
        //public IHttpActionResult Post(CustomerDTO customerDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.CustomersDTO.Add(customerDTO);
        //    db.SaveChanges();

        //    return Created(customerDTO);
        //}

        //// PATCH: odata/CustomerDTO(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<CustomerDTO> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    CustomerDTO customerDTO = db.CustomersDTO.Find(key);
        //    if (customerDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(customerDTO);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerDTOExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(customerDTO);
        //}

        //// DELETE: odata/CustomerDTO(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    CustomerDTO customerDTO = db.CustomersDTO.Find(key);
        //    if (customerDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    db.CustomersDTO.Remove(customerDTO);
        //    db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CustomerDTOExists(int key)
        //{
        //    return db.CustomersDTO.Count(e => e.CustomerID == key) > 0;
        //}
    }
}
