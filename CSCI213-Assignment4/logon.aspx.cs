using CSCI213_Assignment4.Assignment4Work;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CSCI213_Assignment4
{
    public partial class logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            // get relative path to database
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

            // connect to database
            using (var db = new KarateSchoolDataContextDataContext(connString))
            {
                try
                {
                    // get password from user name
                    var result1 = (from user in db.NetUsers
                                   where user.UserName == Login1.UserName
                                   select user.UserPassword).First();

                    // get user type from user name
                    var result2 = (from user in db.NetUsers
                                   where user.UserName == Login1.UserName
                                   select user.UserType).First();

                    // convert to string
                    string password = Convert.ToString(result1);
                    string userType = Convert.ToString(result2);

                    // check credentials and redirect if valid
                    if (Login1.Password == password)
                    {
                        if (userType == "Member")
                            Response.Redirect("~/Assignment4Work/member.aspx", true);
                        else if (userType == "Instructor")
                            Response.Redirect("~/Assignment4Work/instructor.aspx", true);
                        else if (userType == "Administrator")
                            Response.Redirect("~/Assignment4Work/administrator.aspx", true);
                    }
                    else
                    {
                        // error
                    }
                    
                }
                catch (SqlException)
                {
                    // error
                }
                catch (InvalidOperationException)
                {
                    // error
                }

            }
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {
            Login1.FailureText = "Your user name and/or password was incorrect. Please try again.";
        }
    }
}