$(document).ready(function () {
    $('.decimal-only').on('keypress', function (event) {
        var charCode = (event.which) ? event.which : event.keyCode;
        var value = $(this).val();

        // Allow backspace, delete, tab, escape, and enter
        if ($.inArray(charCode, [46, 8, 9, 27, 13]) !== -1 ||
            // Allow Ctrl+A, Ctrl+C, Ctrl+V, Ctrl+X
            (charCode == 65 && event.ctrlKey === true) ||
            (charCode == 67 && event.ctrlKey === true) ||
            (charCode == 86 && event.ctrlKey === true) ||
            (charCode == 88 && event.ctrlKey === true)) {
            return;
        }

        // Prevent a second decimal point
        if (charCode === 46 && value.indexOf('.') !== -1) {
            event.preventDefault();
        }

        // Prevent anything that isn't a number or a decimal point
        if (charCode !== 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            event.preventDefault();
        }
    });

    // Optional: Clean up pasted text that isn't a valid decimal
    $('.decimal-only').on('blur', function () {
        var value = $(this).val();
        if (isNaN(value) || value === '') {
            $(this).val('0.00');
        } else {
            $(this).val(parseFloat(value).toFixed(2));
        }
    });
});
