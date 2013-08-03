
/// <reference path="../services/logger.js" />

mainModule.controller('SearchController',
    ['$scope', 'logger','search','dblogger',
    function ($scope, logger,search,dblogger) {

        logger.log('search controller');
        $scope.searchfor = '';
        $scope.loading = false;
        $scope.results = [];
        $scope.showResults = false;
        $scope.search = dosearch;

        function dosearch() {
            $scope.loading = true;
            logger.log('searching..');
            var params = {};
            params.searchfor = $scope.searchfor;
            
        search.searchForNotice(params).done(function (data)
            {
                success(data);
            }).fail(function (jqXHR, textStatus, errorThrown)
            {
                alert(errorThrown);
                dblogger.log(errorThrown);
            }   
             );
            refreshView();
        };
        function success(data) {
            $scope.showResults = true;
            logger.log('success search');
            $scope.results = data;
            $scope.loading = false;
            refreshView();
        }
        function refreshView() {
            if (!$scope.$$phase) {
                $scope.$apply();
            }
        }

    }]);