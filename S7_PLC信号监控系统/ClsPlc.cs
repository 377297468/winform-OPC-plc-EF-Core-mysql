using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjS7OPC;
using System.Data;

namespace 立体库PLC调度系统.BLL
{
    class ClsPlc
    {
        prjS7OPC.ClsS7OPC objcomm = new ClsS7OPC();
        short  handle = 0;
        string[] SinItemID = new string[3];
        #region ConnToPlc
        public Boolean ConnToPLC()
        {
            objcomm.GroupNumber = 10;
            int i = 0;
            string v_PLC_ID = "";
            string v_PLCDB_DB106 = "";
            string v_PLCDB_ID = "";

            Boolean Result = true;
            SinItemID[1] = "S7:[BZX1]DB19,WORD0,3818";
            SinItemID[2] = "S7:[BZX2]DB19,WORD0,3818";
            handle = objcomm.SetItems(1, SinItemID);    


            if (handle==0)
            { Result = false; }
            return Result;
        }
        #endregion 


        #region 判断读取状态
        public Boolean ReadDevStatus()
        {
            Boolean Result = true;
            Boolean Res = true;
            int i ;
            string strRst = "";
            string[] arrayData1 = new string[20000]; 
            var  strGetVal_Test = objcomm.GetVal(handle);
            if (strGetVal_Test is Array)
            {
                int iMax = (strGetVal_Test as Array).Length;
                for (i = 1; i <= iMax; i++)
                {
                    strRst = (strGetVal_Test as Array).GetValue(i).ToString();
                    Res = BZXStatusExch(i, strRst);
                }
                if (Res==false )
                {
                    Result = false;
                }
            }

                return  Result;
        }
        #endregion

        #region 包装线PLC数据交互
        private bool BZXStatusExch(int PlcNumber, string StatusData)
        {
            Boolean Result = true;
            string[] DataTmp = new string[20000];
            Boolean Res;
            Boolean Retmsg = true;

            Res = DataExch(StatusData.ToString(), DataTmp);
            if (Res == false)
            {
                goto ErrorHandle;
            }
            if (PlcNumber == 1)//小车1的plc
            {
                ClsGloble.ID[0] = Convert.ToInt32(DataTmp[3401]);
                ClsGloble.StationId[0] = Convert.ToInt32(DataTmp[3506]);
                ClsGloble.WaitTime[0] = Convert.ToString(DataTmp[3523]);
                ClsGloble.SilkID[0] = Convert.ToString(DataTmp[3752]);
            }
            if (PlcNumber == 2)//小车2的plc
            {

            }

        ErrorHandle:
            Result = false;
            return Result;
        }
        #endregion




        #region 判断是否数据交互
        public Boolean DataExch(string strdata, string[] arrayData)
        {
            Boolean Result = true;
            string strTmp, strCheck;
            int i, J;
            J = 0;
            strTmp = "";
            try {
                if (strdata.Length  == 0)
                {
                    goto ErrorHandle;
                }
                for (i = 1; i <= strdata.Length; i++)
                {
                    strCheck = strdata.Substring(i, 1);
                    if ((strCheck == "{") || (strCheck == "|") || (strCheck == "}"))
                    {
                        arrayData[J] = strTmp;
                        strTmp = "";
                        J = J + 1;
                    }
                    else
                    { strTmp = strTmp + strCheck; }
                }
                Result = true;
                return Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        ErrorHandle:
            Result = false;
            return Result;
        }
        #endregion


    }
}