'use strict';

angular.module('eLearning').controller('ProjectCtrl', function($scope, $modal) {
        $scope.project = {
            Id: 1,
            Name: 'Benz'
        };

        $scope.open = function() {
            var modalInstance = $modal.open({
                scope: $scope,
                templateUrl: 'app/Project/Modal.html'
            });

            modalInstance.result.then(function (newProject) {
                alert(newProject.Name);
            }, function() {
                alert('Error!');
            });

            $scope.newProject = {
                Name: ''
            };

            $scope.ok = function () {
                modalInstance.close($scope.newProject);
            };

            $scope.submitForm= function() {
                if ($scope.form.userForm.$valid) {
                    modalInstance.close($scope.newProject);
                }
            }

            $scope.cancel = function () {
                modalInstance.dismiss('cancel');
            };
        }
    }
);