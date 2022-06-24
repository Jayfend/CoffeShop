
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
function ShowNoti(Case, message) {
    document.querySelector(".text-2").innerHTML = message;
    if (Case == true) {
        document.querySelector(".text-1").innerHTML = "Success";
        document.getElementById("checkNoti").style.backgroundColor = '#c79c60';
        document.getElementById("progress").style.backgroundColor = '#c79c60';
        document.getElementById("toast").style.borderColor = "#c79c60";
        toast.classList.add("active");
        progress.classList.add("active");

    }
    else if (Case === false) {
        document.querySelector(".text-1").innerHTML = "Error";
        document.getElementById("checkNoti").style.backgroundColor = '#F15412';
        document.getElementById("progress").style.backgroundColor = '#F15412';
        document.getElementById("toast").style.borderColor = "#F15412";
        toast.classList.add("active");
        progress.classList.add("active");
    }
    timer1 = setTimeout(() => {

        toast.classList.remove("active");

    }, 3000);

    timer2 = setTimeout(() => {

        progress.classList.remove("active");
    }, 3000);
   
    
}
