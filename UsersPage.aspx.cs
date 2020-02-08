using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning
{
    public partial class UsersPage : System.Web.UI.Page
    {
        public List<User> users;

        int totalCount = 0;
        public int tableIndex;

        PlanningDBEntities entities = new PlanningDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                getUserTable();
            }
        }
        private void getUserTable()
        {

            int val = Convert.ToInt16(txtHidden.Value);
            tableIndex = val + 1;
            if (val <= 0)
                val = 0;
            totalCount = entities.Users.Count();
            if (totalCount - val < 20)
            {
                users = entities.Users.ToList().GetRange(val, totalCount - val);
            }
            else
            {
                users = entities.Users.ToList().GetRange(val, 20);

            }
            //rptrCompanines.DataSource = companies;
            //rptrCompanines.DataBind();
            rptrUsers.DataSource = users;
            rptrUsers.DataBind();

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
        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string searchStr = searchTxt.Text;
            int val = Convert.ToInt16(txtHidden.Value);
            var result = searchForUser(searchStr);
            tableIndex = val + 1;
            rptrUsers.DataSource = result;
            rptrUsers.DataBind();
        }

        protected void addNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adduser.aspx");
        }

        protected void lnkBtnPrev_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) - 20);
            getUserTable();
        }

        protected void lnkBtnNext_Click(object sender, EventArgs e)
        {
            txtHidden.Value = Convert.ToString(Convert.ToInt16(txtHidden.Value) + 20);
            getUserTable();
        }


        private List<User> searchForUser(string searchStr)
        {

            List<User> result = new List<User>();

            result = entities.Users.Where(u => u.name.Contains(searchStr)).ToList();


            return result;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton b = sender as LinkButton;
                int userID = int.Parse(b.CommandArgument);
                var deleteUser = entities.Users.Where(u => u.id == userID).First();
                entities.Users.Remove(deleteUser);
                entities.SaveChanges();
                getUserTable();
            }
            catch (Exception ex)
            {
                getUserTable();
            }
        }
        public string capFirst(string str)
        {
           return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str);
        }
    }
}