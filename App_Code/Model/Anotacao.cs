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
/// Summary description for Anotacao
/// </summary>
public class Anotacao
{
    public int cod_anotacao { get; set; }
    public int cod_internacao { get; set; }
    public string diagnostico { get; set; }
    public string detalhamento { get; set; }
    public string aguarda { get; set; }
    public DateTime data_anotacao { get; set; }
    public string usuario_anotacao { get; set; }
}