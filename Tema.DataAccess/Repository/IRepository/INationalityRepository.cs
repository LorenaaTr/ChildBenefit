﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema.Models;

namespace Tema.DataAccess.Repository.IRepository
{
    public interface INationalityRepository : IRepository<Nationality>
    {
        void Update(Nationality obj);
    }
}
