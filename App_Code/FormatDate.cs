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

    public static int CalculaIdade(string dataNascimento)
    {
        DateTime dt = DateTime.Now;
        int dia = Convert.ToInt32(dataNascimento.Substring(0, 2));
        int mes = Convert.ToInt32(dataNascimento.Substring(3, 2));
        int ano = Convert.ToInt32(dataNascimento.Substring(6, 4));
        DateTime dtnasc = new DateTime(ano, mes, dia);
        
        int idade = dt.Year - dtnasc.Year;

        if (dtnasc.AddYears(idade) > dt)
            idade--;


        return idade;
    }
}
