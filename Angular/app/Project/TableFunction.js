'use strict';

angular.module('eLearning')
    .controller('tablefunctionController', ['$scope',
        function ($scope) {
            //$scope.dataItems = [{ Id: 1 }, { Id: 2 }];
            $scope.exportData = function (dataItems) {
                var a = dataItems;
            }
        }
    ])
    .directive('tablefunction', [
        function() {
            return {
                restrict: 'EA',
                replace: true,
                templateUrl: 'app/Project/TableFunction.html',
                controller: 'tablefunctionController',
                link: function (scope, element, attrs, ctrls) {
                    var dataSource = [];
                    var unWatchDataSource = scope.$watch('displayedProject', function (result) {
                        if (result) {
                            dataSource = result;
                        }
                    });
                    scope.selectAll = function (isSelecte) {
                        angular.forEach(dataSource, function (project) {
                            project.isSelected = isSelecte;
                        });
                    }
                }
            }
        }
    ]);