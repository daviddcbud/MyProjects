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


        $scope.error = "";

        $scope.clearError = function () {
            $scope.error=''
        };
        $scope.setError = function (errorMessage) {
            $scope.error = errorMessage;
        };
        logger.log("creating Menu BaseController");

        function Menu(name, href, classname) {
            this.name = name;
            this.href = href;
            this.classname = classname;
        }
        var menus = [];
        var menu = new Menu("Search", "#/search","active");
        menus.push(menu);
        var menu = new Menu("Debug Logs", "#/logfiles");
        menus.push(menu);
        var menu = new Menu("About", "#/about");
        menus.push(menu);

        $scope.menus = menus;

        $scope.menuclicked = function (index) {
            $.each(menus, function () {
                this.classname = "";
            });

            menus[index].classname="active"
        };

    }]);