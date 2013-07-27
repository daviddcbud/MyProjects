/// <reference path="../services/main.datacontext.js" />
/// <reference path="../services/logger.js" />
/* Defines the "MainController" controller
 * Constructor function relies on Ng injector to provide:
 *     $scope - context variable for the view to which the view binds
 *     breeze - breeze is a "module" known to the injectory thanks to main.js
 *     datacontext - injected data and model access component (todo.datacontext.js)
 *     logger - records notable events during the session (about.logger.js)
 */
mainModule.controller('MainController',
    ['$scope', 'breeze', 'maindatacontext', 'logger',
    function ($scope, breeze, maindatacontext, logger) {

        logger.log("creating Main Controller");
        $scope.error = 'Hello';
        $scope.title = 'Test';
        $scope.todos = [];
        $scope.getTodos = getTodos;
        $scope.getTodos();

        //#region private functions 
        function getTodos(forceRefresh) {
            maindatacontext.getTodoLists(forceRefresh)
                .then(getSucceeded).fail(failed).fin(refreshView);
        }
        function refresh() { getTodos(true); }

        function getSucceeded(data) {
            $scope.todos = data;
        }
     

        function failed(error) {
            $scope.error = error.message;
        }
        function refreshView() {
            $scope.$apply();
        } 
        function clearErrorMessage(obj) {
            if (obj && obj.errorMessage) {
                obj.errorMessage = null;
            }
        } 
         
    }]);