using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace 立体库PLC调度系统.DAL.DAL
{
    class clscarrespositroy : BaseRespositroy<clscar>,IBaseRespositroy<clscar>
    {

        protected new readonly DbContext context;
        public clscarrespositroy(DbContext _context) : base(_context)
        {
            context = _context;
        }


        public new IEnumerable<clscar> GetEntities()
        {
            return context.Set<clscar>().ToList();
        }

        public new clscar Get(int ID)
        {
            return context.Set<clscar>().Find(ID);
        }

        #region 用最新的主键ID去查询分配车在几号站台
        public  IEnumerable<clscar> Find(Expression<Func<clscar, int, bool>> Fx)
        {
            return context.Set<clscar>().Where(Fx);
        }
        #endregion

        public new void Add(clscar Entity)
        {
            context.Set<clscar>().Add(Entity);
        }

        public new void AddRange(IEnumerable<clscar> Entity)
        {
            context.Set<clscar>().AddRange(Entity);
        }

        public new void Remove(clscar Entity)
        {
            context.Set<clscar>().Remove(Entity);
        }


        public new void RemoveRange(IEnumerable<clscar> Entity)
        {
            context.Set<clscar>().RemoveRange(Entity);
        }
    }
}
