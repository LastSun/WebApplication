'use strict';

// Declare app level module which depends on views, and components
angular.module('eLearning', [
        'ui.router',
        'ui.bootstrap',
        'ngResource',
        'smart-table'
    ])
    .factory('$exceptionHandler', function() {
        return function(exception, cause) {
            alert(exception);
            alert(cause);
        };
    })
    .config(function($httpProvider) {
        $httpProvider.interceptors.push(function($q) {
            return {
                response: function(response) {
                    return response;
                },
                responseError: function(response) {
                    return $q.reject(response);
                }
            }
        });
    })
    .config([
        '$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/index.html');

            $stateProvider
                .state('home', {
                    url: '/home',
                    templateUrl: 'app/Home/home.html',
                    controller: 'HomeCtrl'
                })
                .state('project', {
                    url: '/project',
                    templateUrl: 'app/Project/project.html',
                    controller: 'ProjectCtrl'
                })
                .state('user', {
                    url: '/user',
                    templateUrl: 'app/User/User.html',
                    controller: 'UserCtrl'
                })
                .state('about', {
                    url: '/about',
                    template: '<h1>View2</h1>'
                });
        }
    ])
;