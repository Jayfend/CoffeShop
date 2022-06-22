
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