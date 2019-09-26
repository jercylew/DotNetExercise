<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="ASP.NetWebApp._Default" %>
<%@ Register TagPrefix="My" TagName="UserInfoBoxControl" Src="~/UserInfoBoxControl.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>

        <div class="col-md-4">
            <h2>Event Handling Demo</h2>
            <div>
                <asp:Label runat="server" id="HelloWorldLabel"></asp:Label>
                <br /><br />
                <asp:TextBox runat="server" id="TextInput" /> 
                &nbsp;&nbsp; 
                <asp:Button runat="server" id="GreetButton" text="Say Hello!" OnClick="GreetButton_Click" />
            </div>
        </div>

        <div class="col-md-4">
            <h2>User Control Demo</h2>
            <My:UserInfoBoxControl runat="server" ID="MyUserInfoBoxControl" UserName="John Doe" UserAge="45" UserCountry="Australia" />
        </div>

        <div class="col-md-4">
            <h2>Updatepanel Demo</h2>
            <p>In an updatepanel the control can be updated partially without refreshing the whole page</p>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label runat="server" id="m_lblGreetText"></asp:Label>
                    <br /><br />
                    <asp:TextBox runat="server" id="m_txtName" /> 
                    &nbsp;&nbsp; 
                    <asp:Button runat="server" id="m_btnGreet" text="Say Hello!" OnClick="m_btnGreet_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
