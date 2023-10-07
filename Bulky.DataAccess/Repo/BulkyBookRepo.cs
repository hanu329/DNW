using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repo.IRepo;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repo
{
  
        public class BulkyBookRepo : Repository<BulkyBook>, IBulkyBooks
        {
            private readonly ApplicationDbContext1 _db;


            public BulkyBookRepo(ApplicationDbContext1 db) : base(db)
            {
                _db = db;
            }
            //public void Save()
            //{
            //    _db.SaveChanges();
            //}

            public void Update(BulkyBook model)
            {
                _db.BulkyBooks.Update(model);
            }
        
    }
}
