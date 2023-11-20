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
            // get relative path to database
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

            //Display information
            using (var db = new KarateSchoolDataContextDataContext(connString))
            {
                try
                {
                    int UID = getUserID(db);
                    setNames(db, UID);
                    setGridView(db, UID);
                }
                catch (Exception)
                {
                    //error
                }
            }
        }

        private int getUserID(KarateSchoolDataContextDataContext db)
        {
            // get user id from database based on user name
            string userName = User.Identity.Name;

            var result1 = (from user in db.NetUsers
                           where user.UserName == userName
                           select user.UserID).First();

            return Convert.ToInt32(result1);
        }
        private void setNames(KarateSchoolDataContextDataContext db,int userID)
        {
            // get first name
            var fName = (from m in db.Members
                         where m.Member_UserID == userID
                         select m.MemberFirstName).First();

            //Get last name
            var lName = (from m in db.Members
                         where m.Member_UserID == userID
                         select m.MemberLastName).First();

            //Display first and last name
            lblFirstName.Text = Convert.ToString(fName);
            lblLastName.Text = Convert.ToString(lName);
        }

        private void setGridView(KarateSchoolDataContextDataContext db, int userID)
        {
            // get data for GridView
            var result = (from s in db.Sections
                          join i in db.Instructors on s.Instructor_ID equals i.InstructorID
                          where s.Member_ID == userID
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

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("logon.aspx", true);
        }
    }
}