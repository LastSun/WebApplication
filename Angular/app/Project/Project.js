'use strict';

angular.module('eLearning').controller('ProjectCtrl', function($scope, $modal, $resource) {
        var Project = $resource('api/project/:id');
        $scope.displayPerPage = 10;
        $scope.testData = '10';
        $scope.dataItems = [{ Id: 3 }, { Id: 4 }];
        $scope.projects = Project.query(function (data) {
            $scope.sourceProject = data;
            $scope.displayedProject = [].concat($scope.sourceProject);
        });

        //$scope.selectAll = function(isSelecte) {
        //    angular.forEach($scope.displayedProject, function(project) {
        //        project.isSelected = isSelecte;
        //    });
        //}

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

        $scope.delete = function() {
            $modal.open({
                scope: $scope,
                templateUrl: 'app/Project/ConfirmModal.html',
                backdrop: 'static',
                controller: function($scope, $modalInstance) {

                    $scope.ok = function() {
                        $modalInstance.close();
                    }

                    $scope.cancel = function() {
                        $modalInstance.dismiss('cancel');
                    };

                    $modalInstance.result.then(function(result) {
                        var a = result;
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