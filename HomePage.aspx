﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="AS_Assignment.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset>
    <legend>HomePage</legend>

    <br />

    <asp:Label ID="lblMessage" runat="server" EnableViewState="false" />
    <br />
    <br />

    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="LogoutMe" Visible="false" />

    <p/>

    </fieldset>
    </div>
    </form>
</body>
</html>
