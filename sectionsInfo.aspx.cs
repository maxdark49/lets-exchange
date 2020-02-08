using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class sectionsInfo : System.Web.UI.Page
    {
        public List<SECTION> sECTIONs;
        PlanningDBEntities entities = new PlanningDBEntities();
        public int tableIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getfields();
            }
        }

        private void getfields()
        {

            var test = from o in entities.SECTIONS
                       join b in entities.BRANCHES on o.id equals b.id
                       select new
                       {
                           o.id,
                           o.S_name,
                           b.B_name
                       };

            tableIndex += 1;
            rptrFields.DataSource = test.ToList();
            rptrFields.DataBind();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton b = sender as LinkButton;
                int fieldID = int.Parse(b.CommandArgument);
                var deleteField = entities.SECTIONS.Where(u => u.id == fieldID).First();

                entities.SECTIONS.Remove(deleteField);
                entities.SaveChanges();
                getfields();
            }
            catch (Exception ex)
            {
                getfields();
            }
        }
    }
}