$('#legal-person-checkbox-create-seller').change(function () {
    var labelElement = $(this).parents('.form-switch').find('label');
    if (this.checked) {
        addRequiredRule('#CreateSeller_CompanyName');
        addRequiredRule('#CreateSeller_RegisterNumber');
        addRequiredRule('#CreateSeller_EconomicCode');
        addRequiredRule('#CreateSeller_SignatureOwners');
        addRequiredRule('#CreateSeller_NationalId');
        labelElement.html('شخص حقوقی');
    }
    else {
        removeRequiredRule('#CreateSeller_CompanyName');
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
    var labelElement = $(selector).parent().find('label');
    var displayName = labelElement.length > 0 ? labelElement.html().trim() : $(selector).attr('name');
    $(selector).rules('add', {
        required: true,
        messages: {
            required: `لطفا ${displayName} را وارد نمایید`,
        }
    });
}


function removeRequiredRule(selector) {
    var labelElement = $(selector).parent().find('label');
    var displayName = labelElement.length > 0 ? labelElement.html().trim() : $(selector).attr('name');
    $(selector).rules('remove', 'required');
}

var firstTab = $('#create-seller-container .nav-tabs button:first').attr('data-bs-target');
var lastTab = $('#create-seller-container .nav-tabs button:last').attr('data-bs-target');
$('#create-seller-container #previous-tab-create-seller').attr('disabled', 'disabled');

var currentTab = $('#create-seller-container .nav-tabs button:first').attr('data-bs-target');

$('#create-seller-container #next-tab-create-seller').click(function () {
    var nextTab = $(`#create-seller-container .nav-tabs button[data-bs-target="${currentTab}"]`).next();
    if (nextTab.attr('data-bs-target')) {
        currentTab = nextTab.attr('data-bs-target');
        nextTab.tab('show');
    }
});
$('#create-seller-container #previous-tab-create-seller').click(function () {
    var previousTab = $(`#create-seller-container .nav-tabs button[data-bs-target="${currentTab}"]`).prev();
    if (previousTab.attr('data-bs-target')) {
        currentTab = previousTab.attr('data-bs-target');
        previousTab.tab('show');
    }
});

$('#create-seller-container .nav-tabs button').on('show.bs.tab', function (e) {
    currentTab = $(e.target).attr('data-bs-target');
    if (currentTab == lastTab) {
        $('#create-seller-container #next-tab-create-seller').attr('disabled', 'disabled');
    }
    else {
        $('#create-seller-container #next-tab-create-seller').removeAttr('disabled');
    }
    if (currentTab == firstTab) {
        $('#create-seller-container #previous-tab-create-seller').attr('disabled', 'disabled');
    }
    else {
        $('#create-seller-container #previous-tab-create-seller').removeAttr('disabled');
    }

});
