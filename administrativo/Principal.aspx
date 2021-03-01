<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Principal.aspx.cs" Inherits="administrativo_Principal" Title="KANBAN - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <link href="../build/css/jquery.dataTable.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPopup() {
            $('#myModal').modal('show');
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-md-12">
            <div class="x_title">
                <h2>
                    Pesquisa Internados</h2>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        
        <div class="col-md-12">
            <div class="x_title">
                <asp:Button ID="btnCenso" runat="server" Text="Carrega censo" class="btn btn-default form-group"
                    OnClick="btnCenso_Click" data-toggle="modal" data-target="#modalAguarde" />
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="x_title">
                <h3>
                    <asp:Label ID="Label1" runat="server" Text="Selecione a Data"></asp:Label></h3>
                <div class="clearfix">
                </div>
                <div class="row">
                    <div class="col-md-4 form-group">
                        <asp:TextBox ID="txbDOB" runat="server" Enabled="false" class="form-control" required></asp:TextBox>
                    </div>
                    <div class="col-md-1 form-group">
                        <asp:LinkButton ID="btnDOB" runat="server" OnClick="btnDOB_Click">
                            <i class="glyphicon glyphicon-calendar fa fa-calendar fa-3x" title="Calendário"></i>
                        </asp:LinkButton>
                    </div>
                    <div class="col-md-2 form-group">
                        <asp:Button ID="btnListar" runat="server" Text="Listar" class="btn btn-primary form-control"
                            OnClick="btnListar_Click" />
                    </div>
                </div>
                <div class="row">
                    <asp:Calendar ID="cdrCalendar" runat="server" BackColor="White" Width="320px" Height="200px"
                        Font-Size="8pt" Font-Names="Verdana" BorderWidth="1px" BorderColor="#3366CC"
                        DayNameFormat="Shortest" Visible="False" CellPadding="1" ForeColor="#003399"
                        OnSelectionChanged="ocultaCalendar">
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <TodayDayStyle ForeColor="White" BackColor="Black"></TodayDayStyle>
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"></NextPrevStyle>
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px"></DayHeaderStyle>
                        <TitleStyle Font-Size="10pt" Font-Bold="True" BorderWidth="1px" ForeColor="#CCCCFF"
                            BackColor="#003399" BorderColor="#3366CC" Height="25px"></TitleStyle>
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#CCCCCC"></OtherMonthDayStyle>
                    </asp:Calendar>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalAguarde" tabindex="-1" role="dialog" aria-hidden="true"
        data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">
                        Importação do Censo SGH</h5>
                </div>
                <div class="modal-body" align="center">
                    <h2>
                        Aguarde a importação...</h2>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/build/images/loading.gif" alt="gif image"
                        Width="100px" Height="100px" />
                </div>
            </div>
        </div>
    </div>
    
    
    <!-- Modal ainda não funcionado -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel">Server Message</h4>
            </div>
            <div class="modal-body">
                <div class="table-responsive">
                        Selecione uma data
                </div>
                <!-- content1 end  -->
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
        </div>
        <!-- modal-content -->
    </div>
    <!-- modal-dialog -->
</div>
    <!-- modal -->

</asp:Content>