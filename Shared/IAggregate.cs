﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public interface IAggregate
    {
        IIterator<IStructure> CreateIterator();
    }
}
