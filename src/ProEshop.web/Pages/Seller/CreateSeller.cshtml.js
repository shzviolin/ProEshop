$('#legal-person-checkbox-create-seller').on('change', function () {
    var labelElement = $(this).parents('.form-switch').find('label');
    if (this.checked) {
        addRequiredRule('#CreateSeller_CompanyName');
        addRequiredRule('#CreateSeller_RegisterNumber');
        addRequiredRule('#CreateSeller_EconomicCode');
        addRequiredRule('#CreateSeller_SignatureOwners');
        addRequiredRule('#CreateSeller_NationalId');
        addRangeRule('#CreateSeller_companyType');
        labelElement.html('شخص حقوقی');
    }
    else {
        removeRequiredRule('#CreateSeller_CompanyName');
        removeRequiredRule('#CreateSeller_RegisterNumber');
        removeRequiredRule('#CreateSeller_EconomicCode');
        removeRequiredRule('#CreateSeller_SignatureOwners');
        removeRequiredRule('#CreateSeller_NationalId');
        removeRangeRule('#CreateSeller_CompanyType');
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
            required: `لطفا ${displayName} را وارد نمایید`
        }
    });
}

function removeRequiredRule(selector) {
    $(selector).rules('remove', 'required');
}

function addRangeRule(selector) {
    var labelElement = $(selector).parent().find('label');
    var displayName = labelElement.length > 0 ? labelElement.html().trim() : '';
    $(selector).rules('add', {
        range: [0, 4],
        messages: {
            range: `لطفا ${displayName} را وارد نمایید`
        }
    });
}


function removeRangeRule(selector) {
    $(selector).rules('remove', 'range');
}


var firstTab = $('#create-seller-container .nav-tabs button:first').attr('data-bs-target');
var lastTab = $('#create-seller-container .nav-tabs button:last').attr('data-bs-target');
$('#create-seller-container #previous-tab-create-seller').attr('disabled', 'disabled');

var currentTab = $('#create-seller-container .nav-tabs button:first').attr('data-bs-target');

$('#create-seller-container #next-tab-create-seller').on('click', function () {
    var nextTab = $(`#create-seller-container .nav-tabs button[data-bs-target="${currentTab}"]`).next();
    if (nextTab.attr('data-bs-target')) {
        currentTab = nextTab.attr('data-bs-target');
        nextTab.tab('show');
    }
});
$('#create-seller-container #previous-tab-create-seller').on('click', function () {
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

$('#CreateSeller_ProvinceId').on('change', function () {
    var formData = {
        provinceId: $(this).val(),
    }
    getDataWithAJAX('/Seller/CreateSeller/parameter?handler=GetCities', formData, 'putCitiesInTheSelectBox');
})

function putCitiesInTheSelectBox(message, data) {
    $('#CreateSeller_CityId option').remove();
    $('#CreateSeller_CityId').append('<option value="0">انتخاب کنید</option>');
    $.each(data, function (key, value) {
        $('#CreateSeller_CityId').append(`<option value="${key}">${value}</option>`);
    });
}