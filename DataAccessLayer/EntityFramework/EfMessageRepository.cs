using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageRepository : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetMessagesByReceiver(int receiverId)
        {
            using (var context = new Context())
            {
                return context.Messages.Include(x=>x.Sender).ToList();
            }
        }
    }
}
