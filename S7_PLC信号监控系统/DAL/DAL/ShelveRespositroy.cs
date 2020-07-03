using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace 立体库PLC调度系统.DAL.DAL
{
    class ShelveRespositroy: BaseRespositroy<shelve>, IBaseRespositroy<shelve>
    {
        protected readonly DbContext context;
        public ShelveRespositroy(DbContext _context) : base(_context)
        {
            context = _context;
        }
        public  IEnumerable<shelve> GetEntities()
        {
            return context.Set<shelve>().ToList();
        }

        public new shelve Get(int SlikId)
        {
            return context.Set<shelve>().Find(SlikId);
        }

        #region 用Silk号查询在哪个货架
        public  IEnumerable<shelve> Find(Expression<Func<shelve, int, bool>> Fx)
        {
            return context.Set<shelve>().Where(Fx);
        }
        #endregion

        public  void Add(shelve Entity)
        {
            context.Set<shelve>().Add(Entity);
        }

        public  void AddRange(IEnumerable<shelve> Entity)
        {
            context.Set<shelve>().AddRange(Entity);
        }

        public  void Remove(shelve Entity)
        {
            context.Set<shelve>().Remove(Entity);
        }


        public  void RemoveRange(IEnumerable<shelve> Entity)
        {
            context.Set<shelve>().RemoveRange(Entity);
        }
    }
}
