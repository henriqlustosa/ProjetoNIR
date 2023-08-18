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
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for CensoDAO
/// </summary>
public class CensoDAO
{
    public static void InserirCenso(Censo p)
    {
        int existPac = PacienteDAO.existPaciente(p.prontuario);
        p.usuario_carga = System.Web.HttpContext.Current.User.Identity.Name.ToLower();

        if (existPac.Equals(0))
        {
            PacienteDAO.InserirPaciente(p.prontuario, p.nome, p.nascimento, p.sexo, p.vinculo);
            InternacaoDAO.InserirInternacao(p.prontuario, p.quarto, p.data_internacao_data, p.especialidade, p.medico, p.tempo, p.cid, p.descricaoCid, p.unidade_funcional);
        }
        else
        {
            PacienteDAO.AtualizarPaciente(p.prontuario, p.nome, p.nascimento, p.sexo, p.vinculo);
            int existInternacao = InternacaoDAO.VerificaInternacao(p.prontuario, p.data_internacao_data);

            if (existInternacao.Equals(0))
            {
                InternacaoDAO.InserirInternacao(p.prontuario, p.quarto, p.data_internacao_data, p.especialidade, p.medico, p.tempo, p.cid, p.descricaoCid, p.unidade_funcional);
            }
            else
            {
                InternacaoDAO.AtualizarInternacao(p.prontuario, p.quarto, p.data_internacao_data, p.especialidade, p.medico, p.tempo, p.cid, p.descricaoCid, p.unidade_funcional, p.usuario_carga);
            }
        }
    }

    
    public static List<Paciente> getListaPacientesInternadosUltimaCarga(string data_carga)
    {
        string data = data_carga;
        int dia = Convert.ToInt32(data.Substring(0, 2));
        int mes = Convert.ToInt32(data.Substring(3, 2));
        int ano = Convert.ToInt32(data.Substring(6, 4));

        //int dia = DateTime.Now.Day;
        //int mes = DateTime.Now.Month;
        //int ano = DateTime.Now.Year;



        var listaInternados = new List<Paciente>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["nirConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            string sqlConsulta = "SELECT [prontuario]" +
                              ",[nome]" +
                              ",[quarto]" +
                              ",[unidade_funcional]" +
                              ",[dt_internacao]" +
                              ",[especialidade]" +
                              ",[tempo]" +
                              ",[cid]" +
                              ",[descricao_cid]" +
                              ",[diagnostico]" +
                              ",[detalhamento]" +
                              ",[aguarda]" +
                              ",[cod_internacao]" +
                              ",[data_carga]" +
                              ",[nascimento]" +
                              " FROM [v_relatorio_detalhado] " +
                              " WHERE DAY(data_carga) = "+ dia +" and MONTH(data_carga)= "+ mes +" and YEAR(data_carga)= " +ano ;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    Paciente p = new Paciente();

                    p.prontuario = dr1.GetInt32(0);
                    p.nome = dr1.GetString(1);
                    p.quarto = dr1.GetInt32(2);
                    p.unidade_funcional = dr1.GetString(3);
                    p.data_internacao_data = dr1.GetString(4);
                    p.especialidade = dr1.GetString(5);
                    p.tempo = dr1.GetString(6);
                    p.cid = dr1.GetString(7);
                    p.descricao_cid = dr1.GetString(8);
                    //colocar o cid no diagnóstico. Em 09/04/2021
                    p.diagnostico = p.cid.ToString() + " - " + p.descricao_cid;
                    p.diagnostico += dr1.IsDBNull(9) ? "" : ";" + dr1.GetString(9);
                    p.detalhamento = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    p.aguarda = dr1.IsDBNull(11) ? "" : dr1.GetString(11);
                    p.cod_internacao = dr1.GetInt32(12);
                    p.data_carga = dr1.GetDateTime(13);
                    p.nascimento = dr1.GetString(14);
                    p.idade = FormatDate.CalculaIdade(p.nascimento);
                    listaInternados.Add(p);

                    
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            //listaInternados.OrderBy(internado => internado.quarto);

            return listaInternados;
        }
    }
}
