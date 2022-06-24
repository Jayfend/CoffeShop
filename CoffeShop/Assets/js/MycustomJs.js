function calPrice(i) {

    var CurrentTotal = parseFloat(document.getElementById('total').innerHTML);
    var itemquantity = parseFloat(document.getElementById('quantity_' + i).value);
    var oneitemprice = parseFloat(document.getElementById('totalitemforone_' + i).value);
    var itemPrice = parseFloat(document.getElementById('Price_' + i).innerHTML);
    var itemDiscount = parseFloat(document.getElementById('Discount_' + i).innerHTML);
    var newitemprice = (itemPrice - (itemPrice * itemDiscount / 100)) * itemquantity;
    CurrentTotal = (CurrentTotal - oneitemprice) + newitemprice;
    var oneitemdiscount = parseFloat(document.getElementById('totaldiscountforone_' + i).value);
    var CurrentDiscountTotal = parseFloat(document.getElementById('totaldiscount').innerHTML)
    var newitemdiscount = (itemPrice * itemDiscount / 100) * itemquantity;
    CurrentDiscountTotal = (CurrentDiscountTotal - oneitemdiscount) + newitemdiscount;
    document.getElementById('total').innerHTML = CurrentTotal.toString();
    document.getElementById('totalitemforone_' + i).value = newitemprice.toString();
    document.getElementById('totaldiscount').innerHTML = CurrentDiscountTotal.toString();
    document.getElementById('totaldiscountforone_' + i).value = newitemdiscount.toString();

    //totalnotdiscount
    var oneitemnotdiscount = parseFloat(document.getElementById('totalnotdiscountforone_' + i).value);
    var CurrentNotdiscountTotal = parseFloat(document.getElementById('totalnotdiscount').innerHTML);
    var newitemnotdiscount = itemPrice * itemquantity;

    CurrentNotdiscountTotal = (CurrentNotdiscountTotal - oneitemnotdiscount) + newitemnotdiscount;

    document.getElementById('totalnotdiscount').innerHTML = CurrentNotdiscountTotal.toString();
    document.getElementById('totalnotdiscountforone_' + i).value = newitemnotdiscount.toString();
}


$("#SubmitBtn").click(function () {
    console.log("click");
    var totalitem = parseInt(document.getElementById('totalitem').value);
    var listData = [];
    for (let i = 0; i < totalitem; i++) {
        var OrderItemId = parseInt(document.getElementById('OrderItemId_' + i).value);
        var Quantity = parseFloat(document.getElementById('quantity_' + i).value);
        listData[i] = { OrderItemId: OrderItemId, Quantity: Quantity };

    }
    console.log(listData);
    if (listData.length > 0) {
        $.post("/Cart/UpdatetoOrderItem", { checkout: listData }, function (data) {
            if (data) {
                console.log(data);
                if (data.Result == true) {
                    window.location.href = data.ReturnURL;
                }
                else {
                    ShowNoti(false, "Checkout Failed, please try again");
                }
            }
        });
    }
    else {
        ShowNoti(false, "Your cart is empty");
    }

});

function check() {
    var password = document.getElementById('signup-password').value;
    var repassword = document.getElementById('signup-repassword').value;
    if (password == repassword) {

        document.getElementById('confirmpassword-message').style.color = 'green';
        document.getElementById('confirmpassword-message').innerHTML = 'Password matching';
        document.getElementById('SignUpBtn').disabled = false;
    }
    else {

        document.getElementById('confirmpassword-message').style.color = 'red';
        document.getElementById('confirmpassword-message').innerHTML = 'Password not match';
        document.getElementById('SignUpBtn').disabled = true;
    }
}

$("#SaveBtn").click(function () {
    console.log("click");
    var totalitem = parseInt(document.getElementById('totalitem').value);
    var listData = [];
    for (let i = 0; i < totalitem; i++) {
        var OrderItemId = parseInt(document.getElementById('OrderItemId_' + i).value);
        var Quantity = parseFloat(document.getElementById('quantity_' + i).value);
        listData[i] = { OrderItemId: OrderItemId, Quantity: Quantity };

    }
    console.log(listData);
    if (listData.length > 0) {
        $.post("/Cart/Save", { checkout: listData }, function (data) {
            if (data) {
                console.log(data);
                if (data.Result == true) {
                    ShowNoti(true, "Save Successfully!");
                    /*location.reload();*/
                }
                else {
                    ShowNoti(false, "Save Failed!");
                }
            }
        });
    }
    else {
        ShowNoti(false, "Your cart is empty");
    }

});

