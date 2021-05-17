using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.Logic
{
    public interface IGenericService<E, T> where E : class, IEntity where T : class
    {
        public Task Delete(Guid id);
        public Task<T> Create(T model);
        public Task<T> Update(T model);
        public Task<List<T>> GetAll();
        public Task<T> GetById(Guid id);
    }
}