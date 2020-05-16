class CookiesClass {

    constructor() {
        if (!!CookiesClass.Cookies) {
            return CookiesClass.Cookies;
        }
        CookiesClass.Cookies = this;
    }

    setCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        } else {
            var expires = "";
        }
        document.cookie = name + "=" + value + expires + "; path=/";
    }

    getCookie(name) {
        var nameEQ = name + "=";
        var ca = document.cookie.split(";");
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == " ") {
                c = c.substring(1, c.length);
            }
            if (c.indexOf(nameEQ) == 0) {
                return c.substring(nameEQ.length, c.length);
            }
        }
        return null;
    }

    removeCookie(name) {
        this.setCookie(name, "", -1);
    }

    checkCookie(name) {
        return this.getCookie(name) != null;
    }

}

var Cookies = Object.freeze(new CookiesClass());
