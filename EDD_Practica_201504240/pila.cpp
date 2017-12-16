#include "pila.h"

void push(NodoPila *&pila, int valor)
{
    NodoPila *nuevo = new (NodoPila);
    nuevo->dato=valor;
    nuevo->siguiente=pila;
    pila = nuevo;
}

void pop(NodoPila *&pila, int &valor)
{
    NodoPila *aux= pila;
    valor = aux->dato;
    pila=aux->siguiente;
    delete(aux);
}


