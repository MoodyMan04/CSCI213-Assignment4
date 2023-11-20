using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213_Assignment4.Assignment4Work
{
    public partial class administrator : System.Web.UI.Page
    {
        // get relative path to database
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            // connect to database
            using (var db = new KarateSchoolDataContextDataContext(connString))
            {
                try
                {
                    setMemberGV(db);
                    setInstructorGV(db);
                }
                catch (Exception)
                {
                    // error
                }
            }
        }

        private void setMemberGV(KarateSchoolDataContextDataContext db)
        {
            // get data for GridView
            var result = (from m in db.Members
                          select new
                          {
                              First_Name = m.MemberFirstName,
                              Last_Name = m.MemberLastName,
                              Phone_Number = m.MemberPhoneNumber,
                              Date_Joined = m.MemberDateJoined,
                          });
            //add data to the GridView
            MemberGridView.DataSource = result;
            MemberGridView.DataBind();
        }

        private void setInstructorGV(KarateSchoolDataContextDataContext db)
        {
            // get data for GridView
            var result = (from i in db.Instructors
                          select new
                          {
                              First_Name = i.InstructorFirstName,
                              Last_Name = i.InstructorLastName
                          });
            //add data to the GridView
            InstructorGridView.DataSource = result;
            InstructorGridView.DataBind();
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            // connect to database
            using (var db = new KarateSchoolDataContextDataContext(connString))
            {
                try
                {
                    //Create Section
                    Section newSec = new Section
                    {
                        SectionName = txtSectionName.Text,
                        SectionStartDate = Convert.ToDateTime(txtStartDate.Text),
                        Member_ID = Convert.ToInt32(txtAssignMemID.Text),
                        Instructor_ID = Convert.ToInt32(txtAssignInID.Text),
                        SectionFee = Convert.ToDecimal(txtCost.Text)
                    };

                    //Section is added to Database
                    db.Sections.InsertOnSubmit(newSec);
                    db.SubmitChanges();

                    //Error label is hidden
                    lblAssignError.Visible = false;
                }
                catch (Exception)
                {
                    //Displays error label
                    lblAssignError.Visible = true;
                }

            }
        }

        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            // connect to database
            using (var db = new KarateSchoolDataContextDataContext(connString))
            {
                try
                {  
                    // adding new user
                    NetUser newUser = new NetUser
                    {
                        UserName = tbMemberUserName.Text,
                        UserPassword = tbMemberPassword.Text,
                        UserType = "Member"
                    };

                    db.NetUsers.InsertOnSubmit(newUser);
                    db.SubmitChanges();

                    // get userID
                    var result = (from user in db.NetUsers
                                  where user.UserName == tbMemberUserName.Text
                                  select user.UserID).Single();

                    // add new member
                    Member newMember = new Member
                    {
                        Member_UserID = Convert.ToInt32(result),
                        MemberFirstName = tbMemberFirstname.Text,
                        MemberLastName = tbMemberLastname.Text,
                        MemberDateJoined = DateTime.Now,
                        MemberPhoneNumber = tbMemberPhoneNumber.Text,
                        MemberEmail = tbMemberEmail.Text
                    };

                    db.Members.InsertOnSubmit(newMember);
                    db.SubmitChanges();

                    // remove error
                    lblInvalidMember.Visible = false;

                    // update gv
                    setMemberGV(db);
                }
                catch (Exception)
                {
                    lblInvalidMember.Visible = true;
                }
            }
        }

        protected void btnAddInstructor_Click(object sender, EventArgs e)
        {
            // connect to database
            using (var db = new KarateSchoolDataContextDataContext(connString))
            {
                try
                {
                    // adding new user
                    NetUser newUser = new NetUser
                    {
                        UserName = tbMemberUserName.Text,
                        UserPassword = tbMemberPassword.Text,
                        UserType = "Instructor"
                    };

                    db.NetUsers.InsertOnSubmit(newUser);
                    db.SubmitChanges();

                    // get userID
                    var result = (from user in db.NetUsers
                                  where user.UserName == tbMemberUserName.Text
                                  select user.UserID).Single();

                    // add instructor
                    Instructor newInstructor = new Instructor
                    {
                        InstructorID = Convert.ToInt32(result),
                        InstructorFirstName = tbInstructorFirstname.Text,
                        InstructorLastName = tbInstructorLastname.Text,
                        InstructorPhoneNumber = tbInstructorPhoneNumber.Text
                    };

                    db.Instructors.InsertOnSubmit(newInstructor);
                    db.SubmitChanges();

                    // remove error
                    lblInvalidInstructor.Visible = false;

                    // update gv
                    setInstructorGV(db);
                }
                catch (Exception)
                {
                    lblInvalidInstructor.Visible = true;
                }
            }
        }

        protected void btnDelUser_Click(object sender, EventArgs e)
        {
            // connect to database
            using (var db = new KarateSchoolDataContextDataContext(connString))
            {
                try
                {
                    // get user id to delete
                    int userID = Convert.ToInt32(txtDelUID.Text);

                    // check if admin, if so, skip
                    var result = (from user in db.NetUsers
                                  where user.UserID == userID
                                  select user.UserType).Single();

                    if (Convert.ToString(result) == "Administrator")
                        return;

                    // delete sections first
                    var result2 = from user in db.Sections
                                  where user.Member_ID == userID
                                  where user.Instructor_ID == userID
                                  select user;

                    foreach (Section section in result2)
                    {
                        db.GetTable<Section>().DeleteOnSubmit(section);
                        db.SubmitChanges();
                    }


                    // check if member or instructor, delete needed row in table
                    if (Convert.ToString(result) == "Member")
                    {
                        var result3 = (from user in db.Members
                                       where user.Member_UserID == userID
                                       select user).Single();

                        db.GetTable<Member>().DeleteOnSubmit(result3);
                        db.SubmitChanges();
                    }
                    else if (Convert.ToString(result) == "Instructor")
                    {
                        var result3 = (from user in db.Instructors
                                       where user.InstructorID == userID
                                       select user).Single();

                        db.GetTable<Instructor>().DeleteOnSubmit(result3);
                        db.SubmitChanges();
                    }

                    // delete netuser
                    var result4 = (from user in db.NetUsers
                                   where user.UserID == userID
                                   select user).Single();

                    db.GetTable<NetUser>().DeleteOnSubmit(result4);
                    db.SubmitChanges();

                    // update gv
                    setMemberGV(db);
                    setInstructorGV(db);

                    // remove error
                    lblInvalidDelete.Visible = false;
                }
                catch (Exception)
                {
                    lblInvalidDelete.Visible = true;
                }
            }
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("logon.aspx", true);
        }
    }
}