function LanguageGet(LanguageAbbrevation) {
    $.ajax
        ({
            type: "GET",
            url: "/Base/Change",
            data: { LanguageAbbrevation },
            dataType: "text",
            success: function (data) {
                console.log(data);
               
                if (data.result === true) {
                    
                    location.reload();
                }
            }
        });
}
function CartDelete(Id) {
    $.ajax
        ({
            type: "GET",
            url: "/Base/DeleteItem",
            data: { OrderItemId: Id },
            dataType: "text",
            success: function (data) {
                $("#Cart").html(data);
            }
        });
}


function SignUp() {
    $('#signupForm').validate();
    if (!$('#signupForm').valid()) {
        return;
    }
    console.log("click");
    var username = document.getElementById('signup-user').value;
    var password = document.getElementById('signup-password').value;
    var repassword = document.getElementById('signup-repassword').value;
    var email = document.getElementById('signup-mail').value;
    var accountviewmodel = { UserName: username, Password: password, Email: email, ConfirmPassword: repassword };
    console.log(accountviewmodel);

    $.ajax({
        type: "POST",
        url: "/Login/Register",
        data: { account: accountviewmodel },
        success: function (data) {
            if (data.result === true) {
                ShowNoti(true, "Register Successfully");
                timeRefresh_Login(2000);
            }
            else {
                ShowNoti(false, "Email or Username already Existed");
            }
        },
    });

}
function ChangePassword() {
    
    $('#forgotForm').validate();
    if (!$('#forgotForm').valid()) {
        return;
    }
    console.log("click");
    var password = document.getElementById('forgot-password').value;
    var repassword = document.getElementById('forgot-repassword').value;
    var email = document.getElementById('forgot-mail').value;
    var forgotpasswordviewmodel = { Email: email, Password: password, ConfirmPassword: repassword };
    

    $.ajax({
        type: "POST",
        url: "/ForgotPassword/ChangePassword",
        data: { user: forgotpasswordviewmodel },
        success: function (data) {
            console.log(data);

            if (data.result === true) {
                ShowNoti(true, "Changepassword successfully");

            }
            else {
                ShowNoti(false, "Email is not correct!");
            }
        },
    });
}
$(function () {
    $('#forgotForm').submit(function (e) {
        e.preventDefault();
    });
})

$(function () {
    $('#signupForm').submit(function (e) {
        e.preventDefault();
    });
})
$(function () {
    $('#signinForm').submit(function (e) {
        e.preventDefault();
    });
})
$(function () {
    $('#contactform').submit(function (e) {
        e.preventDefault();
    });
})
function SignIn() {
    $('#signinForm').validate();
    if (!$('#signinForm').valid()) {
        return;
    }
    console.log("click");
    var username = document.getElementById('signin-user').value;
    var password = document.getElementById('signin-password').value;

    var loginviewmodel = { UserName: username, Password: password };
    console.log(loginviewmodel);

    $.ajax({
        type: "POST",
        url: "/Login/Login",
        data: { account: loginviewmodel },
        success: function (data) {
            console.log(data);

            if (data.result === true) {
                window.location.href = data.message;
            }
            else {
                ShowNoti(false, "Username or Password not correct");
            }
        },
    });

}
function ContactSend() {
    $('#contactform').validate();
    if (!$('#contactform').valid()) {
        return;
    }
    var name = document.getElementById('contact_name').value;
    var subject = document.getElementById('contact_subject').value;
    var text = document.getElementById('contact_message').value;
    var email = document.getElementById('contact_email').value;
    var contactviewmodel = { Name: name, Email: email, Subject: subject, Message: text };

    $.ajax({
        type: "POST",
        url: "/Contact/Reviews",
        data: { review: contactviewmodel },
        success: function (data) {
            if (data.Result == true) {
                ShowNoti(true, "Your review has been sent");
                timeRefresh(1000);
            }
            else {
                ShowNoti(false, "Couldn't send your review");
            }
        },
    });

}

function timeRefresh(time) {
    setTimeout("location.reload(true);", time);
}

function timeRefresh_Login(time) {
    setTimeout("window.location.assign('/Login')", time);
}

