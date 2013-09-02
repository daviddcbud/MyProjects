 

myapp.factory('snsutils',
        ['$http', '$q', function ($http, $q) {


            var snsutils = {
                get: get,
                ajaxjsonpost: ajaxjsonpost,
                ajaxget: ajaxget
            };

            return snsutils;


            function get(controllerName, parameters) {
                var deferred = $q.defer();

                $http.get('/api/' + controllerName, { params: parameters }).then(function (result) {
                    //send back just the actual data
                    deferred.resolve(result.data);
                },
                function (result) {
                    //send back exception message
                    var msg = '';
                    for (var k in result.data) {
                        msg += k + ':' + result.data[k] + '\n';
                    }
                    deferred.reject(msg);
                });


                return deferred.promise;
            }
            function ajaxget(cache, controllerName, parameters) {
                var ajax = $.ajax({
                    url: "/api/" + controllerName,
                    data: parameters,
                    type: "GET"


                });
                return ajax;
            }

            function ajaxjsonpost(controllerName, objectToPost) {
                var ajax = $.ajax({
                    url: "/api/" + controllerName,
                    data: JSON.stringify(objectToPost),
                    type: "POST",
                    contentType: "application/json;charset=utf-8"
                });
                return ajax;

            }




        }]);
 