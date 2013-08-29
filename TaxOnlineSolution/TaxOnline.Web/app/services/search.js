mainModule.factory('search',
    ['snsutils','$http','$q', function (snsutils, $http,$q) {

        var results = [];

        var search = {
            searchForNotice: searchForNotice
        };

        return search;


        function searchForNotice(parameters) {
           return snsutils.get('Search', parameters);
            
        }

        

        




    }]);