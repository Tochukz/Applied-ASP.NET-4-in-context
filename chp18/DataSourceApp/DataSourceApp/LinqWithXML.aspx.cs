using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DataSourceApp
{
    public partial class LinqWithXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xmlDataString = @"<Athletes>
                                        <Athlete>
                                            <Name>Adam Freeman</Name>
                                            <City>London</City>
                                        </Athlete>
                                        <Athlete>
                                           <Name>Joe Smith</Name>
                                            <City>New York</City>       
                                        </Athlete>
                                    </Athletes>";

            if (!IsPostBack)
            {
                var results = XDocument.Parse(xmlDataString).Descendants("Name").Select(elem => elem.Value);
                DropDownList1.DataSource = results;
                DropDownList1.DataBind();
            }
        }
    }
}