using 立体库PLC调度系统.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 立体库PLC调度系统.BLL;
using System.Data.Entity;

namespace 立体库PLC调度系统
{
    public partial class Form1 : Form
    {

        ClsPlc clsplc = new ClsPlc();
        BaseService<clscar> Car = new ClsCarService();
        public Form1()
        {
            InitializeComponent();
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
           try
            {
                dataGridView2.DataSource = Car.GetEntities(); //dataGridView显示数据

                clsplc.ReadDevStatus(); //读PLC数据
                var car = new clscar()
                {
                    ID = ClsGloble.ID[0],
                    StationId = ClsGloble.StationId[0],
                    WaitTime = ClsGloble.WaitTime[0],
                    SilkID = ClsGloble.SilkID[0],
                    Datatime = DateTime.Now
                };
                Car.Add(car);//将实体添加到关系数据库中
                        
             
                ClsGloble.SilkID[0] = Car.Get(0).SilkID;
                ClsGloble.SilkID[1] = Car.Get(1).SilkID;
                ClsGloble.SilkID[2] = Car.Get(2).SilkID;
                ClsGloble.SilkID[3] = Car.Get(3).SilkID;
                ClsGloble.SilkID[4] = Car.Get(4).SilkID;

                //根据货架号显示最新搬运的丝箱号
                label6.Text = Convert.ToString(ClsGloble.SilkID[0]);
                label7.Text = Convert.ToString(ClsGloble.SilkID[1]);
                label8.Text = Convert.ToString(ClsGloble.SilkID[2]);
                label9.Text = Convert.ToString(ClsGloble.SilkID[3]);
                label10.Text = Convert.ToString(ClsGloble.SilkID[4]);
            }
           catch (Exception ex)
           {
                string Msg = ex.ToString();
                label6.Text = "Timer Error!!!";
                label7.Text = "Timer Error!!!";
                label8.Text = "Timer Error!!!";
                label9.Text = "Timer Error!!!";
                label10.Text = "Timer Error!!!";
           }
        }
    }
}
