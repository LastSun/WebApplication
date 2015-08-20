'use strict';

angular.module('eLearning').controller('ProjectCtrl', [
    '$scope',
    function($scope, $modal) {
        $scope.project = {
            Id: 1,
            Name: 'Benz'
        };

        $scope.showModal = function() {
            $modal.open({
                templateUrl: 'app/Project/Modal.html',
                controller: 'ProjectCtrl'
            });
        };
    }
]);