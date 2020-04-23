var CFValidator = (function() {

    var Result = function(isValid, errorMessage) {
        this.isValid = isValid;
        this.errorMessage = errorMessage;
    }

    // Remove whitespace and convert to uppercase
    var normalize = function(cf) {
        return cf.replace(/\s/g, "").toUpperCase();
    }

    // Validate a regular CF
    var validateRegular = function(cf) {
        if (! /^[0-9A-Z]{16}$/.test(cf)) {
            return new Result(false, "Invalid characters");
        }
        let s = 0;
        let even_map = "BAFHJNPRTVCESULDGIMOQKWZYX";
        for (let i = 0; i < 15; i++) {
            let c = cf[i];
            let n = 0;
            if ("0" <= c && c <= "9") {
                n = c.charCodeAt(0) - "0".charCodeAt(0);
            } else {
                n = c.charCodeAt(0) - "A".charCodeAt(0);
            }
            if ((i & 1) === 0) {
                n = even_map.charCodeAt(n) - "A".charCodeAt(0);
            }
            s += n;
        }
        if (s%26 + "A".charCodeAt(0) !== cf.charCodeAt(15)) {
            return new Result(false, "Invalid checksum");
        }
        return new Result(true);
    }


    // Validate a temporary CF
    var validateTemporary = function(cf) {
        if (! /^[0-9]{11}$/.test(cf)) {
            return new Result(false, "Invalid characters");
        }
        let s = 0;
        for (let i = 0; i < 11; i++) {
            let n = cf.charCodeAt(i) - "0".charCodeAt(0);
            if ((i & 1) === 1) {
                n *= 2;
                if (n > 9) {
                    n -= 9;
                }
            }
            s += n;
        }
        if (s % 10 !== 0) {
            return new Result(false, "Invalid checksum");
        }
        return new Result(true);
    }

    return {

        // Normalize the given CF
        format: function(cf) {
            return normalize(cf);
        },

        // Validate the given CF
        validate: function(cf) {
            cf = normalize(cf);
            if (cf.length === 0) {
                return new Result(false, "Empty");
            } else if( cf.length === 16 ) {
                return validateRegular(cf);
            } else if( cf.length === 11 ) {
                return validateTemporary(cf);
            } else {
                return new Result(false, "Invalid length");
            }
        }
    }
})();
