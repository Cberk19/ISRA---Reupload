using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ISRA.Classes;

namespace ISRA
{
    public partial class Student_Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect to landing if nobody logged in
            if (Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("../General_LandingPage.aspx");
            }
            else
            {
                // redirect 404 if not correct user
                if (Request.Cookies["user_cookie"]["user_type"].CompareTo("student") != 0)
                {
                    Response.Redirect("General_404.aspx");
                }
            }
            if (!IsPostBack)
            {
                // for filter badges
                Dictionary<string, string> filterItems = new Dictionary<string, string>();
                filterItems.Add("course", "Any");
                filterItems.Add("semester", "Any");
                filterItems.Add("status", "Any");
                filterItems.Add("sort", "newest");
                ViewState["filterItems"] = filterItems;

                int tuid = int.Parse(Request.Cookies["tuid_cookie"].Value.ToString());
                List<ISRARequest> requests = this.sortedRequests(ISRAUtils.GetAllISRAByTUID(tuid)); // fetched from db

                this.displayRecords(requests); // show all requests in ui
                this.showCurrentFilters();
            }
        }

        protected void btn_View(object sender, CommandEventArgs e)
        {
            int rowClicked = int.Parse(e.CommandArgument.ToString());
            Label lblIsraID = (Label)rptRequests.Items[rowClicked].FindControl("lblIsraId");
            Session["pageSwitchID"] = lblIsraID.Text;
            Response.Redirect("General_StatusPage.aspx");
        }

        private void displayRecords(List<ISRARequest> requests)
        {
            this.rptRequests.DataSource = requests;
            this.rptRequests.DataBind();

            this.spanResultCount.InnerHtml = requests.Count.ToString();
        }

        protected void rpt_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            List<ISRARequest> sortedAndFiltered = this.sortedRequests(this.filteredRequests());
            this.displayRecords(sortedAndFiltered);
            this.showCurrentFilters();
        }
        private List<ISRARequest> filteredRequests()
        {
            List<ISRARequest> toReturn = new List<ISRARequest>();

            int tuid = int.Parse(Request.Cookies["tuid_cookie"].Value.ToString());
            List<ISRARequest> allRequests = ISRAUtils.GetAllISRAByTUID(tuid);

            foreach (ISRARequest request in allRequests)
            {
                bool courseHasValue = this.ddlCourse.SelectedItem.Value.CompareTo("Any") == 0 ? true : request.Course_Number.CompareTo(this.ddlCourse.SelectedItem.Value) == 0;
                bool semesterHasValue = this.ddlSemester.SelectedItem.Value.CompareTo("Any") == 0 ? true : request.Semester.Contains(this.ddlSemester.SelectedItem.Value);
                bool statusHasValue = this.ddlAppStatus.SelectedItem.Value.CompareTo("Any") == 0 ? true : request.Status.CompareTo(this.ddlAppStatus.SelectedItem.Value) == 0;

                if (courseHasValue && semesterHasValue && statusHasValue && searchQueryMatches(request))
                {
                    toReturn.Add(request);
                }
            }
            return toReturn;
        }
        private List<ISRARequest> sortedRequests(List<ISRARequest> oldList)
        {
            List<ISRARequest> toReturn = oldList;

            if (this.radAlph.Checked)
            {
                toReturn = oldList.OrderBy(request => request.Student_First + request.Student_Last).ToList();
            } else if (this.radNew.Checked)
            {
                toReturn = oldList.OrderByDescending(request => request.Isra_Id).ToList();
            } else if (this.radOld.Checked)
            {
                toReturn = oldList.OrderBy(request => request.Isra_Id).ToList();
            }

            return toReturn;
        }

        protected void lbClearFilters_Click(object sender, EventArgs e)
        {
            this.ddlCourse.SelectedIndex = 0;
            this.ddlSemester.SelectedIndex = 0;
            this.ddlAppStatus.SelectedIndex = 0;
            this.txtSearch.Text = string.Empty;

            this.radAlph.Checked = false;
            this.radOld.Checked = false;
            this.radNew.Checked = true;

            List<ISRARequest> requests = this.sortedRequests(this.filteredRequests());

            this.displayRecords(requests);
            this.showCurrentFilters();
        }

        private void showCurrentFilters()
        {
            Dictionary<string, string> filterItems = (Dictionary<string, string>)ViewState["filterItems"];
            filterItems["course"] = this.ddlCourse.SelectedItem.Value;
            filterItems["semester"] = this.ddlSemester.SelectedItem.Value;
            filterItems["status"] = this.ddlAppStatus.SelectedItem.Value;

            if (this.radAlph.Checked)
            {
                filterItems["sort"] = this.radAlph.Value;
            }
            else if (this.radNew.Checked)
            {
                filterItems["sort"] = this.radNew.Value;
            }
            else if (this.radOld.Checked)
            {
                filterItems["sort"] = this.radOld.Value;
            }

            string filterBadges = string.Empty;
            foreach (KeyValuePair<string, string> item in filterItems)
            {
                if (item.Value.CompareTo("Any") != 0 && !String.IsNullOrEmpty(item.Value))
                {
                    filterBadges += $"<span class='badge rounded-pill bg-secondary me-2'>{item.Value}</span>";
                }
            }
            this.divCurrentFilters.InnerHtml = filterBadges;
        }
        private bool searchQueryMatches(ISRARequest request)
        {
            if (String.IsNullOrEmpty(this.txtSearch.Text))
            {
                return true;
            }
            return request.Isra_Id.ToString().CompareTo(this.txtSearch.Text) == 0 ||
                   request.TUID.ToString().CompareTo(this.txtSearch.Text) == 0 ||
                   request.Student_First.ToLower().CompareTo(this.txtSearch.Text.ToLower()) == 0 ||
                   request.Student_Last.ToLower().CompareTo(this.txtSearch.Text.ToLower()) == 0 ||
                   request.Student_Email.ToLower().CompareTo(this.txtSearch.Text.ToLower()) == 0 ||
                   request.Grade_Instructor.ToLower().CompareTo(this.txtSearch.Text.ToLower()) == 0 ||
                   request.Registrar.ToLower().CompareTo(this.txtSearch.Text.ToLower()) == 0 ||
                   request.Student_Major.ToLower().CompareTo(this.txtSearch.Text.ToLower()) == 0;
        }
        protected void Item_Bound(object sender, RepeaterItemEventArgs e)
        {
            Label lblStudentInitials = (Label)e.Item.FindControl("lblStudentInitials");
            Label lblStudentFirst = (Label)e.Item.FindControl("lblStudentFirst");
            Label lblStudentLast = (Label)e.Item.FindControl("lblStudentLast");
            string color = ISRAUtils.GenerateHexColor($"{lblStudentFirst.Text} {lblStudentLast.Text}");
            color = ISRAUtils.DarkenHexColor(color, 0.8);

            lblStudentInitials.Style.Add("background", $"{color};");
            lblStudentInitials.Style.Add("border-radius", "50%;");
        }
    }
}