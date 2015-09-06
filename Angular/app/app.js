'use strict';

// Declare app level module which depends on views, and components
var app = angular.module('eLearning', [
        'ui.router',
        'ui.bootstrap',
        'ui.multiselect',
        'ngResource',
        'smart-table',
        'LocalStorageModule'
    ])
    .factory('$exceptionHandler', function() {
        return function(exception, cause) {
            alert(exception);
            alert(cause);
        };
    })
    .config(function($httpProvider) {
        $httpProvider.interceptors.push(function ($q, localStorageService) {
            return {
                request: function(request) {
                    request.headers = request.headers || {};
                    var authData = localStorageService.get('authorizationData');
                    if (authData) {
                        request.headers.Authorization = 'Bearer ' + authData.token;
                    }
                    return request;
                },
                response: function(response) {
                    return response;
                },
                responseError: function (response) {
                    alert(response.status + ': ' + response.statusText);
                    if (response.status === 401) {
                        $location.path('/login');
                    }
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
                .state('signup', {
                    url: '/signup',
                    templateUrl: 'app/account/signup.html',
                    controller: 'signupCtrl'
                })
                .state('login', {
                    url: '/login',
                    templateUrl: 'app/account/login.html',
                    controller:'loginCtrl'
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