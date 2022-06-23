function Checkout() {
    console.log("click");
    var totalitem = parseInt(document.getElementById('totalitem').value);
    var listData = [];
    for (let i = 0; i < totalitem; i++) {
        var OrderItemId = parseInt(document.getElementById('OrderItemId_' + i).value);
        var Quantity = parseFloat(document.getElementById('quantity_' + i).value);
        listData[i] = { OrderItemId: OrderItemId, Quantity: Quantity };

    };
    if (listData.length > 0) {
        $.ajax({
            
            type: "POST",
            url: "/Cart/UpdatetoOrderItem",
            data: { checkout: listData },
            success: function (data) {
                console.log(data);

                if (data.result === true) {
                    window.location.href = data.ReturnURL;

                }
                else {
                    ShowNoti(false, "Checkout Failed, please try again");
                }
            },
        });
    }
    else {
        alert("Your cart is empty");
    }

};