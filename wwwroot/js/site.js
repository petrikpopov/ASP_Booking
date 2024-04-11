// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
document.addEventListener('DOMContentLoaded',function (){
   const autorButton = document.getElementById("auth-button");
   if(autorButton){
       autorButton.addEventListener('click',authButtonClick);
   }
});

function authButtonClick() {
    const authEmail = document.getElementById("auth-name");
    if(!authEmail){
        throw "Element auth-name not found!";
    }
    const alertErrorEmail = document.getElementById("auth-emailError");
    if(!alertErrorEmail){
        throw "Element auth-emailError not found!";
    }
    const alertErrorPassword = document.getElementById("auth-passwordError");
    if(!alertErrorPassword) {
        throw "Element auth-passwordError not found!";
    }
    const authPassword = document.getElementById("auth-password");
    if(!authPassword){
        throw "Element auth-password not found!";
    }
    const authMessage = document.getElementById("auth-message");
    if(!authMessage){
        throw "Element auth-message not found!";
    }
    const email = authEmail.value.trim();
    const password = authPassword.value.trim();
    if(!email){
        alertErrorEmail.classList.remove('visually-hidden');
        alertErrorEmail.innerText="Необхідно ввести Email!";
        return;
    }
    if(!password){
        alertErrorPassword.classList.remove('visually-hidden');
        alertErrorPassword.innerText="Необхідно ввести Password!";
        return;
    }
    else{
        alertErrorEmail.classList.add('visually-hidden');
        alertErrorPassword.classList.add('visually-hidden');
        
    }
    fetch(`/api/auth?email=${email}&password=${password}`).then(r=>{
        if(r.status!=200)
        {
            authMessage.classList.remove('visually-hidden');
            authMessage.innerText=" Вхід скасовано, перевірте введені данні!!";
        }
        else
        {
            window.location.reload();
        }
        console.log(r)});
}
