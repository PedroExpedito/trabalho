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

  printf("MENU\n"
      "1 para login \n"
      "2 para sair\n");

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

  puts("Dijite o usuario:");
  scanf("%s", inputUser);
  if ( strcmp(inputUser, user) != 0 ) {
    puts("usuario invalido!!!");
    login();
  }
  puts("Dijite a senha:");
  scanf("%s", inputPassworld);
  if ( strcmp(inputPassworld, password) != 0 ) {
    puts("senha invalida!!!");
    login();
  }
  return 0;
}

int logged(void) {
  clearScreen();
  printf("MENU\n"
      "0 para sair\n"
      "1 para registrar paciente\n"
      "2 para gerar aquivo para secretaria da saude\n"
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

