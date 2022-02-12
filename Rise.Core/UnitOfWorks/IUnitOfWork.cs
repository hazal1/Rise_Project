﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task SaveChangeAsync();
        void SaveChange();
    }
}
