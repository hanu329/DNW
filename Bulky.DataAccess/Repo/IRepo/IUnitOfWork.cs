using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repo.IRepo
{
    public interface IUnitOfWork
    {
        ICategory? category { get; }
        IBulkyBooks? bulkybooks { get; }

        IUserModel? userModel { get; }
        void Save();
    }
}
