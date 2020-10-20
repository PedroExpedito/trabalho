//Dessa forma ele captura o primeiro nome porém não captura o segundo, eu não entendo o motivo.

//A saida é "Nome: João Fulaninho Da silva, Apelido: @^C" então ele pega lixo no segundo valor

//O esperado seria: "Nome: João Fulaninho Da silva, Apelido: João" então ele pega lixo no segundo valor
#include <stdio.h>
#include <stdlib.h>

typedef struct {
  char name[200];
  char apelido[200];
  char rua[200];
  char numero[10];
}Pessoa;

void save_to_file(int size, Pessoa pessoa[]) {
  FILE *file;
  file = fopen("data2.txt", "w");
  fprintf(file,"%d\n", size);
  for(int i = 0; i < size; i++) {
    fprintf(file,"%s\n", pessoa[i].name);
    fprintf(file,"%s\n", pessoa[i].apelido);
    fprintf(file,"%s\n", pessoa[i].rua);
    fprintf(file,"%s\n", pessoa[i].numero);
  }
  fclose(file);
}

int main(void) {

  int tam;
  int size;
  FILE *file;
  file = fopen("data.txt", "r");
  if ( file == NULL) {
    fprintf(stderr, "erro ao abrir arquivo");
    exit(1);
  }
  fscanf(file,"%d", &size);
  fclose(file);
  file = fopen("data.txt", "r");
  Pessoa *pessoa = malloc(sizeof(Pessoa)*size);
  int first = 0;
  for (int i = 0; i < size; i++){
    if ( first == 0){
    fscanf(file, "%d\n%[^\n] %[^\n] %[^\n] %[^\n]s",&tam, pessoa[i].name, pessoa[i].apelido,pessoa[i].rua, pessoa[i].numero);
    first = 1;
    } else {
      fscanf(file, "\n%[^\n] %[^\n] %[^\n] %[^\n]s", pessoa[i].name, pessoa[i].apelido,pessoa[i].rua, pessoa[i].numero);

    }
  }

  fclose(file);
  printf("TAm: %d\n", tam);
  for (int i = 0; i < size; i++){
    printf("\n\nPESSOA %d\n\n",i+1);
  printf("Nome: %s\nApelido: %s\nRua: %s\nnumero: %s\n", pessoa[i].name, pessoa[i].apelido,pessoa[i].rua,pessoa[i].numero);
  }
  save_to_file(size,*&pessoa);
  return 0;
}



