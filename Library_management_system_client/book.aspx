<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LibraryMangement.Master" CodeBehind="book.aspx.cs" Inherits="Library_management_system_client.book" %>

<asp:Content runat="server" ContentPlaceHolderID="titleSection">Library</asp:Content>
<asp:Content ContentPlaceHolderID="contantSection" runat="server">
    <div class="container" id="dashboard">

        <asp:Panel runat="server" CssClass="alert alert-danger" ID="errPanel" Visible="false">
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </asp:Panel>


        <p>
            <label class="auto-style2">Number Of Books :&nbsp;&nbsp;&nbsp;&nbsp; </label>
            <strong>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </strong>
        </p>


        <br />
        <br />
        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="col">No.</th>
                    <th scope="col">Id</th>
                    <th scope="col">Name</th>
                    <th scope="col">Author</th>
                    <th scope="col">Category</th>
                    <th scope="col">Edition</th>
                    <th scope="col">Total</th>
                    <th scope="col">Available</th>
                </tr>
            </thead>
            <tbody>

                <asp:Repeater ID="itemtable" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Container.ItemIndex + 1 %></td>
                            <td><%#Eval("Id") %></td>
                            <td><%#Eval("Name") %></td>
                            <td><%#Eval("Author") %></td>
                            <td><%#Eval("Category") %></td>
                            <td><%#Eval("Edition") %></td>
                            <td><%#Eval("No_of_Total_Copy") %></td>
                            <td><%#Eval("No_of_Available_Copy") %></td>
                            <td class="action">
                                <asp:Button runat="server" OnCommand="update_Command" CommandArgument='<%#Eval("Id") %>' Text="Update" CssClass="btn" />
                            </td>
                            <td class="action">
                                <asp:Button runat="server" OnCommand="delete_Command" CommandArgument='<%#Eval("Id") %>' Text="Delete" CssClass="btn" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="linkSection">


    <style type="text/css">
        .auto-style2 {
            height: 0px;
            margin-left: 520px;
        }
    </style>


</asp:Content>
