myapp.directive('ngDsFade', function () {
    return function (scope, element, attrs) {
        scope.$watch(attrs.ngDsFade, function (value) {
           
            if (value) {

                element.fadeOut(5000);
            }
            else {
                element.fadeIn(200);
            }
        });
    };
});

    //#region Ng directives
    /*  We extend Angular with custom data bindings written as Ng directives */
myapp.directive('ngFocus', function () {
        return {
            restrict: 'A',
            link: function (scope, elm, attrs) {
                elm.bind('focus', function () {
                    scope.$apply(attrs.ngFocus);
                });
            }
        };
    })
        .directive('ngBlur', function () {
            return {
                restrict: 'A',
                link: function (scope, elm, attrs) {
                    elm.bind('blur', function () {
                        scope.$apply(attrs.ngBlur);
                    });
                }
            };
        }).directive('ngEnter', function () {
            return function (scope, element, attrs) {
                element.bind("keydown keypress", function (event) {

                    if (event.which === 13) {

                        scope.$apply(function () {
                            scope.$eval(attrs.ngEnter);
                        });

                        event.preventDefault();
                    }
                });
            };
        }).
    directive('activeLink', ['$location', function (location) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs, controller) {
                var clazz = attrs.activeLink;
                scope.location = location;
                scope.$watch('location.path()', function (newPath) {
                    if (attrs.href.substring(1) === newPath) {
                        element.addClass(clazz);
                    } else {
                        element.removeClass(clazz);
                    }
                });
            }

        };

    }]).directive('selectedWhen', function () {
        return function (scope, elm, attrs) {
            scope.$watch(attrs.selectedWhen, function (shouldBeSelected) {
                if (shouldBeSelected) {
                    elm.select();
                }
            });
        };
    });
    if (!Modernizr.input.placeholder) {
        // this browser does not support HTML5 placeholders
        // see http://stackoverflow.com/questions/14777841/angularjs-inputplaceholder-directive-breaking-with-ng-model
        mainModule.directive('placeholder', function () {
            return {
                restrict: 'A',
                require: 'ngModel',
                link: function (scope, element, attr, ctrl) {

                    var value;

                    var placeholder = function () {
                        element.val(attr.placeholder);
                    };
                    var unplaceholder = function () {
                        element.val('');
                    };

                    scope.$watch(attr.ngModel, function (val) {
                        value = val || '';
                    });

                    element.bind('focus', function () {
                        if (value == '') unplaceholder();
                    });

                    element.bind('blur', function () {
                        if (element.val() == '') placeholder();
                    });

                    ctrl.$formatters.unshift(function (val) {
                        if (!val) {
                            placeholder();
                            value = '';
                            return attr.placeholder;
                        }
                        return val;
                    });
                }
            };
        });
    }
    //#endregion 


 