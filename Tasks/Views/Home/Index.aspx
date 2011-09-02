<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%if (Request.IsAuthenticated)
          { %>
        <%Html.RenderAction("index", "task"); %>
        <%}
          else
          {   %>
        Please [
        <%: Html.ActionLink("Log On", "LogOn", "Account") %>
        ] or register [<%: Html.ActionLink("Register", "Register", "Account")%>] if you
        don't have an account.
        <%}%>
    </p>
</asp:Content>
