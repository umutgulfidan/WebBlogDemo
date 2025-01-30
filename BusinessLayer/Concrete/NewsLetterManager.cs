using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _newsLetterDal.Insert(newsLetter);
        }

        public bool IsEmailExists(NewsLetter newsLetter)
        {
            return _newsLetterDal.GetListAll(x=> x.Mail == newsLetter.Mail).Any();
        }

        public bool IsEmailExists(string email)
        {
            return _newsLetterDal.GetListAll(x => x.Mail == email).Any();
        }
    }
}
