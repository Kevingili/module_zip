<%@ Page Title="" Language="C#" MasterPageFile="~/MasterZip.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FichiersZip.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 260px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%; height: 206px;">
        <tr>
            <td>Nom</td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxNom" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxNom" ErrorMessage="Erreur champ vide"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Prenom</td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxPrenom" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPrenom" ErrorMessage="Erreur champ vide"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Je ne telecharge pas de fichier" />
            </td>
            <td>
                <asp:Label ID="LabelCheck" runat="server" Text="Erreur XXX"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Fichier1</td>
            <td class="auto-style3"><asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" /></td>
            <td>
                <asp:Label ID="LabelFc1" runat="server" Text="Erreur XXX"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Fichier2</td>
            <td class="auto-style3"><asp:FileUpload ID="FileUpload2" runat="server" />
            </td>
            <td>
                <asp:Label ID="LabelFc2" runat="server" Text="Erreur XXX"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3"><asp:Button ID="ButtonEnvoyer" runat="server" Text="Envoyer" OnClick="ButtonEnvoyer_Click1" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
