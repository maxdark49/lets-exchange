using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class AddJob : System.Web.UI.Page
    {
        PlanningDBEntities entities = new PlanningDBEntities();
        public List<job_info> job_Infos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loaddata();
            }
        }

        protected void loaddata()
        {
            /////DropDownlist (SR)_load//////
            ///
            var SR = from o in entities.SECTORS
                          select new
                          {
                              o.id,
                              o.SR_name

                          };
            DropDownList1.DataSource = SR.ToList();
            DropDownList1.DataTextField = "SR_name";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem(String.Empty));

            ////////////////////////////////////

            /////DropDownlist (dir)_load//////
            ///
            var dir = from o in entities.DIRECTIONS
                          select new
                          {
                              o.id,
                              o.d_name

                          };
            DropDownList2.DataSource = dir.ToList();
            DropDownList2.DataTextField = "d_name";
            DropDownList2.DataValueField = "id";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem(String.Empty));

            ////////////////////////////////////
            ///

            /////DropDownlist (dir)_load//////
            ///
            var BR = from o in entities.BRANCHES
                      select new
                      {
                          o.id,
                          o.B_name

                      };
            DropDownList3.DataSource = BR.ToList();
            DropDownList3.DataTextField = "B_name";
            DropDownList3.DataValueField = "id";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem(String.Empty));

            ////////////////////////////////////
            ///

            /////DropDownlist (dir)_load//////
            ///
            var SC = from o in entities.SECTIONS
                     select new
                     {
                         o.id,
                         o.S_name

                     };
            DropDownList4.DataSource = SC.ToList();
            DropDownList4.DataTextField = "S_name";
            DropDownList4.DataValueField = "id";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, new ListItem(String.Empty));

            ////////////////////////////////////
            ///

            /////DropDownlist (dir)_load//////
            ///
            var of = from o in entities.job_info
                     select new
                     {
                         o.id,
                         o.job_name

                     };
            DropDownList5.DataSource = of.ToList();
            DropDownList5.DataTextField = "job_name";
            DropDownList5.DataValueField = "id";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, new ListItem(String.Empty));

            ////////////////////////////////////
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            { Label6.Visible = true; }
            else
                Label6.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                    job_info newofficer = new job_info();
                    newofficer.job_name = textbox1.Text;
            newofficer.sector_id = int.Parse(DropDownList1.SelectedValue);
            newofficer.direction_id = int.Parse(DropDownList2.SelectedValue);
            newofficer.branch_id = int.Parse(DropDownList3.SelectedValue);
            newofficer.section_id = int.Parse(DropDownList4.SelectedValue);
            newofficer.top_assossiated = int.Parse(DropDownList5.SelectedValue);
            entities.job_info.Add(newofficer);
                    entities.SaveChanges();
                    Response.Redirect("jobInfo.aspx");
                
              
            
            

        }
    }
}