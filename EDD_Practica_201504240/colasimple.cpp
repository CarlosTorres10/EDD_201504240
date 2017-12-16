#include "colasimple.h"
#include <iostream>
#include <QDebug>
#include <fstream>
#include "QString"


int contadorDo  = 0;
int SizeCola = 0;



void Encolar(Cola &PunteroCola, int valor)
{
    NodoCola *aux = new (NodoCola);
    aux->DatoAvion = valor;
    aux->siguiente = 0;

    if (PunteroCola.adelante == 0)
        PunteroCola.adelante = aux;
    else
        (PunteroCola.atras)->siguiente = aux;

    PunteroCola.atras = aux;
}

void Desencolar(Cola &PunteroCola)
{
    NodoCola *aux;
    aux = PunteroCola.adelante;  //aux apunta al primero de la cola
    PunteroCola.adelante = (PunteroCola.adelante)->siguiente;
    delete(aux);  //libera la memoria del apuntador aux.
}

void MostrarCola(Cola &PunteroCola,std::string urlText)
{
    NodoCola *aux;

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


                text<<"node"<<contadorDo<<"[label = \"{"<<"Avión "<< aux->DatoAvion<<"} \"];"<<std::endl;
                //printf("%d",aux->DatoAvion);
                contadorDo++;
                aux = aux->siguiente;
                SizeCola++;
            }


            contadorDo=0;
            aux=(PunteroCola.adelante)->siguiente;

            while (aux != 0)
            {
                 text <<"\"node"<<contadorDo<<"\""<<" -> "<<"\"node"<<contadorDo + 1<<"\";"<<std::endl;
                 text <<"\"node"<<contadorDo+1<<"\""<<" -> "<<"\"node"<<contadorDo<<"\";"<<std::endl;
                 aux = aux->siguiente;
                 contadorDo++;
            }

            text << "}";
            contadorDo=0;
        }
        text.close();
}

void VaciarCola(Cola &PunteroCola)
{
    NodoCola *aux;
    while (PunteroCola.adelante != 0)
    {
        aux = PunteroCola.adelante;
        PunteroCola.adelante = aux->siguiente;
        delete(aux);
    }
    PunteroCola.adelante=0;
    PunteroCola.atras=0;

}
