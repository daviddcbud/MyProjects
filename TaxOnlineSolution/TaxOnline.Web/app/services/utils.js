
mainModule.factory('snsutils',
    ['$http', function ($http) {


        var snsutils = {
           
            ajaxjsonpost: ajaxjsonpost,
            ajaxget:ajaxget
        };

        return snsutils;

        function ajaxget(cache,controllerName, parameters) {
            var ajax = $.ajax({
                url: "/api/" + controllerName,
                data: JSON.stringify(parameters),
                type: "GET"
                
            });
            return ajax;
        }

        function ajaxjsonpost(controllerName, objectToPost) {
            var ajax= $.ajax({
                url: "/api/" + controllerName,
                data: JSON.stringify(objectToPost),
                type: "POST",
                contentType: "application/json;charset=utf-8"
            });
            return ajax;

        }

       

        
    }]);