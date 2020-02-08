using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class DirInfo : System.Web.UI.Page
    {
        public List<DIRECTION> dIRECTIONs;
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

            var test = from o in entities.DIRECTIONS
                       select new
                       {
                           o.id,
                           o.d_name,
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
                var deleteField = entities.DIRECTIONS.Where(u => u.id == fieldID).First();
                // var deleteComFields = entities.Company_Field_Reg.Where(u => u.field_id == fieldID).ToList();
                // entities.Company_Field_Reg.RemoveRange(deleteComFields);
                entities.DIRECTIONS.Remove(deleteField);
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