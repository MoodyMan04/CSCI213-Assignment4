using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213_Assignment4.Assignment4Work
{
    public partial class instructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get relative path to database
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

            // connect to database
            using (var db = new KarateSchoolDataContextDataContext(connString))
            {
                try
                {
                    int userID = getUserID(db);

                    welcomeUser(db, userID);

                    loadGridView(db, userID);   
                }
                catch (Exception)
                {
                    // error
                }
            }
        }

        private int getUserID(KarateSchoolDataContextDataContext db)
        {
            // get user id from database based on user name
            string userName = User.Identity.Name;

            var result1 = (from user in db.NetUsers
                           where user.UserName == userName
                           select user.UserID).Single();

            return Convert.ToInt32(result1);
        }

        private void welcomeUser(KarateSchoolDataContextDataContext db, int userID)
        {
            // get first and last name from database based on user id
            var result1 = (from instructor in db.Instructors
                           where instructor.InstructorID == userID
                           select instructor.InstructorFirstName).Single();

            var result2 = (from instructor in db.Instructors
                           where instructor.InstructorID == userID
                           select instructor.InstructorLastName).Single();

            // display name
            lblFirstName.Text = Convert.ToString(result1);
            lblLastName.Text = Convert.ToString(result2);
        }

        private void loadGridView(KarateSchoolDataContextDataContext db, int userID)
        {
            // update grid view of sections and members in sections
            // get section name
            var result1 = from section in db.Sections
                          where section.Instructor_ID == userID
                          select section.SectionName;

            // convert to list of sections
            string[] sectionNames = result1.ToArray();

            // make datatable to add to grid view
            DataTable dt = new DataTable();
            dt.Columns.Add("Sections", typeof(string));
            dt.Columns.Add("Member First Name", typeof(string));
            dt.Columns.Add("Member Last Name", typeof(string));

            // get all section ids to iterate through
            var result2 = from section in db.Sections
                          where section.Instructor_ID == userID
                          select section.SectionID;

            int[] sectionIDs = result2.ToArray();

            // get all members for each section and add it to dt
            for (int i = 0; i < sectionIDs.Length; i++)
            {
                // get member id of section
                var result3 = (from section in db.Sections
                               where section.SectionID == sectionIDs[i]
                               select section.Member_ID).Single();

                int memberID = Convert.ToInt32(result3);

                // get member first and last name from member id
                var result4 = (from member in db.Members
                               where member.Member_UserID == memberID
                               select member.MemberFirstName).Single();

                var result5 = (from member in db.Members
                               where member.Member_UserID == memberID
                               select member.MemberLastName).Single();

                string memberFirstName = Convert.ToString(result4);
                string memberLastName = Convert.ToString(result5);

                // add to dt
                DataRow dr = dt.NewRow();
                dr[0] = sectionNames[i];
                dr[1] = memberFirstName;
                dr[2] = memberLastName;
                dt.Rows.Add(dr);
            }

            // add data to grid view
            gvSections.DataSource = dt;
            gvSections.DataBind();
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("logon.aspx", true);
        }
    }
}