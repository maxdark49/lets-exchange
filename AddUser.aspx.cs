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
    public partial class AddUser : System.Web.UI.Page
    {
        PlanningDBEntities entities = new PlanningDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                User newUser = new User();
                newUser.name = name.Text.ToLower();
                newUser.job = job.Text;
                newUser.is_admin = false;
                newUser.password = getHashPassword(password.Text);

                if (isAdmin.Checked == true)
                {
                    newUser.is_admin = true;
                }
                var selected = accountType.SelectedValue;
                if (selected.Equals("officer"))
                {
                    newUser.account_type = 1;
                }
                else if (selected.Equals("archiverSold"))
                {
                    newUser.account_type = 2;
                }
                else if (selected.Equals("techSold"))
                {
                    newUser.account_type = 3;
                }
                entities.Users.Add(newUser);
                entities.SaveChangesAsync();
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
            else if (entities.Users.Where(u => u.name.Equals(name.Text.ToLower())).Count() > 0)
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
        }

        protected void accountType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}