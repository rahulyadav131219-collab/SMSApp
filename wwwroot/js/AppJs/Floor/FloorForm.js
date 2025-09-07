var _FloorForm = null;
var mFlrAdmnId;

app.controller('FloorFormCtrl', function ($scope, $http) {

	_FloorForm = $scope;

	$scope.FloorAdminList = [];
	$scope.FloorAdminId = "0";

	var mFloorAdminId = $("#txtFloorAdminId").val();

	if (mFloorAdminId != undefined & mFloorAdminId != null) {
		$scope.FloorAdminId = mFloorAdminId;
	}

	$scope.GetAllFloorAdmin = function () {

		$http.post("/Floor/GetAllFloorAdminList",
			{
			}
		).then(function (resp) {

			var mData = JSON.parse(resp.data);

			$scope.FloorAdminList = mData.Table;

		}, function (data) {
		});
	}

	$scope.GetAllFloorAdmin();

	$scope.RedirectUserToEdit = function (vId) {
		window.location.href = "/User/Edit/" + vId;
	}

});

function SaveFloor() {

	$("#txtFloorAdmId").val(_FloorForm.FloorAdminId);

	return true;
}

function OnFlrAdmnSel() {
	mFlrAdmnId = $("#ddlFloorAdmin option:selected").val().split(':')[1];
}
