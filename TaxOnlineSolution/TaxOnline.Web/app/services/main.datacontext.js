/// <reference path="logger.js" />
/// <reference path="../../Scripts/breeze.intellisense.js" />
/* datacontext: data access and model management layer */

// create and add datacontext to the Ng injector
// constructor function relies on Ng injector
// to provide service dependencies
mainModule.factory('maindatacontext',
    ['breeze', 'Q', 'model', 'logger', '$timeout',
    function (breeze, Q, model, logger, $timeout) {

        logger.log("creating datacontext");
        var initialized;

        configureBreeze();
        var manager = new breeze.EntityManager("api/TodoItem");
        manager.enableSaveQueuing(true);

        var datacontext = {
            metadataStore: manager.metadataStore,
            getTodoLists: getTodoLists
        };
        model.initialize(datacontext);
        return datacontext;

        //#region private members

        function getTodoLists(forceRefresh) {

            var query = breeze.EntityQuery
                .from("Todos")
                .orderBy("Id desc");

            if (initialized && !forceRefresh) {
                query = query.using(breeze.FetchStrategy.FromLocalCache);
            }
            initialized = true;

            return manager.executeQuery(query)
                .then(getSucceeded); // caller to handle failure
        }

        function getSucceeded(data) {
            var qType = data.XHR ? "remote" : "local";
            logger.log(qType + " query succeeded");
            return data.results;
        }

        

        function configureBreeze() {
            // configure to use the model library for Angular
            breeze.config.initializeAdapterInstance("modelLibrary", "backingStore", true);

            // configure to use camelCase
            breeze.NamingConvention.camelCase.setAsDefault();

            // configure to resist CSRF attack
            var antiForgeryToken = $("#antiForgeryToken").val();
            if (antiForgeryToken) {
                // get the current default Breeze AJAX adapter & add header
                var ajaxAdapter = breeze.config.getAdapterInstance("ajax");
                ajaxAdapter.defaultSettings = {
                    headers: {
                        'RequestVerificationToken': antiForgeryToken
                    },
                };
            }
        }
        //#endregion
    }]);