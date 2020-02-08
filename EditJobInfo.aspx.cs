using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class EditJobInfo : System.Web.UI.Page
    {
        public int id;


        PlanningDBEntities entities = new PlanningDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                loaddata();
            }
        }

        protected void loaddata()
        {

            /////Textbox (job name)_load//////
            var curofficer = from o in entities.job_info
                             where o.id.Equals(id)
                             select new
                             {      
                                 o.job_name,
                             };
            var test = curofficer.First();
            TextBox1.Text = test.job_name;


            /////DropDownlist (Sector)_load//////

            var SR = from o in entities.SECTORS
                       select new
                       {
                           o.SR_name,
                           o.id

                       };

            SRlist.DataSource = SR.ToList();
            SRlist.DataTextField = "SR_name";
            SRlist.DataValueField = "id";
            SRlist.DataBind();
            SRlist.Items.Insert(0, new ListItem(String.Empty));
            loadselected();

            /////////////////////////////
            ///

            /////DropDownlist (dir)_load//////

            var dir = from o in entities.DIRECTIONS
                       select new
                       {
                           o.d_name,
                           o.id

                       };

            dirlist.DataSource = dir.ToList();
            dirlist.DataTextField = "d_name";
            dirlist.DataValueField = "id";
            dirlist.DataBind();
            dirlist.Items.Insert(0, new ListItem(String.Empty));
            loadselected2();

            /////////////////////////////
            ///

            /////DropDownlist (branch)_load//////

            var branch = from o in entities.BRANCHES
                      select new
                      {
                          o.B_name,
                          o.id

                      };

            BRlist.DataSource = branch.ToList();
            BRlist.DataTextField = "B_name";
            BRlist.DataValueField = "id";
            BRlist.DataBind();
            BRlist.Items.Insert(0, new ListItem(String.Empty));
            loadselected3();

            /////////////////////////////
            ///

            /////DropDownlist (sec)_load//////

            var sec = from o in entities.SECTIONS
                         select new
                         {
                             o.S_name,
                             o.id

                         };

            Slist.DataSource = sec.ToList();
            Slist.DataTextField = "S_name";
            Slist.DataValueField = "id";
            Slist.DataBind();
            Slist.Items.Insert(0, new ListItem(String.Empty));
            loadselected4();

            /////////////////////////////
            ///

            /////DropDownlist (ass)_load//////

            var ass = from o in entities.job_info
                      select new
                      {
                          o.job_name,
                          o.id

                      };

            asslist.DataSource = ass.ToList();
            asslist.DataTextField = "job_name";
            asslist.DataValueField = "id";
            asslist.DataBind();
            asslist.Items.Insert(0, new ListItem(String.Empty));
            loadselected5();

            /////////////////////////////
        }

        protected void loadselected5()
        {
            var result = from o in entities.job_info
                         where o.id.Equals(id)
                         select new
                         {
                             o.top_assossiated
                         };
            var test = result.First();
            asslist.SelectedValue = (test.top_assossiated).ToString();
        }

        protected void loadselected4()
        {
            var result = from o in entities.job_info
                         where o.id.Equals(id)
                         select new
                         {
                             o.section_id
                         };
            var test = result.First();
            Slist.SelectedValue = (test.section_id).ToString();
        }

        protected void loadselected3()
        {
            var result = from o in entities.job_info
                         where o.id.Equals(id)
                         select new
                         {
                             o.branch_id
                         };
            var test = result.First();
            BRlist.SelectedValue = (test.branch_id).ToString();
        }

        protected void loadselected2()
        {
            var result = from o in entities.job_info
                         where o.id.Equals(id)
                         select new
                         {
                             o.direction_id
                         };
            var test = result.First();
            dirlist.SelectedValue = (test.direction_id).ToString();
        }

        protected void loadselected()
        {
            var result = from o in entities.job_info
                         where o.id.Equals(id)
                         select new
                         {
                             o.sector_id
                         };
            var test = result.First();
            SRlist.SelectedValue = (test.sector_id).ToString();
        }

        protected void SRlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SRlist.SelectedIndex == 0)
            {
                jobv.Visible = true;
            }
            else
                jobv.Visible = false;

        }

        protected void dirlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dirlist.SelectedIndex == 0)
            {
                Label1.Visible = true;
            }
            else
                Label1.Visible = false;

        }

        protected void BRlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BRlist.SelectedIndex == 0)
            {
                Label2.Visible = true;
            }
            else
                Label2.Visible = false;

        }

        protected void Slist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Slist.SelectedIndex == 0)
            {
                Label3.Visible = true;
            }
            else
                Label3.Visible = false;

        }

        protected void asslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (asslist.SelectedIndex == 0)
            {
                Label4.Visible = true;
            }
            else
                Label4.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            job_info editofficer = entities.job_info.Find(id);
            editofficer.job_name = TextBox1.Text;
            editofficer.sector_id = int.Parse(SRlist.SelectedValue);
            editofficer.direction_id = int.Parse(dirlist.SelectedValue);
            editofficer.branch_id = int.Parse(BRlist.SelectedValue);
            editofficer.section_id = int.Parse(Slist.SelectedValue);
            editofficer.top_assossiated = int.Parse(asslist.SelectedValue);
            entities.SaveChanges();
            Response.Redirect("jobInfo.aspx");
        }
    }
}