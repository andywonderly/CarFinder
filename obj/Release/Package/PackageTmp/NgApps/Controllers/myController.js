app.controller('myController', [function () {
    var vm = this;
    vm.model = {
        firstname: 'Jack',
        lastname: 'Smith',
    };
    vm.message = 'loves cheese';
    vm.click = function () {
        vm.message = 'is a winner!';
    };
}]);

app.controller('ctrAppCar', [function () {
    var vm = this;
    vm.model = {
        firstname: 'Jack',
        lastname: 'Smith',
    };
    vm.message = 'loves cheese';
    vm.click = function () {
        vm.message = 'is a winner!';
    };
}]);

