<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Eventino.Pages.Account.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $('#myTab a:last').tab('show')
        })


    </script>

    <script>
        function ModalToggle() {
            $('#myModal').modal('show');
        }
        function EventClick() {
            $('#AddEventModal').modal('show');
            return false;
        }
        function Dim()
        {
            document.getElementById("EventButton").style = 'height:80px; background-image:none; background-color:blue';
        }
    </script>

    <link href="../../Scripts/ProfileStyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br />

   

  <!-- AddEventModal -->
  <div class="modal fade" id="AddEventModal" role="dialog">
    <div class="modal-dialog modal-md">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Create New Events</h4>
        </div>
        <div class="modal-body">
          
            <div class="form-group" id="EventDiv"> 
                <table cellpadding="10px" cellspacing="10px" border="0" style="width:100%">
                    <tr>
                        <td> <h5>Event Name</h5> </td>
                        <td> <asp:TextBox ID="eventName" CssClass="form-control" runat="server"></asp:TextBox> </td>
                    </tr>

                     <tr>
                        <td> <h5>Event Date</h5> </td>
                        <td>  <asp:TextBox ID="eventDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox> </td>
                    </tr>

                     <tr>
                        <td> <h5>Event Location</h5> </td>
                               <td> <asp:TextBox ID="location" TextMode="MultiLine" Rows="2" CssClass="form-control" runat="server"></asp:TextBox> </td>
                    </tr>

                     <tr>
                        <td> <h5>Event Start Time</h5> </td>
                        <td> <asp:TextBox ID="startDate" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>  </td>
                    </tr>

                    <tr>
                        <td> <h5>Event Stop Time</h5> </td>
                        <td> <asp:TextBox ID="stopDate" CssClass="form-control" runat="server" TextMode="Time"></asp:TextBox>  </td>
                    </tr>

                    <tr>
                        <td> <h5>Short Description</h5> </td>
                        <td> <asp:TextBox ID="ShortDesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>  </td>
                    </tr>

                     <tr>
                        <td> <h5>Long Description</h5> </td>
                        <td> <asp:TextBox ID="LongDesc" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>  </td>
                    </tr>

                     <tr>
                        <td> <h5>Event Type</h5> </td>
                        <td>  <asp:DropDownList ID="EventType" CssClass="form-control" runat="server" DataSourceID="EventtypeDB" DataTextField="EVENTTYENAME" DataValueField="EVENTTYPEID"></asp:DropDownList>
                            <asp:SqlDataSource runat="server" ID="EventtypeDB" ConnectionString='<%$ ConnectionStrings:EventConnectionString %>' SelectCommand="SELECT * FROM [EVENTTYPE]"></asp:SqlDataSource>
                        </td>
                    </tr>

                     <tr>
                        <td> <h5>Event Image</h5> </td>
                        <td> <asp:FileUpload ID="FileUpload1" AllowMultiple="true" CssClass="form-control" runat="server" />  </td>
                    </tr>

                </table>
                                

                            </div>

        </div>
        <div class="modal-footer">
            <asp:Button ID="saveRelease" CssClass="btn" runat="server" OnClick="saveRelease_Click" Text="Post and Release" />
            <asp:Button ID="savePost" runat="server" CssClass="btn" OnClick="savePost_Click" Text="Save Post" />
        </div>
      </div>
    </div>
  </div>


      <!-- Change Cover Pic Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog modal-md">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Add Cover</h4>
        </div>
        <div class="modal-body">
            <asp:FileUpload ID="CoverUpload" runat="server" />
        </div>
        <div class="modal-footer">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" Text="Change Pix" OnClick="Button1_Click" />
        </div>
      </div>
    </div>
  </div>



    <div class="container">
        <div class="row well">
            <div class="col-md-2">
                <ul class="nav nav-pills nav-stacked well">
                    <li class="active"><a href="#"><i class="fa fa-envelope"></i>Compose</a></li>
                    <li><a href="#"><i class="fa fa-home"></i>Home</a></li>
                    <li><a href="#"><i class="fa fa-user"></i>Profile</a></li>
                    <li><a href="#"><i class="fa fa-key"></i>Security</a></li>
                    <li><a href="#"><i class="fa fa-sign-out"></i>Logout</a></li>
                </ul>
            </div>
            <div class="col-md-10">
                <div class="panel" id="Cover" onmouseover="CoverHover(ChangeCover)" runat="server">
                    <img class="pic img-circle" id="Profilepics" runat="server" src="#" style="width:150px; height : 150px;"  />
                    <div class="name" ><small> <%= new Eventino.Models.LoginSession().Getusername() %> </small></div>
                    <a id="ChangeCover" onclick="ModalToggle()" class="btn btn-xs btn-primary pull-right" style="margin: 10px;" runat="server" ><span class="glyphicon glyphicon-picture"></span>Change cover</a>
                </div>

                <br />
                <br />
                <br />
                <ul class="nav nav-tabs" id="myTab">
                    <li class="active"><a href="#inbox" data-toggle="tab"><i class="fa fa-envelope-o"></i>Inbox</a></li>
                    <li><a href="#sent" data-toggle="tab"><i class="fa fa-reply-all"></i>Sent</a></li>
                    <li><a href="#assignment" data-toggle="tab"><i class="fa fa-file-text-o"></i>Assignment</a></li>
                    <li><a href="#event" data-toggle="tab"><i class="fa fa-clock-o"></i>Event</a></li>
                </ul>

                <div class="tab-content">
                    <div class="tab-pane active" id="inbox">
                        <a type="button" data-toggle="collapse" data-target="#a1">
                            <div class="btn-toolbar well well-sm" role="toolbar" style="margin: 0px;">
                                <div class="btn-group">
                                    <input type="checkbox"></div>
                                <div class="btn-group col-md-3">Admin Kumar</div>
                                <div class="btn-group col-md-8"><b>Hi Check this new Bootstrap plugin</b>
                                    <div class="pull-right"><i class="glyphicon glyphicon-time"></i>12:10 PM
                                        <button class="btn btn-primary btn-xs" data-toggle="modal" data-target=".bs-example-modal-lg"><i class="fa fa-share-square-o">Reply</i></button></div>
                                </div>
                            </div>
                        </a>
                        <div id="a1" class="collapse out well">This is the message body1</div>
                        <br>
                        <button class="btn btn-primary btn-xs"><i class="fa fa-check-square-o"></i>Delete Checked Item's</button>
                    </div>


                    <div class="tab-pane" id="sent">
                        <a type="button" data-toggle="collapse" data-target="#s1">
                            <div class="btn-toolbar well well-sm" role="toolbar" style="margin: 0px;">
                                <div class="btn-group">
                                    <input type="checkbox"></div>
                                <div class="btn-group col-md-3">Kumar</div>
                                <div class="btn-group col-md-8"><b>This is reply from Bootstrap plugin</b>
                                    <div class="pull-right"><i class="glyphicon glyphicon-time"></i>12:30 AM</div>
                                </div>
                            </div>
                        </a>
                        <div id="s1" class="collapse out well">This is the message body1</div>
                        <br>
                        <button class="btn btn-primary btn-xs"><i class="fa fa-check-square-o"></i>Delete Checked Item's</button>
                    </div>


                    <div class="tab-pane" id="assignment">
                        <a href="">
                            <div class="well well-sm" style="margin: 0px;">Open GL Assignments <span class="pull-right"><i class="glyphicon glyphicon-time"></i>12:20 AM 20 Dec 2014 </span></div>
                        </a>
                    </div>

                    <div class="tab-pane" id="event">
                        <div class="form-group">
                            <br />
                            <br />
                             <a href= "#" class="btn btn-info btn-lg form-control" style="height:50px" data-toggle="modal" data-target="#AddEventModal">Add New Event</a>   
                        </div>
                        <div class="media">
                            <a class="pull-left" href="#">
                                <img class="media-object img-thumbnail" width="100" src="http://placehold.it/120x120" alt="..." />
                            </a>
                            <div class="media-body">
                                <h4 class="media-heading">Animation Workshop</h4>
                                2Days animation workshop to be conducted
                            </div>
                        </div>

                        <asp:Panel ID="ListEvents" runat="server"></asp:Panel>

                    </div>



                </div>

            </div>
        </div>


    </div>




    <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <br />
                <br />
                <div class="form-horizontal">
                    <fieldset>
                        <!-- Text input-->
                        <div class="form-group">
                            <label class="col-md-2 control-label" for="body">Body :</label>
                            <div class="col-md-8">
                                <input id="body" name="body" type="text" placeholder="Message Body" class="form-control input-md">
                            </div>
                        </div>

                        <!-- Textarea -->
                        <div class="form-group">
                            <label class="col-md-2 control-label" for="message">Message :</label>
                            <div class="col-md-8">
                                <textarea class="form-control" id="message" name="message"></textarea>
                            </div>
                        </div>

                        <!-- Button -->
                        <div class="form-group">
                            <label class="col-md-2 control-label" for="send"></label>
                            <div class="col-md-8">
                                <button id="send" name="send" class="btn btn-primary">Send</button>
                            </div>
                        </div>

                    </fieldset>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
