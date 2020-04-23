var PIValidator = (function() {

    var Result = function(isValid, errorMessage) {
        this.isValid = isValid;
        this.errorMessage = errorMessage;
    }

    // Remove whitespace
    var normalize = function(pi) {
        return pi.replace(/\s/g, "");
    }

    return {

        // Normalize the given PI
        format: function(pi) {
            return normalize(pi);
        },

        // Validate the given PI
        validate: function(pi) {
            pi = normalize(pi);
            if (pi.length === 0) {
                return new Result(false, "Empty");
            } else if (pi.length !== 11) {
                return new Result(false, "Invalid length");
            }
            if (! /^[0-9]{11}$/.test(pi)) {
                return new Result(false, "Invalid characters");
            }
            var s = 0;
            for (var i = 0; i < 11; i++) {
                var n = pi.charCodeAt(i) - "0".charCodeAt(0);
                if ((i & 1) === 1) {
                    n *= 2;
                    if(n > 9) {
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
    }
})();
