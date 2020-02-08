using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class AddSector : System.Web.UI.Page
    {
        PlanningDBEntities entities = new PlanningDBEntities();
        public List<SECTOR> sECTORs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loaddata();
            }

        }

        protected void loaddata()
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SECTOR newofficer = new SECTOR();
            newofficer.SR_name = textbox1.Text;
            entities.SECTORS.Add(newofficer);
            entities.SaveChanges();
            Response.Redirect("SecInfo.aspx");
        }
    }
}