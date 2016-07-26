using Eventino.EF;
using Eventino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventino.Pages.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((new LoginSession()).GetSession() == null)
                Response.Redirect("~/Index");
            Profilepics.Src = (new LoginSession()).GetImage();
            Cover.Attributes.Add("style", "background-image:url(" + this.processCoverName((new LoginSession()).GetCoverImage()) + ")");
            LoadUserEvents(ListEvents);
        }
        private string processCoverName(string name)
        {
            return name.Replace("~/", "../../");
        }
        private string SaveImage(Control c)
        {

            FileUpload fuImage = (FileUpload)c;
            if (!System.IO.Directory.Exists(Server.MapPath("~/images/PasImage/")))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("~/images/PasImage/"));
            }
            string name = "~/images/PasImage/"  + fuImage.PostedFile.FileName;
            fuImage.SaveAs(Server.MapPath(name));

            return name;

        }
        protected void ChangeCover_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.SaveImage(CoverUpload);
            ACCOUNT Account = new LoginSession().GetAccount();
            Account.CoverImage = name;
            (new AccountModel()).update(Account.ACCOUNTID, Account);
            Cover.Attributes.Add("style", "background-image:url(" + this.processCoverName((new LoginSession()).GetCoverImage()) + ")");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "EventClick();", true);
        }

        private int SaveEvent(bool released)
        {
            try
            {
                EVENT ev = new EVENT();
                ev.NAME = eventName.Text;
                ev.DATE = eventDate.Text;
                ev.STARTTIME = startDate.Text;
                ev.STOPTIME = stopDate.Text;
                ev.LOCATION = location.Text;
                ev.SHORTDESC = ShortDesc.Text;
                ev.LONGDESC = LongDesc.Text;
                ev.RELEASED = released;
                ev.POSTEDDATE = DateTime.Now+"";
                ev.EVENTTYPEID = int.Parse(EventType.SelectedValue.ToString());
                ev.LOGINID = (new LoginSession()).GetSession().LOGINID;
                new EventModel().Add(ev);
                this.SaveImage(FileUpload1,ev.EVENTID);
                return ev.EVENTID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private string SaveImage(Control c, int eventid)
        {
            FileUpload fuImage = (FileUpload)c;

            foreach (HttpPostedFile file in fuImage.PostedFiles)
            {
                if (!System.IO.Directory.Exists(Server.MapPath("~/images/PasImage/")))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/images/PasImage/"));
                }
                string name = "~/images/PasImage/"  + file.FileName;
                file.SaveAs(Server.MapPath(name));
                EVENTIMAGE image = new EVENTIMAGE();
                image.EVENTID = eventid;
                image.FILENAME = file.FileName;
                image.FULLPATH = name;
                new Imagemodel().Add(image);
            }
            return "";

        }

        private void LoadUserEvents(Control c)
        {
            Panel listevts = (Panel)c;
            List<EVENT> allevts = (new EventModel()).UserEvent();
            foreach (EVENT e in allevts)
            {
                List<EVENTIMAGE> evimg = (new Imagemodel()).EventImage(e.EVENTID);
                string html = "";
                try
                {
                     html = "<a href=\"~/Pages/Event/EventPage?id="+ e.EVENTID +"\"><div class=\"media\"><a class=\"pull-left\" href=\"#\">" +
                                   " <img class=\"media-object img-thumbnail\" width=\"120\" height=\"120\" src=\"" + this.processCoverName(evimg.ElementAt(0).FULLPATH) + "\" alt=\"...\" />" +
                                "</a><div class=\"media-body\">" +
                                    "<h4 class=\"media-heading\">" + e.NAME + "</h4>" +
                                    "" + e.SHORTDESC + "<br />" +
                                    "<a class=\"btn btn-info btn-sm\" href=\"../../Pages/Event/EventPage?id=" + e.EVENTID + "\" >  View More >></a>" +
                                "</div>" +
                            "</div></a>";
                }
                catch
                {
                    html = " <div class=\"media\"><a class=\"pull-left\" href=\"#\">" +
                                   " <img class=\"media-object img-thumbnail\"  width=\"120\" height=\"120\" src=\"#\" alt=\"...\" />" +
                                "</a><div class=\"media-body\">" +
                                    "<h4 class=\"media-heading\">" + e.NAME + "</h4>" +
                                    "" + e.SHORTDESC + "<br />" +
                                    "<a class=\"btn btn-info btn-sm\" href=\"../../Pages/Event/EventPage?id=" + e.EVENTID + "\" > View More >></a>" +
                                "</div>" +
                            "</div>";
                }
                listevts.Controls.Add(new Literal { Text = html });
            }
        }

        protected void saveRelease_Click(object sender, EventArgs e)
        {
            int evid = this.SaveEvent(true);
            
        }

        protected void savePost_Click(object sender, EventArgs e)
        {
            int evid = this.SaveEvent(false);
        }
    }
}