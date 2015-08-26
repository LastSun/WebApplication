'use strict';

angular.module('eLearning').controller('ProjectCtrl', function($scope, $modal, $resource) {
        var Project = $resource('api/project/:id');
        $scope.itemsPerPage = 10;

        Project.query(function(data) {
            $scope.sourceProject = data;
            $scope.displayedProject = [].concat($scope.sourceProject);
        });

        $scope.executeDelete = function () {
            angular.forEach($scope.sourceProject, function(deleteProject, key) {
                if (deleteProject.isSelected) {
                    Project.delete({ id: deleteProject.Id }, function() {
                        $scope.sourceProject.splice(key, 1);
                    });
                }
            });
        }

        $scope.executeExport = function() {
            var a = 1;
        }

        $scope.executeCreate = function(createProject) {
            Project.save(createProject, function (createdProject) {
                $scope.sourceProject.push(createdProject);
            });
        }

        $scope.executeEdit = function(editProject) {
            Project.save(editProject, function (editedProject) {
                angular.forEach($scope.sourceProject, function(project) {
                    if (project.Id === editedProject.Id) {
                        project.isSelected = false;
                    }
                });
            });
        }

        $scope.triggerModal = function(project) {
            var dataItem = project || { Name: '' };
            dataItem.IsCreate = project == undefined;
            $scope.openModal('app/Project/ProjectModal.html', dataItem);
        }
    }
);