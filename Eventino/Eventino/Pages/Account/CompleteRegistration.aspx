<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CompleteRegistration.aspx.cs" Inherits="Eventino.Pages.Account.CompleteRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="container">

        <asp:Panel ID="Panel1" runat="server"></asp:Panel>

        <div class="col-lg-6 col-md-6 col-sm-3 col-xs-3">
            <div class="well" style="background-color: pink; background-image: none;">
                <h5>First Name </h5>
                <asp:TextBox ID="Fname" CssClass="form-control" placeholder="First Name ..." runat="server"></asp:TextBox>
                <br />
                <h5>Last Name </h5>
                <asp:TextBox ID="Lname" CssClass="form-control" placeholder="Last Name ..." runat="server"></asp:TextBox>
                <br />
                <h5>DOB </h5>
                <asp:TextBox ID="Dob" CssClass="form-control" TextMode="Date" placeholder="Date of Birth ..." runat="server"></asp:TextBox>
                <br />
                <h5>Phone Number </h5>
                <asp:TextBox ID="Pnumber" CssClass="form-control" TextMode="Phone" placeholder="Phone Number ..." runat="server"></asp:TextBox>

            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-sm-3 col-xs-3">
            <div class="well" style="background-color: pink; background-image: none;">
                <h5>Country</h5>
                <asp:DropDownList ID="Country" runat="server" CssClass="form-control" DataSourceID="countrydata" DataTextField="NAME" DataValueField="COUNTRYID"></asp:DropDownList>
                <asp:SqlDataSource ID="countrydata" runat="server" ConnectionString="<%$ ConnectionStrings:EventConnectionString %>" SelectCommand="SELECT * FROM [COUNTRY]"></asp:SqlDataSource>

                <h5>Marital Status</h5>
                <asp:DropDownList ID="MaritalStatus" runat="server" CssClass="form-control">
                    <asp:ListItem>Single</asp:ListItem>
                    <asp:ListItem>Married</asp:ListItem>
                    <asp:ListItem>Divorce</asp:ListItem>
                </asp:DropDownList>

                <h5>Gender</h5>
                <asp:RadioButton ID="Radiom" GroupName="gender" runat="server" Text="Male" />

                <asp:RadioButton ID="RadioF" GroupName="gender" runat="server" Text="Female" />
                <br />
                <h5>Profile Image</h5>
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                <br />
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn btn-default" Text="Save" OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" CssClass="btn btn-default" Text="Skip" OnClick="Button2_Click" />
            </div>
        </div>
    </div>

</asp:Content>
