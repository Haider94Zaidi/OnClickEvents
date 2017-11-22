$("document").ready(function () {



	$("#terms").click(function () {

		if (!$("#terms").is(':checked')) {
			$("#registerbtn").attr('disabled', true);
		}
		if ($("#terms").is(':checked')) {
			$("#registerbtn").attr('disabled', false);
		}
	});

	$("#continuebtn").click(function () {
		$("#successModal").modal('hide');
		window.location.href = "/Home/Index";
	});

	/***  
	*
	* Vendor Registration
	*
	*/
	$("#registervendorbtn").click(function () {
		
			
			var contact = $("#ven_contact").val();
			var contact_len = $("#ven_contact").val().length;

			var name = $("#ven_name").val();
			var email = $("#ven_email").val();
			var pass = $("#ven_pwd").val();
			var repeatpass = $("#ven_repwd").val();
			var address = $("#ven_address").val();

			var cnic = $("#ven_cnic").val();
			var cnic_len = $("#ven_cnic").val().length;

			var account = $("#ven_account").val();
			var account_len = $("#ven_account").val().length;

			if (name != "") {
				if (email != "") {
					if (pass == repeatpass && pass != "" && repeatpass != "") {
						if (address != "") {
							if (contact != "" && contact_len == 11) {
								if (cnic != "" && cnic_len != 12) {
									if (account != "" && account_len != 23) {
										
										$.ajax({
											type: 'POST',
											contentType: "application/json; charset=utf-8",
											dataType: 'json',
											url: '../Registration/vendorRegister',
											data: "{'Name': '" + name + "','Email': '" + email + "','Password': '" + pass + "','Address': '" + address + "','Contact': '" + contact + "','Cnic': '" + cnic + "','Account': '" + account + "'}",
											success: function (data) {
												if (data == "success") {
													$("#VendorModal").modal('hide');
													$("#successModal").modal('show');
												}
												else {
													alert("There is some problem in registering you");
												}
											},
											error: function (data) {
												alert(data);
											}

										});
									}
									else {
										$("#errormsg").text("Invalid Account");
									}
								}
								else {
									$("#errormsg").text("Invalid CNIC");
								}
							}

							else {
								$("#errormsg").text("Invalid Contact");
							}
						}
						else {
							$("#errormsg").text("Invalid Address");
						}
						
					}
					else {
						$("#errormsg").text("Passwords are not same");
					}
				}
				else {
					$("#errormsg").text("Email is not valid");
				}
			}
			else {
				$("#errormsg").text("Name is Empty");
				return;
			}
		});
	

	/***  
	*
	* customer Registration
	*
	*/
	$("#registerbtn").click(function () {

		var contact = $("#contact").val();
		var len = $("#contact").val().length;
		var name = $("#name").val();
		var email = $("#email").val();
		var pass = $("#pass").val();
		var repeatpass = $("#repeatpass").val();
		var date;
		var day = $("#day option:selected").val();
		var month = $("#month option:selected").val();
		var year = $("#year option:selected").val();
		if (name != "") {
			if (email != "") {
				if (pass == repeatpass && pass != "" && repeatpass != "") {
					if (contact != "" && len == 11) {
						if (day != "dd" && month != "mm" && year != "yyyy") {
							$(".loader").css("visibility", "visible");
							date = day + "-" + month + "-" + year;

							$.ajax({
								type: 'POST',
								contentType: "application/json; charset=utf-8",
								dataType: 'json',
								url: '../Registration/Registering',
								data: "{'Name': '" + name + "','Email': '" + email + "','Password': '" + pass + "','DOB': '" + date + "','Contact': '" + contact + "'}",
								success: function (data) {
									alert(data);
									$(".loader").css("visibility", "hidden");
								},
								error: function (data) {
									alert(data);
								}

							});
						}
						else {
							alert("Invalid D-O-B");
						}
					}
					else {
						alert("Invalid Contact");
					}
				}
				else {
					alert("Password are not same");
				}
			}
			else {
				alert("Email is not valid");
			}
		}
		else {
			alert("Name is Empty");
			return;
		}
	});

	/***  
	*
	* customer Sign In
	*
	*/
	$("#signinbtn").click(function () {

		var email = $("#signin_email").val();
		var pwd = $("#signin_password").val();

		if (email != "" && pwd != "") {

			$.ajax({
				type: 'POST',
				contentType: "application/json; charset=utf-8",
				dataType: 'json',
				url: '../Registration/Signin',
				data: "{'Email': '" + email + "','Pwd': '" + pwd + "'}",
				success: function (data) {
					alert(data);
				}
				

			});
		}
		else {
			alert("Fields cannot be empty");
		}

	});


});