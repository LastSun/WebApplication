'use strict';

angular.module('eLearning').controller('UserCtrl', function($scope, $resource) {
        $resource('api/Project/:id').query(function(data) {
            $scope.projects = data;
        });
        $scope.itemsPerPage = 1;
        $scope.triggerEditData = function(user) {
            $scope.editData('app/User/UserModal.html', user, { Project: {}, Projects: $scope.projects });
        }
    }
);