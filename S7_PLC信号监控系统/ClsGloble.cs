using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 立体库PLC调度系统
{
    class ClsGloble
    {
        public static short ProLineNum = 0;

        public static int[] ID = new int[3];  //out#堆货货架
        public static int[] StationId = new int[2];  //下线口#货架
        public static string[] SilkID = new string[99999];   //丝箱号
        public static string[] WaitTime = new string[99999];  //询问允许 托盘

        public static int[] AskFullAollow = new int[51];   //询问满允许
        public static int[] AskEmptyAollow = new int[51]; //询问空允许
        public static long[] OutAollow_Palletid = new long[51];//出货运行托盘
    }
}
