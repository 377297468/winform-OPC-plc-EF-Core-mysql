using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 立体库PLC调度系统.DAL;
using 立体库PLC调度系统.DAL.DAL;
using 立体库PLC调度系统.DAL.IDAL;
using System.Data;


namespace 立体库PLC调度系统.BLL
{
    class ClsCarService : BaseService<clscar>
    {
         plcEntities plcEntities=new plcEntities();
      

        public override void Add(clscar Entity)
        {
            throw new NotImplementedException();
        }

        //private   clscarrespositroy _clscarrespositroy = new clscarrespositroy(context);
        //clscar _clscar = new clscar() { id = 5,
        //                                stationid = 6,
        //                                waittime = convert.tostring(46),
        //                                silkid = convert.tostring(156463),
        //                                datatime = datetime.utcnow
        //};
        //public void add(clscar _clscar)
        //{
        //    _clscarrespositroy.add(_clscar);
        //}
        public override void SetCurrentRepository()
        {
             CurrentRepository = new clscarrespositroy(plcEntities);
        }

    }
}
