#ifndef MENU_H_
#define MENU_H_

#include <stdio.h>
#include <stdlib.h>
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
  int ret = getchar() - '0';
  if(ret == 2) {
    exit(0);
  }
  if ( ret < 1 || ret > 2 ) {
    main_menu();
  }
  return ret;
}

int logged(void) {
  printf("MENU\n"
      "1 para registrar paciente\n"
      "2 para gerar aquivo para secretaria da saude\n"
      "3 para sair\n");

  int ret = getchar() - '0';
  if(ret == 3) {
    exit(0);
  }
  if ( ret < 1 || ret > 3 ) {
    main_menu();
  }
  return ret;
}

#endif

