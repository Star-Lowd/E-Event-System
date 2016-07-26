<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EventPage.aspx.cs" Inherits="Eventino.Pages.Event.EventPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="http://fontawesome.io/assets/font-awesome/css/font-awesome.css" />
    <script>
        function checkerror() {
            var text = document.getElementById("<%= this.CommentText.ClientID %>").value;
            if (text == '' || text == null) {
                document.getElementById("Message").innerHTML = "Comment Cannot Be left Null";
                return false;
            }
            else {
                return true;
            }


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-sx btn-primary" OnClick="Button1_Click" Text="Reply" />
  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-md">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Events Videos</h4>
        </div>
        <div class="modal-body">
            <center>
          <h4>Enter Url of Video</h4>
            <br />
            <asp:TextBox ID="VideoUrl" CssClass="form-control" placeholder="Url" runat="server"></asp:TextBox>
            </center>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnAddVideos" runat="server" OnClick="btnAddVideos_Click" Text="Add Video" />
        </div>
      </div>
    </div>
  </div>
    <br />
    <br />
    <div class="container-fluid" id="actionField" runat="server">
        <asp:Button ID="EdtBtn" CssClass="btn btn-primary btn-sm" runat="server" Text="Edit" />

        <asp:Button ID="btnDelete" CssClass="btn btn-error btn-sm" runat="server" Text="Delete" />
    </div>
    <br />
    <br />
    <br />
    <div class="container">
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 well" style="height: 470px;">
            <asp:Panel ID="EventData" runat="server" Style="height: 430px; border: double; border-width: medium; border-color: pink">

                <asp:Panel ID="data" runat="server"></asp:Panel>
                
                <asp:Panel ID="buttons" runat="server" Style="left: 50%; margin-left: 50px">
                    <br />
                    
                    <asp:LinkButton ID="Likes" Text="0" OnClick="Likes_Click" runat="server" Style="color: none; padding: 10px; font-size: 1.0em; text-decoration: none; float: left">
                        <span class="glyphicon glyphicon-lg glyphicon-thumbs-up"></span>
                        <p id="likeCount" style="float: right" runat="server"></p>
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" Enabled="false" Text="0" runat="server" Style="color: none; padding: 10px; font-size: 1.0em; text-decoration: none; float: left"><span class="glyphicon glyphicon-lg glyphicon-sunglasses"></span> 
                       
                        <p id="ViewCount" style="float: right" runat="server"></p>
                    </asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" Text="0" Enabled="false" runat="server" Style="color: none; padding: 10px; font-size: 1.0em; text-decoration: none; float: left"><span class="glyphicon glyphicon-lg glyphicon-comment"></span>   
                        
                        <p id="CommentCount" style="float: right" runat="server"></p>
                    </asp:LinkButton>
                  
                          <p id="error" runat="server"></p>
                </asp:Panel>

            </asp:Panel>

        </div>

        <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12">

            <div id="myCarousel" class="carousel slide" data-ride="carousel" style="width: 800px; height: 300px">
                <!-- Indicators -->
                <ol class="carousel-indicators" id="indicator" runat="server">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>

                </ol>

                <!-- Wrapper for slides -->
                <div runat="server" id="imageWrapper" class="carousel-inner" role="listbox">

                    <div class="item active">
                        <img runat="server" id="Image0" src="img_chania.jpg" alt="Chania" style="width: 800px; height: 300px" />
                    </div>
                </div>

                <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
            <br />
            <div class="well" style="height: 150px; width: 800px ;">
                <div class="container-fluid" style="border: double; border-width: medium; border-color:black;margin-left: auto; margin-right: auto; width: 750px; height: 120px; overflow-y: scroll;">
                    <p runat="server" id="longDesc"></p>
                </div>
            </div>
        </div>

        <div class="form">
            <center>
                
                
                <a class="btn btn-info btn-lg form-control" id="AddVide" runat="server"  data-toggle="modal" data-target="#myModal">Add Event Videos</a>
                <hr />
                 <asp:Panel ID="Panel1" runat="server"></asp:Panel>
            </center>
        </div>
        <br /><br />
        <div class="container-fluid" id="comment" runat="server">
            <div class="form">
                <img id="cmImg" runat="server" alt="" height="100" width="100" style="float:left; padding:10px" src="#"  />
                <asp:TextBox ID="CommentText" TextMode="MultiLine" Width="900px"  placeholder="Place your Comment Here" Style="text-align:center; float:left; padding:10px" Rows="5" cols="150" runat="server"></asp:TextBox>
                <asp:Button ID="btnSubmitComment" OnClientClick="checkerror()" OnClick="btnSubmitComment_Click" CssClass="btn btn-info" Style="float:left; padding:10px; padding-top:20px" height="120" width="80"  runat="server" Text="Comment" />
           
                <p id="Message" runat="server"></p>
           </div>
        </div>
        <br /><br />



        <asp:Panel ID="Comments" runat="server"></asp:Panel>



</asp:Content>
