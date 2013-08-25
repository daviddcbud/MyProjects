mainModule.factory('statemanager',
    ['snsutils', 'logger', function (snsutils,logger) {

        logger.log('creating state manager');
        var datastore = {};
        var statemanager = {

            addstate: addstate,
            getstate:getstate
        };

        return statemanager;

        function getstate(key) {
            logger.log('getting state ' + datastore);
            return datastore[key];
        }
        function addstate(data,key) {
            if (datastore[key]) {
                datastore[key] = data;
            }
            else {
                logger.log('adding state ' + key);
                datastore[key]=data;
            }
        }








    }]);