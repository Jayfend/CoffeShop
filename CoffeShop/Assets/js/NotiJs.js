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