using 立体库PLC调度系统.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace 立体库PLC调度系统.BLL
{
        //基类
        public abstract class BaseService<TEntity> where TEntity : class, new()
        {
            public IBaseRespositroy<TEntity> CurrentRepository { get; set; }
            //基类的构造函数
            public BaseService()
            {
                SetCurrentRepository();  //构造函数里面去调用了，此设置当前仓储的抽象方法
            }

            //约束
            public abstract void SetCurrentRepository();  //子类必须实现

          
            public IEnumerable<TEntity> GetEntities()
            {
               return CurrentRepository.GetEntities();
            }

            public  TEntity Get(int ID)
            {
               return CurrentRepository.Get(ID);
            }

        //实现数据库的条件查询    
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, int, bool>> Fx)
        {
            return CurrentRepository.Find(Fx);
        }


        //实现对数据库的添加一行功能
        public abstract void Add(TEntity Entity);

        //实现对数据库的添加多行功能
        public void AddRange(IEnumerable<TEntity> Entity)
        {
            CurrentRepository.AddRange(Entity);
        }
        //实现对数据库的删除一行功能
        public void Remove(TEntity Entity)
        {
            CurrentRepository.Remove(Entity);
        }

        //实现对数据库的删除多行功能
        public void RemoveRange(IEnumerable<TEntity> Entity)
        {
            CurrentRepository.RemoveRange(Entity);
        }
         


    }


}
