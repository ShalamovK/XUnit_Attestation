using Common.Contracts.Repos.Base;
using Common.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repos.Base {
    public class BaseRepository<TKey, TEnt> : IBaseRepository<TKey, TEnt>
        where TEnt : BaseEntity<TKey>
        where TKey : IEquatable<TKey> {

        protected DbContext DbContext { get; private set; }
        protected DbSet<TEnt> DbSet { get; set; }

        public BaseRepository(DbContext dbContext) {
            DbContext = dbContext ?? throw new ArgumentNullException("dbContext");
            DbSet = DbContext.Set<TEnt>();
        }

        public IQueryable<TEnt> GetAll(IEnumerable<Expression<Func<TEnt, object>>> includeProperties = null) {
            IQueryable<TEnt> query = DbSet;

            if (includeProperties != null) {
                foreach (var includeProperty in includeProperties) {
                    query = query.Include(includeProperty);
                }
            }

            return query;
        }

        public virtual void Add(TEnt entity) {
            DbSet.Add(entity);
        }
        public void Update(TEnt entity) {
            DbContext.Entry(entity).State = EntityState.Modified;
        }
        public TEnt AddOrUpdate(TEnt entity) {
            if (entity.Id.Equals(default(TKey))) {
                entity.Id = default(TKey);
                Add(entity);
            } else {
                Update(entity);
            }

            return entity;
        }

        public void Delete(TEnt entity) {
            DbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(TKey id) {
            TEnt entity = GetById(id);
            if (entity != null) {
                Delete(entity);
            }
        }

        public EntityEntry<TEnt> GetEntry(TEnt entity) {
            return DbContext.Entry(entity);
        }

        public void DeleteRange(IEnumerable<TKey> ids) {
            if (ids == null || ids.Count() == 0) {
                return;
            }

            foreach (TKey id in ids) {
                Delete(id);
            }
        }

        public TEnt GetById(TKey id, IEnumerable<Expression<Func<TEnt, object>>> includeProperties = null, bool localOnly = false) {
            Expression<Func<TEnt, bool>> predicate =
                x => x.Id.Equals(id);

            return GetByExpression(predicate, includeProperties, localOnly);
        }

        protected TEnt GetByExpression(Expression<Func<TEnt, bool>> predicate, IEnumerable<Expression<Func<TEnt, object>>> includeProperties = null, bool localOnly = false) {
            TEnt entity = FirstOrDefault(LocalSet, predicate, includeProperties);
            if (entity != null && localOnly) {
                return entity;
            }

            return FirstOrDefault(DbSet, predicate, includeProperties);
        }

        protected TEnt FirstOrDefault(IQueryable<TEnt> source, Expression<Func<TEnt, bool>> predicate, IEnumerable<Expression<Func<TEnt, object>>> includeProperties = null) {
            IQueryable<TEnt> query = source.AsQueryable();

            if (includeProperties != null) {
                foreach (var includeProperty in includeProperties) {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault(predicate);
        }

        protected IQueryable<TEnt> LocalSet {
            get { return DbSet.Local.AsQueryable(); }
        }

        public void Load(Expression<Func<TEnt, bool>> predicate = null) {
            IQueryable<TEnt> query = DbSet.AsQueryable();
            if (predicate != null) {
                query = query.Where(predicate);
            }

            query.Load();
        }
    }
}
