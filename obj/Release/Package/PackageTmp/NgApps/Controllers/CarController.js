app.controller('ctrNewCar', ['$scope', 'svcNewCar', function ($scope, svcNewCar) {
    $scope.selectedYear = '';
    $scope.selectedMake = '';
    $scope.selectedModel = '';
    //$scope.selectedTrim = '';

    $scope.years = [];
    $scope.makes = [];
    $scope.models = [];
    $scope.trims = [];

    $scope.getYears = function () {
        svcNewCar.HCLYears().then(function (data) {
            $scope.years = data;
        });
    };

    $scope.getMakes = function () {
        svcNewCar.HCLMakes($scope.selectedYear).then(function (data) {
            $scope.makes = data;
        });
    };

    $scope.getModels = function () {
        svcNewCar.HCLModels($scope.selectedYear, $scope.selectedMake).then(function (data) {
            $scope.models = data;
        });
    };

    $scope.getTrims = function () {
        svcNewCar.HCLTrims($scope.selectedYear, $scope.selectedMake, $scope.selectedModel).then(function (data) {
            $scope.trims = data;
        });
    };

    $scope.getYears();
    $scope.getMakes();
    $scope.getModels();
}])