<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AS_Assignment.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://www.google.com/recaptcha/api.js?render=6Ldw3WQeAAAAAAxqWrTxm6Ii1_lWKMRunWL8-7Q4"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>

    <fieldset>
    <legend> Login </legend>             
    <p> Username : <asp:TextBox ID="tb_userid" runat="server" Height="25px" Width="137px" /> </p>
    <p> Password : <asp:TextBox ID="tb_pwd" runat="server" Height="25px" Width="137px" /> </p>
    <p> <asp:Button ID="btnSubmit" runat="server" Text="Login" OnClick="LoginMe" Height="27px" Width="133px"/></p> 
    <br />
    <br />

    <asp:Label ID="lblMessage" runat="server" EnableViewState="False" > Error Mesage Here (lblMessage)</asp:Label>

           
    </fieldset>


    </div>
    <input type="hidden" name="g-recaptcha-response" id="g-recaptcha-response" />
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
