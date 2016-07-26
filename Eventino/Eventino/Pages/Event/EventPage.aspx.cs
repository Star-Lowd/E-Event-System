using Eventino.EF;
using Eventino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventino.Pages.Event
{
    public partial class EventPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((new LoginSession()).GetSession() == null)
            {
                comment.Visible = false;
                actionField.Visible = false;
            }
            else
            {
                LOGIN login = new LoginSession().GetSession();
                if (login.LOGINID != int.Parse(Request.QueryString["id"]))
                {
                    actionField.Visible = false;
                }
            }
            if (Request.QueryString["id"] == null)
            {
                Response.Write("<h2>Abeg Commot Go find ID joor</h2>");
                return;
            }
            int evtid = int.Parse(Request.QueryString["id"]);
            EVENT EE = new EventModel().Find(evtid);
            if ((new LoginSession()).GetSession() == null)
                AddVide.Visible = false;
            else if (EE.LOGINID.Value != (new LoginSession()).GetSession().LOGINID)
                AddVide.Visible = false;
            this.LoadEventImages(evtid);
            View(evtid);
            likeCount.InnerText = (new LikeModel()).CountLikes(evtid)+"";
            if ((new LoginSession().GetSession()== null) || (new LikeModel().Exist(evtid, (new LoginSession()).GetSession().LOGINID))){
                Likes.Enabled = false;
            }

            DisplayVideos(Panel1);
            cmImg.Src = new LoginSession().GetImage();
            ViewCount.InnerHtml = new ViewModel().CountView(evtid)+"";
            CommentCount.InnerHtml = new CommentModel().CountComment(evtid) + "";

            ListComment(Comments);
            SendReply.Click +=SendReply_Click;
        }
        
        private void View(int evtid)
        {
            VIEW view = new VIEW();
            view.EVENTID = evtid;
            view.IPADDRESS = this.GetIPAddress();
           
            (new ViewModel()).Add(view);
        }
        private string processCoverName(string name)
        {
            return name.Replace("~/", "../../");
        }


        public void ListComment(Panel p)
        {
            p.Controls.Clear();
            List<COMMENT> cmt = new CommentModel().List(int.Parse(Request.QueryString["id"]));
            cmt.Reverse();
            foreach (COMMENT comm in cmt)
            {
                
                LOGIN login = new LoginModel().getLogin(comm.LOGINID.Value);
                
                ACCOUNT acct = new AccountModel().GetAccountByLogin(login.LOGINID);

                string imagePath = "";
                string CommenterName = "";

                if (acct == null)
                {
                    CommenterName = login.USERNAME;
                    imagePath = "~/DataFiles/Images/unisex.jpg";
                }
                else
                {
                    CommenterName = acct.FIRSTNAME + " " + acct.LASTNAME;
                    imagePath = acct.IMAGE;
                }
                
                p.Controls.Add(new Literal { Text = "<div class=\"container-fluid\" style=\"width:100%\">"+
                                        "<div class=\"col-sm-1\">"+
                                        "<div class=\"thumbnail\">"+
                                    "<img class=\"img-responsive user-photo\" style='' src=\""+ this.processCoverName(imagePath) + "\" />"+
                                    "</div>"+
                                    "<!-- /thumbnail -->"+
                                    "</div>"+
                                    "<!-- /col-sm-1 -->"+

                                    "<div class='col-sm-11'>"+
                                    " <div class='panel panel-default'>"+
                                    " <div class='panel-heading'>"+
                                    "<strong>"+ CommenterName  +"</strong> <span style='float:right' class='text-muted'>"+comm.CREATEDATE+"</span>"+
                                    " </div>"+
                                    "<div class='panel-body'>"+
                                    "  "+ comm.COMMENT1 +"<br /><br />"});
                                    Panel Response = new Panel();
                                    Response.CssClass = "form";
                                    LinkButton reply = new LinkButton();
                                    reply.CssClass = "btn btn-info btn-xs";
                                    reply.Text = "Reply";
                                    Response.Controls.Add(reply);
                                    p.Controls.Add(Response);
                                    p.Controls.Add(new Literal { Text = " "+
                                    "</div>"+
                                    "<!-- /panel-body -->"+
                                    "</div>"+
                                    "<!-- /panel panel-default -->"+
                                    "</div>"+
                                    "</div>" });
                                    reply.Click += reply_Click;
                                    reply.CommandArgument = comm.COMMENTID+"";
                                   
                            List<REPLY> repl = new ReplyModel().List(comm.COMMENTID);
                            repl.Reverse();
                            foreach(REPLY r in  repl){
                                LOGIN loginn = new LoginModel().getLogin(r.LOGINID.Value);

                                ACCOUNT acctt = new AccountModel().GetAccountByLogin(loginn.LOGINID);
                                string image = "";
                                string DisplayedName = "";

                                if (acctt == null)
                                {
                                    DisplayedName = loginn.USERNAME;
                                    image = "~/DataFiles/Images/unisex.jpg";
                                }
                                else
                                {
                                    DisplayedName = acctt.FIRSTNAME + " " + acctt.LASTNAME;
                                    image = acctt.IMAGE;
                                }

                                p.Controls.Add(new Literal
                                {
                                    Text = "<div class='col-sm-1'></div><div class='col-sm-9'>" +
                                    "<div class='panel panel-default'>"+
                                    " <div class='panel-heading'>"+
                                    " <strong>" + DisplayedName + "</strong> <span style='float:right' class='text-muted'> " + r.CREATEDATE + "</span>" +
                                    "</div>"+
                                    "<div class='panel-body'>"+
                                    r.REPLY1 +
                                    "</div>"+
                 
                                    "  </div>"+
               
                                    "</div>"+
                                    "</div>"+
                                    "<div>"+
                                    "<div class='container'>"+
                                    "<div class='col-sm-1'>"+
                                    "<div class='thumbnail'>"+
                                    "<img class='img-responsive user-photo' src='"+ this.processCoverName( image ) +"' />"+
                                    "</div>"+
                                    " <!-- /thumbnail -->"+
                                    " </div>"+
                                    "</div>"});
                            }
            }
        }

        TextBox tbreply = new TextBox();
        LinkButton SendReply = new LinkButton();
        Button snd = new Button();
        void reply_Click(object sender, EventArgs e)
        {
            Button bnt = new Button();
            bnt.Click += bnt_Click;
            int commid = int.Parse(((LinkButton)(sender)).CommandArgument);
       //     System.Windows.Forms.MessageBox.Show(commid+"");

            TextBox1.TextMode = TextBoxMode.MultiLine;
            TextBox1.Rows = 2;
            TextBox1.CssClass = "form-control";
            SendReply.CssClass = "btn btn-primary ";
            SendReply.Text = "Reply";
            
           // snd.Click += snd_Click;

            ((LinkButton)(sender)).Parent.Controls.Add(TextBox1);
            ((LinkButton)(sender)).Parent.Controls.Add(Button1);
          //  ((LinkButton)(sender)).Parent.Controls.Add(snd);
            
            ((LinkButton)(sender)).Visible = false;
            //SendReply.Click += SendReply_Click;
            Button1.CommandArgument = commid+"";

//            replyTextBox.Add(int.Parse(((LinkButton)(sender)).CommandArgument), tbreply);
            SendReply.CommandArgument = commid + "";
            Application["commentID"] = commid + "";
            Application["textbox"] = tbreply;
        }

        void bnt_Click(object sender, EventArgs e)
        {
             System.Windows.Forms.MessageBox.Show("fghjgfdf");
        }


        void SendReply_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Entered");
            string text = tbreply.Text;
            REPLY re = new REPLY();
            re.LOGINID = new LoginSession().GetSession().LOGINID;
            re.REPLY1 = text;
            re.COMMENTID = int.Parse(((LinkButton)(sender)).CommandArgument);
            System.Windows.Forms.MessageBox.Show(new ReplyModel().Add(re));
        }

        protected string GetIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void LoadEventImages(int evtid)
        {
            EVENT Evt = (new EventModel()).Find(evtid);
            List<EVENTIMAGE> allevtImages = (new Imagemodel()).EventImage(evtid);
            int cnt = 0;
            foreach (EVENTIMAGE img in allevtImages)
            {
                if (cnt == 0)
                {
                    Image0.Src = this.processCoverName(img.FULLPATH);
                }
                else
                {
                    indicator.Controls.Add(new Literal { Text = "<li data-target=\"#myCarousel\" data-slide-to=\"" + cnt + "\" ></li>" });
                    imageWrapper.Controls.Add(new Literal
                    {
                        Text = "<div class=\"item\">" +
                            "<img src=\"" + this.processCoverName(img.FULLPATH) + "\" style=\"width: 800px; height: 300px\" >" +
                            "</div>" 
                    });
                }
                cnt++;
            }
            string EventType = (new EventTypeModel()).FindEventType(Evt.EVENTTYPEID.Value);
            string imageSources = "../../DataFiles/Images/"+EventType+".jpg";
            
            data.Controls.Add(new Literal
            {
                Text = "<center>" +
                       "<br /> <img src='"+ imageSources +"' style='width:120px; height:120px ' />"+
                       "<br /><h4>"+ Evt.NAME +"</h4>"+
                        "<br /><h4>" + Evt.DATE + "</h4>" +
                        "<br /><h4>" + Evt.LOCATION + "</h4>" +
                      
                    "</center>"
            });
            longDesc.InnerText = Evt.LONGDESC;
        }


        private bool createLike()
        {
            try
            {
                LIKE like = new LIKE();
                like.LOGINID = (new LoginSession()).GetSession().LOGINID;
                like.EVENTID = int.Parse(Request.QueryString["id"]);
                new LikeModel().Add(like);

                return true;
            }
            catch(Exception ex )
            {
                //likeerr
                return false;
            }
        }
        protected void Likes_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton) sender;
            bool isliked = createLike();
            if (isliked)
            {
                likeCount.InnerText = (int.Parse(likeCount.InnerText) + 1)+"";
            }
            btn.Enabled = false;
        }

        public bool IsAuthorize()
        {
            if ((new LoginSession().GetSession() == null))
                return false ;
            EVENT EE = new EventModel().Find(int.Parse(Request.QueryString["id"]));
            if ((new LoginSession().GetSession().LOGINID != EE.LOGINID))
                return false;
            else
                return true;
        }

        public string ProcessVideoEmbed(string link)
        {
            return link.Replace("watch?v=", "embed/");
        }
        private void DisplayVideos(Panel videos)
        {
            int evtid = int.Parse(Request.QueryString["id"]);
            List<EVENTVIDEO> Evideos = (new VideoModel()).Videos(evtid);
            longDesc.InnerText = longDesc.InnerText + "<h2>" + Evideos.Count + "</h2>";
            videos.Controls.Add(new Literal { Text = "<center>" });
            //System.Windows.Forms.MessageBox.Show(Evideos.Count() + "");
            bool isodd = false;
            if (Evideos.Count == 1 || Evideos.Count % 2 != 0)
                isodd = true;

            int cnt = 1;
            foreach (EVENTVIDEO EV in Evideos)
            {
                if (isodd)
                {
                    if (cnt == Evideos.Count())
                        videos.Controls.Add(new Literal { Text = "<iframe width=\"1120\" height=\"315\" src=\"" + this.ProcessVideoEmbed(EV.URL) + "\" frameborder=\"0\" allowfullscreen></iframe>" });
                    else if (cnt == 1)
                        videos.Controls.Add(new Literal { Text = "<iframe style='float:left; padding:10px' width=\"560\" height=\"315\" src=\"" + this.ProcessVideoEmbed(EV.URL) + "?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe>" });
                    else
                        videos.Controls.Add(new Literal { Text = "<iframe style='float:left; padding:10px' width=\"560\" height=\"315\" src=\"" + this.ProcessVideoEmbed(EV.URL) + "\" frameborder=\"0\" allowfullscreen></iframe>" });

                    
                }
                else
                {
                    if (cnt == 1)
                        videos.Controls.Add(new Literal { Text = "<iframe style='float:left; padding:10px' width=\"560\" height=\"315\" src=\"" + this.ProcessVideoEmbed(EV.URL) + "?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe>" });
                    else
                        videos.Controls.Add(new Literal { Text = "<iframe style='float:left; padding:10px' width=\"560\" height=\"315\" src=\"" + this.ProcessVideoEmbed(EV.URL) + "\" frameborder=\"0\" allowfullscreen></iframe>" });

                }
                cnt++;
            }
            videos.Controls.Add(new Literal { Text = "</center>" });
        }

        private void AddVideo()
        {
            EVENTVIDEO EV = new EVENTVIDEO();
            EV.EVENTID = int.Parse(Request.QueryString["id"]);
            EV.URL = VideoUrl.Text;
            new VideoModel().Add(EV);
        }
        protected void btnAddVideos_Click(object sender, EventArgs e)
        {
            if (IsAuthorize())
            {
                Panel1.Controls.Clear();
                this.AddVideo();

                this.DisplayVideos(Panel1);
            }
        }

        protected void btnSubmitComment_Click(object sender, EventArgs e)
        {
            string comment = CommentText.Text;
            CommentText.Text = "";
            if (comment == "" || comment == null)
            {
                Message.InnerHtml = "Comment Cannot Be left Empty<br />";
                return;
            }
            COMMENT cmt = new COMMENT();
            cmt.LOGINID = new LoginSession().GetSession().LOGINID;
            cmt.CREATEDATE = DateTime.Now.ToString();
            cmt.EVENTID = int.Parse(Request.QueryString["id"]);
            cmt.COMMENT1 = comment;

            Message.InnerHtml = new CommentModel().Add(cmt);
            ListComment(Comments);
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           // System.Windows.Forms.MessageBox.Show(Application["commentID"].ToString());
         //   TextBox tbx = tbreply.Text;
            string text = TextBox1.Text;
            REPLY re = new REPLY();
            re.LOGINID = new LoginSession().GetSession().LOGINID;
            re.REPLY1 = text;
            re.CREATEDATE = DateTime.Now.ToString();
            re.COMMENTID = int.Parse(Application["commentID"].ToString());
            new ReplyModel().Add(re);
           Response.Redirect("~/Pages/Event/EventPage?id="+Request.QueryString["id"]);
        }
    }
}