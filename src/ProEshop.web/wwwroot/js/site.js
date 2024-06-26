﻿//__RequestVerificationToken
var rvt = '__RequestVerificationToken';

var loadingModalHtml = `<div class="modal" id="loading-modal" data-bs-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">لطفا صبر کنید</h5>
            </div>
            <div class="modal-body text-center">
                <img src="/images/application/loading.gif" />
            </div>
        </div>
    </div>
</div>`;
function showLoading() {
    if ($('#loading-modal').length === 0) {
        $('body').append(loadingModalHtml);
    }
    $('#loading-modal').modal('show');
}
function hideLoading() {
    $('#loading-modal').modal('hide');
}

// Toastr
function showToastr(status, message) {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    toastr[status](message);
}
// End toastr

// Enabling tooltips
function enablingTooltips() {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    });
}

enablingTooltips();

function showErrorMessage(message) {
    showToastr('error', message != null ? message : 'خطایی به وجود آمد، لطفا مجددا تلاش نمایید');
}

function initializeTinyMCE() {
    if ($('textarea.custom-tinymce').length > 0) {
        tinymce.remove('textarea.custom-tinymce');
        tinymce.init({
            selector: 'textarea.custom-tinymce',
            height: 300,
            max_height: 500,
            language: 'fa_IR',
            language_url: '/js/tinymce-langs/fa_IR.js',
            content_style: 'body{font-family:Vazir}',
            plugins: 'link table preview wordcount',
            toolbar: [
                {
                    name: 'history', items: ['undo', 'redo', 'preview']
                },
                {
                    name: 'styles', items: ['styleselect']
                },
                {
                    name: 'formatting', items: ['bold', 'italic', 'underline', 'link']
                },
                {
                    name: 'alignment', items: ['alignleft', 'aaligncenter', 'alignright', 'alignjustify', 'forecolor', 'bacjcolor']
                },
                {
                    name: 'table', items: ['table', 'wordcount']
                },
                {
                    name: 'indentation', items: ['outdent', 'indent']
                }
            ],
            menubar: false,
            branding: false
        });
    }
}

initializeTinyMCE();

document.addEventListener('focusin', function (e) {
    if (e.target.closest('.tox-tinymce-aux, .moxman-window, .tam-assetmanager-root') !== null) {
        e.stopImmediatePropagation();
    }
});

function initializeSelect2() {
    $('.custom-select2').select2({
        theme: 'bootstrap-5',
        dropdownParent: $('#form-modal-place')
    });
}

function initializeSelect2WithoutModal() {
    if ($('.custom-select2').length > 0) {
        $('.custom-select2').select2({
            theme: 'bootstrap-5',
        });
    }
}

initializeSelect2WithoutModal();

// Validation

// fileRequired

var imageInputsWithProblems = [];

// یک آرایه و یک آیتم میگیره
// آیتم رو از آرایه حذف میکنه
function removeItemInArray(arr, item) {
    var found = arr.indexOf(item);

    while (found !== -1) {
        arr.splice(found, 1);
        found = arr.indexOf(item);
    }
}


if (jQuery.validator) {

    //Display validation for hidden inputs
    $.validator.setDefaults({
        ignore: []
    });

    var defaultRangeValidator = $.validator.methods.range;

    $.validator.methods.range = function (value, element, param) {
        if (element.type === 'checkbox') {
            return element.checked;
        } else {
            return defaultRangeValidator.call(this, value, element, param);
        }
    }

    jQuery.validator.addMethod("fileRequired", function (value, element, param) {
        if (element.files[0] != null)
            return element.files[0].size > 0;
        return false;
    });
    jQuery.validator.unobtrusive.adapters.addBool("fileRequired");

    // allowExtensions
    jQuery.validator.addMethod('allowExtensions', function (value, element, param) {
        if (element.files[0] != null) {
            var whiteListExtensions = $(element).data('val-whitelistextensions').split(',');
            return whiteListExtensions.includes(element.files[0].type);
        }
        return true;
    });
    jQuery.validator.unobtrusive.adapters.addBool('allowExtensions');

    // isImage
    jQuery.validator.addMethod('isImage', function (value, element, param) {
        var selectedFile = element.files[0];
        if (selectedFile === undefined) {
            return true;
        }
        var whiteListExtensions = $(element).data('val-whitelistextensions').split(',');
        if (!whiteListExtensions.includes(selectedFile.type)) {
            return false;
        }
        var currentElementId = $(element).attr('id');
        var currentForm = $(element).parents('form');

        if (imageInputsWithProblems.includes(currentElementId)) {
            removeItemInArray(imageInputsWithProblems, currentElementId);
            return false;
        }

        if ($('#image-preview-box-temp').length === 0) {
            $('body').append('<img class="d-none" id="image-preview-box-temp" />');
        }
        $('#image-preview-box-temp').attr('src', URL.createObjectURL(selectedFile));
        $('#image-preview-box-temp').off('error');
        $('#image-preview-box-temp').on('error',
            function () {
                imageInputsWithProblems.push(currentElementId);
                currentForm.validate().element(`#${currentElementId}`);
            });
        return true;
    });
    jQuery.validator.unobtrusive.adapters.addBool('isImage');

    // maxFileSize
    jQuery.validator.addMethod('maxFileSize', function (value, element, param) {
        if (element.files[0] != null) {
            var maxFileSize = $(element).data('val-maxsize');
            var selectedFileSize = element.files[0].size;
            return maxFileSize >= selectedFileSize;
        }
        return true;
    });
    jQuery.validator.unobtrusive.adapters.addBool('maxFileSize');
}

