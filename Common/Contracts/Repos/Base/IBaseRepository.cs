using Common.Models.Entities.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Contracts.Repos.Base {
    public interface IBaseRepository<TKey, TEntity>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey> {
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity AddOrUpdate(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TKey id);
        void DeleteRange(IEnumerable<TKey> ids);
        EntityEntry<TEntity> GetEntry(TEntity entity);
        IQueryable<TEntity> GetAll(IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null);
        TEntity GetById(TKey id);
        TEntity GetById(TKey id, IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null, bool localOnly = false);
        //IQueryable<TEntity> Get(out int total, string orderBy, int skip, int take = 0, bool descOrder = true, IEnumerable<Expression<Func<TEntity, bool>>> conditions = null, IEnumerable<Expression<Func<TEntity, object>>> includeProperties = null);
        void Load(Expression<Func<TEntity, bool>> condition = null);
    }
}
