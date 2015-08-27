'use strict';

angular.module('eLearning').controller('UserCtrl', function($scope) {
        $scope.itemsPerPage = 1;
        $scope.triggerEditData = function(user) {
            $scope.editData('app/User/UserModal.html', user, { Project: {} });
        }
    }
);