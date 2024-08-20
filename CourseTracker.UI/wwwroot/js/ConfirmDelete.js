$(document).ready(function () {
    confirmDelete.Init(deleteUri);
});

var confirmDelete = {

	Uri: null,
	DeleteClass: "confirmDelete",
    ModalSelector: "modalContainer",
    SubmitButtonSelector: "btnYesDeleteRecord",
    CancelButtonSelector: "btnNoDeleteRecord",
    Form: null,

    Init: function (deleteUri) {

        this.Uri = deleteUri;

        this.HookupMagnificPopup();

    },

    HookupModalHandlers: function () {

        this.Form = $("#deleteConfirmationModal")[0];

        $("#" + this.SubmitButtonSelector).on("click", confirmDelete.Delete);

        $("#" + this.CancelButtonSelector).on("click", function (e) {
            e.preventDefault();
            $.magnificPopup.instance.close();
        });

    },

    HookupMagnificPopup: function () {

        $("." + this.DeleteClass).magnificPopup({
            type: 'inline',
            modal: true,
            callbacks: {
                elementParse: confirmDelete.ElementParse,
                close: confirmDelete.Close,
            }
        });

    },

    ElementParse: function (item) {

        var id = $(item.el).data().id;

        $.get("/Base/ConfirmDeleteModal/" + id)
            .done(function (data, textStatus, jqXHR) {
                $("#" + confirmDelete.ModalSelector).html($(data));
                confirmDelete.HookupModalHandlers();
            })
            .fail(function (data, textStatus, jqXHR) {
                $.magnificPopup.close();
            });

    },

    Close: function () {
        $(confirmDelete.ModalSelector).empty();
    },

    Delete: function (e) {

        e.preventDefault();
        var formData = $(confirmDelete.Form).serialize();

        $.ajax({
            type: "DELETE",
            url: confirmDelete.Uri,
            data: formData,
            success: confirmDelete.DeleteSuccess,
            fail: confirmDelete.DeleteFail
        });

    },

    DeleteSuccess: function (data) {

        if (data.result) {

            $.magnificPopup.close();
            window.location = data.uri;

        }
        else {
            $(confirmDelete.ModalSelector).html($(data));
            confirmDelete.HookupModalHandlers();
        }

    },

    DeleteFail: function (e) {
        $.magnificPopup.close();
    },

}