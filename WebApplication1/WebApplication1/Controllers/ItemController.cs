using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ItemController : Controller
    {
        DataAccessLayer db = new DataAccessLayer();

        [HttpGet]
        [Route("api/Item/Index")]
        public IEnumerable<ItemViewModel> Index()
       {
            return db.GetAllItems();//.Select(x=> new { x.InvItemId,x.Name,x.ItemNumber,x.UnitCost });
        }

        [HttpPost]
        [Route("api/Item/Create")]
        public int Create([FromBody]List<ItemViewModel> item)
        {
            foreach (var i in item)
            {
                 db.AddItem(i);
            }
            return 1;
        }

        [HttpGet]
        [Route("api/Item/Details/{id}")]
        public InvItem Details(int id)
        {
            return db.GetItemData(id);
        }

        [HttpPost]
        [Route("api/Item/Edit")]
        public  int Edit([FromBody]List<ItemViewModel> item)
        {
            foreach (var i in item)
            {
                db.UpdateItem(i);
            }
            return 1;
        }

        [HttpPost]
        [Route("api/Item/Delete")]
        public int Delete([FromBody]List<ItemViewModel> item)
        {
            foreach (var i in item)
            {
                 db.DeleteItem(i.invItemId);
            }
            return 1;
        }

        //[HttpGet]
        //[Route("api/Employee/GetCityList")]
        //public IEnumerable<TblCities> Details()
        //{
        //    return objemployee.GetCities();
        //}
    }
}