$("#PayBtn").click(function () {
    var totalPrice = parseFloat(document.getElementById('totalPrice').innerHTML);
    var PhoneNumber = document.getElementById('Phone-Number').value;
    var Address = document.getElementById('Address').value;
    var Name = document.getElementById('Full-Name').value;

    var listData = { TotalPrice: totalPrice, PhoneNumber: PhoneNumber, Address: Address, Name: Name };

    if (totalPrice == 0 || PhoneNumber.length === 0 || Address.length === 0 || Name.length === 0) {
        ShowNoti(false, "Failed to pay !");
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Payment/CreateBill",
            data: { bill: listData },
            success: function (data) {

                if (data.result === true) {
                    ShowNoti(true, "Thank you for buying!");
                    
                    timeRefresh_Payment(1000);
                }
                else {
                    ShowNoti(false, "Something went wrong!");
                }
            },
        });
    }
});

$(function () {
    $('#proceedform').submit(function (e) {
        e.preventDefault();
    });
})
//$(function () {
//    $('#PayBtn').submit(function (e) {
//        e.preventDefault();
//    });
//})

function timeRefresh_Payment(time) {
    setTimeout("window.location.assign('/')", time);
}