<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Tasks.Models.TaskModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Id) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Id) %>
                <%: Html.ValidationMessageFor(model => model.Id) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DueDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DueDate) %>
                <%: Html.ValidationMessageFor(model => model.DueDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Task) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Task) %>
                <%: Html.ValidationMessageFor(model => model.Task) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Priority) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Priority) %>
                <%: Html.ValidationMessageFor(model => model.Priority) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.User) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.User) %>
                <%: Html.ValidationMessageFor(model => model.User) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

