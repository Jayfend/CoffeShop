
toast = document.querySelector(".toast"),
closeIcon = document.querySelector(".close"),
progress = document.querySelector(".progress");
let timer1, timer2;
closeIcon.addEventListener("click", () => {
    toast.classList.remove("active");

    setTimeout(() => {
        progress.classList.remove("active");

    }, 300);

    clearTimeout(timer1);
    clearTimeout(timer2);

});
function ShowSuccess(message) {
    document.querySelector(".text-2").innerHTML = message;
    toast.classList.add("active");
    progress.classList.add("active");
    timer1 = setTimeout(() => {

        toast.classList.remove("active");

    }, 3000);

    timer2 = setTimeout(() => {

        progress.classList.remove("active");
    }, 3000);
    
}
function ShowError(message) {
    document.querySelector(".text-1") = "Error"
    document.querySelector(".text-2").innerHTML = message;
    document.getElementById("progress").style.color = red;
    toast.classList.add("active");
    progress.classList.add("active");
    timer1 = setTimeout(() => {

        toast.classList.remove("active");

    }, 3000);

    timer2 = setTimeout(() => {

        progress.classList.remove("active");
    }, 3000);
   
}