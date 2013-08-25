
mainModule.controller('TaxNoticeController',
    ['$scope', 'logger','dblogger','$routeParams',
    function ($scope, logger,  dblogger, $routeParams) {

        logger.log('tax notice controller');
        $scope.id = $routeParams.id;


        $scope.goback = function () {
            window.history.back();
        };
    }]);