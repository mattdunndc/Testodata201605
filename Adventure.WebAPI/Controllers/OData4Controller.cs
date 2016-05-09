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

namespace Adventure.WebAPI.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. 
    Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using Adventure.EFCodeFirst.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<DTOCustomer>("DTOCustomers");
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class OData4Controller : ODataController
    {
        private AdventureEntities db = new AdventureEntities();

        // GET: odata/DTOCustomers
        [EnableQuery(PageSize = 50)]
        public IQueryable<DTOCustomer> GetOData4()
        {
            //////
            /////
            var result= (from customer in db.Customers
                        select new DTOCustomer
                        {
                            CustomerID = customer.CustomerID,
                            FirstName = customer.FirstName,
                            MiddleName = customer.MiddleName,
                            LastName = customer.LastName,
                            Title = customer.Title,
                            Suffix = customer.Suffix,
                            CompanyName = customer.CompanyName,
                            EmailAddress = customer.EmailAddress,
                            Phone = customer.Phone,
                            SalesPerson = customer.SalesPerson
                        });

            return result.AsQueryable();  // db.DTOCustomers;
        }

        //// GET: odata/DTOCustomers(5)
        //[EnableQuery]
        //public SingleResult<DTOCustomer> GetDTOCustomer([FromODataUri] int key)
        //{
        //    return SingleResult.Create(db.DTOCustomers.Where(dTOCustomer => dTOCustomer.CustomerID == key));
        //}

        //// PUT: odata/DTOCustomers(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<DTOCustomer> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    DTOCustomer dTOCustomer = db.DTOCustomers.Find(key);
        //    if (dTOCustomer == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(dTOCustomer);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DTOCustomerExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(dTOCustomer);
        //}

        //// POST: odata/DTOCustomers
        //public IHttpActionResult Post(DTOCustomer dTOCustomer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.DTOCustomers.Add(dTOCustomer);
        //    db.SaveChanges();

        //    return Created(dTOCustomer);
        //}

        //// PATCH: odata/DTOCustomers(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<DTOCustomer> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    DTOCustomer dTOCustomer = db.DTOCustomers.Find(key);
        //    if (dTOCustomer == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(dTOCustomer);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DTOCustomerExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(dTOCustomer);
        //}

        //// DELETE: odata/DTOCustomers(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    DTOCustomer dTOCustomer = db.DTOCustomers.Find(key);
        //    if (dTOCustomer == null)
        //    {
        //        return NotFound();
        //    }

        //    db.DTOCustomers.Remove(dTOCustomer);
        //    db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool DTOCustomerExists(int key)
        //{
        //    return db.DTOCustomers.Count(e => e.CustomerID == key) > 0;
        //}
    }
}
