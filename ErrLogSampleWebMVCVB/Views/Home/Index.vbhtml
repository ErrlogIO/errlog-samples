
@Code
    ViewData("Title") = "Index"
End Code

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
        @Ajax.ActionLink("HelloWorld", "HelloWorld", Nothing, New AjaxOptions With {.UpdateTargetId = "lblMessages"}, New With {.class = "btn btn-default"})
        @Ajax.ActionLink("ErrLogVersion", "ErrLogVersion", Nothing, New AjaxOptions With {.UpdateTargetId = "lblMessages"}, New With {.class = "btn btn-default"})


    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <br />
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        @Html.ActionLink("InvalidCastException", "InvalidCastException", Nothing, New With {.class = "btn btn-default"})
        @Html.ActionLink("IndexOutOfRangeException", "IndexOutOfRangeException", Nothing, New With {.class = "btn btn-default"})
        @Html.ActionLink("ArgumentException", "ArgumentException", Nothing, New With {.class = "btn btn-default"})
        @Html.ActionLink("NothingReferenceException", "NothingReferenceException", Nothing, New With {.class = "btn btn-default"})
        @Html.ActionLink("SqlException", "SqlException", Nothing, New With {.class = "btn btn-default"})

    </div>
</div>
<div class="row" style="margin-top: 100px">
    <label for="lblMessages">Messages</label>
    <div class="col-md-12" style="box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);">
        <div ID="lblMessages" style="width: 100%; height: 320px;">
            &nbsp;
        </div>
    </div>
</div>