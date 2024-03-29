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

    const json = PessoaFormToJson(formData);

    console.log( JSON.stringify(json));

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
        window.location.assign("/pessoa/consulte");
      }
    })

  });
}

const insirirTelefones = document.getElementById("insira_telefones"); 
const adicionarTelefone = document.getElementById("adicionar_telefones");



if(insirirTelefones) {
  adicionarTelefone.onclick = () => {
      $(telefone).clone().appendTo(insirirTelefones).find("input").val("");
  }
  console.log(telefone);
}


const insirirForm = document.getElementById("inserir_form");

if(insirirForm) {
  insirirForm.addEventListener("submit", (e) => {
    e.preventDefault();
    const formData = new  FormData(insirirForm);
    let json = PessoaFormToJson(formData);
    json.id = 0;

    fetch("/api/pessoa/", {
      method: 'POST',
      body: JSON.stringify(json),
      headers: {
    'Content-Type': 'application/json'
  }
    }).then(function (response) {
      if(response.ok) {
        window.location.assign("/pessoa/consulte");
      } 
    }).catch( (error) => {
      console.log(error.message);
    });


    
  });
}


function PessoaFormToJson(formData) {
      let telefones = [];
      const numeros = formData.getAll("t_numero");
      const ddds = formData.getAll("t_ddd");
      const tipos = formData.getAll("t_tipo");

      for(let i = 0; i < numeros.length; i++) {
        const telefone = {
          numero: parseInt(numeros[i]),
          ddd: parseInt(ddds[i]),
          tipo: {
            tipo: tipos[i]
          }
        }
        telefones.push(telefone);
    };

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
      telefones: telefones    
    }
  return json;
}

