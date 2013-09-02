 

    
myapp.controller('TaxNoticeController',
        ['$scope', 'logger', 'dblogger', '$routeParams', 'taxnoticeloader','statemanager',
        function ($scope, logger, dblogger, $routeParams, taxnoticeloader, statemanager) {

            logger.log('tax notice controller');
            

            $scope.id = $routeParams.id;

            $scope.setloading(true);
            logger.log('loading tax notice ' + $scope.id);

            $scope.data = {};

             


            taxnoticeloader.get($scope.id).then(function (data) {//success
                success(data);
                //save page state
                var savedstate = { data: data };
                logger.log('adding state');
                statemanager.addstate(savedstate, 'taxnotice');
            }
            ,
            function (data) {//error

                $scope.addError(data);
                dblogger.log(data);

            }
            ).then(function () {
                $scope.setloading(false);
            });




            function success(data) {

                logger.log('success load');
                data.taxpayer.formattedAddress = data.taxpayer.formattedAddress.replace('\n', '<br/>');
                angular.copy(data, $scope.data);
                $scope.setloading(false);

            }
            function refreshView() {
                if (!$scope.$$phase) {
                    $scope.$apply();
                }
            }

            $scope.goback = function () {
                window.history.back();
            };
        }]);
 