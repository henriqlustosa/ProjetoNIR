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
/// Summary description for Internacao
/// </summary>
public class Internacao : Anotacao
{
    public int cod_internacao { get; set; }
    public int prontuario_pac { get; set; }
    public int quarto { get; set; }
    public string  data_internacao_data { get; set; }
    public string data_internacao_hora { get; set; }
    public string especialidade { get; set; }
    public string medico { get; set; }
    public string tempo { get; set; }
    public string cid { get; set; }
    public string descricao_cid { get; set; }
    public string unidade_funcional { get; set; }
    public DateTime data_carga { get; set; }
}
