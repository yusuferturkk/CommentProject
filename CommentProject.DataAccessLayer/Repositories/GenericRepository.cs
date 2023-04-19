using CommentProject.DataAccessLayer.Abstract;
using CommentProject.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, new()
    {

        Context context = new Context();

        public void Add(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetList()
        {
            return context.Set<TEntity>().ToList();
        }

        public List<TEntity> GetListByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>().Where(filter).ToList();
        }
    }
}
