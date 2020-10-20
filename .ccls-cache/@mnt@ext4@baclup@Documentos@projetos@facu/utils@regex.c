#include <stdio.h>
#include <regex.h>
#include <stdlib.h>
#include <string.h>

int reg(char *expression, char *email) {
  regex_t regex;
  char msgbuf[100];

  // //i;
  int reti = regcomp(&regex, expression, 0);
  if (reti) {
    fprintf(stderr, " Could not compile regex\n");
  }
  reti = regexec(&regex, email, 0, NULL , 0);
  if (!reti) {
    return 0;
  } else if ( reti == REG_NOMATCH) {
    return 1;
    exit(1);
  } else {
    regerror(reti, &regex, msgbuf, sizeof(msgbuf));
    return 3;
  }
}

int main(void) {
  reg("@gmail.com", "email.com") == 0 ? printf("SIM") : printf("Não");
}
