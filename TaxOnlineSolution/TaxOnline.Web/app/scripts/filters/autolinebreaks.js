myapp.filter('autolinebreaks', function () {
    return function (input, param) {
        if (input) { return input.replace('\n', '<br/>'); }
        else { return ''; }
    }
});