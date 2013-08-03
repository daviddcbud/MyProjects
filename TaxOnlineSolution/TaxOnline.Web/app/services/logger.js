/// <reference path="errorlog.datacontext.js" />
/// <reference path="utils.js" />
/* logger: logs messages of events during 
 * current user session in an in-memory log 
 */
mainModule.factory('logger', function () {

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
    }
});



mainModule.factory('dblogger',
    ['logger', 'snsutils', function (logger, snsutils) {

    
    var dblogger = {
        log: log,
        
        
    };

    return dblogger;
         
    function log(message) {


        var logItem = {};
        logItem.Error = message;
        snsutils.ajaxjsonpost('ErrorLog', logItem).fail(function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        });
         

    }

         
    
}]);