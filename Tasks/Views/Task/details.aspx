<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Tasks.Models.TaskModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">DueDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.DueDate) %></div>
        
        <div class="display-label">Task</div>
        <div class="display-field"><%: Model.Task %></div>
        
        <div class="display-label">Priority</div>
        <div class="display-field"><%: Model.Priority %></div>
        
        <div class="display-label">User</div>
        <div class="display-field"><%: Model.User %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

