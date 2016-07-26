using Eventino.EF;
using Eventino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eventino
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadEvents(EventPanel);
        }

        private string processImagePath(string path){
            return path.Replace("~/","../../");
        }

        public string processDesc(string desc,int size)
        {
            if (desc.Length <= size)
                return desc;
            else
            {
                string returnedText = "";
                int cnt = 0;
                foreach (char c in desc)
                {
                    returnedText += c;
                    if (cnt == size)
                        break;
                    cnt++;
                }
                return returnedText+"...";
            }
        }

        public int CountText(string number)
        {
            int cnt = 0;
            foreach (char c in number)
            {
                cnt++;
            }
            return cnt;
        }

        public void LoadEvents(Panel p)
        {
            //string html;
            List<EVENT> evts = new EventEntities().EVENTs.ToList();
            evts.Reverse();
            foreach (EVENT ev in evts)
            {
                ACCOUNT acct = new AccountModel().GetAccountByLogin(ev.LOGINID.Value);
                string profileimgurl = "../../DataFiles/Images/unisex.jpg";
                if (acct != null)
                    profileimgurl = this.processImagePath(acct.IMAGE);

                List<EVENTIMAGE> img = new Imagemodel().EventImage(ev.EVENTID);
                
                string html = "<div class='col-lg-3 col-sm-6' style='height:40px'>" +

                                "<div class='card hovercard' style='background-color:White;'>" +
                                "<div class='cardheader' style='background-image:url("+ this.processImagePath( img.ElementAt(0).FULLPATH ) +")'> </div>" +


                                "<div class='avatar'>" +
                                "<img src='" + this.processImagePath(acct.IMAGE) + "'> </div>" +

                                "<div class='info' >" +
                                "<div class='title'>" +
                                "<a href='Pages/Event/EventPage?id=" + ev.EVENTID + "' style='font-size:16px'>" + this.processDesc(ev.NAME, 22) + "</a>" +
                                "</div>" +
                                "<div class='desc'>" + processDesc(ev.SHORTDESC,150) + "</div>" +
                                "</div>" +
                                "<div class='bottom'>" +
                                "<a class='btn btn-primary btn-twitter btn-sm form-control' style='' onmouseover='displayButton(this)' onmousedown='UndisplayButton(this)'  href='Pages/Event/EventPage?id=" + ev.EVENTID + "'>" +
                                "<i class='fa fa-twitter'></i>"+
                                "View Event</a></div></div></div>";
                //if (this.CountText() < 150)
                p.Controls.Add(new Literal { Text = html });
            }
        }
    }
}