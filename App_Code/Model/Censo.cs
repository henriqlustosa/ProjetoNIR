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
/// Summary description for Censo
/// </summary>
public class Censo
{
    public int prontuario { get; set; }
    public string nome { get; set; }
    public string nascimento { get; set; }
    public string quarto { get; set; }
    public string data_internacao_data{ get; set; }
    public string data_internacao_hora { get; set; }
    public string especialidade { get; set; }
    public string medico { get; set; }
    public string sexo { get; set; }
    public string idade { get; set; }
    public string cid { get; set; }
    public string descricaoCid { get; set; }
    public string tempo { get; set; }
    public string unidade_funcional { get; set; }
    public string vinculo { get; set; }
    public string dt_aguarda { get; set; }
    public DateTime data_carga { get; set; }
    public string usuario_carga { get; set; }
}
