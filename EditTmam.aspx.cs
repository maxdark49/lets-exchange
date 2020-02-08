using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class EditTmam : System.Web.UI.Page
    {
        PlanningDBEntities entities = new PlanningDBEntities();
        public List<STATE> sTATEs;
        public int id;

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
            var curofficer = from o in entities.STATEs
                             join b in entities.OFFICERs on o.officer_id equals b.id
                             join c in entities.TmamTypes on o.state1 equals c.Id
                             where o.id.Equals(id)
                             select new
                             { 
                                 b.O_name,
                                 o.Date,
                                 c.type_name
                             };
            var test = curofficer.First();
            Label5.Text = test.O_name;
            Label1.Text = test.Date.ToString("dd/MM/yyyy");



            var weapons = from o in entities.TmamTypes
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
            loadselected3();
        }

        protected void loadselected3()
        {
            var result = from o in entities.STATEs
                         where o.id.Equals(id)
                         select new
                         {
                             o.state1,

                         };
            var test = result.First();
            weaponlist.SelectedValue = (test.state1).ToString();

        }

        protected void weaponlist_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            STATE editofficer = entities.STATEs.Find(id);
            editofficer.state1 = int.Parse(weaponlist.SelectedValue);
            entities.SaveChanges();
            //Response.Redirect("Tmam.aspx");
        }
    } 
}