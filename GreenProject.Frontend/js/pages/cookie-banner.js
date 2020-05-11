const cookieConsentName = "cookieConsent";
const cookieConsentValue = "on";
const cookieConsentDays = 365;

if (Cookies.checkCookie("cookieConsent")) {
    $("#alert-cookie").alert("close");
}

$("#cookie-allow-button").click(function() {
    $("#alert-cookie").alert("close");
    Cookies.setCookie(cookieConsentName, cookieConsentValue, cookieConsentDays);
});
