'use strict';

// Declare app level module which depends on views, and components
angular.module('eLearning', [
        'ui.router',
        'ui.bootstrap',
        'ui.multiselect',
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
                responseError: function (response) {
                    alert(response.status + ': ' + response.statusText);
                    return $q.reject(response);
                }
            }
        });
    })
    .config([
        '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/index.html');

            $stateProvider
                .state('home', {
                    url: '/home',
                    templateUrl: 'app/home/home.html',
                    controller: 'HomeCtrl'
                })
                .state('project', {
                    url: '/project',
                    templateUrl: 'app/project/project.html',
                    controller: 'ProjectCtrl'
                })
                .state('user', {
                    url: '/user',
                    templateUrl: 'app/user/user.html',
                    controller: 'UserCtrl'
                })
                .state('class', {
                    url: '/class',
                    templateUrl: 'app/class/class.html',
                    controller: 'ClassCtrl'
                })
                .state('about', {
                    url: '/about',
                    template: '<h1>View2</h1>'
                });
        }
    ])
    .run(function($rootScope, $templateCache) {
        $rootScope.$on('$viewContentLoaded', function() {
//            $templateCache.removeAll();
        });
    });