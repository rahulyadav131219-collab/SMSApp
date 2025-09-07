app.controller('SeatBookViewCtrl', function ($scope, $http) {

	$scope.SeatBookList = [];
	$scope.FloorList = [];
	$scope.FloorId = "0";

	$scope.GetAllFloor = function () {

		$http.post("/UserAccess/GetAllFloorList",
			{
			}
		).then(function (resp) {

			var mData = JSON.parse(resp.data);

			$scope.FloorList = mData.Table;

		}, function (data) {
		});
	}

	$scope.GetAllFloor();

	$scope.LoadSeatBookViewList = function () {

		$http.post("/SeatBook/ViewSeatBookList",
			{
			}
		).then(function (resp) {

			var mData = JSON.parse(resp.data);

			$scope.SeatBookList = mData.Table;

		}, function (data) {
		});
	}

	$scope.LoadSeatBookViewList();

	$scope.BookSeat = function () {

		var mFloorId = $scope.FloorId;

		window.location.href = "/Floor/EditMapFloor?id=" + mFloorId + "&vType=BS";

		return false;
	}

});