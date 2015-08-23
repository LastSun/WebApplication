'use strict';

angular.module('eLearning').controller('ProjectCtrl', function($scope, $modal, $resource) {
        $scope.project = {
            Id: 1,
            Name: 'Benz'
        };

        var Project = $resource('api/project/:id');

        $scope.open = function() {
            var modalInstance = $modal.open({
                scope: $scope,
                templateUrl: 'app/Project/Modal.html',
                backdrop: 'static'
            });

            modalInstance.result.then(function(newProject) {
                alert(newProject.Name);
                Project.save(newProject, function(result) {
                    var a = result;
                }, function(result) {
                    var a = result;
                });
            }, function(err) {
                alert(err);
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