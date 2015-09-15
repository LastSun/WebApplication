'use strict';

angular.module('eLearning').directive('tablefunction', [
    '$modal','$resource',
    function ($modal, $resource) {
        return {
            scope: { resourceApi: '=', triggerEditData: '=', editData: '=', source: '=', displayedSource: '=', itemsPerPage: '=' },
            templateUrl: 'app/tableFunction.html',
            link: function (scope, element, attrs, ctrls) {
                scope.resourceBaseUrl = 'http://localhost:55893/';
                scope.resource = $resource(scope.resourceBaseUrl + scope.resourceApi);
                scope.resource.query(function (data) {
                    scope.source = data;
                    scope.displayedSource = [].concat(scope.source);
                });

                scope.selectAll = function(isSelect) {
                    angular.forEach(scope.source, function(project) {
                        project.isSelected = isSelect;
                    });
                }

                scope.editData = function (pModalPath, pDataItem, pNewDataItem) {
                    var tempDataItem = pDataItem || pNewDataItem;
                    tempDataItem.externalData = pNewDataItem.externalData;
                    tempDataItem.IsCreate = pDataItem == undefined;

                    $modal.open({
                        scope: scope,
                        templateUrl: pModalPath,
                        backdrop: 'static',
                        resolve: {
                            dataItem: function () { return tempDataItem; }
                        },
                        controller: function($scope, $modalInstance, dataItem) {
                            $scope.dataItem = dataItem;
                            $scope.submitForm = function () { $modalInstance.close($scope.dataItem); }
                            $scope.cancel = function() { $modalInstance.dismiss(); };
                        }
                    }).result.then(function(resultDataItem) {
                        if (resultDataItem.IsCreate) {
                            scope.resource.save(resultDataItem, function (createdDataItem) {
                                scope.source.push(createdDataItem);
                            });
                        } else {
                            scope.resource.save(resultDataItem, function (updatedDataItem) {
                                angular.forEach(scope.source, function (dataItem) {
                                    if (dataItem.Id === updatedDataItem.Id) {
                                        dataItem.isSelected = false;
                                    }
                                });
                            });
                        };
                    });
                }

                scope.deleteData = function () {
                    $modal.open({
                        scope: scope,
                        templateUrl: 'app/confirmModal.html',
                        controller: function ($scope, $modalInstance) {
                            $scope.ok = function () { $modalInstance.close(); }
                            $scope.cancel = function () { $modalInstance.dismiss(); };
                        }
                    }).result.then(function () {
                        angular.forEach(scope.source, function (dataItem, key) {
                            if (dataItem.isSelected) {
                                scope.resource.remove({ id: dataItem.Id }, function () {
                                    scope.source.splice(key, 1);
                                });
                            }
                        });
                    });
                }

                scope.exportData = function () {
                    var a = 1;
                }
            }
        }
    }
]);