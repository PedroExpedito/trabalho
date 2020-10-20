#include <stdio.h>

int main(void) {
  FILE *arq;
  char frase[200];
  arq = fopen("teste.txt", "r");
  fscanf(arq, "%s" , *&frase);
  printf("%s",frase);
  fclose(arq);
}
