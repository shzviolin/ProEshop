$('#legal-person-checkbox-create-seller').change(function () {
    var labelElement = $(this).parents('.form-switch').find('label');
    if (this.checked) {
        addRequiredRule('#CCreateSeller_CompanyName');
        addRequiredRule('#CreateSeller_RegisterNumber');
        addRequiredRule('#CreateSeller_EconomicCode');
        addRequiredRule('#CreateSeller_SignatureOwners');
        addRequiredRule('#CreateSeller_NationalId');
        labelElement.html('شخص حقوقی');
    }
    else {
        removeRequiredRule('#CCreateSeller_CompanyName');
        removeRequiredRule('#CreateSeller_RegisterNumber');
        removeRequiredRule('#CreateSeller_EconomicCode');
        removeRequiredRule('#CreateSeller_SignatureOwners');
        removeRequiredRule('#CreateSeller_NationalId');

        labelElement.html('شخص حقیقی');
    }
    $(this).parents('form').valid();
    $('#legal-person-box-create-seller').slideToggle();
});

$('#legal-person-box-create-seller').hide(0);

function addRequiredRule(selector) {
    var displayName = $(selector).parent().find('label').html().trim();
    $(selector).rules('add', {
        required: true,
        messages: {
            required: `لطفا ${displayName} را وارد نمایید`,
        }
    });
}

function removeRequiredRule(selector) {
    $(selector).rules('remove', 'required');
}