


myapp.controller('TransactionDetailController',
        ['$scope', 'logger', 'dblogger', '$routeParams', 'transactionloader', 'statemanager',
        function ($scope, logger, dblogger, $routeParams, transactionloader, statemanager) {

            logger.log('Trans detail controller');


            $scope.id = $routeParams.id;

            $scope.setloading(true);
            logger.log('loading Transaction Detail ' + $scope.id);

            $scope.data = {};




            transactionloader.get($scope.id).then(function (data) {//success
                success(data);
                //save page state
                var savedstate = { data: data };
                logger.log('adding state');
                statemanager.addstate(savedstate, 'transactiondetail');
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
