/// <reference path="../services/main.datacontext.js" />
/// <reference path="../services/logger.js" />
/* Defines the "MainController" controller
 * Constructor function relies on Ng injector to provide:
 *     $scope - context variable for the view to which the view binds

 *     logger - records notable events during the session (about.logger.js)
 */
mainModule.controller('BaseController',
    ['$scope', 'logger',
    function ($scope, logger) {


        $scope.alerts = [];
        $scope.loading = false;
         

        $scope.closeAlert=function(index){
            $scope.alerts.splice(index, 1);
        }

        $scope.clearError = function () {
            $scope.alerts = [];
        };
        $scope.addError = function (errorMessage) {
            var alert={type:'error' ,msg:errorMessage};
            $scope.alerts.push(alert);
        };
        $scope.setloading = function (data) {
            $scope.loading = data;
        };
        logger.log("creating Menu BaseController");

        $scope.addError('test');
         
        function Menu(name, href, classname) {
            this.name = name;
            this.href = href;
            this.classname = classname;
        }
        var menus = [];
        var menu = new Menu("Search", "#/search","active");
        menus.push(menu);
        
        var menu = new Menu("Payment", "#/payment");
        menus.push(menu);
        var menu = new Menu("Reports", "#/reports");
        menus.push(menu);
        var menu = new Menu("Setup", "#/setup");
        menus.push(menu);
        var menu = new Menu("Debug Logs", "#/logfiles");
        menus.push(menu);

        var menu = new Menu("About", "#/about");
        menus.push(menu);

        $scope.menus = menus;

        //$scope.menuclicked = function (index) {
        //    $.each(menus, function () {
        //        this.classname = "";
        //    });

        //    menus[index].classname = "active";
        //};

    }]);