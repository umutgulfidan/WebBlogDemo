﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class Notification : IEntity
    {
        [Key]
        public int NotificationID { get; set; }
        public string NotificationType { get; set; }
        public string NotificationTypeSymbol { get; set; }
        public string NotificationTypeColor { get; set; }
        public string NotificationDetails { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus {  get; set; }

    }
}
