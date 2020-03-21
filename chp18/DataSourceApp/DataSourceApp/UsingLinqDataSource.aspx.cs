using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataSourceApp
{
    public class Fruit
    {
        public string Name { get; set; }

        public string Color { get; set; }
    }

    public class LinqWrapper
    {
        public string Name { set; get; }
    }

    public partial class UsingLinqDataSource : System.Web.UI.Page
    {
        public Fruit[] FruitDataArray = new[]
       {
            new Fruit() { Name = "Applie", Color = "Green" },
            new Fruit() { Name = "Banana", Color = "Yellow" },
            new Fruit() { Name = "Cherry", Color = "Red"},
            new Fruit() { Name = "Plum", Color = "Red"}
        };

        /* This field must be initialized outside of any page event method like PageLoad, PageInit or PagePreInit. 
         * That is because DataSouces are initialized before any of the page event method is invoked.
         * This means we cannot change the nature of the LinQ query in response to the state of the page.
         */
        public IEnumerable<LinqWrapper> AthleteNames = new TrainingDataEntities().Events.Select(ev => new LinqWrapper { Name = ev.Athlete });
        /* We had to wrap the Property in an object - LinqWrapper because without it we get a sequence of string which may not be suitable for the DataSource control */

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /* This example is more flexible and allows us to use the full range of LINQ features */
                var results = new TrainingDataEntities().Events.Select(ev => ev.Athlete).Distinct().ToList();
                DropDownList3.DataSource = results;
                DropDownList3.DataBind();
            }
        }


    }
}