<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="instructor.aspx.cs" Inherits="CSCI213_Assignment4.Assignment4Work.instructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <span style="font-size: x-large">Welcome,
        </span>
        <asp:Label ID="lblFirstName" runat="server" Text="Label" style="font-size: x-large"></asp:Label>
        <asp:Label ID="lblLastName" runat="server" Text="Label" style="font-size: x-large"></asp:Label>
        <br />
    </p>
    <p>
        <strong>Sections</strong></p>
    <p>
        <asp:GridView ID="gvSections" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="77px" Width="531px">
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
    <p>
        <asp:LoginStatus ID="LoginStatus1" runat="server" OnLoggingOut="LoginStatus1_LoggingOut" />
    </p>
</asp:Content>
