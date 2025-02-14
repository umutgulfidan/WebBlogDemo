using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserDal _userDal;

        public UserManager(UserManager<AppUser> userManager,IUserDal userDal)
        {
            _userManager = userManager;
            _userDal = userDal;
        }

        public List<AppUser> SearchUser(string searchTerm)
        {
            return _userManager.Users
                .Where(u => u.Email.Contains(searchTerm) || u.UserName.Contains(searchTerm))
                .ToList();
        }
        public AppUser GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<AppUser> GetList()
        {
            return _userDal.GetListAll();
        }

        public void TAdd(AppUser t)
        {
            _userDal.Insert(t);
        }

        public void TDelete(AppUser t)
        {
            _userDal.Delete(t);
        }

        public void TUpdate(AppUser t)
        {
            _userDal.Update(t);
        }
    }
}
