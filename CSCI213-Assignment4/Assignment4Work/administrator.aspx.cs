using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
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
                catch(Exception ex)
                {
                    //Displays error label
                    lblAssignError.Visible = true;
                }
                
            }
        }
    }
}