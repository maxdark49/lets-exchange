using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Planning.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        PlanningDBEntities entities = new PlanningDBEntities();
        public List<OFFICER> OFFICERs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loaddata();
            }
        }

        protected void loaddata()
        {
            /////DropDownlist (weapons)_load//////
            var weapons = from o in entities.WEAPONS
                          select new
                          {
                              o.id,
                              o.Weapon_name

                          };
            DropDownList2.DataSource = weapons.ToList();
            DropDownList2.DataTextField = "Weapon_name";
            DropDownList2.DataValueField = "id";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem(String.Empty));
            ////////////////////////////////////

            /////DropDownlist (jobs)_load//////
            ///


            var freejobs = from o in entities.job_info
                           where !(from b in entities.OFFICERs select b.job_id).Contains(o.id)

                           select o;


            var jobs = from o in entities.job_info

                       select new
                       {
                           o.job_name,
                           o.id

                       };

           
            DropDownList3.DataSource = freejobs.ToList();
            DropDownList3.DataTextField = "job_name";
            DropDownList3.DataValueField = "id";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem(String.Empty));
         //   loadfreejobs();
            ////////////////////////////////////
        }

        protected void loadfreejobs()
        {

           
        }
        protected bool checkdata()
        {
            if(DropDownList1.SelectedIndex==0)
            {
                nameV.Visible = true;
                  return false;
            }
            else
            {
                nameV.Visible = false;
                if(DropDownList2.SelectedIndex==0)
                {
                    Label4.Visible = true;
                    return false;
                }
                else
                {
                    Label4.Visible = false;
                    if(DropDownList3.SelectedIndex==0)
                    {
                        Label6.Visible = true;
                        return false;
                    }
                    else
                    {
                        Label6.Visible = false;
                        string[] split = textbox1.Text.Split(' ');
                        if (split.Count() < 3)
                        {
                            Label1.Visible = true;
                            return false;
                        }
                        else
                        {
                            Label1.Visible = false;
                            if (textbox2.Text.Count() <= 0)
                            {
                                Label2.Visible = true;
                                return false;
                            }
                            else
                            {
                                Label2.Visible = false;
                                if (textbox3.Text.Count() <= 10)
                                {
                                    Label3.Text = "رقم التليفون يجب أن يكون صحيح";
                                    Label3.Visible = true;
                                    return false;
                                }
                                else
                                {
                                    Label3.Text = "يجب أن يكون هناك رقم هاتف";

                                    Label3.Visible = false;
                                    if (textbox4.Text.Count() <= 0)
                                    {
                                        Label5.Visible = true;
                                        return false;
                                    }
                                    else
                                    {
                                        Label5.Visible = false;
                                        return true;
                                    }
                                }

                            }

                        }
                    }
                    }
                }
                
            
               
                    }

        protected bool validatedata()
        {
            if(entities.OFFICERs.Any(o => o.O_name==textbox1.Text))
            {
                Label1.Text = "هذا الاسم موجود سابقاً";
                Label1.Visible = true;
                return false;
            }
            else
            {
                Label1.Text = "Name is Required ! (يجب أن يكون الأسم ثلاثيا)";
                Label1.Visible = false;
                int test = int.Parse(textbox4.Text);
                if(entities.OFFICERs.Any(o =>o.olde==test))
                {
                    Label5.Text = "هذا الرقم موجود سابقاً";
                    Label5.Visible = true;
                    return false;
                }
                else
                {
                    int test2 = int.Parse(DropDownList3.SelectedValue);

                    if(entities.OFFICERs.Any(o => o.job_id==test2))
                    {
                        Label6.Text = "يوجد من يشغل هذه الوظيفة بالفعل";
                        Label6.Visible = true;
                        return false;
                    }
                    else
                    {
                        Label6.Text = "يجب أن تختار وظيفة";
                        Label6.Visible = true;
                        return true;
                    }
                }
            }
        
        }
          

        
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            { nameV.Visible = true; }
            else
                nameV.Visible=false;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (DropDownList2.SelectedIndex == 0)
             { Label4.Visible = true; }
            else
                 Label4.Visible = false;
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedIndex == 0)
            { Label6.Visible = true; }
            else
                Label6.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkdata()==true)
            {
                if(validatedata()==true)
                {
                    Label7.Visible = false;
                    OFFICER newofficer =new OFFICER();
                    newofficer.rank = DropDownList1.SelectedValue;
                    newofficer.O_name = textbox1.Text;
                    newofficer.weapon_id = int.Parse(DropDownList2.SelectedValue);
                    newofficer.olde = int.Parse(textbox4.Text);
                    newofficer.address = textbox2.Text;
                    newofficer.telephone = textbox3.Text;
                    newofficer.job_id = int.Parse(DropDownList3.SelectedValue);
                    entities.OFFICERs.Add(newofficer);
                    entities.SaveChanges();
                    Response.Redirect("OFFICERS.aspx");
                }
                else
                {
                    Label7.Visible = true;
                }
            }
            else
            {
                Label7.Visible = true;

            }

        }

       
    }
}