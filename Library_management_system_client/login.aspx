<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Library_management_system_client.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="Static/css/auth.css" />

</head>
<body>
    <div class="card shadow-lg p-3 mb-5 bg-white rounded form">
        <form id="form1" runat="server">
            <div class="card-body">
                <h5 class="card-title">
                    Sign In
                </h5>
                <strong>
                <asp:Label ID="Label1"  class="errorMsg" runat="server" CssClass="errorBox" ForeColor="DarkRed"></asp:Label>
                <br />
                <br />
                </strong>
                <br />
                <div class="card-text">
                    <label> <strong>College Id</strong></label><br/>
                   
                <asp:TextBox ID="CollegeIdField" placeholder="Enter College Id" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" class="errorMsg" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="CollegeIdField" ErrorMessage="please enter College Id"></asp:RequiredFieldValidator>
                   <br /><br />
                    <label><strong>Password</strong></label><br/>
                    
                   
                <asp:TextBox ID="PasswordField" placeholder="Enter Password" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="errorMsg" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="PasswordField" ErrorMessage="please enter Password"></asp:RequiredFieldValidator>
                   <br /><br />
                    
                    <asp:Button ID="Button1" class="btn" runat="server" OnClick="Button1_Click" Text="Login" CssClass="btn" />
                    
                    
                    <br />
                    
                    
                    <br />
                    
                    <div class="register"> Don't Have An Account ? <a href="/register.aspx">New Account</a></div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
