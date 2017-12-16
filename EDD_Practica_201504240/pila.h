#ifndef PILA_H
#define PILA_H

struct NodoPila
{
    int dato;
    NodoPila *siguiente;
};

void push(NodoPila *&,int valor);
void pop(NodoPila *&, int &);
void mostrarPila(NodoPila *&);
#endif // PILA_H
