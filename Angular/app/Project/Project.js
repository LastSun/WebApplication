'use strict';

angular.module('eLearning').controller('ProjectCtrl', function($scope) {
        $scope.itemsPerPage = 1;
        $scope.triggerEditData = function (project) {
            $scope.editData('app/project/projectModal.html', project, { Name: '' });
        }
    }
);