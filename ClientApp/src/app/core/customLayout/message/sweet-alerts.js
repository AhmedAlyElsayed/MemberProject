"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ConfirmColor = exports.ConfirmMessage = exports.AjaxRequest = exports.OutsideClick = exports.TypeError = exports.TypeWarning = exports.TypeInfo = exports.TypeSuccess = exports.ShakeAnimation = exports.TadaAnimation = exports.FlipXAnimation = exports.FadeInAnimation = exports.BounceInAnimation = exports.PositionBottomEnd = exports.PositionBottomStart = exports.PositionTopEnd = exports.PositionTopStart = exports.HtmlAlert = exports.WithFooter = exports.WithTitle = exports.BasicAlert = void 0;
var sweetalert2_1 = require("sweetalert2");
//-------------- Basic --------------
// Simple Alert
function BasicAlert() {
    sweetalert2_1.default.fire({
        title: 'Any fool can use a computer',
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false
    });
}
exports.BasicAlert = BasicAlert;
// Alert with Title
function WithTitle() {
    sweetalert2_1.default.fire({
        title: 'The Internet?',
        text: "That thing is still around?",
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.WithTitle = WithTitle;
// Alert with footer
function WithFooter() {
    sweetalert2_1.default.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Something went wrong!',
        footer: '<a href = "javascript:void(0);">Why do I have this issue?</a>',
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false
    });
}
exports.WithFooter = WithFooter;
//  HTML Alert
function HtmlAlert() {
    sweetalert2_1.default.fire({
        title: '<strong>HTML <u>example</u></strong>',
        icon: 'info',
        html: 'You can use <b>bold text</b>, ' +
            '<a href="https://pixinvent.com/" target="_blank">links</a> ' +
            'and other HTML tags',
        showCloseButton: true,
        showCancelButton: true,
        focusConfirm: false,
        confirmButtonText: '<i class="fa fa-thumbs-o-up"></i> Great!',
        confirmButtonAriaLabel: 'Thumbs up, great!',
        cancelButtonText: '<i class="fa fa-thumbs-o-down"></i>',
        cancelButtonAriaLabel: 'Thumbs down',
        buttonsStyling: false,
        customClass: {
            confirmButton: 'btn btn-primary',
            cancelButton: 'btn btn-danger ml-1'
        },
    });
}
exports.HtmlAlert = HtmlAlert;
//-------------- Position --------------
// Top-start
function PositionTopStart() {
    sweetalert2_1.default.fire({
        position: 'top-start',
        icon: 'success',
        title: 'Your work has been saved',
        showConfirmButton: false,
        timer: 1500,
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.PositionTopStart = PositionTopStart;
// Top-end
function PositionTopEnd() {
    sweetalert2_1.default.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Your work has been saved',
        showConfirmButton: false,
        timer: 1500,
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.PositionTopEnd = PositionTopEnd;
// Bottom-start
function PositionBottomStart() {
    sweetalert2_1.default.fire({
        position: 'bottom-start',
        icon: 'success',
        title: 'Your work has been saved',
        showConfirmButton: false,
        timer: 1500,
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.PositionBottomStart = PositionBottomStart;
// Bottom-end
function PositionBottomEnd() {
    sweetalert2_1.default.fire({
        position: 'bottom-end',
        icon: 'success',
        title: 'Your work has been saved',
        showConfirmButton: false,
        timer: 1500,
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.PositionBottomEnd = PositionBottomEnd;
//-------------- Animations --------------
// Bounce-in
function BounceInAnimation() {
    sweetalert2_1.default.fire({
        title: 'Bounce In Animation',
        showClass: {
            popup: 'animated bounceIn'
        },
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.BounceInAnimation = BounceInAnimation;
// Fade-in
function FadeInAnimation() {
    sweetalert2_1.default.fire({
        title: 'Fade In Animation',
        showClass: {
            popup: 'animated fadeIn'
        },
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false
    });
}
exports.FadeInAnimation = FadeInAnimation;
// Flip-in
function FlipXAnimation() {
    sweetalert2_1.default.fire({
        title: 'Flip In Animation',
        showClass: {
            popup: 'animated flipInX'
        },
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.FlipXAnimation = FlipXAnimation;
// Tada
function TadaAnimation() {
    sweetalert2_1.default.fire({
        title: 'Tada Animation',
        showClass: {
            popup: 'animated tada'
        },
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.TadaAnimation = TadaAnimation;
// Shake
function ShakeAnimation() {
    sweetalert2_1.default.fire({
        title: 'Shake Animation',
        showClass: {
            popup: 'animated shake'
        },
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.ShakeAnimation = ShakeAnimation;
//-------------- Types --------------
// Success
function TypeSuccess() {
    sweetalert2_1.default.fire({
        title: "Good job!",
        text: "You clicked the button!",
        icon: "success",
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.TypeSuccess = TypeSuccess;
// Info
function TypeInfo(message) {
    sweetalert2_1.default.fire({
        title: "Info!",
        text: "" + message,
        icon: "info",
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.TypeInfo = TypeInfo;
// Warning
function TypeWarning() {
    sweetalert2_1.default.fire({
        title: "Warning!",
        text: "You clicked the button!",
        icon: "warning",
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.TypeWarning = TypeWarning;
// Error
function TypeError(message) {
    sweetalert2_1.default.fire({
        title: "Error!",
        showClass: {
            popup: 'animated tada'
        },
        text: "" + message,
        icon: "error",
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.TypeError = TypeError;
// Allow Outside Click
function OutsideClick() {
    sweetalert2_1.default.fire({
        title: 'Outside click is disabled!',
        text: 'This is a cool message!',
        allowOutsideClick: false,
        customClass: {
            confirmButton: 'btn btn-primary'
        },
        buttonsStyling: false,
    });
}
exports.OutsideClick = OutsideClick;
// Ajax Request
function AjaxRequest() {
    sweetalert2_1.default.fire({
        title: 'Submit your Github username',
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        buttonsStyling: false,
        showCancelButton: true,
        confirmButtonText: 'Look up',
        showLoaderOnConfirm: true,
        customClass: {
            confirmButton: 'btn btn-primary',
            cancelButton: 'btn btn-danger ml-1'
        },
        preConfirm: function (login) {
            return fetch("//api.github.com/users/" + login)
                .then(function (response) {
                if (!response.ok) {
                    throw new Error(response.statusText);
                }
                return response.json();
            })
                .catch(function (error) {
                sweetalert2_1.default.showValidationMessage("Request failed: " + error);
            });
        },
        allowOutsideClick: function () { return !sweetalert2_1.default.isLoading(); }
    }).then(function (result) {
        if (result.value) {
            sweetalert2_1.default.fire({
                title: result.value.login + "'s avatar",
                imageUrl: result.value.avatar_url
            });
        }
    });
}
exports.AjaxRequest = AjaxRequest;
//-------------- Confirm-options --------------
// Confirm Text
function ConfirmMessage(message, actionButton) {
    return sweetalert2_1.default.fire({
        title: 'Are you sure?',
        text: "" + message,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#2F8BE6',
        cancelButtonColor: '#F55252',
        confirmButtonText: actionButton,
        customClass: {
            confirmButton: 'btn btn-primary',
            cancelButton: 'btn btn-danger ml-1'
        },
        buttonsStyling: false,
    });
}
exports.ConfirmMessage = ConfirmMessage;
// Confirm Color
function ConfirmColor() {
    sweetalert2_1.default.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#2F8BE6',
        cancelButtonColor: '#F55252',
        confirmButtonText: 'Yes, delete it!',
        customClass: {
            confirmButton: 'btn btn-warning',
            cancelButton: 'btn btn-danger ml-1'
        },
        buttonsStyling: false,
    }).then(function (result) {
        if (result.value) {
            sweetalert2_1.default.fire({
                icon: "success",
                title: 'Deleted!',
                text: 'Your imaginary file has been deleted.',
                customClass: {
                    confirmButton: 'btn btn-success'
                },
            });
        }
        else if (result.dismiss === sweetalert2_1.default.DismissReason.cancel) {
            sweetalert2_1.default.fire({
                title: 'Cancelled',
                text: 'Your imaginary file is safe :)',
                icon: 'error',
                customClass: {
                    confirmButton: 'btn btn-success'
                },
            });
        }
    });
}
exports.ConfirmColor = ConfirmColor;
//# sourceMappingURL=sweet-alerts.js.map