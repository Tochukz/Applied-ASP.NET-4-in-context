using System;
using System.Web.UI;

namespace HandlingErrors
{
    public class PageController: Page
    {
        protected virtual void Page_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            if (ex is ArgumentOutOfRangeException)
            {
                Server.Transfer("/CustomError.aspx");
            }
        }
    }
}