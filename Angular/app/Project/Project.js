'use strict';

angular.module('eLearning').controller('ProjectCtrl', function($scope, $modal, $resource, ngTableParams) {
        var Project = $resource('api/project/:id');

        $scope.rowCollection = [
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Laurent', lastName: 'Renard', birthDate: new Date('1987-05-21'), balance: 102, email: 'whatever@gmail.com' },
            { firstName: 'Blandine', lastName: 'Faivre', birthDate: new Date('1987-04-25'), balance: -2323.22, email: 'oufblandou@gmail.com' },
            { firstName: 'Francoise', lastName: 'Frere', birthDate: new Date('1955-08-27'), balance: 42343, email: 'raymondef@gmail.com' }
        ];

        var data1 = [
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 19, name: 'asdf' },
            { id: 23, name: 'gsd' }
        ];
        $scope.tableParams = new ngTableParams({
            page: 1,
            count: 2
        }, {
            total: 20,
            data: data1
            //getData: function($defer, params) {
            //    $defer.resolve(data1.slice((params.page() - 1) * params.count(), params.page() * params.count()));
            //}
        });
        $scope.tableParams.reload();

        $scope.projects = Project.query(function(data) {
        });
        $scope.pageChanged = function() {
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