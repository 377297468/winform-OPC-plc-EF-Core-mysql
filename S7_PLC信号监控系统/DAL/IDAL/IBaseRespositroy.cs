using 立体库PLC调度系统.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace 立体库PLC调度系统.DAL
{   //存储库模式增删改查接口
    public  interface IBaseRespositroy<TEntity> where TEntity : class
    {
        TEntity Get(int ID);
        IEnumerable<TEntity> GetEntities();  
        IEnumerable<TEntity> Find(Expression<Func<TEntity, int,bool>> Fx);

        void Add(TEntity Entity);
        void AddRange(IEnumerable<TEntity> Entity);
        void Remove(TEntity Entity);
        void RemoveRange(IEnumerable<TEntity> Entity);

    }
}
