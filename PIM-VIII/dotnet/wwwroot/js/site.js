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
