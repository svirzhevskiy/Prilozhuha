using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public interface IGenericService<T> where T : class
    {
        public Task Delete(Guid id);
        public Task Create(T model);
        public Task Update(T model);
        public Task<List<T>> GetAll();
        public Task<T> GetById(Guid id);
    }
}