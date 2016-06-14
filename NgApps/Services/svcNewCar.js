app.service('svcNewCar', ['$http', function($http) {
    this.HCLYears = function () {
        return $http.get('/api/Cars/Years')
            .then(function (response) {return response.data; });
    };

    this.HCLMakes = function (model_year) {
        var options = { params: { model_year: model_year } };
        return $http.get('/api/Cars/YearMakes', options)
            .then(function (response) { return response.data; });
    };

    this.HCLModels = function (model_year, make) {
        var options = { params: { model_year: model_year, make: make } };
        return $http.get('/api/Cars/YearMakeModels', options)
            .then(function (response) { return response.data; });
    };

    this.HCLTrims = function (model_year, make, model_name) {
        var options = { params: { model_year: model_year, make: make, model_name: model_name } };
        return $http.get('/api/Cars/YearMakeModelTrims', options)
            .then(function (response) { return response.data; });
    };

    this.HCLGetCarData = function (model_year, make, model_name, model_trim) {
        var options = { params: { model_year: model_year, make: make, model_name: model_name, model_trim: model_trim } };
        return $http.get('/api/Cars/GetCarData', options)
            .then(function (response) { return response.data; });
    }

}]);