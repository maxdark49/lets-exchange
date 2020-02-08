using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class Tmam_day : System.Web.UI.Page
    {
        public List<STATE> sTATEs;
        public int officerid;
        PlanningDBEntities entities = new PlanningDBEntities();
        public int tableIndex;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void show_Click(object sender, EventArgs e)
        {
            
                getfields();
            
        }

        private void getfields()
        {
            /*ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            string date2 =  cph.FindControl("test5").UniqueID;
            string date = Request.Form[date2];*/

             DateTime datestr = stringToDate(TextBox1.Text);

            var test = from o in entities.STATEs
                       join b in entities.OFFICERs on o.officer_id equals b.id
                       where o.Date == datestr
                       select new
                       {
                           o.id,
                           b.rank,
                           b.O_name,
                           o.Date,
                           st = o.state1
                       };

            tableIndex += 1;
            rptrFields.DataSource = test.ToList();
            rptrFields.DataBind();


            ///////////////////////////

               /* var weapons = from o in entities.TmamTypes
                       select new
                       {
                           o.type_name,
                           o.Id

                       };            

            weaponlist.DataSource = weapons.ToList();
            weaponlist.DataTextField = "type_name";
            weaponlist.DataValueField = "Id";
            weaponlist.DataBind();
            weaponlist.Items.Insert(0, new ListItem(String.Empty));
            loadselected3();*/

        }

        /*protected void loadselected3()
        {
            for (int x = 0; x < rptrFields.Items.Count; x++)
            {
                //string officername= rptrFields.Controls[x].Controls[0].

                Label officeridlabel = (Label)rptrFields.Controls[x].FindControl("Label3");
                officerid = int.Parse(officeridlabel.Text);

                var result = from o in entities.STATEs
                             where o.id.Equals(officerid)
                             select new
                             {
                                 o.id,

                             };
                var test = result.First();
                weaponlist.SelectedValue = (test.id).ToString();
            }
        }*/

        public string Label4_Load(int test)
        {
            if (test == 2)
            {
                return "سنوية";
            }
            else if (test == 3)
            {
                return "أجازة عارضة";
            }
            else if (test == 4)
            {
                return "عارضة طارئة";
            }
            else if (test == 5)
            {
                return "مرضية";
            }
            else if (test == 6)
            {
                return "بدل راحة";
            }
            else if (test == 7)
            {
                return "فرقة";
            }
            else if (test == 8)
            {
                return "مأمورية خارجية";
            }
            else if (test == 9)
            {
                return "مأمورية";
            }
            else if (test == 10)
            {
                return "تفرغ .د عليا";
            }
            else if (test == 11)
            {
                return "تفرغ بحوث";
            }
            else if (test == 12)
            {
                return " تفرغ جزئى";
            }
            else if (test == 13)
            {
                return "تفرغ كلى";
            }
            else if (test == 14)
            {
                return "علاج طبيعى";
            }
            else if (test == 15)
            {
                return "مستشفى";
            }
            else if (test == 16)
            {
                return "منحة وفاة";
            }
            else if (test == 17)
            {
                return "منحة";
            }
            else if (test == 18)
            {
                return "نوبتجى";
            }
            else
            {
                return "موجود";
            }
        }

        public DateTime stringToDate(string date)
        {
            string[] messageDate = date.Trim().Split('/', '-');
            int dayM = int.Parse(messageDate[0]);
            int monthM = int.Parse(messageDate[1]);
            int yearM = int.Parse(messageDate[2]);
            DateTime dateTimeMessage = new DateTime(yearM, monthM, dayM);
            return dateTimeMessage;
        }

        protected void tmamTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}