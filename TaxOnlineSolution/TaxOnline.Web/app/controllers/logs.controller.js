 
/// <reference path="../services/logger.js" />
 
mainModule.controller('LogFilesController',
    ['$scope', 'logger',
    function ($scope, logger) {

         
        $scope.logs = logger.logEntries;
         


    }]);