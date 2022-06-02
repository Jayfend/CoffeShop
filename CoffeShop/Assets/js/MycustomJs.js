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
    console.log("oldtotal", CurrentNotdiscountTotal);
    CurrentNotdiscountTotal = (CurrentNotdiscountTotal - oneitemnotdiscount) + newitemnotdiscount;
    console.log("old",oneitemnotdiscount);
    console.log("new", newitemnotdiscount);
    console.log("Newtotal", CurrentNotdiscountTotal);
    

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
    console.log(totalPrice);
    console.log(PhoneNumber);
    console.log(Address);
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
            url: "Base/Change",
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
