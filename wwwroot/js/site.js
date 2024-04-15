// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
document.addEventListener('DOMContentLoaded',function (){
   const autorButton = document.getElementById("auth-button");
   if(autorButton){
       autorButton.addEventListener('click',authButtonClick);
   }
    initAdminPage();
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

////////// ADMIN-PAge
function initAdminPage(){
    loadCategories();
}
function loadCategories(){
    const container =document.getElementById("category-container");
    if(!container){
        throw "Element category-container not found!"
    }
    fetch("/api/category") // запитуємо наявні категоріі
        .then(r=>r.json())
        .then(j=>{
            let html ="";
            for (let ctg of j) {
                html += "<p>" + ctg["name"] + "</p>";
            }
            html += `Назва: <input id="ctg-name" /><br/>
            Опис: <textarea id="ctg-description"></textarea><br/>
            <button onclick='addCategory()'>Add</button>`;
            container.innerHTML = html;
        })
}
function loadLocation(){
    const container = document.getElementById()
}
function addCategory(){
   const ctgName = document.getElementById("ctg-name").value;
   const ctgDescription = document.getElementById("ctg-description").value;
   if( confirm(`Додаємо категорію ${ctgName} ${ctgDescription} ?`)){
       fetch("/api/category",{method:'POST',
           headers:{'Content-Type':'application/json'},
           body:JSON.stringify({'name':ctgName,
               'description':ctgDescription})
       }).then(r=>{
           if(r.status==201){
               loadCategories();
           }
           else {
               alert('Error!');
           }
           console.log(r)
       });
           
      // alert('ok');
   }
  
}