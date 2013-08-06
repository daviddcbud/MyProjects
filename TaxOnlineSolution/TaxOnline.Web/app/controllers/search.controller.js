
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
        $scope.message = '';
        $scope.showMessage = false;
        $scope.searchtypes = [
            {
                name: 'Name',
                id: 0
            },
            {
                name: 'Bill#',
                id: 1
            },
            {
                name: 'Address',
                id: 2
            }

        ];
        $scope.searchtype = $scope.searchtypes[0];
        function dosearch() {
            $scope.showMessage = false;
            $scope.loading = true;
            logger.log('searching..');
            var params = {};
            params.searchfor = $scope.searchfor;
            params.searchtype = $scope.searchtype.id;
            
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
            if (data.length > 0) {
                $scope.showResults = true;
            }
            else {
                $scope.showMessage = true;
                $scope.message = "No Results Found";
            }
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