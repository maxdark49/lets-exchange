using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class EditOFFICERS : System.Web.UI.Page
    {
        public List<OFFICER> OFFICERs;
        public int id;


        PlanningDBEntities entities = new PlanningDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["id"]);
           // this.accountType.SelectedIndexChanged += new System.EventHandler(accountType_SelectedIndexChanged);
            if (!IsPostBack)
            {
                
               loaddata();
            }
        }
        
        protected void loaddata()
        {

            /////DropDownlist (ranks)_load//////

            var ranks = from o in entities.OFFICERs
                         select new
                         {
                             o.rank

                         };

            accountType.DataSource = ranks.ToList();
            accountType.DataTextField = "rank";
            accountType.DataValueField = "rank";
            accountType.DataBind();
            accountType.Items.Insert(0, new ListItem(String.Empty));
            loadselected();
            /////////////////////////////


            /////DropDownlist (jobs)_load//////

            var jobs = from o in entities.job_info
                        select new
                        {
                            o.job_name,
                            o.id

                        };

            joblist.DataSource = jobs.ToList();
            joblist.DataTextField = "job_name";
            joblist.DataValueField = "id";
            joblist.DataBind();
            joblist.Items.Insert(0, new ListItem(String.Empty));
            loadselected2();
            
            /////////////////////////////


            /////DropDownlist (weapns)_load//////

            var weapons = from o in entities.WEAPONS
                       select new
                       {
                           o.Weapon_name,
                           o.id

                       };

            weaponlist.DataSource = weapons.ToList();
            weaponlist.DataTextField = "Weapon_name";
            weaponlist.DataValueField = "id";
            weaponlist.DataBind();
            weaponlist.Items.Insert(0, new ListItem(String.Empty));
            loadselected3();

            /////////////////////////////



            var curofficer = from o in entities.OFFICERs
                         join b in entities.job_info on o.job_id equals b.id
                         where o.id.Equals(id)
                         select new 
                         {
                            o.rank,
                              o.O_name,
                              o.telephone,
                              o.address,
                            o.job_id,
                          o.weapon_id,
                             o.study_id,
                      o.martial_status_id,
                            b.job_name

                         };
            var test = curofficer.First();
            TextBox1.Text = test.O_name;
            TextBox2.Text = test.address;
            TextBox3.Text = test.telephone;

           // accountType.SelectedValue = test.rank;
        }
        protected void loadselected()
        {
            var result = from o in entities.OFFICERs
                     where o.id.Equals(id)
                         select new
                         {
                             o.rank,
              
                         };
            var test = result.First();
            accountType.SelectedValue = test.rank;

        }


        protected void loadselected2()
        {
            var result = from o in entities.OFFICERs
                         join b in entities.job_info on o.job_id equals b.id
                         where o.id.Equals(id)
                         select new
                         {
                             b.id
                          //   b.job_name

                         };
            var test = result.First();
           // joblist.SelectedItem.Text = test.job_name;
            joblist.SelectedValue = test.id.ToString();
        }


        protected void loadselected3()
        {
            var result = from o in entities.OFFICERs
                         where o.id.Equals(id)
                         select new
                         {
                             o.weapon_id,

                         };
            var test = result.First();
            weaponlist.SelectedValue = (test.weapon_id).ToString();

        }
        protected void accountType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (accountType.SelectedIndex == 0)
            {
                nameV.Visible = true;
            }
            else
                nameV.Visible = false;
            }

        protected void joblist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(joblist.SelectedIndex==0)
            {
                jobv.Visible = true;
            }
            else
            jobv.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OFFICER editofficer = entities.OFFICERs.Find(id);
            editofficer.rank = accountType.SelectedValue.ToString();
            editofficer.O_name = TextBox1.Text;
            editofficer.address = TextBox2.Text;
            editofficer.telephone = TextBox3.Text;
            editofficer.job_id = int.Parse(joblist.SelectedValue);
            editofficer.weapon_id = int.Parse(weaponlist.SelectedValue);
            entities.SaveChanges();
            Response.Redirect("OFFICERS.aspx");
        }

        protected void DropDownList2_TextChanged(object sender, EventArgs e)
        {
            if (weaponlist.SelectedIndex == 0)
            { Label4.Visible = true; }
            else
                Label4.Visible = false;
        }
               

        
    }
}