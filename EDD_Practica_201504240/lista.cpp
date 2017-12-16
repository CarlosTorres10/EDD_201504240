#include "lista.h"
#include <iostream>
#include <QDebug>
#include <fstream>
#include "QString"
int contadorlista = 0;


void insertarLista(NodoListaS *&lista, int dato)
{
    NodoListaS *nuevonodo = new (NodoListaS);
    nuevonodo->estacion=dato;

    NodoListaS *aux1 = lista;
    NodoListaS *aux2;

    while ((aux1 != 0)&&(aux1->estacion<dato))
    {
        aux2=aux1;
        aux1=aux1->siguiente;
    }

    if (lista==aux1)
    {
        lista=nuevonodo;
    }
    else
    {
        aux2->siguiente=nuevonodo;
    }

    nuevonodo->siguiente=aux1;

}

void mostrarListaS(NodoListaS *lista,std::string urlText)
{
    NodoListaS *actual = new (NodoListaS);
    actual = lista;
    std::string url = urlText + ".dot";
    std::ofstream text;
    text.open(url, std::ios::out);

    if (text.is_open())
    {

        text << "digraph G {\n";
        text << "nodesep = .05;\n";
        text << "rankdir = LR;\n";
        text << "node [shape = record, width=.1, height=.1];\n";

        while (actual != 0)
        {


            text<<"node"<<contadorlista<<"[label = \"{"<<"Estación "<< actual->estacion<<"} \"];"<<std::endl;
            contadorlista++;
            actual = actual->siguiente;
        }

        if (actual == 0)
        {
           text<<"node"<<contadorlista<<"[label = \"{"<<"Estación "<<"NULL"<<"} \"];"<<std::endl;
           contadorlista=0;
           actual = lista;
        }


        while (actual != 0)
        {
             text <<"\"node"<<contadorlista<<"\""<<" -> "<<"\"node"<<contadorlista + 1<<"\";"<<std::endl;
             actual = actual->siguiente;
             contadorlista++;
        }



        text << "}";
        contadorlista=0;
    }
    text.close();

}

