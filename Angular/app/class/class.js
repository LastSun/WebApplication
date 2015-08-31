'use strict';

angular.module('eLearning').controller('ClassCtrl', function($scope, $resource) {
        $resource('api/Project/:id').query(function(data) {
            $scope.projects = data;
        });
        var d = $scope.sourceClass;
        $scope.itemsPerPage = 1;
        $scope.triggerEditData = function(editClass) {
            $scope.editData('app/class/classModal.html', editClass, { Project: {}, Projects: $scope.projects });
        }
    }
);