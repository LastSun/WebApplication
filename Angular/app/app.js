'use strict';

// Declare app level module which depends on views, and components
angular.module('eLearning', [
        'ui.router',
        'ui.bootstrap',
        'ui.validate'
    ])
    .config([
        '$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider) {
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
                .state('about', {
                    url: '/about',
                    template: '<h1>View2</h1>'
                });
        }
    ]);