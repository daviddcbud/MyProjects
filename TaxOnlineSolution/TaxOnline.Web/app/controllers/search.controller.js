
/// <reference path="../services/logger.js" />

mainModule.controller('SearchController',
    ['$scope', 'logger', 'search', 'dblogger', 'statemanager',
    function ($scope, logger, search, dblogger, statemanager) {

        logger.log('search controller');
        var existingstate = statemanager.getstate('search');
        logger.log('state=' + existingstate, 'high');
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

        if (existingstate) {
            $scope.results = existingstate.results;
            $scope.showResults = true;
            $scope.searchtype = $scope.searchtypes[existingstate.searchtype];
        }
        function dosearch() {
            $scope.showMessage = false;
            $scope.loading = true;
            logger.log('searching..');
            var params = {};
            params.searchfor = $scope.searchfor;
            params.searchtype = $scope.searchtype.id;

            search.searchForNotice(params).done(function (data) {
                 
                success(data);

                var savedstate = { results: data, searchtype: $scope.searchtype.id };
                logger.log('adding state');
                statemanager.addstate(savedstate, 'search');
            }).fail(function (jqXHR, textStatus, errorThrown) {
                $scope.setError(errorThrown);
                 
                dblogger.log(errorThrown);
                $scope.loading = false;
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
            angular.copy(data, $scope.results);
            $scope.loading = false;
            refreshView();
        }
        function refreshView() {
            if (!$scope.$$phase) {
                $scope.$apply();
            }
        }

    }]);