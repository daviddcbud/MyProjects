/// <reference path="../../Scripts/angular.js" />
/// <reference path="../../Scripts/breeze.intellisense.js" />
 
 
window.mainModule = angular.module('mainModule', []);

// Add global "services" (like breeze and Q) to the Ng injector
mainModule.value('breeze', window.breeze)
    .value('Q', window.Q);

// Configure routes
mainModule.config(['$routeProvider', function ($routeProvider) {
	$routeProvider.
		when('/', { templateUrl: 'app/templates/index.view.html', controller: 'MainController' }).
		when('/about', { templateUrl: 'app/templates/about.view.html', controller: 'MainController' }).
		when('/todos', { templateUrl: 'Home/Todo', controller: 'ToDoController' }).
		when('/logfiles', { templateUrl: 'app/templates/logs.view.html', controller: 'LogFilesController' }).
		otherwise({ redirectTo: '/' });
}]);

//#region Ng directives
/*  We extend Angular with custom data bindings written as Ng directives */
mainModule.directive('onFocus', function () {
	return {
		restrict: 'A',
		link: function (scope, elm, attrs) {
			elm.bind('focus', function () {
				scope.$apply(attrs.onFocus);
			});
		}
	};
})
    .directive('onBlur', function () {
    	return {
    		restrict: 'A',
    		link: function (scope, elm, attrs) {
    			elm.bind('blur', function () {
    				scope.$apply(attrs.onBlur);
    			});
    		}
    	};
    })
    .directive('onEnter', function () {
    	return function (scope, element, attrs) {
    		element.bind("keydown keypress", function (event) {
    			if (event.which === 13) {
    				scope.$apply(function () {
    					scope.$eval(attrs.onEnter);
    				});

    				event.preventDefault();
    			}
    		});
    	};
    })
    .directive('selectedWhen', function () {
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