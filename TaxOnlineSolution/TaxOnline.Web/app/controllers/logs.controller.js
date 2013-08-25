 
/// <reference path="../services/logger.js" />
 
mainModule.controller('LogFilesController',
    ['$scope', 'logger',
    function ($scope, logger) {




        $scope.logtypes = [];
        
        $scope.alllogs = logger.logEntries;
        for (var item in $scope.alllogs) {
            var logitem = $scope.alllogs[item];
            
            if(($.inArray(logitem.type, $scope.logtypes)))
            {
                
                $scope.logtypes.push(logitem.type);
            }
        }


        $scope.logs = logger.logEntries;
        $scope.logtype = '';
        $scope.filter = function () {
            
            var filtered = [];
            for (var item in $scope.alllogs) {
                var logitem = $scope.alllogs[item];
                 
                if (logitem.type == $scope.logtype) {
                    filtered.push(logitem);
                }
            }
            $scope.logs = filtered;
        };


    }]);