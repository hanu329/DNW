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

    public class UserModelRepo : Repository<UserModel>, IUserModel
    {
        private readonly ApplicationDbContext1 _db;


        public UserModelRepo(ApplicationDbContext1 db) : base(db)
        {
            _db = db;
        }
        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(UserModel model)
        {
            _db.UserModels.Update(model);
        }

    }
}
