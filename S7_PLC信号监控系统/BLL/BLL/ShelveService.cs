using 立体库PLC调度系统.DAL;
using 立体库PLC调度系统.DAL.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 立体库PLC调度系统.BLL
{
    class ShelveService : BaseService<shelve>
    {
        plcEntities plcEntities = new plcEntities();

        public override void Add(shelve Entity)
        {
            throw new NotImplementedException();
        }

        public override void SetCurrentRepository()
        {
            CurrentRepository = new ShelveRespositroy(plcEntities);
        }
    }
}
