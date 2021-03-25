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
/// Summary description for Paciente
/// </summary>
public class Paciente : Internacao
{
    public int prontuario { get; set; }
    public string nome { get; set; }
    public string nascimento { get; set; }
    public string sexo { get; set; }
    public string vinculo { get; set; }
    public int idade { get; set; }
}
