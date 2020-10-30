#ifndef MENU_H_
#define MENU_H_

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
void clearScreen() {
#ifdef __linux__
  printf("\e[1;1H\e[2J");
#elif defined _WIN32
  system("cls");
#endif
}
int main_menu(void) {
  clearScreen();

  printf("======= MENU ========\n"
      "Pressione 1 para login \n"
      "Pressione 2 para sair\n"
      "=====================\n");

  int ret;

  scanf("%d", &ret);

  if(ret == 2) {
    exit(0);
  }
  if ( ret < 1 || ret > 2 ) {
    main_menu();
  }
  return ret;
}

int login(void) {
  char inputUser[100];
  char inputPassworld[100];
  char user[] = "admin";
  char password[] = "admin";

  puts("Digite o usuário:");
  scanf("%s", inputUser);
  if ( strcmp(inputUser, user) != 0 ) {
    puts("usuário invalido!!!\n"
        "Dados de autenticação pode ser encontrado na documentação 'PIM' ");
    login();
  }
  puts("Digite a senha:");
  scanf("%s", inputPassworld);
  if ( strcmp(inputPassworld, password) != 0 ) {
    puts("senha invalida!!!"
        "Dados de autenticação pode ser encontrado na documentação 'PIM' ");
    login();
  }
  return 0;
}

int logged(void) {
  clearScreen();
  printf("======= MENU =======\n"
      "0 para sair\n"
      "1 para registrar paciente\n"
      "2 para gerar aquivo para secretaria da saúde\n"
      "3 para imprimir lista de pacientes\n"
      "4 para remover datas 'Pacientes'\n"
      );
  int ret;

  scanf("%d", &ret);
  getchar();

  if(ret == 0) {
    exit(0);
  }
  if ( ret < 1 || ret > 4 ) {
    logged();
  }
  return ret;
}

#endif

