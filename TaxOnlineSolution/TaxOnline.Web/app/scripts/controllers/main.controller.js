﻿/// <reference path="../services/main.datacontext.js" />
/// <reference path="../services/logger.js" />
/* Defines the "MainController" controller
 * Constructor function relies on Ng injector to provide:
 *     $scope - context variable for the view to which the view binds

 *     logger - records notable events during the session (about.logger.js)
 */
 


myapp.controller('MainController',
        ['$scope', 'logger',
        function ($scope, logger) {



            $scope.title = 'Test';
            logger.log("creating Main Controller");



        }]);
 