// End validation

// Ajax operations

function activaitingDeleteButtons() {
    $('.delete-row-button').on('click', function () {
        var currentForm = $(this).parent();
        var customMessage = $(this).attr('custom-message');

        var formData = currentForm.serializeArray();

        Swal.fire({
            title: 'اعلان',
            text: customMessage == undefined ? 'آیا از حذف این مورد مطمئن هستید؟' : customMessage,
            icon: 'warning',
            confirmButtonText: 'بله',
            showDenyButton: true,
            denyButtonText: 'خیر',
            confirmButtonColor: '#198754',
            allowOutsideClick: false
        }).then((result) => {
            if (result.isConfirmed) {

                showLoading();
                $.post(currentForm.attr('action'), formData, function (data, status) {
                    if (data.isSuccessful === false) {
                        showToastr('warning', data.message);
                    }
                    else {
                        fillDataTable();
                        showToastr('success', data.message);
                    }
                }).always(function () {
                    hideLoading();
                }).fail(function () {
                    showErrorMessage();
                })
            }
        })
    });
}

function initializingAutocomplete() {
    if ($('.autocomplete').length > 0) {

        $('.autocomplete').autocomplete({
            source: `${location.pathname}?handler=AutocompleteSearch`,
            minLenght: 2,
            delay: 500
        });
    }
}

// این فانکشن فرم های مربوط به ایجاد و ویرایش را
// به صورت ایجکس برگشت میزند که در داخل مودال نمایش دهیم
function activatingModalForm() {
    $('.show-modal-form-button').on('click', function (e) {
        e.preventDefault();
        var urlToLoadForm = $(this).attr('href');
        var customTitle = $(this).attr('custom-title');
        if (customTitle == undefined) {
            customTitle = $(this).text().trim();
        }
        $('#form-modal-place .modal-header h5').html(customTitle);
        showLoading();
        $.get(urlToLoadForm, function (data, status) {
            if (data.isSuccessful === false) {
                showToastr('warning', data.message);
            }
            else {
                $('#form-modal-place .modal-body').html(data);
                initializeTinyMCE();
                initializeSelect2();
                initializingAutocomplete();
                activatingInputAttributes();
                $.validator.unobtrusive.parse($('#form-modal-place form'));
                $('#form-modal-place').modal('show');
            }
        }).fail(function () {
            showErrorMessage();
        }).always(function () {
            hideLoading();
        });
    });
}

function activatingPagination() {
    $('#main-pagianation button').on('click', function () {
        isMainPaginationClicked = true;
        var currentPageSelected = $(this).val();
        $('.search-form-via-ajax input[name$="Pagination.CurrentPage"]').val(currentPageSelected);
        $('.search-form-via-ajax').on('submit');
    });
}

function activatingGoToPage() {
    $('#go-to-page-button').on('click', function () {
        isGoToPageClicked = true;
    });
}

