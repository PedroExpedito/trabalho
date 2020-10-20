#include <stdio.h>
#include <string.h>
#include <stdlib.h>

typedef struct String {
  char data[10];

  // void (*create)(String*, char*);

} String;

  // void create_str(String* string, char str[]) {
  // // string->data = (char *)malloc(sizeof(char) * strlen(str) + 1);
  // strcpy(string->data,str);
// }

// void contructor(String* string) {
//   string->create = create_str;
// }
int main(void) {
  String str;
  // str.data = (char *)malloc(10);
  strcpy(str.data, "Ola");
  puts(str.data);

}


