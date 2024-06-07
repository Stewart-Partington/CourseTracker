$(window).on("load", function () {
	upload.Init();
});

var upload = {

    Uri: "/Attachments/Upload",
    Input: $("#filesInput")[0],
    Button: $("#btnSubmitUpload")[0],

    Init: function () {

        $(this.Button).on("click", upload.Upload);

    },

    Upload: function (e) {

        e.preventDefault();

        var files = upload.Input.files;
        var formData = new FormData();

        for (var i = 0; i != files.length; i++) {
            formData.append("files", files[i]);
        }
        var token = $("input[name='__RequestVerificationToken']").val();
        formData.append("__RequestVerificationToken", token);

        $.ajax({
            type: "POST",
            url: upload.Uri,
            data: formData,
            processData: false,
            contentType: false,
            success: upload.Success,
            fail: upload.Fail
        });

    },

    Success: function (data) {

        location.reload();

    },

    Fail: function (e) {
        debugger;
    }

}