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
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AnotacaoDAO
/// </summary>
public class AnotacaoDAO
{

    public static List<Anotacao> listaAnotacaoInternacao(int _item)
    {
        var listaAnotacoes = new List<Anotacao>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["nirConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            string sqlConsulta = "SELECT [cod_anotacao]" +
                              ",[data_anotacao]"+
                              ",[usuario_anota]"+
                              ",[cod_internacao]"+
                              ",[diagnostico]" +
                              ",[detalhamento]" +
                              ",[aguarda]" +
                              " FROM [Anotacoes] " +
                              " WHERE [cod_internacao] = " + _item;
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    Anotacao a = new Anotacao(); ;
                    a.cod_anotacao = dr1.GetInt32(0);
                    a.data_anotacao = dr1.GetDateTime(1);
                    a.usuario_anotacao = dr1.GetString(2);
                    a.cod_internacao = dr1.GetInt32(3);
                    a.diagnostico = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    a.detalhamento = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    a.aguarda = dr1.IsDBNull(6) ? "" : dr1.GetString(6);

                    listaAnotacoes.Add(a);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return listaAnotacoes;
        }
    }

    public static void GravaAnotacaoInternacao(int cod_internacao, string usuario, string diagnostico, string detalhamento, string aguarda)
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
                cmm.CommandText = "Insert into [Anotacoes] " +
                                   "([data_anotacao]" +
                                   ",[usuario_anota]" +
                                   ",[cod_internacao]" +
                                   ",[diagnostico]" +
                                   ",[detalhamento]" +
                                   ",[aguarda])" +
                                   " VALUES (@data_anotacao, @usuario_anota, @cod_internacao, @diagnostico, @detalhamento, @aguarda)";

                cmm.Parameters.Add("@data_anotacao", SqlDbType.DateTime).Value = DateTime.Now;
                cmm.Parameters.Add("@usuario_anota", SqlDbType.VarChar).Value = usuario.ToLower();
                cmm.Parameters.Add("@cod_internacao", SqlDbType.VarChar).Value = cod_internacao;
                cmm.Parameters.Add("@diagnostico", SqlDbType.VarChar).Value = diagnostico;
                cmm.Parameters.Add("@detalhamento", SqlDbType.VarChar).Value = detalhamento;
                cmm.Parameters.Add("@aguarda", SqlDbType.VarChar).Value = aguarda;
                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                mt.Rollback();
            }
        }
    }

    public static void DeletaAnotacaoInternacao(int _cod_anotacao)
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
                cmm.CommandText = "DELETE FROM [Anotacoes] " +
                     " WHERE  [cod_anotacao] = @cod_anotacao";
                cmm.Parameters.Add(new SqlParameter("@cod_anotacao", _cod_anotacao));
                cmm.ExecuteNonQuery();

                mt.Commit();
                mt.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
    }

    public static void AtualizaAnotacaoInternacao(int _cod_anotacao, string diagnostico, string detalhamento, string aguarda)
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
                cmm.CommandText = "UPDATE Anotacoes " +
                    "SET diagnostico = @diagnostico, " +
                    " detalhamento = @detalhamento, " +
                    " aguarda = @aguarda, " +
                    " data_anotacao = @data_anotacao, " +
                    " usuario_anota = @usuario_anota " +
                    " WHERE cod_anotacao = @cod_anotacao";
                cmm.Parameters.Add(new SqlParameter("@cod_anotacao", _cod_anotacao));
                cmm.Parameters.Add(new SqlParameter("@diagnostico", diagnostico));
                cmm.Parameters.Add(new SqlParameter("@detalhamento", detalhamento));
                cmm.Parameters.Add(new SqlParameter("@aguarda", aguarda));
                cmm.Parameters.Add(new SqlParameter("@data_anotacao", DateTime.Now));
                cmm.Parameters.Add(new SqlParameter("@usuario_anota", System.Web.HttpContext.Current.User.Identity.Name.ToLower()));

                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                try
                {
                    mt.Rollback();
                }
                catch (Exception ex1)
                { }
            }
        }
    }
}
