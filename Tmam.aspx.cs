using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class Tmam : System.Web.UI.Page
    {
        public List<OFFICER> OFFICERs;
        PlanningDBEntities entities = new PlanningDBEntities();
        public int tableIndex;

        public int mawgod;
        public int sanwya;
        public int arda;
        public int tarka;
        public int mardy;
        public int raha; 
        public int ferka;
        public int m_khargy;
        public int mamorya;
        public int olya;
        public int bohos;
        public int gozy;
        public int kolly;
        public int elag;
        public int mostshfa;
        public int wafah;
        public int menha;
        public int nobatshy;
        public int khareg;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                getfields();
            }

            
            System.Globalization.DateTimeFormatInfo HDTF = new System.Globalization.CultureInfo("ar-SA", false).DateTimeFormat;
            HDTF.Calendar = new System.Globalization.HijriCalendar();
            var s = DateTime.Now.ToString("dddd", HDTF);
            var f = DateTime.Now.ToString("d MMMM yyyy", HDTF);


            System.Globalization.DateTimeFormatInfo GDTF = new System.Globalization.CultureInfo("en-US", false).DateTimeFormat;
            GDTF.MonthGenitiveNames = new string[] { "يناير" , "فبراير" , "مارس" , "أبريل" , "مايو" , "يونيو" , "يوليو" , "أغسطس" , "سبتمبر" , "أكتوبر" , "نوفمبر" , "ديسمبر" , "" };
            var h = DateTime.Now.ToString("d MMMM yyyy", GDTF);


            subject.Text = "يومية تمام الضباط عن يوم " + s + " الموافق " + "\"" + h + "م\" " + "\"" + f + "هـ\"";
        }

        private void getfields()
        {
            
            var test = from o in entities.OFFICERs
                       select new
                       {
                           o.id,
                           o.O_name,
                           o.rank,
                       };
            
            tableIndex += 1;
            rptrFields.DataSource = test.ToList();
            rptrFields.DataBind();
            int count = rptrFields.Items.Count;
            Label91.Text = count.ToString();
        }
        /*
        private void getfields2()
        {
            int count = rptrFields.Items.Count;
            var test = from o in entities.STATEs
                       select new
                       {
                           
                       };

            Repeater1.DataSource = test.ToList();
            Repeater1.DataBind();
        }*/

        protected void SaveButton_Click(object sender, EventArgs e)
        {

            /*STATE newstate = new STATE();
               Tmam newTman = new Tmam();
                LinkButton b = sender as LinkButton;
                int fieldID = int.Parse(b.CommandArgument);
                var Field = entities.OFFICERs.Where(u => u.id == fieldID).First();*/

            //int count = rptrFields.Items.Count;
           
            STATE nState = new STATE();
            for (int x=0;x<rptrFields.Items.Count;x++)
            {
                //string officername= rptrFields.Controls[x].Controls[0].
                
                Label officeridlabel = (Label)rptrFields.Controls[x].FindControl("Label3");
                DropDownList statedrop = (DropDownList)rptrFields.Controls[x].Controls[1].FindControl("accountType");
                string officerstate = statedrop.SelectedValue.ToString();
                string officerid = officeridlabel.Text;
                nState.officer_id = int.Parse(officerid);
                nState.state1 = int.Parse(officerstate);
                string date1 = DateTime.Now.ToString("d/MM/yyyy");
                //var datestr = stringToDate(date1);
                nState.Date = Convert.ToDateTime(date1);

                entities.STATEs.Add(nState);
                entities.SaveChanges();
                
                //   var Field = entities.OFFICERs.Where(u => u.id == x).First();
                //    
                //     nState.Date = System.DateTime.Now;
                //  nState.state1 =;
                //   entities.STATEs.Add(nState);
                //  entities.SaveChanges();

            }
            Response.Redirect("OFFICERS.aspx");

            // var deleteComFields = entities.Company_Field_Reg.Where(u => u.field_id == fieldID).ToList();
            // entities.Company_Field_Reg.RemoveRange(deleteComFields);

            //entities.Tmams.Add(newTman);
            //entities.SaveChanges();
        }

        protected void accountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int x = 0; x < rptrFields.Items.Count; x++)
             {
                 DropDownList statedrop = (DropDownList)rptrFields.Controls[x].Controls[1].FindControl("accountType");
                if(statedrop.Text == "2")
                {
                    sanwya += 1;
                } else if(statedrop.Text == "3")
                {
                    arda += 1;
                } else if(statedrop.Text == "4")
                {
                    tarka += 1;
                } else if(statedrop.Text == "5")
                {
                    mardy += 1;
                } else if(statedrop.Text == "6")
                {
                    raha += 1;
                } else if(statedrop.Text == "7")
                {
                    ferka += 1;
                } else if(statedrop.Text == "8")
                {
                    m_khargy += 1;
                } else if(statedrop.Text == "9")
                {
                    mamorya += 1;
                } else if(statedrop.Text == "10")
                {
                    olya += 1;
                } else if(statedrop.Text == "11")
                {
                    bohos += 1;
                } else if(statedrop.Text == "12")
                {
                    gozy += 1;
                } else if(statedrop.Text == "13")
                {
                    kolly += 1;
                } else if(statedrop.Text == "14")
                {
                    elag += 1;
                } else if(statedrop.Text == "15")
                {
                    mostshfa += 1;
                } else if(statedrop.Text == "16")
                {
                    wafah += 1;
                } else if(statedrop.Text == "17")
                {
                    menha += 1;
                } else if(statedrop.Text == "18")
                {
                    nobatshy += 1;
                }
                else
                {
                    mawgod += 1;
                }

             }
            khareg = rptrFields.Items.Count - mawgod;
            
            Label4.Text = mawgod.ToString();
            Label5.Text = sanwya.ToString();
            Label6.Text = arda.ToString();
            Label7.Text = tarka.ToString();
            Label8.Text = mardy.ToString();
            Label9.Text = raha.ToString();
            Label10.Text = ferka.ToString();
            Label11.Text = m_khargy.ToString();
            Label12.Text = mamorya.ToString();
            Label13.Text = olya.ToString();
            Label14.Text = bohos.ToString();
            Label15.Text = gozy.ToString();
            Label16.Text = kolly.ToString();
            Label17.Text = elag.ToString();
            Label18.Text = mostshfa.ToString();
            Label19.Text = wafah.ToString();
            Label20.Text = menha.ToString();
            Label21.Text = nobatshy.ToString();
            Label22.Text = khareg.ToString();
        }

        protected void day_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tmam_day.aspx");
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
    }
   
}