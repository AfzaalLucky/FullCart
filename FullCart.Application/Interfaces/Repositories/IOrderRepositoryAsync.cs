﻿using FullCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Application.Interfaces.Repositories
{
    public interface IOrderRepositoryAsync : IRepositoryAsync<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUserNameAsync(string userName);
    }
}
