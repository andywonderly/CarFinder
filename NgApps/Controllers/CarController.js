app.controller('ctrNewCar', ['$scope', 'svcNewCar', function ($scope, svcNewCar) {
    $scope.selectedYear = '';
    $scope.selectedMake = '';
    $scope.selectedModel = '';
    $scope.selectedTrim = '';

    $scope.years = [];
    $scope.makes = [];
    $scope.models = [];
    $scope.trims = [];
    $scope.imageUrl = '';

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

    $scope.getCarData = function () {
        svcNewCar.HCLGetCarData($scope.selectedYear, $scope.selectedMake, $scope.selectedModel, $scope.selectedTrim).then(function (data) {
            $scope.imageUrl = data.Images;
            
        });
    };

    $scope.getYears();
}])

app.controller('HomeController', ['$scope', 'svcNewCar', function ($scope, svcNewCar) {}])

app.controller('AboutController', ['$scope', 'svcNewCar', function ($scope, svcNewCar) {}])

app.controller('ContactController', ['$scope', 'svcNewCar', function ($scope, svcNewCar) {}])

app.controller('ApiHelpController', ['$scope', 'svcNewCar', function ($scope, svcNewCar) {}])