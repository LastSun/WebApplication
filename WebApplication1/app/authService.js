﻿'use strict';

app.factory('authService', ['$http', '$q', 'localStorageService',
    function ($http, $q, localStorageService) {
        var serviceBase = 'http://localhost:48752/';
        var authServiceFactory = {};
        var _authentication = {
            isAuth: false,
            userName: ""
        };

        var _saveRegistration= function(registration) {
            _logout();
            return $http.post(serviceBase + 'api/account', registration).then(function(response) {
                return response;
            });
        }

        var _login = function (loginData) {
            _logout();
            var data = "grant_type=password"
                + "&username=" + loginData.userName
                + "&password=" + loginData.password;
            var deferred = $q.defer();
            $http.post(serviceBase + 'oauth2/token', data, {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                    'Authorization': 'Basic RUJGRkE5NkUtRDczNy00RkNGLUIxMTUtQUY0NTIxNzlENjJGOkhleWtlcg=='
                }
            }).success(function(response) {
                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });
                _authentication.isAuth = true;
                _authentication.userName = loginData.userName;
                deferred.resolve(response);
            }).error(function(err, status) {
                _logout();
                deferred.reject(err);
            });
            return deferred.promise;
        }

        var _logout= function() {
            localStorageService.remove('authorizationData');
            _authentication.isAuth = false;
            _authentication.userName = "";
        }

        var _fillAuthData= function() {
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
            }
        }

        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logout = _logout;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentication = _authentication;
        return authServiceFactory;
    }
]);