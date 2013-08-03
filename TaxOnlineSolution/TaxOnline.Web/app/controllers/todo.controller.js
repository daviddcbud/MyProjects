/// <reference path="../services/todo.datacontext.js" />
/// <reference path="../services/main.datacontext.js" />
/// <reference path="../services/utils.js" />
/// <reference path="../services/logger.js" />
/* Defines the controller
 * Constructor function relies on Ng injector to provide:
 *     $scope - context variable for the view to which the view binds

 *     logger - records notable events during the session (about.logger.js)
 */
mainModule.controller('ToDoController',
    ['$scope',   'logger','dblogger','snsutils',
function ($scope,   logger,dblogger,snsutils) {

     
    dblogger.log('does this work');
        logger.log("creating ToDo Controller");
        $scope.title = 'To Do';
        $scope.todos = [];
        $scope.getTodos = getTodos;
        $scope.getTodos();
        $scope.save = save;
        $scope.loading = true;
        function save() {
            $scope.todos[0].message = 'Saved test';
           
        }

        //#region private functions 
        function getTodos(forceRefresh) {
            $scope.loading = true;
            logger.log('loading todos');
            snsutils.ajaxget(false, 'TodoList', '').
                done(function (data) { success(data); }).fail(function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                    dblogger.log(errorThrown);
                }
                );
            refreshView();
             
        }
        function refresh() { getTodos(true); }

        function success(data) {
            logger.log('success todos');
            $scope.todos = data;
            $scope.loading = false;
            refreshView();
        }


        function failed(error) {
            $scope.loading = false;
            $scope.error = error.message;
        }
        function refreshView() {
            if (!$scope.$$phase) {
                $scope.$apply();
            }
        }
        function clearErrorMessage(obj) {
            if (obj && obj.errorMessage) {
                obj.errorMessage = null;
            }
        }

    }]);