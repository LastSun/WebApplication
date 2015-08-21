'use strict';

angular.module('eLearning').controller('ProjectCtrl', function($scope, $modal) {
        $scope.project = {
            Id: 1,
            Name: 'Benz'
        };

        $scope.open = function() {
            var modalInstance = $modal.open({
                scope: $scope,
                templateUrl: 'app/Project/Modal.html',
                backdrop: 'static'
            });

            modalInstance.result.then(function(newProject) {
                alert(newProject.Name);
            }, function(err) {
                alert('Error!');
            });

            $scope.newProject = {
                Name: ''
            };

            $scope.submitForm = function(isValid) {
                if (isValid) {
                    modalInstance.close($scope.newProject);
                }
            }

            $scope.cancel = function() {
                modalInstance.dismiss('cancel');
            };
        }
    }
);