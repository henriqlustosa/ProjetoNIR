using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class administrativo_DetalhamentoPaciente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ddlTipoInformacao.DataSource = Tipo_InformcaoDAO.getListaTipoInformacao();
            //ddlTipoInformacao.DataTextField = "descricao_informacao";
            //ddlTipoInformacao.DataValueField = "cod_tipo_informacao";
            //ddlTipoInformacao.DataBind();

            btnAtualizar.Visible = false;
            int cod = Convert.ToInt32(Request.QueryString["cod"]);
            BindInternacao(cod);
        }
    }


    private void BindInternacao(int _cod_internacao)
    {
        Paciente p = new Paciente();

        p = PacienteDAO.getPacienteCenso(_cod_internacao);

        if (p.cod_internacao.Equals(0))
        {
            lbProntuario.Text = "";
        }
        else
        {
            lbCodInternacao.Text = p.cod_internacao.ToString();
            lbProntuario.Text = p.prontuario.ToString();
            lbNome.Text = p.nome;
            lbDtInternacao.Text = p.data_internacao_data;
            lbTempo.Text = p.tempo;
            lbEspecialidade.Text = p.especialidade;
            lbQuarto.Text = p.quarto.ToString();
            lbUnidadeFuncional.Text = p.unidade_funcional;
            lbCID.Text = p.cid + " - " + p.descricao_cid;
            lbSexo.Text = p.sexo;
            lbNascimento.Text = p.nascimento;
            lbVinculo.Text = p.vinculo;
            lbdtCarga.Text = p.data_carga.ToShortDateString();
        }
    }

    protected void gvDetalhamento_PreRender(object sender, EventArgs e)
    {
        if (lbCodInternacao.Text != "")
        {
            int _item = Convert.ToInt32(lbCodInternacao.Text);
            gvDetalhamento.DataSource = AnotacaoDAO.listaAnotacaoInternacao(_item);
            gvDetalhamento.DataBind();
        }
    }

    protected void btnVoltarLista_Click(object sender, EventArgs e)
    {
        string data = lbdtCarga.Text;
        Response.Redirect("~/administrativo/ListaInternados.aspx?data_carga=" + FormatDate.formatarData(data));
    }

    protected void btnGravaAnotacao_Click(object sender, EventArgs e)
    {
        Anotacao a = new Anotacao();
        a.cod_internacao = Convert.ToInt32(lbCodInternacao.Text);
        a.usuario_anotacao = System.Web.HttpContext.Current.User.Identity.Name;
        a.diagnostico = txbDiagnostico.Text;
        a.detalhamento = txbDetalhamento.Text;
        a.aguarda = txbAguarda.Text;
        
        AnotacaoDAO.GravaAnotacaoInternacao(a.cod_internacao, a.usuario_anotacao, a.diagnostico, a.detalhamento, a.aguarda);
        txbDiagnostico.Text = "";
        txbDetalhamento.Text = "";
        txbAguarda.Text = "";
    }

    protected void btnAtualizaAnotacao_Click(object sender, EventArgs e)
    {
        Anotacao a = new Anotacao();
        a.cod_anotacao = Convert.ToInt32(lbCodAnotacao.Text);
        a.diagnostico = txbDiagnostico.Text;
        a.detalhamento = txbDetalhamento.Text;
        a.aguarda = txbAguarda.Text;
        AnotacaoDAO.AtualizaAnotacaoInternacao(a.cod_anotacao, a.diagnostico, a.detalhamento, a.aguarda);

        txbDiagnostico.Text = "";
        txbDetalhamento.Text = "";
        txbAguarda.Text = "";
        lbCodAnotacao.Text = "";

        btnGravar.Visible = true;
        btnAtualizar.Visible = false;
    }

    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        int _cod_anotacao;

        if (e.CommandName.Equals("editAnotacao"))
        {
            Anotacao a = new Anotacao();
            index = Convert.ToInt32(e.CommandArgument);
            // necessário um index único
            _cod_anotacao = Convert.ToInt32(gvDetalhamento.DataKeys[index].Value.ToString());
            GridViewRow row = gvDetalhamento.Rows[index];

            a.diagnostico = HttpUtility.HtmlDecode(row.Cells[1].Text);
            a.detalhamento = HttpUtility.HtmlDecode(row.Cells[2].Text);
            a.aguarda = HttpUtility.HtmlDecode(row.Cells[3].Text);


            lbCodAnotacao.Text = row.Cells[0].Text;
            txbDiagnostico.Text = a.diagnostico;
            txbDetalhamento.Text = a.detalhamento;
            txbAguarda.Text = a.aguarda;

            btnGravar.Visible = false;
            btnAtualizar.Visible = true;
        }
        if (e.CommandName.Equals("deletaAnotacao"))
        {
            index = Convert.ToInt32(e.CommandArgument);

            // necessário um index único
            _cod_anotacao = Convert.ToInt32(gvDetalhamento.DataKeys[index].Value.ToString());
            GridViewRow row = gvDetalhamento.Rows[index];

            AnotacaoDAO.DeletaAnotacaoInternacao(_cod_anotacao);
        }
    }
}