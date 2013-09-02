/// <reference path="errorlog.datacontext.js" />
/// <reference path="utils.js" />
/* logger: logs messages of events during 
 * current user session in an in-memory log 
 */
 

myapp.factory('logger', ['$log', function ($log) {

        var logEntries = [];
        var counter = 1;
        var logger = {
            log: log,
            logEntries: logEntries
        };

        return logger;

        function log(message, type) {
            var logEntry = {
                id: counter++,
                message: message,
                type: type || "info"
            };
            logEntries.push(logEntry);
            $log.log(message);
        }
    }]);



myapp.factory('dblogger',
        ['logger', 'snsutils', '$log', function (logger, snsutils, $log) {


            var dblogger = {
                log: log


            };

            return dblogger;

            function log(message) {


                var logItem = {};
                logItem.Error = message;
                if (logItem.Error == null || logItem.Error == '') return;
                snsutils.ajaxjsonpost('ErrorLog', logItem).fail(function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                });


            }



        }]);
 