$('#legal-person-checkbox-create-seller').change(function () {
    var labelElement = $(this).parents('.form-switch').find('label');
    if (this.checked) {
        labelElement.html('شخص حقوقی');
    }
    else {
        labelElement.html('شخص حقیقی');
    }
    $('#legal-person-box-create-seller').slideToggle();
});

$('#legal-person-box-create-seller').hide(0);