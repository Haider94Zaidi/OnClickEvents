$("document").ready(function () {



	$("#terms").click(function () {

		if (!$("#terms").is(':checked')) {
			$("#registerbtn").attr('disabled', true);
		}
		if ($("#terms").is(':checked')) {
			$("#registerbtn").attr('disabled', false);
		}
	});

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