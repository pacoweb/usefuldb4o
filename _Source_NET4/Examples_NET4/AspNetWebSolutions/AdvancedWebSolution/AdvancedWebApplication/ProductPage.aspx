<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="AdvancedWebApplication.ProductPage" %>
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
        onmodechanging="FormView1_ModeChanging">
        <HeaderTemplate>
            
        </HeaderTemplate>

        <EditItemTemplate>
            <fieldset>
                <legend><asp:Literal runat="server" ID="ltlName" EnableViewState="false" Mode="Encode" Text='<%#Bind("Name")%>'></asp:Literal></legend>

                <asp:Label runat="server" ID="lblName" AssociatedControlID="txtName" EnableViewState="false" Text="Product Name"></asp:Label>
                <asp:TextBox runat="server" ID="txtName" Text='<%#Bind("Name")%>'></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rqNameValidator" ControlToValidate="txtName" Text="*"></asp:RequiredFieldValidator>
                <br />

                <asp:Label runat="server" ID="lblPrice" AssociatedControlID="txtPrice" EnableViewState="false" Text="Product Price"></asp:Label>
                <asp:TextBox runat="server" ID="txtPrice" Text='<%#Bind("Price")%>' MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rqPriceValidator" ControlToValidate="txtPrice" Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="rgxPriveValidator" ControlToValidate="txtPrice" ValidationExpression="^\d+(\.\d{1,2})?$" Text="*"></asp:RegularExpressionValidator>
                <br />

                <asp:Label runat="server" ID="lblCategory" AssociatedControlID="cmbCategory" EnableViewState="false" Text="Product Category"></asp:Label>
                <asp:DropDownList runat="server" ID="cmbCategory" AppendDataBoundItems="true" DataSourceID="ObjectDataSource2" DataTextField="CategoryName" DataValueField="ID" SelectedValue='<%#Bind("ProductCategory.ID") %>'>
                    <asp:ListItem Text="Pick a category..." Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rqCategoryValidator" ControlToValidate="cmbCategory" Text="*"></asp:RequiredFieldValidator>
                <br />

                <asp:CheckBox runat="server" ID="chkEnabled" Checked='<%#Bind("IsEnabled")%>' Text="Enabled" />
                <br />

                <asp:Button ID="btnUpdate" Text="Salvar" runat="server" CommandName="Update"/>
                <asp:Button ID="btnDelete" Text="Borrar" runat="server" CommandName="Delete"/>

            </fieldset>
        </EditItemTemplate>

        <InsertItemTemplate>
            <fieldset>
                <legend>New Product</legend>

                <asp:Label runat="server" ID="lblName" AssociatedControlID="txtName" EnableViewState="false" Text="Product Name"></asp:Label>
                <asp:TextBox runat="server" ID="txtName" Text='<%#Bind("Name")%>'></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rqNameValidator" ControlToValidate="txtName" Text="*"></asp:RequiredFieldValidator>
                <br />

                <asp:Label runat="server" ID="lblPrice" AssociatedControlID="txtPrice" EnableViewState="false" Text="Product Price"></asp:Label>
                <asp:TextBox runat="server" ID="txtPrice" Text='<%#Bind("Price")%>' MaxLength="10" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rqPriceValidator" ControlToValidate="txtPrice" Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ID="rgxPriveValidator" ControlToValidate="txtPrice" ValidationExpression="^\d+(\.\d{1,2})?$" Text="*"></asp:RegularExpressionValidator>
                <br />

                <asp:Label runat="server" ID="lblCategory" AssociatedControlID="cmbCategory" EnableViewState="false" Text="Product Category"></asp:Label>
                <asp:DropDownList runat="server" ID="cmbCategory" AppendDataBoundItems="true" DataSourceID="ObjectDataSource2" DataTextField="CategoryName" DataValueField="ID" SelectedValue='<%#Bind("ProductCategory.ID") %>'>
                    <asp:ListItem Text="Pick a category..." Value="" Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rqCategoryValidator" ControlToValidate="cmbCategory" Text="*"></asp:RequiredFieldValidator>
                <br />

                <asp:CheckBox runat="server" ID="chkEnabled" Checked='<%#Bind("IsEnabled")%>' Text="Enabled" />
                <br />

                <asp:Button ID="btnInsert" Text="Salvar" runat="server" CommandName="Insert"/>

            </fieldset>
        </InsertItemTemplate>

        <FooterTemplate>
        
        </FooterTemplate>
    </asp:FormView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            TypeName = "AdvancedWebApplication.Services.ProductsServices"
            SelectMethod = "GetProduct"
            InsertMethod = "AddProduct"
            DeleteMethod = "DeleteProduct"
            UpdateMethod = "UpdateProduct" 
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
<%--    <UpdateParameters>
        <asp:ControlParameter Type="Object" ControlID="FormView1" Name="productGuid" PropertyName="SelectedValue" />
    </UpdateParameters>--%>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource runat="server" ID="ObjectDataSource2" TypeName="AdvancedWebApplication.Services.ProductsServices" SelectMethod = "GetAllCategories">
    </asp:ObjectDataSource>
</asp:Content>

