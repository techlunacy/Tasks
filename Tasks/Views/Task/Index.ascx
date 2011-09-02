<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Tasks.Models.TaskModel>>" %>
<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table id="sortedtable" class="tablesorter full_page">
    <thead>
        <tr>
            <th>
                Due Date
            </th>
            <th>
                Name
            </th>
            <th>
                Priority
            </th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var item in Model)
           {
        %>
        <tr class="<%=(item.IsDueToday ? "urgent" : "normal") %>">
            <td>
                <%: String.Format("{0:d}", item.DueDate) %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.Priority %>
            </td>
        </tr>
        <% } %>
    </tbody>
</table>
