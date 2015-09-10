'use strict';

angular.module('eLearning').controller('ClassCtrl', function ($scope, $resource) {
        //$scope.resourceBaseUrl = 'http://localhost:55893/';
        //$resource($scope.resourceBaseUrl + 'api/Project/:id').query(function (data) {
        //    $scope.projects = data;
        //});
        var d = $scope.sourceClass;
        $scope.itemsPerPage = 1;
        $scope.triggerEditData = function (editClass) {
            editClass.Projects = $scope.projects;
            $scope.editData('app/class/classModal.html', editClass, { Projects: $scope.projects });
        }
    }
);