/*
 * Lista de nomes simplesmente encadeada

Funcionalidades:

                1) - Criar lista
                2) - Adicionar na lista
                3) - Listar os elementos da lista
                4) - Verificar se a lista está vazia
                5) - Buscar elemento na lista
                6) - Remover elemento da lista
                7) - Verificar o tamanho da lista

Melhorias:
                * é precisa criar um objeto ao inves de uma lista global
                * Melhorar a strcpy padrão
*/


#ifndef Clist_H_
#define Clist_H_

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

typedef struct exemplo {
  char name[100];
  struct exemplo *prox;
} t_exemplo;

t_exemplo *head = NULL;
t_exemplo *current = NULL;

t_exemplo *create_list(char* name) {
  t_exemplo *p = (t_exemplo *)malloc(sizeof(t_exemplo));

  if (p == NULL) {
    printf("\nFalha ao alocar memoria\n");
    return NULL;
  }

  strcpy(p->name,name);
  p->prox = NULL;

  head = current = p;
  return p;
}

t_exemplo *push_list(char *name) {
  if (head == NULL) {
    return create_list(name);
  }
  t_exemplo *p = (t_exemplo *)malloc(sizeof(t_exemplo));

  if (p == NULL) {
    printf("\nFalha ao alocar memoria\n");
    return NULL;
  }

  strcpy(p->name , name);
  p->prox = NULL;

  current->prox = p;
  current = p;
  return p;
}

void print_list() {
  t_exemplo *aux = head;

  while (aux != NULL) {
    printf("%s\n", aux->name);
    aux = aux->prox;
  }
}


int lista_vazia() {
  if (head == NULL)
    return 1;
  return 0;
}

t_exemplo *search_element(char *name, t_exemplo **ant) {
  if (lista_vazia() == 1)
    return NULL;
  t_exemplo *p = head;
  t_exemplo *aux_ant = NULL;
  int achou = 0;
  while (p != NULL) {
    if (strcmp(p->name, name) == 0) {
      achou = 1;
      break;
    }
    aux_ant = p;
    p = p->prox;
  }

  if (achou == 1) {
    if (ant)
      *ant = aux_ant; // guarda "aux_ant"
    return p;
  }
  return NULL;
}

int pop_list(char *name) {
  t_exemplo *ant = NULL;
  t_exemplo *elem = search_element(name, &ant);
  if (elem == NULL)
    return 0;
  if (ant != NULL)
    ant->prox = elem->prox;

  if (elem == current)
    current = ant;

  if (elem == head)
    head = elem->prox;

  free(elem);
  elem = NULL;
  return 1;
}

int size_list() {
  if (lista_vazia())
    return 0;
  t_exemplo *aux = head;
  int tam = 0;
  while (aux != NULL) {
    tam++;
    aux = aux->prox;
  }
  return tam;
}

char **list_to_vector() {

  char **vector;
  t_exemplo *aux = head;
  //
  int size = size_list() + 1;
  vector = (char **) malloc(sizeof(char *)*size);
  //
  int i = 0;

  while (aux != NULL && i < size) {
    vector[i] = (char *)malloc(strlen(aux->name)+1);
    strcpy(vector[i], aux->name);
    aux = aux->prox;
    i++;
  }
  return vector;
}

#endif
