#include "ListaDoble.h"

Nodo *NodoNuevo(int valor)
{
    Nodo *nuevo = (Nodo*)malloc(sizeof(Nodo));
    nuevo->valor = valor;
    nuevo->siguiente = 0;
    nuevo->anterior = 0;
    return nuevo;
}

ListaDoble *ListaNueva()
{
    ListaDoble *nueva = (ListaDoble*)malloc(sizeof(ListaDoble));
    nueva->primero = 0;
    nueva->ultimo = 0;
    return nueva;
}

void insertar(ListaDoble *lista, int valor)
{
    Nodo *nuevo = NodoNuevo(valor);
    if(lista->primero == 0)
    {
        lista->primero = nuevo;
        lista->ultimo = nuevo;
        return;
    }
    lista->ultimo->siguiente = nuevo;
    nuevo->anterior = lista->ultimo;
    lista->ultimo = nuevo;
}

void eliminar(ListaDoble *ListaDob, int valor)
{
    if(!(ListaDob->primero == 0))
    {
        Nodo *actual = ListaDob->primero;
        while(actual != 0)
        {
            if(actual->valor == valor)
            {
                break;
            }
            actual = actual->siguiente;
        }
        if(actual != 0)
        {
            if(actual == ListaDob->primero)
            {
                ListaDob->primero = actual->siguiente;
                if(actual->siguiente != 0)
                {
                    actual->siguiente->anterior = 0;
                }
            }
            else if(actual->siguiente != 0)
            {
                actual->anterior->siguiente = actual->siguiente;
                actual->siguiente->anterior = actual->anterior;
            }
            else
            {
                actual->anterior->siguiente = 0;
            }
        }
        free(actual);
        return;
    }
    printf("\n La lista esta vacía \n");
}

void mostrar(ListaDoble *ListaDob)
{
    Nodo *actual = ListaDob->primero;
    while(actual != 0)
    {
        printf("%d", actual->valor);
        printf(" <--> ");
        actual = actual->siguiente;
    }
    printf("\n");
    free(actual);
}



