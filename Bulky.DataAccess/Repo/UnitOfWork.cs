using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repo.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategory? category{get; private set;}

        public IBulkyBooks? bulkybooks { get; private set; }

         public IUserModel? userModel { get; private set; } 

        private readonly ApplicationDbContext1 _db;

        public UnitOfWork(ApplicationDbContext1 db)
        {
            _db = db;
            category = new CategoryRepo(_db);
            bulkybooks = new BulkyBookRepo(_db);
            userModel = new UserModelRepo(_db);

        }
        public void Save()
        {
            _db.SaveChanges();
        }
       
    }
}
