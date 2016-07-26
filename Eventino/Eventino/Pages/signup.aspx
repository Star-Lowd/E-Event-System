<%@ Page Title="" enableEventValidation="false" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Eventino.Pages.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <!-- Top menu style="align-content:center;"
		

        <!-- Top content -->
  <br />
    <br />
    <br />
   <div>
            <div class="container"  >
                   
              <form >
                    <div class="col-sm-10 col-sm-offset-1 col-md-8 col-md-offset-2 col-lg-6 col-lg-offset-3 ">
                    	<center>

                            <img class="pic img-circle" id="Profilepics" runat="server" src="../DataFiles/Images/violin.jpg" style="width:150px; height : 150px; border-color:pink; border-width:5px;"  />

                    		<h3>Register To Our App</h3>
                    		<p>Fill in the form to get instant access</p>
                    		
                    	
                    		    <h4>Tell us who you are:</h4>
                    			<div class="form-group">
                    			    <label class="sr-only" for="f1-first-name">UserName</label>
                                    <asp:TextBox ID="txtuname"  type="text" placeholder="Username..." CssClass="form-control" runat="server" required ></asp:TextBox>

                                   </div>
                                <div class="form-group">
                                    <label class="sr-only" for="f1-last-name">Email Address</label>
                                    <asp:TextBox ID="txtemail"  type="email" placeholder="Email Address..." CssClass="form-control" runat="server" required></asp:TextBox>
                                    </div>

                                   <div class="form-group">
                                    <label class="sr-only" for="f1-last-name">Password</label>
                                    <asp:TextBox ID="txtpass"  type="password" placeholder="Password..." CssClass="form-control" runat="server" required ></asp:TextBox>
                                    </div>
                                    
                                    <div class="form-group">
                                    <label class="sr-only" for="f1-last-name">Confirm Password</label>
                                    <asp:TextBox ID="txtcpass"  type="password" placeholder="Confirm Password..." CssClass="form-control" runat="server" required ></asp:TextBox>
                                    </div>

                            <%--    <div class="form-group">
                                    <label class="sr-only" for="f1-about-yourself">About yourself</label>
                                    <textarea name="f1-about-yourself" placeholder="About yourself..." 
                                    	                 class="f1-about-yourself form-control" id="f1-about-yourself"></textarea>
                                </div>--%>
                               
                                <div  >
                                    
                                    <asp:Button ID="addLogin" CssClass="btn btn-primary form-control" runat="server" Text="Register" OnClick="addLogin_Click" />
                                </div>
                         </center> 
                </div>
                           
                    	
                    	</form>
                 </div>
                    </div>
             
   

        <!-- Javascript -->

        <script src="../assets/js/jquery-1.11.1.min.js"></script>
        <script src="../assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="../assets/js/jquery.backstretch.min.js"></script>
        <script src="../assets/js/retina-1.1.0.min.js"></script>
        <script src="../assets/js/scripts.js"></script>
 
        
            <script src="../assets/js/placeholder.js"></script>
     

</asp:Content>
