#include "coladoble.h"
#include <iostream>
#include <QDebug>
#include <fstream>
#include "QString"







void Encolar(ColaD &PunteroCola, int valor)
{
    NodoColaD *aux = new (NodoColaD);
    aux->DatoAvion = valor;
    aux->siguiente = 0;

    if (PunteroCola.adelante == 0)
        PunteroCola.adelante = aux;
    else
        (PunteroCola.atras)->siguiente = aux;

    PunteroCola.atras = aux;
}

void Desencolar(ColaD &PunteroCola)
{
    NodoColaD *aux;
    aux = PunteroCola.adelante;  //aux apunta al primero de la cola
    PunteroCola.adelante = (PunteroCola.adelante)->siguiente;
    delete(aux);  //libera la memoria del apuntador aux.
}

void MostrarCola(ColaD &PunteroCola,std::string urlText)
{
    NodoColaD *aux;

        std::string url = urlText + ".dot";
        std::ofstream text;
        text.open(url, std::ios::out);

        aux = PunteroCola.adelante;

        if (text.is_open())
        {

            text << "digraph G {\n";
            text << "nodesep = .05;\n";
            text << "rankdir = LR;\n";
            text << "node [shape = record, width=.1, height=.1];\n";

            while (aux != 0)
            {


                text<<"node"<<"[label = \"{"<<"Escritorio "<< aux->DatoAvion<<"} \"];"<<std::endl;
                //printf("%d",aux->DatoAvion);

                aux = aux->siguiente;

            }



            aux=(PunteroCola.adelante)->siguiente;

            while (aux != 0)
            {
                 text <<"\"node"<<"\""<<" -> "<<"\"node"<<"\";"<<std::endl;
                 aux = aux->siguiente;

            }

            text << "}";

        }
        text.close();
}

void VaciarCola(ColaD &PunteroCola)
{
    NodoColaD *aux;
    while (PunteroCola.adelante != 0)
    {
        aux = PunteroCola.adelante;
        PunteroCola.adelante = aux->siguiente;
        delete(aux);
    }
    PunteroCola.adelante=0;
    PunteroCola.atras=0;

}
