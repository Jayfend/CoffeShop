
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
        document.getElementById("checkNoti").style.backgroundColor = 'green';
        document.getElementById("progress").style.backgroundColor = 'green';
        document.getElementById("toast").style.borderColor = "green";
        toast.classList.add("active");
        progress.classList.add("active");

    }
    else if (Case === false) {
        document.querySelector(".text-1").innerHTML = "Error";
        document.getElementById("checkNoti").style.backgroundColor = 'red';
        document.getElementById("progress").style.backgroundColor = 'red';
        document.getElementById("toast").style.borderColor = "red";
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
