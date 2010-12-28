<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryPage.aspx.cs" Inherits="AdvancedWebApplication.CategoryPage" %>
<%@ Import Namespace="Example.Entities.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" 
        DataSourceID="ObjectDataSource1" DefaultMode="Edit" 
        ondatabinding="FormView1_DataBinding" ondatabound="FormView1_DataBound" 
        onitemcommand="FormView1_ItemCommand" onitemcreated="FormView1_ItemCreated" 
        onitemdeleted="FormView1_ItemDeleted" onitemdeleting="FormView1_ItemDeleting" 
        oniteminserted="FormView1_ItemInserted" 
        oniteminserting="FormView1_ItemInserting" onitemupdated="FormView1_ItemUpdated" 
        onitemupdating="FormView1_ItemUpdating" onmodechanged="FormView1_ModeChanged" 
        onmodechanging="FormView1_ModeChanging" >
        <HeaderTemplate>
               <asp:ValidationSummary ID="vlSummary" runat="server" DisplayMode="List" ValidationGroup="formPpal" />
        </HeaderTemplate>

        <EditItemTemplate>
            <fieldset>
                <legend><asp:Literal runat="server" ID="ltlName" EnableViewState="false" Mode="Encode" Text='<%#Bind("CategoryName")%>'></asp:Literal></legend>

                <asp:Label runat="server" ID="lblName" AssociatedControlID="txtName" EnableViewState="false" Text="Category Name"></asp:Label>
                <asp:TextBox runat="server" ID="txtName" Text='<%#Bind("CategoryName")%>' Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rqNameValidator" ControlToValidate="txtName" ValidationGroup="formPpal" ErrorMessage="The field Category Name is mandatory"></asp:RequiredFieldValidator>
                <br />

                <p>Total products:&nbsp;<%=GetProductsCount((Category)FormView1.DataItem)%></p>

                <asp:Button ID="btnUpdate" Text="Salvar" runat="server" CommandName="Update"/>
                <asp:Button ID="btnDelete" Text="Borrar" runat="server" CommandName="Delete"/>

            </fieldset>
        </EditItemTemplate>

        <InsertItemTemplate>
            <fieldset>
                <legend>New Category</legend>

                <asp:Label runat="server" ID="lblName" AssociatedControlID="txtName" EnableViewState="false" Text="Category Name"></asp:Label>
                <asp:TextBox runat="server" ID="txtName" Text='<%#Bind("CategoryName")%>' Columns="40"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rqNameValidator" ControlToValidate="txtName" ValidationGroup="formPpal" ErrorMessage="The field Category Name is mandatory"></asp:RequiredFieldValidator>
                <br />

                <asp:Button ID="btnInsert" Text="Salvar" runat="server" CommandName="Insert"/>

            </fieldset>
        </InsertItemTemplate>

        <FooterTemplate>
            
        </FooterTemplate>

    </asp:FormView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            TypeName = "AdvancedWebApplication.Services.ProductsServices"
            SelectMethod = "GetCategory"
            InsertMethod = "AddCategory"
            DeleteMethod = "DeleteCategory"
            UpdateMethod = "UpdateCategory" 
        ondatabinding="ObjectDataSource1_DataBinding" 
        ondeleted="ObjectDataSource1_Deleted" ondeleting="ObjectDataSource1_Deleting" 
        onfiltering="ObjectDataSource1_Filtering" 
        oninserted="ObjectDataSource1_Inserted" 
        oninserting="ObjectDataSource1_Inserting" 
        onobjectcreated="ObjectDataSource1_ObjectCreated" 
        onobjectcreating="ObjectDataSource1_ObjectCreating" 
        onobjectdisposing="ObjectDataSource1_ObjectDisposing" 
        onselected="ObjectDataSource1_Selected" 
        onselecting="ObjectDataSource1_Selecting" onupdated="ObjectDataSource1_Updated" 
        onupdating="ObjectDataSource1_Updating">
    <SelectParameters>
        <asp:QueryStringParameter Type="Object" Name="guid" QueryStringField="id" ConvertEmptyStringToNull="true" />
    </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
