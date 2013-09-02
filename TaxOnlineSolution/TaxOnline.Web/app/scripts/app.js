 
     
var myapp = angular.module('MyApp', ['ui.bootstrap']);
window.myapp = myapp;
myapp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/', { redirectTo: '/search' }).
        when('/about', { templateUrl: 'app/templates/about.view.html', controller: 'MainController' }).
        when('/logfiles', { templateUrl: 'app/templates/logs.view.html', controller: 'LogFilesController' }).
        when('/search', { templateUrl: 'app/templates/search.view.html', controller: 'SearchController' }).
        when('/taxnotice/:id', { templateUrl: 'app/templates/taxnotice.view.html', controller: 'TaxNoticeController' }).
        when('/transdetail/:id', { templateUrl: 'app/templates/transactiondetail.view.html', controller: 'TransactionDetailController' }).
        otherwise({ redirectTo: '/search' });
}]);
 
  