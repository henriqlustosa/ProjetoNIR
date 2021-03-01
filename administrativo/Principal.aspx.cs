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

public partial class administrativo_Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


    protected void btnCenso_Click(object sender, EventArgs e)
    {
        List<Censo> details = new List<Censo>();
        try
        {
            string URI = "http://10.48.21.64:5000/hspmsgh-api/censo/";
            WebRequest request = WebRequest.Create(URI);

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(URI);
            // Sends the HttpWebRequest and waits for a response.
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(httpResponse.GetResponseStream());
                JsonSerializer json = new JsonSerializer();
                var objText = reader.ReadToEnd();
                details = JsonConvert.DeserializeObject<List<Censo>>(objText);

                foreach (Censo paciente in details)
                {
                    CensoDAO.InserirCenso(paciente);
                }
            }
        }
        catch (WebException ex)
        {
            string err = ex.Message;
        }
        catch (Exception ex1)
        {
            string err1 = ex1.Message;
        }
    }

    protected void btnDOB_Click(object sender, EventArgs e)
    {
        try
        {
            if (txbDOB.Text.Trim() != "")
                cdrCalendar.SelectedDate = Convert.ToDateTime(txbDOB.Text);
        }
        catch
        { }
        cdrCalendar.Visible = true;  //showing the calendar.
    }

    protected void ocultaCalendar(object sender, EventArgs e)
    {
        //displaying the selected date in TextBox
        txbDOB.Text = cdrCalendar.SelectedDate.ToShortDateString();
        cdrCalendar.Visible = false; //hiding the calendar.
    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        if (txbDOB.Text.Equals(""))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Pop", "modalAguarde();", true);
        }
        else
        {
            Response.Redirect("~/administrativo/ListaInternados.aspx?data_carga=" + FormatDate.formatarData(txbDOB.Text));
        }
    }
}