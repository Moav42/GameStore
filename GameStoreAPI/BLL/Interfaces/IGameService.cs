﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGameService<T>
    {
        Task<IEnumerable<T>> ReadAllGamesAsync();
    }
}