<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LibraryMangement.Master" CodeBehind="AddBook.aspx.cs" Inherits="Library_management_system_client.AddBook" %>

<asp:Content runat="server" ContentPlaceHolderID="titleSection">Add Book</asp:Content>
<asp:Content ContentPlaceHolderID="contantSection" runat="server">
    <div class="card shadow-lg p-3 mb-5 bg-white rounded form">
        <div class="card-body">
            <div class="heading_container heading_center card-title">
                <h2>Add Book
                </h2>
            </div>
            <asp:Panel runat="server" CssClass="alert alert-danger" ID="errPanel" Visible="false">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </asp:Panel>
            <div class="card-text">

                <div>
                    <div class="form-group">
                        <label>Name</label>
                        <asp:TextBox CssClass="form-control" placeholder="Enter Name" ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="please enter Name"></asp:RequiredFieldValidator>

                        <br />

                    </div>
                    <div class="form-group">
                        <label>Author</label>
                        <asp:TextBox CssClass="form-control" placeholder="Enter Author" ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox1" ErrorMessage="please enter Author Name"></asp:RequiredFieldValidator>

                        <br />

                    </div>

                    <div class="form-group">

                        <label>Category</label>
                        <asp:TextBox CssClass="form-control" placeholder="Enter Category" ID="TextBox5" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5" ErrorMessage="please enter Category"></asp:RequiredFieldValidator>

                        <br />

                    </div>

                    <div class="form-group">

                        <label>Edition</label>
                        <asp:TextBox CssClass="form-control" placeholder="Enter Edition" TextMode="Number" ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="please enter Edition"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator SetFocusOnError="true" ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Edition should be greater than 0" ForeColor="Red" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>

                        <br />

                    </div>

                    <div class="form-group">

                        <label>No_of_Total_Copy</label>
                        <asp:TextBox CssClass="form-control" placeholder="Enter Number of total copy" TextMode="Number" ID="TextBox6" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox3" ErrorMessage="please enter Number of total copy"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator SetFocusOnError="true" ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="No_of_Total_Copy should be greater than 0" ForeColor="Red" ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>

                        <br />

                    </div>




                    <br />
                    <asp:Button ID="Button2" CssClass="btn" runat="server" OnClick="Button2_Click" Text="Add" />
                    <div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
