using 立体库PLC调度系统.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace 立体库PLC调度系统.DAL
{    //存储库模式增删改查 
    public  class BaseRespositroy<TEntity> : IBaseRespositroy<TEntity> where TEntity : class  
    {
        protected readonly DbContext context;
        public BaseRespositroy(DbContext _context)
        {
            context = _context;

        }

        public IEnumerable<TEntity> GetEntities()
        {
            return context.Set<TEntity>().ToList();
        }
 
        public TEntity Get(int SilkID)
        {
            return context.Set<TEntity>().Find(SilkID);
        }

        #region 用最新的主键ID去查询分配车在几号站台
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, int, bool>> Fx)
        {
            return context.Set<TEntity>().Where(Fx);
        }
        #endregion

        public void Add(TEntity Entity)
        {
             context.Set<TEntity>().Add(Entity);
        }

        public void AddRange(IEnumerable<TEntity> Entity)
        {
            context.Set<TEntity>().AddRange(Entity);
        }

        public void Remove(TEntity Entity)
        {
            context .Set<TEntity>().Remove(Entity);
        }
    

        public void RemoveRange(IEnumerable<TEntity> Entity)
        {
            context.Set<TEntity>().RemoveRange(Entity);
        }
    }
}

