
$(document).ready(function () {

    $("#imageFile").change(function () {

        if (this.files && this.files[0]) {

            if (this.files[0].name.match(/\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$/)) {

                if (!(this.files[0].size > (2 * 1024 * 1024))) {

                    $("#imagePreview").attr('src', (window.URL ? URL : webkitURL).createObjectURL(this.files[0]));
                    imagePreviewShowHide();
                } else {
                    alert("Image size larger than 2 MB");
                    $(this).val(null);
                    $("#imagePreview").attr('src', '');
                }
            } else {
                alert("This is not image file");
                $(this).val(null);
                $("#imagePreview").attr('src', '');
            }
        } else {
            $("#imagePreview").attr('src', '');
        }

        imagePreviewShowHide();
    });

    imagePreviewShowHide();
});


function imagePreviewShowHide() {
    if ($("#imagePreview").attr('src') == '') {
        $("#imgContainer").hide();
    } else {
        $("#imgContainer").show();
    }
    //$("#imagePreview[src='']").hide();
    //$("#imagePreview:not([src=''])").show();
}

function imageRemoved() {
    $("#imageFile").val(null);
    $("#imagePreview").attr('src', '');
    imagePreviewShowHide();
}