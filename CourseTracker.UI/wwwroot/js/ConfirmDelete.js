$(document).ready(function () {
	confirmDelete.Init();
});

var confirmDelete = {

	Uri: "/Base/ConfirmDeleteModal",
	DeleteClass: "confirmDelete",
    ModalSelector: "modalContainer",
    SubmitButtonSelector: "btnYesDeleteRecord",
    CancelButtonSelector: "btnNoDeleteRecord",
    Form: null,

	Init: function () {

        this.HookupMagnificPopup();

    },

    HookupModalHandlers: function () {

        //this.Form = $("#deleteConfirmationModal")[0];

        //$("#" + this.SubmitButtonSelector).on("click", deleteLevel.Delete);

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

        $.get(confirmDelete.Uri + "/" + id)
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

}