<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Eventino.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Scripts/Eventcard.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet" />


    <script>
        function displayButton(button) {
            button.value.style.visibility = "visible";
        }

        function UndisplayButton(button) {
            button.value.style.visibility = "hidden";
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <br /><br /><br />
   <div class="container"> 
       <br />
    <asp:Panel ID="EventPanel" runat="server"></asp:Panel>    
       </div>
</asp:Content>
