using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213_Assignment4.Assignment4Work
{
    public partial class member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validates user type
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() != "Member")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("logon.aspx", true);
                }
            }

            //get user id
            int currentUserID = Convert.ToInt32(HttpContext.Current.Session["userID"]);


            // get relative path to database
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

            //Display first and last name
            using (var db = new KarateSchoolDataContextDataContext(connString))
            {
                try
                {
                    // get first name
                    var fName = (from m in db.Members
                                 where m.Member_UserID == currentUserID
                                 select m.MemberFirstName).First();

                    //Get last name
                    var lName = (from m in db.Members
                                 where m.Member_UserID == currentUserID
                                 select m.MemberLastName).First();

                    //Display first and last name
                    lblFirstName.Text = Convert.ToString(fName);
                    lblLastName.Text = Convert.ToString(lName);
                }
                catch (Exception ex)
                {
                    //error
                }
            }



            //load GridView
            // connect to database
            using (var db = new KarateSchoolDataContextDataContext(connString))
            {
                try
                {
                    // get data for GridView
                    var result = (from s in db.Sections
                                  join i in db.Instructors on s.Instructor_ID equals i.InstructorID
                                  where s.Member_ID == currentUserID
                                  select new
                                  {
                                      SectionName = s.SectionName,
                                      InstructorFirstName =
                                               i.InstructorFirstName,
                                      InstructorlastName = i.InstructorLastName,
                                      PaymentDate = s.SectionStartDate,
                                      Payment = s.SectionFee
                                  });
                    //add data to the GridView
                    GridView1.DataSource = result;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    //error
                }
            }
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("logon.aspx", true);
        }
    }
}