@ModelType VBWebApp.dbo_Table_3
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>dbo_Table_3</h4>
    <hr />
    <dl class="dl-horizontal">
    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Aaaa }) |
    @Html.ActionLink("Back to List", "Index")
</p>
