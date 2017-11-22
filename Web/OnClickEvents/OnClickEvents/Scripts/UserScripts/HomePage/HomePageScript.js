$("document").ready(function () {

	$("#cust_attempt_signin").click(function () {
		$("#customer-login-overlay").modal('show');
		//$("#vendsigninmodal").modal('hide');
	});

	$("#vend_attempt_signin").click(function () {
		$("#vendor-login-overlay").modal('show');
	});

});