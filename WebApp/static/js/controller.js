function IndexCtrl($scope, $http) {

    $scope.model = {
        PassportNum: null,
        Nationality: null,
        DOB: {
            year: null,
            month: null,
            day: null
        },
        Exp: {
            year: null,
            month: null,
            day: null
        },
        Sex: null,
        Line: null
    };

    $scope.result = {};

    $scope.formsubmit = function () {
        var x = $scope.model;
        x.DOB.year = $scope.paddzero(x.DOB.year);
        x.DOB.month = $scope.paddzero(x.DOB.month);
        x.DOB.day = $scope.paddzero(x.DOB.day);

        x.Exp.year = $scope.paddzero(x.Exp.year);
        x.Exp.month = $scope.paddzero(x.Exp.month);
        x.Exp.day = $scope.paddzero(x.Exp.day);

        var o = {
            PassportNum: x.PassportNum,
            Nationality: x.Nationality,
            DOB: x.DOB.year + x.DOB.month + x.DOB.day,
            Sex: x.Sex,
            Exp: x.Exp.year + x.Exp.month + x.Exp.day
        };
        $http.post("https://apps.redtone.com/mrzapi/api/mrz/validate", o).success(function (data) {
            $scope.result = data;
            $scope.model.Line = data.Line;
        });
    }

    $scope.paddzero = function (a) {
        if (!$scope.isint(a))
            return a;

        var i = parseInt(a, 10);
        var s = i < 10 ? '0' + i : i;
        return s;
    }

    $scope.isint = function (value) {
        return !isNaN(value) &&
               !isNaN(parseInt(value, 10));
    }

    $scope.status = function (a) {
        var s = a == true ? 'pass' : 'fail';
        return s;
    }
}

app.controller('IndexCtrl', ['$scope', '$http', IndexCtrl]);
