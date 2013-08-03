mainModule.factory('search',
    ['snsutils', function (snsutils) {


        var search = {

            searchForNotice: searchForNotice
        };

        return search;

        function searchForNotice(data) {
            var ajax = snsutils.ajaxget(false, 'Search', data);
            return ajax;
        }

        

        




    }]);