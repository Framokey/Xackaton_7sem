﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoomsRepository
    {
        private readonly WorkspacesDbContext _context;

        public RoomsRepository(WorkspacesDbContext context)
        {
            _context = context;
        }

      
    }
}
