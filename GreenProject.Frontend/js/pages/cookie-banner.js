const cookieConsentName = "cookieConsent";
const cookieConsentValue = "on";
const cookieConsentDays = 365;

if (!Cookies.checkCookie("cookieConsent")) {
    $("#alert-cookie").addClass("show");
}

$("#cookie-allow-button").click(function() {
    Cookies.setCookie(cookieConsentName, cookieConsentValue, cookieConsentDays);
});
