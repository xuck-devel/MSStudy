@ModelType IEnumerable(Of VBWebApp.dbo_Table_3)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.Label(item.Aaaa)
            <br/>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Aaaa }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Aaaa }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Aaaa })
        </td>
    </tr>
Next

</table>
