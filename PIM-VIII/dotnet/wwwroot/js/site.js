// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//
//
const deletePessoaForm = document.getElementById("delete-pessoa");

deletePessoaForm.addEventListener("submit", function (e) {
  e.preventDefault();

  const formData = new FormData(this);

  const id = formData.get('id');

  fetch("/api/pessoa/"+id, {
    method: 'delete',

  }).then(function (response) {
    return response.text();
  }).then(function (text) {
    if(text != "") {
      window.location.assign("/");
    }
  })

});



  document.addEventListener('DOMContentLoaded', function () {
    const updatePessoaForm = document.getElementById("update-pessoa");

    if(!updatePessoaForm){
    updatePessoaForm.addEventListener("submit", function (e) {
      console.log("aaaaaaaaaaa")
      e.preventDefault();

      const formData = new FormData(this);

      var object = {};
      formData.forEach(function(value, key){
        object[key] = value;
      });
      var json = JSON.stringify(object);
      console.log(json)

      fetch("/api/pessoa/"+id, {
        method: 'PUT',
        body: json,

      }).then(function (response) {
        return response.text();
      }).then(function (text) {
        if(text != "") {
          window.location.assign("/");
        }
      })

    });
  }
});
  

