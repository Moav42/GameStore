﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGameRepository<T>
    {
        Task<IEnumerable<T>> ReadAllGamesAsync();

    }
}