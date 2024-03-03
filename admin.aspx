<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Portfolio.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <center>
            <h1>Frontend Edit Section</h1>

                        <asp:GridView ID="GvSkills" runat="server" AutoGenerateColumns="false" ShowFooter="true" DatakeyNames="SkillID"
            showHeaderWhenEmpty="true"
            OnRowCommand="GvSkills_RowCommand" OnRowEditing="GvSkills_RowEditing" OnRowCancelingEdit="GvSkills_RowCancelingEdit"
            OnRowUpdating="GvSkills_RowUpdating" OnRowDeleting="GvSkills_RowDeleting"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">

            <%-- Theme Properties --%>

            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />

            <Columns>
               
                <asp:TemplateField HeaderText="SkillName">
    <ItemTemplate>
        <asp:Label Text='<%# Eval("SkillName") %>' runat="server" />
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtSkillName" Text='<%# Eval("SkillName") %>' runat="server" />
    </EditItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtSkillNameFooter" runat="server" />
    </FooterTemplate>
</asp:TemplateField>


                <asp:TemplateField HeaderText="Skill Percentage">
    <ItemTemplate>
        <asp:Label Text='<%# Eval("SkillPercentage") %>' runat="server" />
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txtSkillPercentage" Text='<%# Eval("SkillPercentage") %>' runat="server" />
    </EditItemTemplate>
    <FooterTemplate>
        <asp:TextBox ID="txtSkillPercentageFooter" runat="server" />
    </FooterTemplate>
 </asp:TemplateField>


                <asp:TemplateField HeaderText="IconClass">
               <ItemTemplate>
                <asp:Label Text='<%# Eval("IconClass") %>' runat="server" />
                </ItemTemplate>
               <EditItemTemplate>
                  <asp:TextBox ID="txtIconClass" Text='<%# Eval("IconClass") %>' runat="server" />
                </EditItemTemplate>
               <FooterTemplate>
                 <asp:TextBox ID="txtIconClassFooter" runat="server" />
                </FooterTemplate>
                </asp:TemplateField>


            <asp:TemplateField>
           <ItemTemplate>
        <asp:Button runat="server" Text="Edit" CommandName="Edit" ToolTip="Edit" Width="100px" CssClass="button" />
        <asp:Button runat="server" Text="Delete" CommandName="Delete" ToolTip="Delete" Width="100px" CssClass="button" />
        </ItemTemplate>
       <EditItemTemplate>
        <asp:Button runat="server" Text="Update" CommandName="Update" ToolTip="Update" Width="100px" CssClass="button" />
        <asp:Button runat="server" Text="Cancel" CommandName="Cancel" ToolTip="Cancel" Width="100px" CssClass="button" />
       </EditItemTemplate>
      <FooterTemplate>
        <asp:Button runat="server" Text="Add New" CommandName="AddNew" ToolTip="Add New" Width="100px" CssClass="button" />
      </FooterTemplate>
      </asp:TemplateField>

            </Columns>
        </asp:GridView>

                <asp:Label ID="lblSuccessMessage1" Text="" runat="server" ForeColor="Green" />

                <asp:Label ID="lblErrorMessage1" Text="" runat="server" ForeColor="Red" />

            </center>
        </div>

    </form>
</body>
</html>
