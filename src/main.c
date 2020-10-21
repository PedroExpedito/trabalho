#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#include "headers/menu.h"
#include "headers/patient_list.h"
#include "headers/register.h"

#define DEBUG

/* bool login(char *senha) { */
/*   if (strcmp(senha, senhav) == 0) { */
/*     return true; */
/*   }; */
/*   return false; */
/* }; */

/* void verificargrupoderisco(Patient* a) { */
/*   printf("valor: %d\n", a->age); */
/*     if (a->age > 65 ) { */
/*       puts("Entrei"); */
/*     a->risco = true; */
/*   } else { */
/*   a->risco = false; */
/*   } */
/* } */

/* int new_patient(Patient* patient) { */
/*  */
/*   return 0; */
/* } */

void teste(Patient *test) {
  strcpy(test->name, "João Feitoso");
  strcpy(test->cpf, "13597551901");
  strcpy(test->phone, "439283743");
  strcpy(test->anddress, "Rua Mathias");
  strcpy(test->email, "email@gmail.com");
  strcpy(test->diagnosticDate, "diagnosticDate");
  strcpy(test->birthDay, "11/04/2001");
  strcpy(test->cep, "cep");
  strcpy(test->comorbidade, "Diabetes");
}

int receita(Patient_list *list) {
  Patient *aux = list->head;

  int size = list->size(list);

  printf("size: %d\n", size);

  time_t user_time;
  user_time = time(NULL);

  struct tm tm = *localtime(&user_time);

  int local_year = tm.tm_year + 1900;

  char year[size][5];

  int j;
  int i = 0;

  while (aux != NULL) {
    for (j = 6; j < 10; j++) {
      year[i][j - 6] = aux->birthDay[j];
    }
    year[i][j - 5] = '\0';
    printf("Ano: %s\n", year[i]);
    int age = local_year - atoi(year[i]);
#ifdef DEBUG
    printf("idade é %d \n", age);
#endif
    if (age > 65) {
      /* remove("secretaria.txt"); */
      FILE *file;
      file = fopen("secretaria.txt", "a");
      fprintf(file, "CEP: %s\nIDADE: %d", aux->cep, age);
      fclose(file);
    }
    aux = aux->prox;
  }
  return 0;
}
// FLUXO
void FluxRegisterPatient(Patient_list *list) {
  Patient p;
  populate_struct_patient(&p);
  list->push(list, &p);
  list->save(list);
  clearScreen();
}
void FluxPrintList(Patient_list * list) {
  list->print(list);
  puts("\nTecle Enter para continuar\n\n");
  getchar();
}
void fluxo(Patient_list *list) {
#ifndef DEBUG
  int o = main_menu();
  if ( o == 1 ) {
    clearScreen();
    o = login();
  }

  if (o == 0) {
    o = logged();
  }
#endif
#ifdef DEBUG
  int o = 0;
#endif

  while (1) {
    switch (o) {
    case 0:
      o = logged();
      break;
    case 1:
      o = 0;
      FluxRegisterPatient(list);
      break;
    case 2:
      o = 0;
      receita(list);
      break;
    case 3:
      o = 0;
      FluxPrintList(list);
    }
  }
}

int main(void) {
  Patient_list *list = read_to_file();

  fluxo(list);

  list->free(list);

  /* teste(&patient); */
  /* populate_struct_patient(&patient); */
  /* list->push(list,&patient); */
  /* list->print(list); */
  /*  */
  /* list->save(list); */
  /* receita(list); */
  /* main_menu(); */
  /* login(); */

  return 0;
}
