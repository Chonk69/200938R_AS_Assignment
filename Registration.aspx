<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="AS_Assignment.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Registration</title>

    <script type="text/javascript">
        function validate() {
            var str = document.getElementById('<%=tb_password.ClientID %>').value;

            if (str.length < 12) {
                document.getElementById("lbl_pwdchecker").innerHTML = "Password Length Must be at least 12 characters";
                document.getElementById("lbl_pwdchecker").style.color = "Red";
                return ("too_short");

            }

            else if (str.search(/[0-9]/) == -1) {
                document.getElementById("lbl_pwdchecker").innerHTML = "Password requires at least 1 number";
                document.getElementById("lbl_pwdchecker").style.color = "Red";
                return ("no_number");
            }            else if (str.search(/[A-Z]/) == -1) {
                document.getElementById("lbl_pwdchecker").innerHTML = "Password requires at least 1 uppercase character";
                document.getElementById("lbl_pwdchecker").style.color = "Red";
                return ("no_uppercase");
            }            else if (str.search(/[a-z]/) == -1) {
                document.getElementById("lbl_pwdchecker").innerHTML = "Password requires at least 1 lowercase character";
                document.getElementById("lbl_pwdchecker").style.color = "Red";
                return ("no_lowercase");
            }            else if (str.search(/[^0-9a-zA-Z]/) == -1) {
                document.getElementById("lbl_pwdchecker").innerHTML = "Password requires at least 1 special character";
                document.getElementById("lbl_pwdchecker").style.color = "Red";
                return ("no_special");
            }
            document.getElementById("lbl_pwdchecker").innerHTML = "Excellent"
            document.getElementById("lbl_pwdchecker").style.color = "Blue";

        }
    </script>
</head>

<body> <script src="https://www.google.com/recaptcha/api.js?render=6LfTx0AaAAAAAEG2Nh9jt8JPpq2VGo6zOFxebi8M"></script>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Registration"></asp:Label>
            <br />
            <br />
            First Name
            <asp:TextBox ID="FName" runat="server"></asp:TextBox>
            <br />
            Last Name&nbsp;
            <asp:TextBox ID="LName" runat="server"></asp:TextBox>
            <br />
            Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <br />
            <br />
            Credit Card Info<br />
            Name on Card&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="CreditName" runat="server"></asp:TextBox>
            <br />
            Credit Card No&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="CreditNo" runat="server" placeholder="1234-1234-1234-1234"></asp:TextBox>
            <br />
            Expiration Date&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="CreditDate" runat="server" type="text" placeholder="MM/YY"></asp:TextBox>
            <br />            CVV&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="CVV" runat="server" placeholder="***"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="passwordLabel" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="tb_password" runat="server" TextMode="Password" onkeyup="javascript:validate()"></asp:TextBox>
            <!---onkeyup="javascript:Validate()" --->
            <asp:Label ID="lbl_pwdchecker" runat="server"></asp:Label>
            <br />
            <br />
            Date of Birth
            <asp:TextBox ID="DoB" runat="server" type="date" ></asp:TextBox>
            <br />
            <asp:Label ID="errorMsg" runat="server"></asp:Label>
            <br />
            Photo??


        </div>
        <asp:Button ID="submitBtn" runat="server" OnClick="submit_btn_Click" Text="Submit" />
         <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response"/>
    </form>
    <script>
        grecaptcha.ready(function () {
            grecaptcha.execute('6Ldw3WQeAAAAAAxqWrTxm6Ii1_lWKMRunWL8-7Q4', { action: 'Login' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
            });
        });
    </script>
</body>
</html>
