﻿using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {

        Task<bool> AddAsync(T entity);

        bool Remove(T entity);
        Task<bool> RemoveAsync(string id);

        bool RemoveRange(List<T> entities);

        bool Update(T entity);

        Task<int> SaveAsync();



    }
}
