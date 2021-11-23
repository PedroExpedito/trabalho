// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//
//
const deletePessoaForm = document.getElementById("delete-pessoa");

if(deletePessoaForm) {
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
}

const editarCamposForm = document.getElementById("editar-campos");

if(editarCamposForm) {
  editarCamposForm.addEventListener("submit", function (e) {
    e.preventDefault();
    const formData = new  FormData(this);

    const json = {
      id: parseInt(formData.get("id")),
      nome: formData.get("nome"),
      cpf: formData.get("cpf"),
      endereco: {
        logradouro: formData.get("logradouro"),
        numero: parseInt(formData.get("numero")),
        cep: formData.get("cep"),
        bairro: formData.get("bairro"),
        cidade: formData.get("cidade"),
        estado: formData.get("estado"),
      },
      telefones: [
        {
          numero: formData.get("t_numero"),
          ddd: formData.get("t_ddd"),
          tipo: {
            tipo: formData.get("t_tipo"),
          }
        }
      ]
    }
    
    console.log(JSON.stringify(json));
    fetch("/api/pessoa/", {
      method: 'PUT',
      body: JSON.stringify(json),
      headers: {
    'Content-Type': 'application/json'
  }
    }).then(function (response) {
      return response.text();
    }).then(function (text) {
      if(text != "") {
        window.location.assign("/home/Pessoas");
        console.log(text);
      }
    })

  });


}



