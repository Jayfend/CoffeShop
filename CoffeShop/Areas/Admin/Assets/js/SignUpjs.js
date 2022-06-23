
function SignUpAdmin() {
 
    console.log("click");
    var username = document.getElementById('signupadmin-user').value;
    var password = document.getElementById('signupadmin-password').value;
    var repassword = document.getElementById('signupadmin-repassword').value;
    var email = document.getElementById('signupadmin-mail').value;
    var accountviewmodel = { UserName: username, Password: password, Email: email, ConfirmPassword: repassword };
    console.log(accountviewmodel);

    $.ajax({
        type: "POST",
        url: "/Login/AdminSignUp",
        data: { account: accountviewmodel },
        success: function (data) {
            console.log(data);

            if (data.result === true) {
                alert("Register Successfully");

            }
            else {
                alert("Email or Username already Existed");
            }
        },
    });
}
function LogOut() {
    window.location.href="/Login/Logout"
}