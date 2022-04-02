<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Library_management_system_client.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" href="Static/css/auth.css" />
</head>
<body>
    <div class="card shadow-lg p-3 mb-5 bg-white rounded form">
        <form id="form1" runat="server">
            <div class="card-body">
                <h5 class="card-title">Registration
                </h5>
                <div class="card-text">

                    <strong>
                <asp:Label ID="Label1"  class="errorMsg" runat="server" CssClass="errorBox" ForeColor="DarkRed"></asp:Label>
                <br />
                <br />
                </strong>
                    <label> <strong>First Name</strong></label><br/>
            <asp:TextBox ID="fName" placeholder="Enter First Name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  class="errorMsg" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="fName" ErrorMessage="please enter first name"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <label> <strong>Last Name</strong></label><br/>
            <asp:TextBox ID="lName" placeholder="Enter Last Name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="errorMsg" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="lname" ErrorMessage="please enter last name"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <label> <strong>Email Id</strong></label><br/>
            <asp:TextBox ID="email" placeholder="Enter Email Id" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" class="errorMsg" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="email" ErrorMessage="please enter email"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="email"  ErrorMessage="Email address is not valid"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                    <label> <strong>Date of Birth</strong></label><br/>
            <asp:TextBox ID="dob" placeholder="Enter Date of Birth" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" class="errorMsg" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="dob" ErrorMessage="please enter date of birth"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <label> <strong>Mobile Number</strong></label><br/>
            <asp:TextBox ID="mobile" placeholder="Enter Mobile Number" runat="server" TextMode="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" class="errorMsg" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="mobile" ErrorMessage="please enter mobile number"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <label> <strong>Password</strong></label><br/>
                    <asp:TextBox ID="password"  placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" class="errorMsg" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="password" ErrorMessage="please enter password"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <label> <strong>Roll No</strong></label><br/>
            <asp:TextBox ID="rollNo" runat="server" placeholder="Enter Roll No" TextMode="Number"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" class="errorMsg" ControlToValidate="rollNo" Display="Dynamic" ErrorMessage="entered roll no. is already registered" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" class="errorMsg" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="rollNo" ErrorMessage="please enter roll number"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <label> <strong>Branch</strong></label><br/>
            <asp:TextBox ID="branch" placeholder="Enter Branch" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" class="errorMsg" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" runat="server" ControlToValidate="branch" ErrorMessage="please enter branch"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Button ID="Button1" class="btn" runat="server" OnClick="Button1_Click" Text="Register" />
                    <br />
                    <br />
                    <div class="register">You Have An Account ? <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/login.aspx">Sign In</asp:HyperLink></div>
                    
                </div>
            </div>
        </form>
    </div>
</body>
</html>
