
function AddCart(Id) {

    $.ajax
        ({
            type: "GET",
            url: "/Menu/UpdateToCart",
            data: { ProductId: Id },
            dataType: "text",
            success: function (data) {

                $("#Cart").html(data);
                ShowNoti(true, "Your Drink has been added!");
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
                ShowNoti(true, "Your Drink has been added!");
            }

        });
}