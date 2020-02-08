using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning
{
    public partial class Site : System.Web.UI.MasterPage
    {
        PlanningDBEntities entitiesMaster = new PlanningDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            var pageName = Page.ToString().Substring(4).ToLower();
            if (Session["UserID"] == null)
            {
                if (!pageName.Contains("login"))
                {
                    Session["lastUrl"] = Request.Url.AbsoluteUri;
                    Response.Redirect("~/Login.aspx");
                }

            }
            else
            {
                if (pageName.Contains("admin"))
                {
                    var res = entitiesMaster.Users.Find(Session["UserID"]).is_admin;
                    if (res != true)
                    {
                        Response.Redirect("~/Home.aspx");
                    }
                }
                if (Session["AccountType"] == null && !pageName.Contains("admin"))
                {
                    Response.Redirect("~/Admin/UsersPage.aspx");
                }
                else if (Session["AccountType"] != null)
                {
                    if (int.Parse(Session["AccountType"] + "") == 2 && (pageName.Contains("companies") || pageName.Contains("experts")))
                    {
                        Response.Redirect("~/Home.aspx");
                    }
                    if (int.Parse(Session["AccountType"] + "") == 3 && pageName.Contains("messages"))
                    {
                        Response.Redirect("~/Home.aspx");
                    }
                }
            }
        }

        public string checkSelected(string pageName)
        {
            if(Page.ToString().ToLower().Contains(pageName)){
                if(pageName.Equals("message")){
                    return "background-color: #00A0EB; color: #fff; font-weight: bold;";
                }
                return "start selected";
            }
            return "";
        }
    }
}