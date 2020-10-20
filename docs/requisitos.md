# Contexto
 Sistema em C para cadastrar pacientes diagnosticados com covid-19.

 OBJETIVO GERAL
 ```
Com base no conteúdo das disciplinas de LINGUAGEM E TÉCNICAS DE PROGRAMAÇÃO
e ENGENHARIA DE SOFTWARE I, o aluno ou grupo do PIM deverá apresentar um
sistema em C que será utilizado pelos hospitais para cadastrar os pacientes que forem
diagnosticados com covid-19 e carecem de um acompanhamento e monitoramento para
que essa informação possa ser enviada para a central da Secretaria da Saúde.
```


Requisitos obrigatórios

0. [ ] - Dados precisam ser salvo em arquivos TXT

1. [?] - Sistema de Login

2. [ ] - Calcular idade de acordo com a data de nascimento

3. [x] - Verificar se o paciente está no grupo de risco ou seja maior que 65 anos

4. [ ] - Guardar o Cep apenas se o paciente for do grupo de risco ????

5. [ ] - Paradigma procedural estruturado.

6. [ ] - Validar campos de entrada.
   [x] - Nome
   x] - cpf
   [x] - Telefone ( Validar tamanho );
    [x] - Endereço
  [ ]
  [ ] - Data de Nascimento
  [ ] - E-mail
  [ ] - Data Do Diagnóstico
  [ ] - Comorbidade do paciente( diabetes,obesidade);
  [ ] - CEP
  [ ] - IDADE

## Telas

[ ] - Login/Registro de quem vai criar pacientes
[ ] - criar paciente
[ ] - listar pacientes
[ ] - listar apenas pacientes de risco


## Campo PODIA TER NO MANUAL MAIS NÃO TEM!!!


### Arquivo principal

Nome
CPF
Telefone
Endereço
Data de Nascimento
E-mail
Data Do Diagnóstico
Comorbidade do paciente( diabetes,obsidade);
CEP
IDADE

### Arquivo secundário

CEP
IDADE

## Entrega

 1) DocPIM (arquivo do Word no formato padrão ABNT, com as telas do programa,
manual do usuário, manual de instalação, como compilar o programa, como testar etc.);

 2) Binários do programa (exel, dlls, arquivos de teste, arquivo de configuração);

 3) Arquivos fontes (projeto desenvolvido no codeblock).

Interessante:

  **Arquivo a principal** vantagem de um arquivo é que as informações
armazenadas podem ser consultadas a qualquer momento) com todos os
  dados do campo.

  **Arquivo secundário** Após o cadastro, o sistema deverá calcular a idade e verificar se o paciente possui
alguma comorbidade e se pertence ao grupo de risco (maiores de 65 anos). Caso o paciente
pertença ao grupo de risco o sistema deverá salvar em um arquivo de texto o CEP e a idade
do paciente para que essa informação possa ser enviada para a central da Secretaria da
Saúde da cidade.

