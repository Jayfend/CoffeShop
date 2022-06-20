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
    document.getElementById('totaldiscount').innerHTML = CurrentDiscountTotal.toString() ;
    document.getElementById('totaldiscountforone_' + i).value = newitemdiscount.toString();
   
    //totalnotdiscount
    var oneitemnotdiscount = parseFloat(document.getElementById('totalnotdiscountforone_' + i).value);
    var CurrentNotdiscountTotal = parseFloat(document.getElementById('totalnotdiscount').innerHTML);
    var newitemnotdiscount = itemPrice * itemquantity;
   
    CurrentNotdiscountTotal = (CurrentNotdiscountTotal - oneitemnotdiscount) + newitemnotdiscount;
   
    

    document.getElementById('totalnotdiscount').innerHTML = CurrentNotdiscountTotal.toString() ;
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
                    alert("Checkout Failed, please try again");
                }
            }
        });
    }
    else {
        alert("Your cart is empty");
    }
   
});
$("#ProceedBtn").click(function () {
    console.log("click");
    var totalPrice = parseFloat(document.getElementById('totalPrice').innerHTML);
    var PhoneNumber = document.getElementById('Phone-Number').value;
    var Address = document.getElementById('Address').value;
    var Name = document.getElementById('Full-Name').value;
   
    var listData = { TotalPrice: totalPrice, PhoneNumber: PhoneNumber, Address: Address, Name: Name };
    console.log(listData);
    if (totalPrice == 0 || PhoneNumber.length === 0 || Address.length === 0 || Name.length === 0) {
        alert("Please fill all information");
    }
    else {
        $.post("/Payment/CreateBill", { bill: listData }, function (data) {
            if (data) {
                console.log(data);
                if (data.Result == true) {
                    alert(data.Message);
                }
                else {
                    alert(data.Message);
                }
            }
        });
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
                    alert(data.Message);
                    location.reload();
                }
                else {
                    alert(data.Message);
                }
            }
        });
    }
    else {
        alert("Your cart is empty");
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
                var a =JSON.parse(data);
                if (a.result === true) {
                    console.log(data);
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
                console.log(data);
                
                
                 $("#Cart").html(data);
                    


            }

        });
}

const button = document.querySelectorAll(".tm-product-price")
    button2 = document.querySelectorAll(".order-now-container"),
    toast = document.querySelector(".toast"),
closeIcon = document.querySelector(".close"),
    progress = document.querySelector(".progress");
let timer1, timer2;
button.forEach(item => {
    item.addEventListener("click", () => {
        console.log("click");
        
        timer1 = setTimeout(() => {
            
            toast.classList.remove("active");
            
        }, 3000); 
       
        timer2 = setTimeout(() => {
            
            progress.classList.remove("active");
        }, 3000);

    });
});
button2.forEach(item => {
    item.addEventListener("click", () => {
        console.log("click");

        timer1 = setTimeout(() => {

            toast.classList.remove("active");

        }, 3000);

        timer2 = setTimeout(() => {

            progress.classList.remove("active");
        }, 3000);

    });
});
closeIcon.addEventListener("click", () => {
    toast.classList.remove("active");

    setTimeout(() => {
        progress.classList.remove("active");
       
    }, 300);

    clearTimeout(timer1);
    clearTimeout(timer2);

});
function AddCart(Id) {
   
    $.ajax
        ({
            type: "GET",
            url: "/Menu/UpdateToCart",
            data: { ProductId: Id },
            dataType: "text",
            success: function (data) {

                $("#Cart").html(data);
               
                toast.classList.add("active");
                progress.classList.add("active");
              

              

            }

        });
}
function AddCartTS(Id) {
    console.log("clicked");
    $.ajax
        ({
            type: "GET",
            url: "/TodaySpecials/UpdateToCart",
            data: { ProductId: Id },
            dataType: "text",
            success: function (data) {
               
                $("#Cart").html(data);
                toast.classList.add("active");
                progress.classList.add("active");
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
                console.log(data);
               
                if (data.result === true) {
                    alert("Register Successfully");

                }
                else {
                    alert("Email or UserName already existed");
                }
            },
        });
    
}

$(function(){
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
                alert(data.message);
            }
        },
    });

}
function ContactSend() {
    $('#contactform').validate();
    if (!$('#contactform').valid()) {
        return;
    }
    console.log("click");
    var name = document.getElementById('contact_name').value;
    var subject = document.getElementById('contact_subject').value;
    var text = document.getElementById('contact_message').value;
    var email = document.getElementById('contact_email').value;
    var contactviewmodel = { Name:name,Email: email,Subject: subject, Message:text };
    console.log(contactviewmodel);

    $.ajax({
        type: "POST",
        url: "/Contact/Reviews",
        data: { review: contactviewmodel },
        success: function (data) {
            if (data.Result == true) {
                console.log("True");
 
                alert("Your review has been sent");

            }
            else {
                alert("Couldn't send your review");
            }
        },
    });

}
