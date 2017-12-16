#ifndef COLASIMPLE_H
#define COLASIMPLE_H
#include <iostream>

struct NodoCola
{
    int DatoAvion;
    NodoCola *siguiente;

};

struct Cola
{
    NodoCola *adelante;
    NodoCola *atras;
};

void Encolar(Cola &PunteroCola, int valor);
void Desencolar(Cola &PunteroCola);
void MostrarCola(Cola &PunteroCola,std::string urlText);
void VaciarCola(Cola &PunteroCola);

#endif // COLASIMPLE_H
