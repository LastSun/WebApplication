'use strict';
app.controller('indexCtrl',['$scope','$location','authService','$http', function($scope,$location,authService,$http) {
        $scope.logout = function() {
            authService.logout();
            $location.path('/index');
        }

    $scope.test= function() {
        $http.get('http://localhost:55893/api/protected').then(function(response) {
            var a = response;
        }, function(err) {
            var a = err;
        });
    }
        $scope.authentication = authService.authentication;
    }
])