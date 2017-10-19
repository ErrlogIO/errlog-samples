<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ErrLogSampleWebWebFormsCS.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ErrLog IO Test Web</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/Site.css" />

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="container body-content">
                    <div class="row">
                        <div class="col-md-12">
                            <h1>ErrLogSampleWeb - WebForms</h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <p>This project simulates various exceptions and how to handle them with errlog.io</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnHelloWorld" runat="server" Text="Hello World!" CssClass="btn btn-default" OnClick="btnHelloWorld_Click" />
                            <asp:Button ID="btnErrLogVersion" runat="server" Text="ErrLog Version" CssClass="btn btn-default" OnClick="btnErrLogVersion_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnInvalidCastException" runat="server" Text="Invalid Cast Exception" CssClass="btn btn-default" OnClick="btnInvalidCastException_Click" />
                            <asp:Button ID="btnIndexOutOfRangeException" runat="server" Text="Array Out of Bounds" CssClass="btn btn-default" OnClick="btnIndexOutOfRangeException_Click" />
                            <asp:Button ID="btnArgumentException" runat="server" Text="Argument Exception" CssClass="btn btn-default" OnClick="btnArgumentException_Click" />
                            <asp:Button ID="btnNullReferenceException" runat="server" Text="Null Reference Exception" CssClass="btn btn-default" OnClick="btnNullReferenceException_Click" />
                            <asp:Button ID="btnSqlException" runat="server" Text="SQL Exception" CssClass="btn btn-default" OnClick="btnSqlException_Click" />
                        </div>
                    </div>
                    <div class="row" style="margin-top: 100px">
                        <label for="<%= lblMessage.ClientID %>">Message</label>
                        <div class="col-md-12" style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);">
                            <asp:Label ID="lblMessage" runat="server" Width="100%" Height="320" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


    </form>
</body>
</html>
