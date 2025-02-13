using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public string NameSurname { get; set; }
        public string? ImageUrl { get; set; }
        public string? About { get; set; }

        List<Blog> Blogs { get; set; }
        public virtual ICollection<Message> WriterSender { get; set; }
        public virtual ICollection<Message> WriterReceiver { get; set; }
    }
}
