#ifndef PATIENT_LIST_H_
#define PATIENT_LIST_H_

#include <stdio.h>
#include <stdlib.h>
#include <string.h>


typedef struct Patient {
  struct Patient *prox;
  // public
  char name[200];
  char cpf[12];
  char phone[20];
  char anddress[500];
  char birthDay[13];
  char email[500];
  char diagnosticDate[13];
  char cep[9];
  char comorbidade[500];
} Patient;

struct Patient_list {
  Patient data;
  Patient *head;
  Patient *current;

  // func
  int (*size)(struct Patient_list *);
  int (*empty)(struct Patient_list *);
  int (*push)(struct Patient_list *, Patient *);
  void (*print)(struct Patient_list *);
  void (*save)(struct Patient_list *list);
  void (*free)(struct Patient_list *);
  int (*seach_cpf)(struct Patient_list *, char *);
};

typedef struct Patient_list Patient_list;

void patient_copy(Patient *dest, Patient *new_patient) {
  strcpy(dest->name, new_patient->name);
  strcpy(dest->cpf, new_patient->cpf);
  strcpy(dest->email, new_patient->email);
  strcpy(dest->phone, new_patient->phone);
  strcpy(dest->anddress, new_patient->anddress);
  strcpy(dest->diagnosticDate, new_patient->diagnosticDate);
  strcpy(dest->birthDay, new_patient->birthDay);
  strcpy(dest->cep, new_patient->cep);
  strcpy(dest->comorbidade, new_patient->comorbidade);
}

int push_patient(Patient_list *list, Patient *data) {

  if (list->head == NULL) {
    puts("\n\nLISTA NULLz\n\n");
    patient_copy(&list->data, data);
    list->data.prox = NULL;
    list->head = &list->data;
    list->current = &list->data;
  } else {
    if (list->seach_cpf(list, data->cpf) == 0) {
      Patient *p = (Patient *)malloc(sizeof(Patient));
      if (p == NULL) {
        fprintf(stderr, "erro ao alocar memoria");
        exit(1);
      }
      patient_copy(p, data);
      p->prox = NULL;
      list->current->prox = p;
      list->current = p;
    } else {
      return 0;
    }
  }
  return 1;
}

int empty_list_patient(Patient_list *list) {
  if (list->head == NULL) {
    return 1;
  }
  return 0;
};

int size_list_patients(Patient_list *list) {
  if (empty_list_patient(list))
    return 0;
  Patient *aux = list->head;
  int tam = 0;
  while (aux != NULL) {
    tam++;
    aux = aux->prox;
  }
  return tam;
}

void print_patients(Patient_list *list) {

  Patient *aux = list->head;

  while (aux != NULL) {
    printf("%s\n", aux->name);
    printf("%s\n", aux->cpf);
    printf("%s\n", aux->phone);
    printf("%s\n", aux->anddress);
    printf("%s\n", aux->email);
    printf("%s\n", aux->diagnosticDate);
    printf("%s\n", aux->birthDay);
    printf("%s\n", aux->cep);
    printf("%s\n", aux->comorbidade);
    aux = aux->prox;
  }
}

void save_to_file(Patient_list *list) {
  puts("CHEGANDO");

  FILE *arq;
  arq = fopen("data.txt", "w");

  Patient *aux = list->head;
  fprintf(arq, "%d\n", size_list_patients(list));

  while (aux != NULL) {
    fprintf(arq, "%s\n", aux->name);
    fprintf(arq, "%s\n", aux->cpf);
    fprintf(arq, "%s\n", aux->phone);
    fprintf(arq, "%s\n", aux->anddress);
    fprintf(arq, "%s\n", aux->email);
    fprintf(arq, "%s\n", aux->diagnosticDate);
    fprintf(arq, "%s\n", aux->birthDay);
    fprintf(arq, "%s\n", aux->cep);
    fprintf(arq, "%s\n", aux->comorbidade);
    aux = aux->prox;
  }
  fclose(arq);
}

void free_patient_list(Patient_list *list) {

  Patient *head = list->head;
  Patient *tmp;

  while (head != NULL) {
    tmp = head;
    head = head->prox;
    free(tmp);
  }
}

int search_patient_wich_cpf(Patient_list *list, char *cpf) {
  Patient *aux = list->head;
  for (int i = 0; i < size_list_patients(list); i++) {
    if (strcmp(aux->cpf, cpf) == 0) {
      return 1;
    }
    aux = aux->prox;
  }
  return 0;
}

void Patient_list_contructor(Patient_list *list) {
  list->size = size_list_patients;
  list->empty = empty_list_patient;
  list->push = push_patient;
  list->print = print_patients;
  list->save = save_to_file;
  list->seach_cpf = search_patient_wich_cpf;
  list->free = free_patient_list;
}

Patient_list *create_patient_list() {
  Patient_list *p = (Patient_list *)malloc(sizeof(Patient_list));
  Patient_list_contructor(p);

  if (p == NULL) {
    printf("\nFalha ao alocar memoria\n");
    exit(1);
  }

  p->data.prox = NULL;
  p->head = NULL;
  p->current = NULL;
  return p;
}

Patient_list *read_to_file() {
  FILE *arq;
  arq = fopen("data.txt", "r");
  if (arq == NULL) {
    return create_patient_list();
  }

  Patient_list *p = (Patient_list *)malloc(sizeof(Patient_list));
  Patient_list_contructor(p);

  if (p == NULL) {
    fprintf(stderr, "falha ao alocar memoria\n");
  }

  Patient tmp;
  int size;
  int lixo;
  int first = 0;
  fscanf(arq, "%d", &size);
  fclose(arq);
  arq = fopen("data.txt", "r");

  // printf("SIZE: %d\n", size);

  for (int i = 0; i < size; i++) {
    if (first == 0) {
      fscanf(
          arq,
          "%d\n%[^\n] %[^\n] %[^\n] %[^\n] %[^\n] %[^\n] %[^\n] %[^\n] %[^\n]s",
          &lixo, tmp.name, tmp.cpf, tmp.phone, tmp.anddress, tmp.email,
          tmp.diagnosticDate, tmp.birthDay, tmp.cep, tmp.comorbidade);

      patient_copy(&p->data, &tmp);
      p->data.prox = NULL;
      p->head = &p->data;
      p->current = &p->data;
      first = 1;
    } else {
      fscanf(arq,
             "\n%[^\n] %[^\n] %[^\n] %[^\n] %[^\n] %[^\n] %[^\n] %[^\n] %[^\n]",
             tmp.name, tmp.cpf, tmp.phone, tmp.anddress, tmp.email,
             tmp.diagnosticDate, tmp.birthDay, tmp.cep, tmp.comorbidade);
      push_patient(p, &tmp);
    }
  }

  fclose(arq);

  return p;
};

#endif
