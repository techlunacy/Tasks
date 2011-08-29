<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Tasks.Models.TaskModel>>" %>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                DueDate
            </th>
            <th>
                Task
            </th>
            <th>
                Priority
            </th>
            <th>
                User
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id = item.Id })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.DueDate) %>
            </td>
            <td>
                <%: item.Task %>
            </td>
            <td>
                <%: item.Priority %>
            </td>
            <td>
                <%: item.User %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>