// خواندن اطلاعات و ریختن آن در داخل گرید
function fillDataTable() {
    $('.data-table-place .data-table-body').remove();
    $('.search-form-submit-button').attr('disabled', 'disabled');
    $('.data-table-loading').removeClass('d-none');
    $('#record-not-found-box').remove();

    const formData = $('form.search-form-via-ajax').serializeArray();

    $.get(`${location.pathname}?handler=GetDataTable`, formData, function (data, status) {
        $('.search-form-submit-button').removeAttr('disabled');
        $('.data-table-loading').addClass('d-none');
        if (status == 'success') {
            $('.data-table-place').append(data);
            activatingPagination();
            activatingGoToPage();
            activatingModalForm();
            activaitingDeleteButtons();
            activatingPageCount();
            enablingTooltips();
        }
        else {
            showErrorMessage();
        }
    });
}

// fillDataTable();

// فرم ایجاد و ویرایش در داخل مودال موقعی که سابمیت شوند توسط این
// فانکشن به صورت ایجکسی به سمت سرور ارسال میشوند
$(document).on('submit', 'form.custom-ajax-form', function (e) {
    e.preventDefault();
    var currentForm = $(this);
    var formAction = currentForm.attr('action');
    var formData = new FormData(this);
    $.ajax({
        url: formAction,
        data: formData,
        type: 'POST',
        enctype: 'multipart/form-data',
        dataType: 'json',
        processData: false,
        contentType: false,
        beforeSend: function () {
            currentForm.find('.submit-custom-ajax-button span').removeClass('d-none');
            currentForm.find('.submit-custom-ajax-button').attr('disabled', 'disabled');
        },
        success: function (data, status) {
            if (data.isSuccessful === false) {
                fillValidationForm(data.data, currentForm);
                showToastr('warning', data.message);
            }
            else {
                fillDataTable();
                $('#form-modal-place').modal('hide');
                showToastr('success', data.message);
            }
        },
        complete: function () {
            currentForm.find('.submit-custom-ajax-button span').addClass('d-none');
            currentForm.find('.submit-custom-ajax-button').removeAttr('disabled');
        },
        error: function () {
            showErrorMessage();
        }
    });
});

// به محض بلر شدن یک اینپوت
// تمامی اینپوت های فرم را مجددا اعتبار سنجی میکند
// چرا از این استفاده میکنیم ؟
// برای مثال شما روی دکمه ثبت نام کلیک میکنید و
// در بالای صفحه و داخل تگ
// <div asp-validation-summary="All" class="text-danger"></div>
// مینویسد ایمیل را وارد کنید
// شما نیز ایمیل را وارد میکنید
// اما در قسمت بالای صفحه همچنان متن "لطفا ایمیل را وارد کنید" وجود دارد
// برای اینکه این مشکل حل شود از این کد استفاده میکنیم
$('form input').on('blur', function () {
    $(this).parents('form').valid();
});

$('form select').on('change', function () {
    $(this).parents('form').valid();
});

// این فانکشن هر فرمی را به صورت پست به سمت سرور با استفاده از ایجکس
// ارسال میکند
$(document).on('submit', 'form.public-ajax-form', function (e) {
    e.preventDefault();
    var currentForm = $(this);
    var formAction = currentForm.attr('action');
    var functionName = currentForm.attr('call-function-in-the-end');
    var formData = new FormData(this);
    $.ajax({
        url: formAction,
        data: formData,
        type: 'POST',
        enctype: 'multipart/form-data',
        dataType: 'json',
        processData: false,
        contentType: false,
        beforeSend: function () {
            showLoading();
        },
        success: function (data, status) {
            if (data.isSuccessful === false) {
                //var finalData = data.data != null ? data.data : [data.message];
                var finalData = data.data || [data.message];
                fillValidationForm(finalData, currentForm);
                showToastr('warning', data.message);
            }
            else {
                window[functionName](data);
            }
        },
        complete: function () {
            hideLoading()
        },
        error: function () {
            showErrorMessage();
        }
    });
});

// فعالساز مربوط به تعداد آیتم در هر صفحه
function activatingPageCount() {
    $('#page-count-selectbox').on('change', function () {
        var pageCountValue = this.value;
        $('form.search-form-via-ajax input[name$="Pagination.PageCount"]').val(pageCountValue);
        $('form.search-form-via-ajax').on('submit');
    });
}

// برای مثال در صفحه دو یک گرید هستیم
// و کاربر یک عبارتی را سرچ میکند ما باید بیاییم
// و از صفحه یک دوباره شروع به نمایش دادن اطلاعات کنیم
// این متغیر برای این کار است
var isMainPaginationClicked = false;
// اگر دکمه برو به فلان صحفحه کلیک شده بود
// باید به همان صفحه برویم
var isGoToPageClicked = false;

