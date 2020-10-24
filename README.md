# Contexto

 Sistema em C para cadastrar pacientes diagnosticados com Covid-19.

 **OBJETIVO GERAL**

 ```

Com base no conteúdo das disciplinas de LINGUAGEM E TÉCNICAS DE PROGRAMAÇÃO
e ENGENHARIA DE SOFTWARE I, o aluno ou grupo do PIM deverá apresentar um
sistema em C que será utilizado pelos hospitais para cadastrar os pacientes que forem
diagnosticados com covid-19 e carecem de um acompanhamento e monitoramento para
que essa informação possa ser enviada para a central da Secretaria da Saúde.

```

### Melhorias RNF

1. [x] - Biblioteca de manipulação de datas com localidade brasileira
2. [x] - Evitar duplicatas de pacientes
3. [ ] - Menus mais bonitos
4. [x] - Melhoria na validação de números de telefone e celulares




Requisitos obrigatórios RF

0. [x] - Dados precisam ser salvo em arquivos TXT

1. [x] - Sistema de Login

2. [x] - Calcular idade de acordo com a data de nascimento

3. [x] - Verificar se o paciente está no grupo de risco ou seja maior que 65 anos

4. [x] - Guardar o CEP apenas se o paciente for do grupo de risco ????

5. [x] - Paradigma procedural estruturado.

### Validar campos de entrada.
1.  [x] - Nome
2.  [x] - CPF
3.  [x] - Telefone ( Validar tamanho );
4.  [x] - Endereço
6.  [x] - Data de Nascimento
7.  [x] - E-mail
8.  [x] - Data Do Diagnóstico
9.  [x] - Comorbidade do paciente( diabetes,obesidade);
11. [x] - CEP
12. [x] - IDADE

## Telas

1. [x] - Login/Registro de quem vai criar pacientes
2. [x] - criar paciente
3. [x] - listar pacientes
4. [x] - Apagar dados

## Campo PODIA TER NO MANUAL MAIS NÃO TEM!!!


### Arquivo principal

Nome
CPF
Telefone
Endereço
Data de Nascimento
E-mail
Data Do Diagnóstico
Comorbidade do paciente( diabetes,obesidade);
CEP
IDADE

### Arquivo secundário

CEP
IDADE

### Interessante:

  **Arquivo a principal** vantagem de um arquivo é que as informações
armazenadas podem ser consultadas a qualquer momento) com todos os
  dados do campo.

  **Arquivo secundário** Após o cadastro, o sistema deverá calcular a idade e verificar se o paciente possui
alguma comorbidade e se pertence ao grupo de risco (maiores de 65 anos). Caso o paciente
pertença ao grupo de risco o sistema deverá salvar em um arquivo de texto o CEP e a idade
do paciente para que essa informação possa ser enviada para a central da Secretaria da
Saúde da cidade.

# Bugs

Erro de datas **RESOLVIDO**
