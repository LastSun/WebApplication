'use strict';

angular.module('eLearning').controller('ProjectCtrl', function($scope, $modal, $resource) {
        var Project = $resource('api/project/:id');
        $scope.itemsPerPage = 10;

        $scope.projects = Project.query(function(data) {
            $scope.sourceProject = data;
            $scope.displayedProject = [].concat($scope.sourceProject);
        });

        $scope.executeDelete = function() {
            var a = 1;
        }

        $scope.executeExport = function() {
            var a = 1;
        }

        $scope.executeCreate = function(createdProject) {
            var a = createdProject;
        }

        $scope.executeEdit= function(editedProject) {
            var a = editedProject;
        }

        //$scope.testObject={}
        $scope.triggerCreateData = function () {
            $scope.testObject();
            $scope.testObject.fun('app/Project/ProjectModal.html', {Name:'SDF'});
        }

        $scope.edit = function(editProject) {
            $modal.open({
                scope: $scope,
                templateUrl: 'app/Project/Modal.html',
                resolve: {
                    project: function() {
                        return editProject;
                    }
                },
                controller: function($scope, $modalInstance, project) {
                    $scope.newProject = project;

                    $scope.submitForm = function(isValid) {
                        if (isValid) {
                            $modalInstance.close($scope.newProject);
                        }
                    }

                    $scope.cancel = function() {
                        $modalInstance.dismiss('cancel');
                    };

                    $modalInstance.result.then(function(newProject) {

                    });
                }
            });
        }

        $scope.open = function() {
            $modal.open({
                scope: $scope,
                templateUrl: 'app/Project/Modal.html',
                backdrop: 'static',
                controller: function($scope, $modalInstance) {
                    $scope.newProject = {
                        Name: ''
                    };

                    $scope.submitForm = function(isValid) {
                        if (isValid) {
                            $modalInstance.close($scope.newProject);
                        }
                    }

                    $scope.cancel = function() {
                        $modalInstance.dismiss('cancel');
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