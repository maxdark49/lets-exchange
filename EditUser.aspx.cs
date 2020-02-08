using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Net.Mail;

namespace Planning
{
    public partial class EditUser : System.Web.UI.Page
    {
        PlanningDBEntities entities = new PlanningDBEntities();
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["id"]);
            if (!IsPostBack)
            {

                PopulateData();
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersPage.aspx");

        }

        protected void save_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                User editUser = entities.Users.Find(id);
                editUser.name = name.Text.ToLower();
                editUser.job = job.Text;
                if (!password.Text.Trim().Equals(""))
                {
                    editUser.password = getHashPassword(password.Text);
                }
                if (isAdmin.Checked == true)
                {
                    editUser.is_admin = true;
                }
                var selected = accountType.SelectedValue;
                if (selected.Equals("officer"))
                {
                    editUser.account_type = 1;
                }
                else if (selected.Equals("archiverSold"))
                {
                    editUser.account_type = 2;
                }
                else if (selected.Equals("techSold"))
                {
                    editUser.account_type = 3;
                }
                entities.SaveChanges();
                Response.Redirect("UsersPage.aspx");
            }
        }

        private string getHashPassword(string pass)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(pass);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
        private bool ValidateData()
        {
            bool state = false;
            string[] nameErrors = { "Name is Required ! (3 Letters Minimum)", "Username is already exists, Please choose another one!" };
            if (name.Text.Length < 2)
            {
                nameV.Text = nameErrors[0];
                nameV.Visible = true;
                name.BorderColor = Color.Red;
                state = true;
            }
            else if (entities.Users.Where(u => u.id != id && u.name.Equals(name.Text.ToLower())).Count() > 0)
            {
                nameV.Text = nameErrors[1];
                nameV.Visible = true;
                name.BorderColor = Color.Red;
                state = true;
            }
            else
            {
                nameV.Visible = false;
                name.BorderColor = Color.Empty;
            }
            if (passwordCB.Checked)
            {
                if (password.Text.Length < 2)
                {
                    passwordV.Visible = true;
                    password.BorderColor = Color.Red;
                    state = true;
                }
                else
                {
                    passwordV.Visible = false;
                    password.BorderColor = Color.Empty;
                }
            }
            if (job.Text.Length < 2)
            {
                jobV.Visible = true;
                job.BorderColor = Color.Red;
                state = true;
            }
            else
            {
                jobV.Visible = false;
                job.BorderColor = Color.Empty;
            }
            if (accountType.SelectedIndex == 0 && !isAdmin.Checked)
            {
                accountTypeV.Visible = true;
                accountType.BorderColor = Color.Red;
                state = true;
            }
            else
            {
                accountTypeV.Visible = false;
                accountType.BorderColor = Color.Empty;
            }

            return state;

        }
        

        private void PopulateData()
        {
            User user = entities.Users.Find(id);
            name.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(user.name);
            job.Text = user.job;

            if (user.is_admin == true)
            {
                isAdmin.Checked = true;
                accountType.Enabled = false;
                accountType.BackColor = Color.FromName("#cccccc");
            }
            switch (user.account_type)
            {
                case 1:
                    accountType.SelectedIndex = 1; break;
                case 2:
                    accountType.SelectedIndex = 2; break;
                case 3:
                    accountType.SelectedIndex = 3; break;
                    
            }
        }

        protected void passwordCB_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordCB.Checked)
            {
                password.Enabled = true;
                password.BackColor = Color.White;
            }
            else
            {
                password.Enabled = false;
                password.BackColor = Color.FromName("#cccccc");

            } 
            if (!isAdmin.Checked)
            {
                accountType.Enabled = true;
                accountType.BackColor = Color.White;
            }
            else
            {
                accountType.SelectedIndex = 0;
                accountType.Enabled = false;
                accountType.BackColor = Color.FromName("#cccccc");

            }
        }

        protected void isAdmin_CheckedChanged(object sender, EventArgs e)
        {
           
            if (!isAdmin.Checked)
            {
                accountType.Enabled = true;
                accountType.BackColor = Color.White;
            }
            else
            {
                accountType.SelectedIndex = 0;
                accountType.Enabled = false;
                accountType.BackColor = Color.FromName("#cccccc");

            }
            if (passwordCB.Checked)
            {
                password.Enabled = true;
                password.BackColor = Color.White;
            }
            else
            {
                password.Enabled = false;
                password.BackColor = Color.FromName("#cccccc");

            } 
        }
        
    }
}