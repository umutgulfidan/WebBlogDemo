using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Message : IEntity
    {
        [Key]
        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }

        [ForeignKey("SenderID")]
        public Writer Sender { get; set; }
        [ForeignKey("ReceiverID")]
        public Writer Receiver { get; set; }

    }
}
