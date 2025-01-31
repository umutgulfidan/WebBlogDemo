﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface INewsLetterService : IGenericService<NewsLetter>
    {
        bool IsEmailExists(NewsLetter newsLetter);
        bool IsEmailExists(string email);
    }
}
