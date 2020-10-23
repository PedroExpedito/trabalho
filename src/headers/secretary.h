#ifndef SECRETARY_H_
#define SECRETARY_H_

#include <stdio.h>
#include <time.h>

#include "patient_list.h"

int send_to_secretary(Patient_list *list) {

  int found = 0;

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
    int age = local_year - atoi(year[i]);

#ifdef DEBUG
    printf("Ano: %s\n", year[i]);
    printf("idade é %d \n", age);
#endif

    if (age > 65 && strcmp(aux->comorbidade, "#") != 0) {

      // evitar duplicatas
      if ( found == 0) {
        remove("secretaria.txt");
      }

      found = 1;
      FILE *file;
      file = fopen("secretaria.txt", "a");
      fprintf(file, "CEP: %s\nIDADE: %d\n", aux->cep, age);
      fclose(file);
      puts("Salvo em ./secrataria.txt \n Dijite Enter para continuar");
      getchar();
    }
    aux = aux->prox;
  }
  if ( found == 0 ) {
    puts("Não a pacientes em grupo de risco para ser enviado!!!\n");
    puts("Clique Enter para continuar");
    getchar();
  } else if ( found == 1 ) {
    puts("Arquivo criado com sucesso!");
  }
  return 0;
}


#endif
