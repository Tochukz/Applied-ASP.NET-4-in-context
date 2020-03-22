using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingApp
{
    public partial class Pager : System.Web.UI.Page
    {
        private PagedDataSource DataSource;

        protected void Page_Load(object sender, EventArgs e)
        {
            /* The PagedDataSource control works only with data sequences that implements the ICollection interface.
             * This is so that it can determine how many records there are and figure out the number if pages.
             * This is not an approach that works well wth the Entity Framewrk, which tries to defer making queries to the database until the data is required.
             * Entity Framework does not implement the ICollection interface because it is unable to tell the result count in advance
             * We get around this by calling the ToArray() method which forces EF to retrieve the data from the database
             * We then end up loading all the recrods event though we need just one.
             * 
             * See the CustomPager.aps.cs code behind for an optimized implementation.
             */
            DataSource = new PagedDataSource();
            DataSource.AllowPaging = true;
            DataSource.DataSource = new TrainingDataEntities().Events.ToArray();
            DataSource.PageSize = 1;

            Repeater1.DataSource = DataSource;

            if (!IsPostBack)
            {
                DoCommonPrep();
                ViewState["page_index"] = 0;
            }
        }

        private void DoCommonPrep()
        {
            Button1.Enabled = !DataSource.IsFirstPage;
            Button2.Enabled = !DataSource.IsLastPage;
            Repeater1.DataBind();
            PagerLabel.Text = String.Format("{0} of {1}", DataSource.CurrentPageIndex + 1, DataSource.DataSourceCount);
        }

        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            if (args is CommandEventArgs)
            {
                int page_index = int.Parse(ViewState["page_index"].ToString());
                switch(((CommandEventArgs)args).CommandName)
                {
                    case "Prev":
                        DataSource.CurrentPageIndex = Math.Max(page_index - 1, 0);
                        break;
                    case "Next":
                        DataSource.CurrentPageIndex = Math.Min(page_index + 1, DataSource.DataSourceCount - 1);
                        break;
                }
                DoCommonPrep();
                ViewState["page_index"] = DataSource.CurrentPageIndex;
                return true;
            }
            return false;
        }

    }
}