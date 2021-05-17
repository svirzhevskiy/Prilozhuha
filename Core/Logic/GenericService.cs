using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Logic;
using AutoMapper;
using Database;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Logic
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TDto : class where TEntity : class, IEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _targetSet;
        protected readonly IMapper _mapper;

        public GenericService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _targetSet = _context.Set<TEntity>();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _targetSet.SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new ArgumentNullException();

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<TDto> Create(TDto model)
        {
            var entity = _mapper.Map<TEntity>(model);

            await _targetSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> Update(TDto model)
        {
            var entity = _mapper.Map<TEntity>(model);

            _targetSet.Update(entity);
            await _context.SaveChangesAsync();
            
            return _mapper.Map<TDto>(entity);
        }

        public async Task<List<TDto>> GetAll()
        {
            var query = _targetSet.Where(x => !x.IsDeleted);

            return await _mapper.ProjectTo<TDto>(query).ToListAsync();
        }

        public async Task<TDto> GetById(Guid id)
        {
            var entity = await _targetSet.SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == id);

            if (entity == null)
                throw new ArgumentNullException();

            return _mapper.Map<TDto>(entity);
        }
    }
}