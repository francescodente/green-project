const cookieConsentName = "cookie_consent";
const cookieConsentValue = "on";
const cookieConsentDays = 365;

if (Cookies.checkCookie(cookieConsentName)) {
    $("#alert-cookie").alert("close");
}

$("#cookie-allow-button").click(function() {
    $("#alert-cookie").alert("close");
    Cookies.setCookie(cookieConsentName, cookieConsentValue, cookieConsentDays);
});
