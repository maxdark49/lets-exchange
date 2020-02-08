using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class BRInfo : System.Web.UI.Page
    {
        public List<BRANCH> bRANCHes;
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

            var test = from o in entities.BRANCHES
                       join b in entities.SECTORS on o.sector_id equals b.id
                       select new
                       {
                           o.id,
                           o.B_name,
                           b.SR_name
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
                var deleteField = entities.BRANCHES.Where(u => u.id == fieldID).First();

                entities.BRANCHES.Remove(deleteField);
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