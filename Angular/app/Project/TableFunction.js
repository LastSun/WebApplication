'use strict';

angular.module('eLearning').directive('tablefunction', [
    '$modal',
    function($modal) {
        return {
            scope: { source: '=', itemsPerPage: '=',testObject:'=', triggerCreateData:'&', executeCreate: '=', executeEdit: '&', executeDelete: '&', executeExport: '&' },
            templateUrl: 'app/Project/TableFunction.html',
            link: function(scope, element, attrs, ctrls) {
                scope.selectAll = function(isSelect) {
                    angular.forEach(scope.source, function(project) {
                        project.isSelected = isSelect;
                    });
                }

                scope.deleteData = function() {
                    $modal.open({
                        scope: scope,
                        templateUrl: 'app/Project/ConfirmModal.html',
                        controller: function($scope, $modalInstance) {
                            $scope.ok = function() { $modalInstance.close(true); }
                            $scope.cancel = function() { $modalInstance.dismiss('cancel'); };
                        }
                    }).result.then(function(result) {
                        scope.executeDelete();
                    });
                }

                scope.testObject= function() {
                    var a = 1;
                }

                scope.testObject.fun = function (pModalPath, pDataItem) {
                    $modal.open({
                        scope: scope,
                        templateUrl: pModalPath,
                        backdrop: 'static',
                        resolve: {
                            dataItem: function() { return pDataItem; }
                        },
                        controller: function ($scope, $modalInstance, dataItem) {
                            $scope.dataItem = dataItem;
                            $scope.submitForm = function () {
                                dataItem.isCreate = true;
                                $modalInstance.close(dataItem);
                            }
                            $scope.cancel = function() { $modalInstance.dismiss('cancel'); };
                        }
                    }).result.then(function(resultDataItem) {
                        resultDataItem.isCreate ? scope.executeCreate(resultDataItem) : scope.executeEdit(resultDataItem);
                    });
                }
            }
        }
    }
]);