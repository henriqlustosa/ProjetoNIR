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
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for InternacaoDAO
/// </summary>
public class InternacaoDAO
{

    private static int TrataTempoInternacao(string tempo)
    {
        int dias = 0;
        var apenasDigitos = new Regex(@"[^\d]");
        dias = Convert.ToInt32(apenasDigitos.Replace(tempo, ""));
        return dias;
    }


    public static int VerificaInternacao(int prontuario, string dt_internacao)
    {
        int exist = 0;
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["nirConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = "SELECT [prontuario_pac] " +
                              "FROM [internacao] " +
                              "WHERE [prontuario_pac] = " + prontuario + " AND dt_internacao =  '"+ dt_internacao +"'";
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


    public static void InserirInternacao(int prontuario_pac, string quarto, string dt_internacao, string especialidade, string medico, string tempo, string cid, string descricao_cid, string unidade_funcional)
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
                cmm.CommandText = "Insert into [internacao] " +
                                   "([prontuario_pac]" +
                                   ",[quarto]" +
                                   ",[dt_internacao]" +
                                   ",[especialidade]" +
                                   ",[medico]" +
                                   ",[cid]" +
                                   ",[descricao_cid]" +
                                   ",[tempo]" +
                                   ",[unidade_funcional]" +
                                   ",[data_carga]" +
                                   ",[usuario_carga])" +
                                   " VALUES (@prontuario, @quarto, @dt_internacao, @especialidade" +
                                   ", @medico, @cid, @descricao_cid, @tempo, @unidade_funcional,@data_carga, @usuario_carga)";

                cmm.Parameters.Add("@prontuario", SqlDbType.Int).Value = prontuario_pac;
                cmm.Parameters.Add("@quarto", SqlDbType.VarChar).Value = quarto;
                cmm.Parameters.Add("@dt_internacao", SqlDbType.VarChar).Value = dt_internacao;
                cmm.Parameters.Add("@especialidade", SqlDbType.VarChar).Value = especialidade;
                cmm.Parameters.Add("@medico", SqlDbType.VarChar).Value = medico;
                cmm.Parameters.Add("@cid", SqlDbType.VarChar).Value = cid;
                cmm.Parameters.Add("@descricao_cid", SqlDbType.VarChar).Value = descricao_cid;

                cmm.Parameters.Add("@tempo", SqlDbType.VarChar).Value = TrataTempoInternacao(tempo);

                cmm.Parameters.Add("@unidade_funcional", SqlDbType.VarChar).Value = unidade_funcional;
                cmm.Parameters.Add("@data_carga", SqlDbType.DateTime).Value = DateTime.Now;
                cmm.Parameters.Add("@usuario_carga", SqlDbType.VarChar).Value = System.Web.HttpContext.Current.User.Identity.Name.ToLower();
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

    public static void AtualizarInternacao(int prontuario_pac, string quarto, string dt_internacao, string especialidade, string medico, string tempo, string cid, string descricao_cid, string unidade_funcional, string usuario_carga)
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
                cmm.CommandText = "UPDATE internacao " +
                    "SET quarto = @quarto, " +
                    " especialidade = @especialidade, " +
                    " medico = @medico, " +
                    " tempo = @tempo, " +
                    " cid = @cid, " +
                    " descricao_cid = @descricao_cid, " +
                    " unidade_funcional = @unidade_funcional, " +
                    " usuario_carga = @usuario_carga, " +
                    " data_carga = @data_carga " +
                    " WHERE prontuario_pac = @prontuario "+
                    " AND dt_internacao = @data_internacao";
                cmm.Parameters.Add(new SqlParameter("@quarto",quarto));
                cmm.Parameters.Add(new SqlParameter("@especialidade",especialidade));
                cmm.Parameters.Add(new SqlParameter("@medico",medico));
                cmm.Parameters.Add(new SqlParameter("@tempo", TrataTempoInternacao(tempo)));
                cmm.Parameters.Add(new SqlParameter("@cid",cid));
                cmm.Parameters.Add(new SqlParameter("@descricao_cid",descricao_cid));
                cmm.Parameters.Add(new SqlParameter("@unidade_funcional",unidade_funcional));
                cmm.Parameters.Add(new SqlParameter("@usuario_carga",usuario_carga.ToLower()));
                cmm.Parameters.Add(new SqlParameter("@prontuario",prontuario_pac));
                cmm.Parameters.Add(new SqlParameter("@data_internacao",dt_internacao));
                cmm.Parameters.Add(new SqlParameter("data_carga", DateTime.Now));

                cmm.ExecuteNonQuery();
                mt.Commit();
                mt.Dispose();
                cnn.Close();
            }catch(Exception ex){
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