$(document).on('submit', 'form.search-form-via-ajax', function (e) {
    e.preventDefault();
    var currentForm = $(this);
    var pageNumberInput = $('#page-number-input').val();
    if (isGoToPageClicked || $('#page-number-input').is(':focus')) {
        currentForm.find('input[name$="Pagination.CurrentPage"]').val(pageNumberInput);
    }
    else if (!isMainPaginationClicked) {
        currentForm.find('input[name$="Pagination.CurrentPage"]').val(1);
    }
    const formData = currentForm.serializeArray();
    //show loading and activation button
    currentForm.find('.search-form-submit-button').attr('disabled', 'disabled');
    currentForm.find('.search-form-submit-button span').removeClass('d-none');

    $('.data-table-loading').removeClass('d-none');
    $('.data-table-body').html('');
    $('[data-bs-toggle="tooltip"], .tooltip').tooltip('hide');
    $('#record-not-found-box').remove();
    $.get(`${location.pathname}?handler=GetDataTable`, formData, function (data, status) {
        isMainPaginationClicked = false;
        isGoToPageClicked = false;
        //hide loading and disable button
        currentForm.find('.search-form-submit-button').removeAttr('disabled');
        currentForm.find('.search-form-submit-button span').addClass('d-none');
        $('.data-table-loading').addClass('d-none');

        if (status == 'success') {
            if (data.isSuccessful === false) {
                fillValidationForm(data.data, currentForm);
                showToastr('warning', data.message);
            }
            else {
                $('.data-table-place').append(data);
                activatingPagination();
                activatingGoToPage();
                activatingModalForm();
                activaitingDeleteButtons();
                activatingPageCount();
                enablingTooltips();
            }
        }
        else {
            showErrorMessage();
        }
    });
});



// موقعی که یک فرم به سمت سرور ارسال میشود
// اگر خطای اعتبار سنجی داشته باشد
// با استفاده از این فانکشن متن خطاها را داخل
// <div asp-validation-summary="All" class="text-danger"></div>
// نمایش میدهیم
function fillValidationForm(errors, currentForm) {
    var result = '<ul>';
    errors.forEach(function (e) {
        result += `<li>${e}</li>`;
    });
    result += '</ul>';
    currentForm.find('div[class*="validation-summary"]').html(result);
}


// End Ajax operations

// نمایش پیش نمایش عکس
$('.image-preview-input').on('change', function () {
    var selectedFile = this.files[0];
    var imagePreviewBox = $(this).attr('image-preview-box');
    if (selectedFile && selectedFile.size > 0) {
        $(`#${imagePreviewBox}`).removeClass('d-none');
        $(`#${imagePreviewBox} img`).attr('src', URL.createObjectURL(selectedFile));
    }
    else {
        $(`#${imagePreviewBox} img`).attr('src', '');
        $(`#${imagePreviewBox}`).addClass('d-none');
    }
});


// با استفاده از این فانکشن میتوانیم اطلاعاتی را از سمت سرور دریافت کنیم
// برای مثال برای خواندن شهرستان های یک استان از این فانکشن استفاده میکنیم
function getDataWithAJAX(url, formData, functionNameToCallAtTheEnd) {
    $.ajax({
        url: url,
        data: formData,
        type: 'Get',
        enctype: 'multipart/form-data',
        dataType: 'json',
        contentType: false,
        beforeSend: function () {
            showLoading();
        },
        success: function (data, status) {
            if (data.isSuccessful === false) {
                showToastr('warning', data.message);
            }
            else {
                window[functionNameToCallAtTheEnd](data.message, data.data);
            }
        },
        complete: function () {
            hideLoading();
        },
        error: function () {
            showErrorMessage();
        }
    });
}

function activatingInputAttributes() {
    // اگر به یک پراپرتی اتریبیوت
    // ltr
    // را بدهیم
    // این خط کد اینپوت مورد نظر را چپ به راست میکند
    $('input[data-val-ltrdirection="true"]').attr('dir', 'ltr');

    // فیلتر کردن ورودی های کاربر هنگام انتخاب فایل
    // فقط عکس هارو به کاربر نمایش میدیم
    $('input[data-val-isimage]').attr('accept', 'image/*');
}

activatingInputAttributes();