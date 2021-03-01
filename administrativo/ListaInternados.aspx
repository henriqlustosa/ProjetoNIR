<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaInternados.aspx.cs" EnableEventValidation="false" Inherits="administrativo_ListaInternados"
    Title="KANBAN - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../build/css/jquery.dataTable.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-md-12">
            <div class="x_title">
                <h2>
                    Painel</h2>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <asp:Button ID="btnVoltaPesquisa" runat="server" Text="Voltar Pesquisa" class="btn btn-default form-group"
            Width="150px" OnClick="btnVoltaPesquisa_Click" />
        <asp:LinkButton ID="Button1" runat="server" Text="Exportar Excell" OnClick="btnExportarExcel_Click"
            class="btn btn-default form-group">
                   <span style="color: green;"> <i class="fa fa-file-excel-o fa-2x" aria-hidden="true"></i></span>
        </asp:LinkButton>
    </div>
    <div class="row">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_internacao"
            OnRowCommand="grdMain_RowCommand" OnRowDataBound="cor1GridView_RowDataBound"
            ForeColor="#333333" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="cod_internacao" HeaderText="Cód" SortExpression="cod_internacao"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="quarto" HeaderText="Leito" SortExpression="quarto" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="prontuario" HeaderText="Prontuário" SortExpression="prontuario"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="nome" HeaderText="Paciente" SortExpression="nome" ItemStyle-CssClass="hidden-md"
                    HeaderStyle-CssClass="hidden-md" />
                <asp:BoundField DataField="data_internacao_data" HeaderText="Dt Int" SortExpression="data_internacao_data"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="unidade_funcional" HeaderText="Unidade Funcional" SortExpression="unidade_funcional"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="especialidade" HeaderText="Especialidade" SortExpression="especialidade"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="tempo" HeaderText="Tempo" SortExpression="tempo" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="diagnostico" HeaderText="Diagnostico" SortExpression="diagnostico"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="detalhamento" HeaderText="Detalhamento" SortExpression="detalhamento"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="aguarda" HeaderText="Aguarda" SortExpression="aguarda"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                <asp:BoundField DataField="data_carga" HeaderText="Data do Censo" SortExpression="data_carga"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled">
                    <ItemTemplate>
                        <div class="form-inline">
                            <asp:LinkButton ID="gvlnkEdit" CommandName="editRecord" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                CssClass="btn btn-info" runat="server">
                                    <i class="fa fa-pencil-square-o" title="Informação"></i> 
                            </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </div>

    <script src='<%= ResolveUrl("~/vendors/jquery/dist/jquery.js") %>' type="text/javascript"></script>

    <script src='<%= ResolveUrl("~/build/js/jquery.dataTables.js") %>' type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $.noConflict();
            $('#<%= GridView1.ClientID %>').DataTable({
                "paging": false,
                "ordering": true,
                "info": false
            });
        });
    </script>

</asp:Content>
