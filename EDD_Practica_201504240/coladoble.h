#ifndef COLADOBLE_H
#define COLADOBLE_H
#include <iostream>


struct NodoColaD
{
    int DatoAvion;
    NodoColaD *siguiente;

};

struct ColaD
{
    NodoColaD *adelante;
    NodoColaD *atras;
};

void Encolar(ColaD &PunteroCola, int valor);
void Desencolar(ColaD &PunteroCola);
void MostrarCola(ColaD &PunteroCola,std::string urlText);
void VaciarCola(ColaD &PunteroCola);
#endif // COLADOBLE_H
