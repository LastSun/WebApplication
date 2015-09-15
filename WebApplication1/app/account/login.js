'use strict';
app.controller('loginCtrl', ['$scope', '$location', 'authService', 'md5',
    function($scope, $location, authService, md5) {
        $scope.loginData = {
            userName: "",
            passwordHash: ""
        };

        $scope.message = "";

        $scope.login = function () {
            $scope.loginData.passwordHash = md5.createHash($scope.loginData.passwordHash);
            $scope.loginData.password = $scope.loginData.passwordHash;
            authService.login($scope.loginData).then(
                function(response) {
                    $location.path('/orders');
                },
                function(err) {
                    $scope.message = err.error_description;
                });
        };
    }
]);