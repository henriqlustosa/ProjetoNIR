using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for FormatDate
/// </summary>
public class FormatDate
{
    public static string formatarData(string data)
    {
        string dataFormatada = "";
        DateTime dt = Convert.ToDateTime(data);

        dataFormatada = dt.ToString("dd/MM/yyyy");

        return dataFormatada;
    }
}
