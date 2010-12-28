<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoriesSearch.aspx.cs" Inherits="AdvancedWebApplication.CategoriesSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:TextBox runat="server" ID="txtCategoryName" />
    <asp:Button Text="Buscar" runat="server" />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataSourceID="ObjectDataSource1" AllowPaging="true" AllowSorting="true">
        <Columns>
            <asp:TemplateField AccessibleHeaderText="Name of the Category" SortExpression="_categoryName" HeaderText="Category Name">
                   <ItemTemplate>
                       <asp:HyperLink ID="hplCategory" NavigateUrl='<%#Bind("ID", "CategoryPage.aspx?id={0}")%>' runat="server" Text='<%#Bind("CategoryName")%>' />
                   </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        TypeName="AdvancedWebApplication.Services.ProductsServices"
        SelectMethod = "GetPagedCategories"
        SelectCountMethod = "GetPagedCategoriesCount" EnablePaging="true" SortParameterName="sortExpression"
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
        <asp:ControlParameter ControlID="txtCategoryName" Name="categoryName" Type="String" />
    </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
