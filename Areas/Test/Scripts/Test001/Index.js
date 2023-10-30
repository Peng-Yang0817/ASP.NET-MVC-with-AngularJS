var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http, $timeout) {

    $scope.keyword = "";
    $scope.message = 'Hello, AngularJS!';

    $scope.nameList = [];
    $scope.nameListCount = 0;

    console.log(getbaseURL());

    // 每當輸入值變更
    $scope.onKeywordChange = function () {
        // 向API 取得資訊
        $http.post(getbaseURL() + "/Test/Test001/GetKeywordData", { keyword: $scope.keyword }).then(
            function (response) {
                // response.status：HTTP 狀態代碼
                // response.statusText：HTTP 狀態代碼描述
                // response.headers：HTTP HEADER 內容
                // response.data：API 回應的真實數據
                $scope.nameList = response.data.ReturnObject;
                $scope.nameListCount = $scope.nameList.length;
                console.log($scope.nameListCount);
                console.log(response.ReturnObject)
            },
            function (error) {
                $scope.errorMessage = "發生錯誤：" + error.statusText;
            }
        );
    }

    // 取得當前網站基礎的URL
    function getbaseURL() {

        var currentURL = window.location.href;
        var url = new URL(currentURL);
        var baseURL = url.origin;

        return baseURL;
    }

});

