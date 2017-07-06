using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using CellCity.Data;

namespace CellCity.Api.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CellCity.Data;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<WishList>("WishLists");
    builder.EntitySet<Order>("Orders"); 
    builder.EntitySet<Product>("Products"); 
    builder.EntitySet<User>("Users"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class WishListsController : ODataController
    {
        private CellCityEntities db = new CellCityEntities();

        // GET: odata/WishLists
        [EnableQuery]
        public IQueryable<WishList> GetWishLists()
        {
            return db.WishLists;
        }

        // GET: odata/WishLists(5)
        [EnableQuery]
        public SingleResult<WishList> GetWishList([FromODataUri] int key)
        {
            return SingleResult.Create(db.WishLists.Where(wishList => wishList.wishListID == key));
        }

        // PUT: odata/WishLists(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<WishList> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WishList wishList = db.WishLists.Find(key);
            if (wishList == null)
            {
                return NotFound();
            }

            patch.Put(wishList);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishListExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(wishList);
        }

        // POST: odata/WishLists
        public IHttpActionResult Post(WishList wishList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WishLists.Add(wishList);
            db.SaveChanges();

            return Created(wishList);
        }

        // PATCH: odata/WishLists(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<WishList> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WishList wishList = db.WishLists.Find(key);
            if (wishList == null)
            {
                return NotFound();
            }

            patch.Patch(wishList);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishListExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(wishList);
        }

        // DELETE: odata/WishLists(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            WishList wishList = db.WishLists.Find(key);
            if (wishList == null)
            {
                return NotFound();
            }

            db.WishLists.Remove(wishList);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/WishLists(5)/Orders
        [EnableQuery]
        public IQueryable<Order> GetOrders([FromODataUri] int key)
        {
            return db.WishLists.Where(m => m.wishListID == key).SelectMany(m => m.Orders);
        }

        // GET: odata/WishLists(5)/Product
        [EnableQuery]
        public SingleResult<Product> GetProduct([FromODataUri] int key)
        {
            return SingleResult.Create(db.WishLists.Where(m => m.wishListID == key).Select(m => m.Product));
        }

        // GET: odata/WishLists(5)/User
        [EnableQuery]
        public SingleResult<User> GetUser([FromODataUri] int key)
        {
            return SingleResult.Create(db.WishLists.Where(m => m.wishListID == key).Select(m => m.User));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WishListExists(int key)
        {
            return db.WishLists.Count(e => e.wishListID == key) > 0;
        }
    }
}
