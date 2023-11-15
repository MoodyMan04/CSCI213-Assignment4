using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                    // get user id from database based on user name
                    string userName = User.Identity.Name;
                    lblLastName.Text = userName;

                    var result1 = (from user in db.NetUsers
                                   where user.UserName == userName
                                   select user.UserID).First();

                    int userID = Convert.ToInt32(result1);

                    // get first and last name from database based on user id
                    var result2 = (from instructor in db.Instructors
                                   where instructor.InstructorID == userID
                                   select instructor.InstructorFirstName).First();

                    var result3 = (from instructor in db.Instructors
                                   where instructor.InstructorID == userID
                                   select instructor.InstructorLastName).First();

                    string firstName = Convert.ToString(result2);
                    string lastName = Convert.ToString(result3);

                    // display first and last name
                    lblFirstName.Text = firstName;
                    lblLastName.Text = lastName;
                }
                catch (Exception)
                {
                    lblFirstName.Text = "error";
                }
            }
        }
    }
}