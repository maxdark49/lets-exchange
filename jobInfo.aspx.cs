using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class jobInfo : System.Web.UI.Page
    {
        //public int direction;


        public List<OFFICER> OFFICERs;
        public List<job_info> jobs;
        PlanningDBEntities entities = new PlanningDBEntities();
        public int tableIndex;
        int totalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getfields();
            }

        }


        private void getfields()
        {
            var test = from o in entities.job_info
                       join b in entities.SECTORS on o.sector_id equals b.id
                       join c in entities.DIRECTIONS on o.direction_id equals c.id 
                       join d in entities.SECTIONS on o.section_id equals d.id
                       join e in entities.BRANCHES on o.branch_id equals e.id
                       
                       select new
                       {
                           o.id,
                           o.job_name,
                           c.d_name,
                           e.B_name,
                           b.SR_name,
                           d.S_name,
                           o.top_assossiated
                           
                       };

            int val = Convert.ToInt16(txtHidden.Value);
            tableIndex = val + 1;
            if (val <= 0)
                val = 0;
            totalCount = test.Count();
            var test1 = test.ToList();
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
            getfields();
        }
        protected void lnkBtnNext_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) + 20);
            getfields();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton b = sender as LinkButton;
                int fieldID = int.Parse(b.CommandArgument);
                var deleteField = entities.job_info.Where(u => u.id == fieldID).First();
                // var deleteComFields = entities.Company_Field_Reg.Where(u => u.field_id == fieldID).ToList();
                // entities.Company_Field_Reg.RemoveRange(deleteComFields);
                entities.job_info.Remove(deleteField);
                entities.SaveChanges();
                getfields();
            }
            catch (Exception ex)
            {
                getfields();
            }
        }

        protected void addNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddJob.aspx");
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string searchStr = searchTxt.Text;

            var result = from o in entities.job_info
                       join b in entities.SECTORS on o.sector_id equals b.id
                       join c in entities.DIRECTIONS on o.direction_id equals c.id
                       join d in entities.SECTIONS on o.section_id equals d.id
                       join f in entities.BRANCHES on o.branch_id equals f.id
                         where o.job_name.Contains(searchStr) /*|| b.SR_name.Contains(searchStr)*/
                         select new
                       {
                           o.id,
                           o.job_name,
                           c.d_name,
                           f.B_name,
                           b.SR_name,
                           d.S_name,
                           o.top_assossiated
                       };

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
                lnkBtnNext.Visible = false;
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






            /*  var result = from o in entities.job_info
                           join b in entities.SECTORS on o.id equals b.id
                           join c in entities.DIRECTIONS on o.direction_id equals c.id
                           join d in entities.SECTIONS on o.section_id equals d.id
                           join z in entities.BRANCHES on o.branch_id equals z.id
                           where o.job_name.Contains(searchStr) || b.SR_name.Contains(searchStr)
                           select new
                           {
                               o.id,
                               o.job_name,
                               c.d_name,
                               z.B_name,
                               b.SR_name,
                               d.S_name,
                               o.top_assossiated;

                           };


              rptrFields.DataSource = result.ToList();
              rptrFields.DataBind();
              int val = Convert.ToInt16(txtHidden.Value);
              tableIndex = val + 1;*/
        }
        
        protected string  gettopname (int id)
        {
            if (id == 0)
                return "لا يوجد";
            else
            {
                var resutlt = entities.job_info.Find(id);

                return resutlt.job_name;
            }
        }
    }
}