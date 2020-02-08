using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace Planning
{
       public partial class CompanyFields : System.Web.UI.Page
    {
        public List<OFFICER> OFFICERs;
       
        
        
        PlanningDBEntities entities = new PlanningDBEntities();
        int totalCount = 0;
        public int tableIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // getFields();
                getfields2();
            }
        }
        private void getFields()
        {
            


            int val = Convert.ToInt16(txtHidden.Value);
            tableIndex = val + 1;
            if (val <= 0)
                val = 0;
            totalCount = entities.OFFICERs.Count();
            if (totalCount - val < 20)
            {
                OFFICERs = entities.OFFICERs.ToList().GetRange(val, totalCount - val);
                
                
            }
            else
            {
                OFFICERs = entities.OFFICERs.ToList().GetRange(val, 20);

            }

            //companyFields = entities.Company_Field.ToList();
            
            
            rptrFields.DataSource = OFFICERs;

            rptrFields.DataBind();
          //  string result= rptrFields.
            

            if (val <= 0)
            {
                lnkBtnPrev.Visible = false;
                lnkBtnNext.Visible = true;
            }    

            if (val >= 20)
            {
                lnkBtnPrev.Visible = true;
                lnkBtnNext.Visible = true;
            }

            if ((val + 20) >= totalCount)
            {
                lnkBtnNext.Visible = false;
            }
        }

          private void getfields2()
        {
            var test = from o in entities.OFFICERs
                       join b in entities.job_info on o.job_id equals b.id
                       select new
                       {
                           o.id,
                           o.O_name,
                           o.rank,
                           b.job_name

                       };
                
             int val = Convert.ToInt16(txtHidden.Value);
            tableIndex = val + 1;
            if (val <= 0)
                val = 0;
            totalCount = test.Count();
            var test1=test.ToList();
            if (totalCount - val < 20)
            {
                test1 = test.ToList().GetRange(val, totalCount - val);

            }
            else
            {
                 test1 = test.ToList().GetRange(val, 20);

            }
            rptrFields.DataSource = test1.ToList();
            rptrFields.DataBind();
            if (val <= 0)
            {
                lnkBtnPrev.Visible = false;
                lnkBtnNext.Visible = true;
            }

            if (val >= 20)
            {
                lnkBtnPrev.Visible = true;
                lnkBtnNext.Visible = true;
            }

            if ((val + 20) >= totalCount)
            {
                lnkBtnNext.Visible = false;
            }
              
        }
        protected void lnkBtnPrev_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) - 20);
            getfields2();
        }
        protected void lnkBtnNext_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) + 20);
            getfields2();
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string searchStr = searchTxt.Text;

            var result = from o in entities.OFFICERs
                       join b in entities.job_info on o.job_id equals b.id 
                        where o.O_name.Contains(searchStr) || o.rank.Contains(searchStr) || b.job_name.Contains(searchStr)
                       select new
                       {
                           o.id,
                           o.O_name,
                           o.rank,
                           b.job_name

                       };


           // var result = entities.OFFICERs.Where(u => u.name.Contains(searchStr)).ToList();
            rptrFields.DataSource = result.ToList();
            rptrFields.DataBind();
            int val = Convert.ToInt16(txtHidden.Value);
            tableIndex = val + 1;
            if (val <= 0)
                val = 0;
            totalCount = result.Count();
            var test1 = result.ToList();
            if (totalCount - val < 20)
            {
                test1 = result.ToList().GetRange(val, totalCount - val);

            }
            else
            {
                test1 = result.ToList().GetRange(val, 20);

            }
            rptrFields.DataSource = test1.ToList();
            rptrFields.DataBind();
            if (val <= 0)
            {
                lnkBtnPrev.Visible = false;
                lnkBtnNext.Visible = true;
            }

            if (val >= 20)
            {
                lnkBtnPrev.Visible = true;
                lnkBtnNext.Visible = true;
            }

            if ((val + 20) >= totalCount)
            {
                lnkBtnNext.Visible = false;
            }

        }

        protected void addNew_Click(object sender, EventArgs e)
        {
            /*string newFieldStr = newField.Text.Trim();
            if (newFieldStr.Equals(""))
            {
                newFieldv.Visible = true;
                newField.BorderColor = Color.Red;
                getFields();
            }
            else if (entities.OFFICERs.Where(u => u.name.Equals(newFieldStr)).Count() > 0)
            {
                newFieldv.Text = "لا يمكن ادخال 2 ضباط للعمل بنفس الإسم!";
                newFieldv.Visible = true;
                newField.BorderColor = Color.Red;
                getFields();
            }
            else
            {

                OFFICER f = new OFFICER();
                f.name = newFieldStr;
                entities.OFFICERs.Add(f);
                entities.SaveChanges();
                newField.Text = "";
                newField.BorderColor = Color.Empty;
                newFieldv.Visible = false;
                getFields();
            }*/
            Response.Redirect("AddOFFICERS.aspx");
        }




        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton b = sender as LinkButton;
                int fieldID = int.Parse(b.CommandArgument);
                var deleteField = entities.OFFICERs.Where(u => u.id == fieldID).First();
               // var deleteComFields = entities.Company_Field_Reg.Where(u => u.field_id == fieldID).ToList();
               // entities.Company_Field_Reg.RemoveRange(deleteComFields);
                entities.OFFICERs.Remove(deleteField);
                entities.SaveChanges();
                getfields2();
            }
            catch (Exception ex)
            {
                getfields2();
            }
        }






    }
}