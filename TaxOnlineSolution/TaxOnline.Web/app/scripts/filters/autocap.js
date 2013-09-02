myapp.filter('autocap', function () {
    return function (input, param) {
        if (input) { return input.toUpperCase(); }
        else { return '';}
    }
});