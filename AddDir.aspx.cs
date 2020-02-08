using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class AddDir : System.Web.UI.Page
    {
        PlanningDBEntities entities = new PlanningDBEntities();
        public List<DIRECTION> dIRECTIONs;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            DIRECTION newofficer = new DIRECTION();
            newofficer.d_name = textbox1.Text;
            entities.DIRECTIONS.Add(newofficer);
            entities.SaveChanges();
            Response.Redirect("SecInfo.aspx");
        }
    }
}