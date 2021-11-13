using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repository;
        public UnitOfWork(StoreContext context)
        {
            this._context = context;
        }

        public async Task<int> Complete()
        {
           return  await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
           _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
          if(_repository==null) _repository = new Hashtable();
        
          var type = typeof(TEntity).Name;

          if(!_repository.ContainsKey(type))
          {
              var repositoryType = typeof(GenericRepository<>);
              var typeRep = repositoryType.MakeGenericType(typeof(TEntity));
            
             var repositoryInstance = Activator.CreateInstance(typeRep, _context);
              _repository.Add(type, repositoryInstance);

          }

              return (IGenericRepository<TEntity>) _repository[type];

        }
    }
}