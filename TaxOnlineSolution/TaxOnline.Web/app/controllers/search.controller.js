
/// <reference path="../services/logger.js" />

mainModule.controller('SearchController',
    ['$scope', 'logger', 'search', 'dblogger', 'statemanager',
    function ($scope, logger, search, dblogger, statemanager) {

        logger.log('search controller');
        var existingstate = statemanager.getstate('search');
        logger.log('state=' + existingstate, 'high');
        $scope.searchfor = '';
         
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
            //load up the ui with existing page state
            $scope.results = existingstate.results;
            $scope.showResults = true;
            $scope.searchtype = $scope.searchtypes[existingstate.searchtype];
            $scope.searchfor = existingstate.searchfor;
        }
        function dosearch() {
            $scope.showMessage = false;
            $scope.setloading(true);
            logger.log('searching..');
            var params = {};
            params.searchfor = $scope.searchfor;
            params.searchtype = $scope.searchtype.id;


            search.searchForNotice(params).then(function (data) {//success
                success(data);
                //save page state
                var savedstate = { results: data, searchtype: $scope.searchtype.id, searchfor:$scope.searchfor };
                logger.log('adding state');
                statemanager.addstate(savedstate, 'search');
            }
            , 
            function (data) {//error
                
                $scope.addError(data);
                dblogger.log(data);
               
                 
            }
            ).then(function () {
                $scope.setloading(false);
                
            }) ;

            
             
        };
        function success(data) {
            //load results
            if (data.length > 0) {
                $scope.showResults = true;
            }
            else {
                $scope.showMessage = true;
                $scope.message = "No Results Found";
            }
            logger.log('success search');
            angular.copy(data, $scope.results);
            $scope.setloading(false);
          //  refreshView();
        }
        function refreshView() {
            if (!$scope.$$phase) {
                $scope.$apply();
            }
        }

    }]);