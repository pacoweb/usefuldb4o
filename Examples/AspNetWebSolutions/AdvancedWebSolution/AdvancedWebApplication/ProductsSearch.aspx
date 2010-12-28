<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsSearch.aspx.cs" Inherits="AdvancedWebApplication.ProductsSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:Label runat="server" ID="lblName" AssociatedControlID="txtProductName" Text="Product Name"></asp:Label>
     <asp:TextBox runat="server" ID="txtProductName" />

     <asp:Label runat="server" ID="lblCategory" AssociatedControlID="cmbCategory" Text="Product Category"></asp:Label>
     <asp:DropDownList runat="server" ID="cmbCategory" AppendDataBoundItems="true" DataSourceID="ObjectDataSource2" DataTextField="CategoryName" DataValueField="ID">
        <asp:ListItem Text="Pick a category..." Value="" Selected="True"></asp:ListItem>
     </asp:DropDownList>

    <asp:Button ID="Button1" Text="Buscar" runat="server" />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataSourceID="ObjectDataSource1" AllowPaging="true" AllowSorting="true">
        <Columns>
            <asp:TemplateField AccessibleHeaderText="Name of the Product" SortExpression="_name" HeaderText="Product Name">
                   <ItemTemplate>
                       <asp:HyperLink ID="hplCategory" NavigateUrl='<%#Bind("ID", "ProductPage.aspx?id={0}")%>' runat="server" Text='<%#Bind("Name")%>' />
                   </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            TypeName="AdvancedWebApplication.Services.ProductsServices"
            SelectMethod = "GetPagedProducts"
            SelectCountMethod = "GetPagedProductsCount" EnablePaging="true" SortParameterName="sortExpression"
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
            <asp:ControlParameter ControlID="txtProductName" Name="productName" Type="String" PropertyName="Text" ConvertEmptyStringToNull="true" />
            <asp:ControlParameter ControlID="cmbCategory" Name="categoryID" Type="Object" PropertyName="SelectedValue" ConvertEmptyStringToNull="true"/>
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource runat="server" ID="ObjectDataSource2" TypeName="AdvancedWebApplication.Services.ProductsServices" SelectMethod = "GetAllCategories">
    </asp:ObjectDataSource>
</asp:Content>
