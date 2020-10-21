#ifndef BR_DATE_H_
#define BR_DATE_H_

#include <time.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>


typedef struct br_date {
  char day[3];
  char month[3];
  char yearl[6];
} br_date;

br_date get_date() {

  time_t user_time;
  user_time = time(NULL);
  struct tm tm = *localtime(&user_time);

  br_date date;

  sprintf(date.day, "%02d",tm.tm_mday);
  date.day[2] = '\0';
  sprintf(date.month, "%02d",tm.tm_mon + 1);
  date.month[2] = '\0';
  sprintf(date.yearl, "%d",tm.tm_year + 1900);

  return date;
}

char *br_date_to_string(br_date *date) {
  char *newDate = (char *) malloc(12);

  sprintf(newDate, "%2s/%2s/%4s",date->day, date->month, date->yearl);

  return newDate;
}


int verificarNumero(char *entrada) {
  int i;

  for (i = 0; entrada[i] != '\0'; i++)
  {
    if (entrada[i] != '/' && !isdigit(entrada[i]))
    {
      return 0;
    }
  }

  return 1;
}

int str_br_date_is_valid(char *date) {
  const char substring[3] = "//";

  if (strstr(date, substring) != NULL) {
    return 0;
  }

  if (!verificarNumero(date)) {
    return 0;
  }

  int i = 0;

  int data[3];

  const char delimitador[2] = "/";

  char *token = strtok(date, delimitador);

  // Alimenta o vetor de inteiros
  while (token != NULL) {
    data[i++] = strtol(token, NULL, 10);
    token = strtok(NULL, delimitador);
  }

  // Realize suas validações. Se alguma não for atingida, retorne '0'
  if ( data[1] > 12) {
    return 0;
  }
  if ( data[1] == 4 && data[0] > 28 ) {
    return 0;
  }

  if ( data[0] > 31) {
    return 0;
  };

  br_date dateForYear = get_date();

  int year = atoi(dateForYear.yearl);

  if ( data[2] > year) {
    return 0;
  }

#ifdef DEBUG
  printf("ano: %d", year);
  printf("Dia: %d\n", data[0]);
  printf("Mes: %d\n", data[1]);
  printf("Ano: %d\n", data[2]);
#endif

  // Caso contrário, retorne '1'

  return 1;
}

#endif
