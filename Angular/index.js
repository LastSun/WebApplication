'use strict';
app.controller('indexCtrl',['$scope','$location','authService', function($scope,$location,authService) {
        $scope.logout = function() {
            authService.logout();
            $location.path('/index');
        }

        $scope.authentication = authService.authentication;
    }
])