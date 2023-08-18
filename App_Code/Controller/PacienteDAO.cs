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

/// <summary>
/// Summary description for PacienteDAO
/// </summary>
public class PacienteDAO
{
    public static int existPaciente(int prontuario)
    {
        int exist = 0;
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["nirConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [prontuario] "+
                              "FROM [Paciente] " +
                              "WHERE [prontuario] = '" + prontuario + "'";
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    exist = 1;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return exist;
    }

    public static void InserirPaciente(int prontuario, string nome, string nascimento, string sexo, string vinculo)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["nirConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {
                cmm.CommandText = "Insert into [Paciente] " +
                                   "([prontuario]" +
                                   ",[nome]" +
                                   ",[nascimento]" +
                                   ",[sexo]"+
                                   ",[vinculo])" +
                                   " VALUES (@prontuario, @nome, @nascimento, @sexo,@vinculo)";

                cmm.Parameters.Add("@prontuario", SqlDbType.Int).Value = prontuario;
                cmm.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                cmm.Parameters.Add("@nascimento", SqlDbType.VarChar).Value = nascimento;
                cmm.Parameters.Add("@sexo", SqlDbType.VarChar).Value = sexo;
                cmm.Parameters.Add("@vinculo", SqlDbType.VarChar).Value = vinculo;
                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                mt.Rollback();
            }
        }
    }

    public static Paciente getPacienteCenso(int _cod_internacao)
    {
        Paciente p = new Paciente();

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
                              ",[nascimento]" +
                              ",[sexo]" +
                              ",[vinculo]" +
                              ",[data_carga] " +
                              " FROM [v_relatorio_detalhado] " +
                              " WHERE cod_internacao = " +_cod_internacao;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                if (dr1.Read())
                {
                    p.prontuario = dr1.GetInt32(0);
                    p.nome = dr1.GetString(1);
                    p.quarto = dr1.GetInt32(2);
                    p.unidade_funcional = dr1.GetString(3);
                    p.data_internacao_data = dr1.GetString(4);
                    p.especialidade = dr1.GetString(5);
                    p.tempo = dr1.GetString(6);
                    p.cid = dr1.GetString(7);
                    p.descricao_cid = dr1.GetString(8);
                    p.diagnostico = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    p.detalhamento = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    p.aguarda = dr1.IsDBNull(11) ? "" : dr1.GetString(11);
                    p.cod_internacao = dr1.GetInt32(12);
                    p.nascimento = dr1.GetString(13);
                    p.sexo = dr1.GetString(14);
                    p.vinculo = dr1.GetString(15);
                    p.data_carga = dr1.GetDateTime(16);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return p;
    }

    internal static void AtualizarPaciente(int prontuario, string nome, string nascimento, string sexo, string vinculo)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["nirConnectionString"].ToString()))
        {
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cnn.Open();
            SqlTransaction mt = cnn.BeginTransaction();
            cmm.Transaction = mt;
            try
            {


                cmm.CommandText = "UPDATE [dbo].[Paciente] " +
                                   " SET" +
                                   " [nome] = @nome " +
                                   ",[nascimento] = @nascimento"  +
                                   ",[sexo] = @sexo " +
                                   ",[vinculo] = @vinculo " +
                                   " WHERE prontuario = @prontuario";

                cmm.Parameters.Add("@prontuario", SqlDbType.Int).Value = prontuario;
                cmm.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                cmm.Parameters.Add("@nascimento", SqlDbType.VarChar).Value = nascimento;
                cmm.Parameters.Add("@sexo", SqlDbType.VarChar).Value = sexo;
                cmm.Parameters.Add("@vinculo", SqlDbType.VarChar).Value = vinculo;
                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                mt.Rollback();
            }
        }
    }
}
