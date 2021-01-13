using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DataAccessLayer
    {
        TS_Relaunch_MergeContext db = new TS_Relaunch_MergeContext();

        public IEnumerable<ItemViewModel> GetAllItems()
        {
            try
            {
                return db.InvItems.Select(x=> new ItemViewModel {
                    invItemId=x.InvItemId,
                    name=x.Name,
                    itemNumber=x.ItemNumber,
                    unitCostID = x.UnitCost

                }).ToList();//.Take(5);
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record   
        public int AddItem(ItemViewModel item)
        {          
            try
            {
                var itemNew = new InvItem();
                itemNew.Name = item.name;
                itemNew.ItemNumber = item.itemNumber;
                itemNew.UnitCost = item.unitCostID;
                db.InvItems.Add(itemNew);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee  
        public int UpdateItem(ItemViewModel item)
        {
            try
            {
                var entity= db.InvItems.Where(x=>x.InvItemId==item.invItemId).FirstOrDefault();
                if (entity!=null)
                {
                    entity.ItemNumber=item.itemNumber;
                    entity.UnitCost=Convert.ToDouble(item.unitCostID);
                    entity.Name=item.name;
                }
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee  
        public InvItem GetItemData(int id)
        {
            try
            {
                InvItem item = db.InvItems.Find(id);
                return item;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee  
        public int DeleteItem(int id)
        {
            try
            {
                InvItem item = db.InvItems.Find(id);
                db.InvItems.Remove(item);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        ////To Get the list of Cities  
        //public List<TblCities> GetCities()
        //{
        //    List<TblCities> lstCity = new List<TblCities>();
        //    lstCity = (from CityList in db.TblCities select CityList).ToList();

        //    return lstCity;
        //}

    }
}
