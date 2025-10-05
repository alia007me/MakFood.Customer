﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Infrstructure.DataAccess.Context
{
    public interface IUnitOfWork
    {
        public Task<int> Commit(CancellationToken ct);
    }
}
