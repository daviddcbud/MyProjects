


myapp.factory('transactionloader',
        ['snsutils', '$http', '$q', function (snsutils, $http, $q) {

            var results = [];

            var search = {
                get: get
            };

            return search;


            function get(id) {
                var deferred = $q.defer();

                $http.get('/api/Transaction/' + id).then(function (result) {
                    //send back just the actual data
                    deferred.resolve(result.data);
                },
                function (result) {
                    //send back exception message
                    deferred.reject(result.data.exceptionMessage);
                });


                return deferred.promise;

            }








        }]);
