<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SunsetEmail.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sunset</title>
    <link rel="stylesheet" href="css/normalize.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="logmod">
        <div class="logmod__wrapper">
            <span class="logmod__close">Close</span>
            <div class="logmod__container">
                <h3 style="padding-left:30px;">Login</h3>
                <div class="logmod__tab-wrapper">
                    <div class="logmod__tab lgm-2 show">
                        <div class="logmod__heading">
                            <span class="logmod__heading-subtitle">Enter your email and password <strong>to sign
                                in</strong></span>
                        </div>
                        <div class="logmod__form">
                            <div class="simform">
                            <div class="sminputs">
                                <div class="input full">
                                    <label class="string optional" for="user-name">
                                        Email*</label>
                                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email address"></asp:TextBox>
                                </div>
                            </div>
                            <div class="sminputs">
                                <div class="input full">
                                    <label class="string optional" for="user-pw">
                                        Password *</label>
                                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="simform__actions">
                                <asp:Button ID="btnSend" runat="server" Text="Send" class="sumbit" onclick="btnSend_Click" />
                                <span class="simform__actions-sidetext"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></span>
                            </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
