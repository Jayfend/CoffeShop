
function SignUpAdmin() {
 
    console.log("click");
    var username = document.getElementById("adminname").value;
    var password = document.getElementById('adminpassword').value;
    var repassword = document.getElementById('adminrepassword').value;
    var email = document.getElementById('adminemail').value;
    
    var accountviewmodel = { UserName: username, Password: password, Email: email, ConfirmPassword: repassword };
    console.log(accountviewmodel);

    $.ajax({
        type: "POST",
        url: "/BasicElement/AdminSignUp",
        data: { account: accountviewmodel },
        success: function (data) {
            console.log(data.result);

            if (data.result === true) {
                ShowNoti(true, "Register Successfully");

            }
            else {
                ShowNoti(false, "Email or Username already Existed");
            }
        },
    });
}
function LogOut() {
    window.location.href="/Login/Logout"
}