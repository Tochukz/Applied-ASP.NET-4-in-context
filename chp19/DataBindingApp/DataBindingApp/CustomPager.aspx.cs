using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBindingApp
{
    public partial class CustomPager : System.Web.UI.Page
    {
        private PagedDataSource DataSource;
        private TrainingDataEntities Entities;

        protected void Page_Load(object sender, EventArgs e)
        {
            /* The only drawback to this custom paging implementation is that it make 2 trips to the database for every request
             * one to get the total number of records and the second to the the actual record to be displayed.
             */
            Entities = new TrainingDataEntities();

            DataSource = new PagedDataSource();
            DataSource.AllowPaging = true;
            DataSource.AllowCustomPaging = true;
            DataSource.PageSize = 1;
            DataSource.VirtualCount = Entities.Events.Count();

            Repeater1.DataSource = DataSource;

            if (!IsPostBack)
            {
                DoCommonPrep();
                ViewState["page_index"] = 0;
            }
        }

        private void DoCommonPrep()
        {
            DataSource.DataSource = Entities.Events
                                            .OrderBy(item => item.ID)
                                            .Skip(DataSource.CurrentPageIndex)
                                            .Take(1);
            Repeater1.DataBind();

            Button1.Enabled = !DataSource.IsFirstPage;
            Button2.Enabled = !DataSource.IsLastPage;
            PagerLabel.Text = String.Format("{0} of {1}", DataSource.CurrentPageIndex + 1, DataSource.DataSourceCount);
        }

        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            if (args is CommandEventArgs)
            {
                int page_index = int.Parse(ViewState["page_index"].ToString());
                switch (((CommandEventArgs)args).CommandName)
                {
                    case "Prev":
                        DataSource.CurrentPageIndex = Math.Max(page_index - 1, 0);
                        break;
                    case "Next":
                        DataSource.CurrentPageIndex = Math.Min(page_index + 1, DataSource.VirtualCount - 1);
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