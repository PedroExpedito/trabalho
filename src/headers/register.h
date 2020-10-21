#ifndef REGISTER_H_
#define REGISTER_H_

#include "patient_list.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
// #include <regex.h>

void setName(char *name) {
  printf("Nome do paciente: ");
  scanf("%[^\n]s", name);
  getchar();
}

void setCpf(char *cpf) {
  printf("CPF do paciente:");
  scanf("%[0-9]s", cpf);
  getchar();
  int icpf[12];
  int i, somador = 0, digito1, result1, result2, digito2, valor;
  for (i = 0; i < 11; i++) {
    icpf[i] = cpf[i] - 48;
  }
  for (i = 0; i < 9; i++) {
    somador += icpf[i] * (10 - i);
  }

  result1 = somador % 11;

  if ((result1 == 0) || (result1 == 1)) {
    digito1 = 0;
  }

  else {
    digito1 = 11 - result1;
  }
  somador = 0;

  for (i = 0; i < 10; i++) {
    somador += icpf[i] * (11 - i);
  }

  valor = (somador / 11) * 11;
  result2 = somador - valor;

  if ((result2 == 0) || (result2 == 1)) {
    digito2 = 0;
  }

  else {
    digito2 = 11 - result2;
  }

  // RESULTADOS DA VALIDACAO.

  if ((digito1 != icpf[9]) && (digito2 != icpf[10])) {
    printf("\nCPF INVALIDO!!.\n");
    setCpf(cpf);
  }
}

void setPhone(char *phone) {
  printf("Telefone do paciente: ");
  scanf("%s", phone);
  getchar();
}

void setAndress(char *anddress) {
  printf("Endreço do paciente: ");
  scanf("%[^\n]s", anddress);
  getchar();
  if (strlen(anddress) < 10) {
    printf("Endereço muito curto! forneça mais detalhes\n");
    setAndress(anddress);
  }
}

void setEmail(char *email) {
  printf("Email do paciente: ");
  scanf("%s", email);
  getchar();

  int invalid = 1;

  int tam = strlen(email);
  if (tam < 6) {
    puts("Email invalido");
    setEmail(email);
  }
  for (int i = 0; i < tam; i++) {
    if (email[i] == ' ') {
      puts("Email invalido");
      setEmail(email);
    }
  }
  for (int i = 0; i < tam; i++) {
    if (email[i] == '@') {
      invalid = 0;
    }
  }
  if (invalid != 0) {
    puts("Email invalido");
    setEmail(email);
  }
  invalid = 1;

  for (int i = 0; i < tam; i++) {
    if (email[i] == '.') {
      invalid = 0;
    }
  }

  if (invalid != 0) {
    puts("Email invalido");
    setEmail(email);
  }
}

void setDiagnosticDate(char *date) {
  printf("Data Do diagnostico do paciente: Ex: dd/mm/aaaa \n");
  scanf("%s", date);
  getchar();

  if (strlen(date) != 10) {
    setDiagnosticDate(date);
  }

  int x = date[0] - '0';

  if (x > 3) {
    setDiagnosticDate(date);
  }
}

void setBirthDay(char *date) {
  printf("Data De Nascimento do paciente: Ex: dd/mm/aaaa \n");
  scanf("%s", date);
  getchar();

  if (strlen(date) != 10) {
    puts("A um erro na formatação");
    setBirthDay(date);
  }

  int x = date[0] - '0';

  if (x > 3) {
    puts("A um erro na formatação");
    setBirthDay(date);
  }
}

void setCep(char *cep) {
  printf("CEP do paciente: ");
  scanf("%s", cep);
  getchar();

  if (strlen(cep) != 8) {
    puts("A um erro na formatação");
    setCep(cep);
  }
}

void setComorbidade(char *names) {
  char op;
  puts("O paciente possui cormobidades ? S para sim e N para não");
  scanf("%c", &op);
  getchar();

  if (op == 'N') {
    strcpy(names, "#");
  } else if (op == 'S') {
    printf("comorbidade do paciente separadas por virgula:\n ");
    scanf("%[^\n]s", names);
    getchar();
  } else {
    puts("Erro de formação S maisculo para SIM e N maisculo para NÃO!!!");
    setComorbidade(names);
  }
}

void populate_struct_patient(Patient *patient) {
  setName(patient->name);
  setCpf(patient->cpf);
  setPhone(patient->phone);
  setAndress(patient->anddress);
  setEmail(patient->email);
  setDiagnosticDate(patient->diagnosticDate);
  setBirthDay(patient->birthDay);
  setCep(patient->cep);
  setComorbidade(patient->comorbidade);
}

#endif
