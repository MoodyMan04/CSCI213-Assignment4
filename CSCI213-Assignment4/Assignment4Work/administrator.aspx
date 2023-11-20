<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="administrator.aspx.cs" Inherits="CSCI213_Assignment4.Assignment4Work.administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Hello Admin,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LoginStatus ID="LoginStatus1" runat="server" OnLoggingOut="LoginStatus1_LoggingOut" />
    </p>
    <p>
        <strong>Members</strong></p>
    <p>
        <asp:GridView ID="MemberGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </p>
    <p>
        <strong>&nbsp;Instructors</strong>
        <asp:GridView ID="InstructorGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </p>
    <p style="font-size: large">
        <strong>Add User:</strong></p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 579px; height: 29px"><strong>Member</strong></td>
                <td style="height: 29px"><strong>Instructor</strong></td>
            </tr>
            <tr>
                <td style="width: 579px">Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbMemberUserName" runat="server"></asp:TextBox>
                </td>
                <td style="width: 579px">Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbInstructorUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 579px">Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbMemberPassword" runat="server"></asp:TextBox>
                </td>
                <td style="width: 579px">Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbInstructorPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 579px">Firstname:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbMemberFirstname" runat="server"></asp:TextBox>
                </td>
                <td style="width: 579px">Firstname:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbInstructorFirstname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 579px">Lastname:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbMemberLastname" runat="server"></asp:TextBox>
                </td>
                <td style="width: 579px">Lastname:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbInstructorLastname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 579px">Phone Number:&nbsp;&nbsp;
                    <asp:TextBox ID="tbMemberPhoneNumber" runat="server"></asp:TextBox>
                </td>
                <td style="width: 579px">Phone Number:&nbsp; &nbsp;
                    <asp:TextBox ID="tbInstructorPhoneNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 579px">Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="tbMemberEmail" runat="server"></asp:TextBox>
                </td>
                <td style="width: 579px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 579px">
                    <asp:Button ID="btnAddMember" runat="server" OnClick="btnAddMember_Click" Text="Add Member" />
                </td>
                <td style="width: 579px">
                    <asp:Button ID="btnAddInstructor" runat="server" Text="Add Instructor" OnClick="btnAddInstructor_Click" />
                </td>
            </tr>
            <tr>
                <td style="width: 579px">
                    <asp:Label ID="lblInvalidMember" runat="server" ForeColor="Red" Text="Invalid Member" Visible="False"></asp:Label>
                </td>
                <td style="width: 579px">
                    <asp:Label ID="lblInvalidInstructor" runat="server" ForeColor="Red" Text="Invalid Instructor" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    </p>
    <p>
&nbsp;</p>
    <p style="font-size: large">
        <strong>Delete User:</strong></p>
    <p>
        User ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDelUID" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelUser" runat="server" Text="Delete" OnClick="btnDelUser_Click" />
    </p>
    <p>
        <asp:Label ID="lblInvalidDelete" runat="server" ForeColor="Red" Text="Invalid UserID" Visible="False"></asp:Label>
    </p>
    <p style="font-size: large">
        <strong>Assign Member to Section:</strong></p>
    <p>
        Section Name:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtSectionName" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Start Date:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtStartDate" runat="server" TextMode="DateTime"></asp:TextBox>
    </p>
    <p>
        Member ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAssignMemID" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Instructor ID:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAssignInID" runat="server" TextMode="Number"></asp:TextBox>
    </p>
    <p>
        Cost:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCost" runat="server" TextMode="Number"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" />
    </p>
    <p>
        <asp:Label ID="lblAssignError" runat="server" ForeColor="Red" Text="Invalid Input, Member Not Assigned to a Section" Visible="False"></asp:Label>
    </p>
</asp:Content>
