#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#include "headers/menu.h"

#include "headers/patient_list.h"

#include "headers/register.h"
#include "headers/brdate.h"
#include "headers/secretary.h"



/* void teste(Patient *test) { */
/*   strcpy(test->name, "João Feitoso"); */
/*   strcpy(test->cpf, "10697591901"); */
/*   strcpy(test->phone, "439283743"); */
/*   strcpy(test->anddress, "Rua Mathias"); */
/*   strcpy(test->email, "email@gmail.com"); */
/*   strcpy(test->diagnosticDate, "diagnosticDate"); */
/*   strcpy(test->birthDay, "11/04/2001"); */
/*   strcpy(test->cep, "cep"); */
/*   strcpy(test->comorbidade, "Diabetes"); */
/* } */

// FLUXO

void FluxRemoveData(Patient_list *list) {
  puts("Você realmente quer deletar todos os dados ?\n"
      "Isso apagara os seguintes aquivos:\n"
      "secretaria.txt e data.txt\n"
      "Dijite S para confirmar ou N para cancelar") ;
  char op;

  scanf("%c", &op);
  if ( op == 'S' ) {
    remove("secretaria.txt");
    remove("data.txt");
    list->free(list);
    list = read_to_file();
    puts("Removido!!!");
  }
}

void FluxRegisterPatient(Patient_list *list) {
  Patient p;
  populate_struct_patient(&p);

  if (list->push(list, &p) != 1) {
    puts("Usuario já cadrastado anteriormente Enter para continuar!");
    getchar();
  } else {
    send_to_secretary(list);
    list->save(list);
    clearScreen();
  }
}

void FluxPrintList(Patient_list *list) {
  list->print(list);
  puts("\nTecle Enter para continuar\n\n");
  getchar();
}

void fluxo(Patient_list *list) {
#ifndef DEBUG
  int o = main_menu();
  if (o == 1) {
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
      send_to_secretary(list);
      break;
    case 3:
      o = 0;
      FluxPrintList(list);
      break;
    case 4:
      o = 0;
      FluxRemoveData(list);
      break;
    }
  }
}

int main(void) {
  // fluxo
  Patient_list *list = read_to_file();
  fluxo(list);
  list->free(list);
  // endfluxo

  return 0;
}
