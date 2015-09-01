'use strict';

angular.module('eLearning').controller('UserCtrl', function($scope, $resource) {
        $resource('api/Project/:id').query(function(data) {
            $scope.projects = data;
        });
        $resource('api/Class/:id').query(function (data) {
            $scope.allClasses = data;
        });
        $scope.itemsPerPage = 1;
        $scope.triggerEditData = function (user) {
            $scope.editData('app/user/userModal.html', user, { ExternalData: { Projects: $scope.projects, AllClass: $scope.allClasses } });
        }
    }
);