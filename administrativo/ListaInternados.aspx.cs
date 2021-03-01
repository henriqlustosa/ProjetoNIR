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
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;

public partial class administrativo_ListaInternados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string data_carga = Request.QueryString["data_carga"];
        PacientesInternados(data_carga);
    }

    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;

        if (e.CommandName.Equals("editRecord"))
        {
            index = Convert.ToInt32(e.CommandArgument);

            // necessário um index único
            int _cod_internacao = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString());
            GridViewRow row = GridView1.Rows[index];
            //string _status = row.Cells[7].Text;

            Response.Redirect("~/administrativo/DetalhamentoPaciente.aspx?cod=" + _cod_internacao + "");
        }
    }

    protected void PacientesInternados(string data_carga)
    {
        GridView1.DataSource = CensoDAO.getListaPacientesInternadosUltimaCarga(data_carga);
        GridView1.DataBind();

        if (GridView1.Rows.Count > 0)
        {
            //This replaces <td> with <th> and adds the scope attribute
            GridView1.UseAccessibleHeader = true;
            //This will add the <thead> and <tbody> elements
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            //This adds the <tfoot> element. 
            //Remove if you don't have a footer row
            GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void cor1GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        //colorindo uma linha com base no conteúdo de uma célula
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int tempo = Convert.ToInt32(e.Row.Cells[7].Text);
            if (tempo <= 5)
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.Green;
                e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
            }
            if(tempo.Equals(6)){
                e.Row.Cells[7].BackColor = System.Drawing.Color.Yellow;
            }
            if(tempo >= 7){
                e.Row.Cells[7].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
            }
        }
    }

    protected void btnVoltaPesquisa_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/administrativo/Principal.aspx");
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the runtime error "  
        //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
    }
    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "NIR" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        GridView1.GridLines = GridLines.Both;
        GridView1.HeaderStyle.Font.Bold = true;
        GridView1.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }

    protected void btnExportarExcel_Click(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }
}