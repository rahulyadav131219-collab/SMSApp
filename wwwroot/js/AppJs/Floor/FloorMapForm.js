var _FloorMapForm = null;
var mDeptId;

app.controller('FloorMapFormCtrl', function ($scope, $http) {

	_FloorMapForm = $scope;

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

	var mDeptId = $("#txtDeptId").val();

	if (mDeptId != undefined & mDeptId != null) {
		$scope.DeptId = mDeptId;
	}

	$scope.GetAllDepartment = function () {

		$http.post("/User/GetAllDepartment",
			{
			}
		).then(function (resp) {

			var mData = JSON.parse(resp.data);

			$scope.DeptList = mData.Table;

		}, function (data) {
		});
	}

	$scope.GetAllDepartment();

});

function SaveFloorMap() {
	$("#txtDeptId").val(mDeptId);
	return true;
}

function OnDeptSel() {
	mDeptId = $("#ddlDept option:selected").val().split(':')[1];
}
