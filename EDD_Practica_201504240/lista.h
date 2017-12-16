#ifndef LISTA_H
#define LISTA_H
#include <iostream>

struct NodoListaS
{
    int estacion;
    NodoListaS *siguiente;
};

void insertarLista(NodoListaS *&,int dato);
void mostrarListaS(NodoListaS *lista,std::string urlText);



#endif // LISTA_H
