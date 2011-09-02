<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.DateTime?>" %>
<%: Html.TextBox("",  String.Format("{0:yyyy-MM-dd}", Model.HasValue ? Model : DateTime.Today), new { @class = "dp"})%>
