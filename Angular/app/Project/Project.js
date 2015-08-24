'use strict';

angular.module('eLearning').controller('ProjectCtrl', function($scope, $modal, $resource) {
        var Project = $resource('api/project/:id');

        $scope.projects = Project.query();
        $scope.pageChanged= function() {
            var a = $scope.currentPage;
        }

        $scope.open = function() {
            var modalInstance = $modal.open({
                scope: $scope,
                templateUrl: 'app/Project/Modal.html',
                backdrop: 'static',
                controller: function($scope, $modalInstance) {
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

                    $modalInstance.result.then(function(newProject) {
                        Project.save(newProject, function(newAddedProject) {
                            $scope.projects.push(newAddedProject);
                        });
                    });
                }
            });
        }
    }
);