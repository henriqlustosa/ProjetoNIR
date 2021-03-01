<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DetalhamentoPaciente.aspx.cs" Inherits="administrativo_DetalhamentoPaciente"
    Title="KANBAN - HSPM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Dados Clínicos</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="container">
        <div class="x_panel">
            <div class="x_title">
                <h2>
                    Dados do Paciente
                </h2>
                <div class="clearfix">
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-sm-6 profile_details">
                    <div class="well profile_view">
                        <div class="col-sm-12">
                            <div class="left col-xs-8">
                                <h3>
                                    <asp:Label ID="lbCodInternacao" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:Label ID="lbNome" runat="server" Text=""></asp:Label>
                                </h3>
                                <p>
                                    <strong>Prontuário: </strong>
                                    <asp:Label ID="lbProntuario" runat="server" Text=""> </asp:Label>
                                </p>
                                <p>
                                    <strong>Nascimento: </strong>
                                    <asp:Label ID="lbNascimento" runat="server" Text=""></asp:Label>
                                    <strong>Sexo: </strong>
                                    <asp:Label ID="lbSexo" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    <strong>Vínculo: </strong>
                                    <asp:Label ID="lbVinculo" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    <strong>Data de Internação: </strong>
                                    <asp:Label ID="lbDtInternacao" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    <strong>Tempo de Internação: </strong>
                                    <asp:Label ID="lbTempo" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    <strong>Quarto: </strong>
                                    <asp:Label ID="lbQuarto" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    <strong>Unidade Funcional: </strong>
                                    <asp:Label ID="lbUnidadeFuncional" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    <strong>Especialidade: </strong>
                                    <asp:Label ID="lbEspecialidade" runat="server" Text=""></asp:Label>
                                </p>
                                <p>
                                    <strong>Data da Carga: </strong>
                                    <asp:Label ID="lbdtCarga" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                            <div class="right col-xs-3 text-center">
                                <img src="../images/user.png" alt="" class="img-circle img-responsive" />
                            </div>
                        </div>
                        <div class="col-xs-12 bottom">
                            <div class="col-xs-12 col-sm-12">
                                <a>
                                    <asp:Label ID="lbCID" runat="server" Text=""></asp:Label></a>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="Voltar a Lista de Pacientes" class="btn btn-warning form-control"
                        Height="40px" Font-Size="Larger" OnClick="btnVoltarLista_Click" />
                </div>
                <!-- Fim dados do Paciente -->
                <div class="col-md-6">
                    <div class="x_panel titulo">
                        <div class="x_title">
                            <h2>
                                Anotação <span>
                                    <asp:Label ID="lbCodAnotacao" runat="server" Text=""></asp:Label></span></h2>
                            <div class="clearfix">
                            </div>
                        </div>
                        <!-- FORMULÁRIO DE CADASTRO -->
                        <%--<div class="row">
                            <div class="col-md-6 form-group ">
                                <label>
                                    Tipo</label>
                                <asp:DropDownList ID="ddlTipoInformacao" AutoPostBack="True" runat="server" class="form-control input-lg">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 form-group">
                                <label>
                                    Descrição</label>
                                <asp:TextBox ID="txbDescricaoInformacao" runat="server" class="form-control input-lg"
                                    TextMode="MultiLine" Rows="4"></asp:TextBox>
                            </div>
                        </div>
                        --%>
                        <div class="row">
                            <div class="col-md-12 form-group">
                                <label>
                                    Diagnóstico</label>
                                <asp:TextBox ID="txbDiagnostico" runat="server" class="form-control input-lg"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 form-group">
                                <label>
                                    Detalhamento</label>
                                <asp:TextBox ID="txbDetalhamento" runat="server" class="form-control input-lg"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 form-group">
                                <label>
                                    Aguarda</label>
                                <asp:TextBox ID="txbAguarda" runat="server" class="form-control input-lg"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                        <div class="col-md-6 form-group">
                            <asp:Button ID="btnGravar" runat="server" Text="Gravar" class="btn btn-primary" Height="40px"
                                Font-Size="Larger" Width="90px" OnClick="btnGravaAnotacao_Click" />
                                
                                <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" class="btn btn-info" Height="40px"
                                Font-Size="Larger" Width="90px" OnClick="btnAtualizaAnotacao_Click"  />   
                             </div>   
                        </div>
                              
                          
                    </div>
                </div>
            </div>
        </div>
        <!-- Fim div x_panel -->
        <!-- page content -->
        <div>
            <div class="">
                <div class="clearfix">
                </div>
            </div>
            <div class="row">
                <!-- Conteúdo  -->
                <div class="x_panel titulo">
                    <div class="x_title">
                        <h2>
                            Informações registradas</h2>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gvDetalhamento" AutoGenerateColumns="False" DataKeyNames="cod_anotacao" runat="server" 
                         OnRowCommand="grdMain_RowCommand" OnPreRender="gvDetalhamento_PreRender"
                            ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                            <Columns>
                                <asp:BoundField DataField="cod_anotacao" HeaderText="Código" SortExpression="cod_anotacao"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                <asp:BoundField DataField="diagnostico" HeaderText="Diagnóstico" SortExpression="diagnostico"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                    <asp:BoundField DataField="detalhamento" HeaderText="Detalhamento" SortExpression="detalhamento"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                    <asp:BoundField DataField="aguarda" HeaderText="Aguarda" SortExpression="aguarda"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                <asp:BoundField DataField="data_anotacao" HeaderText="Data de registro" SortExpression="data_anotacao"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                <asp:BoundField DataField="usuario_anotacao" HeaderText="Usuário" SortExpression="usuario_anotacao"
                                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ações">
                                    <ItemTemplate>
                                        <div class="form-inline">
                                            <asp:LinkButton ID="lbAtualiza" CommandName="editAnotacao" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                                CssClass="btn btn-warning" runat="server">
                                                    <i class="fa fa-pencil fa-2x" title="Editar"></i> 
                                            </asp:LinkButton>
                                       
                                            <asp:LinkButton ID="lbDeleta" CommandName="deletaAnotacao" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                                CssClass="btn btn-danger" runat="server">
                                                    <i class="fa fa-trash-o fa-2x" title="Excluir"></i> 
                                            </asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                <!-- Fim Conteúdo -->
                <div class="ln_solid">
                </div>
            </div>
            <!--  ficar até aqui -->
        </div>
        <!-- /page content -->
    </div>
</asp:Content>
