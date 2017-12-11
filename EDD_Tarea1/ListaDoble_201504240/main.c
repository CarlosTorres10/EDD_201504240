#include <stdio.h>
#include <stdlib.h>
#include "ListaDoble.h"


int main(void)
{
    ListaDoble *ListaDob = ListaNueva();
    int Opcion;
    char Entrada[1];
    int Dato;

    do
    {
        //Opciones del menu principal.
        printf("----Opciones a utilizar para una lista doblemente enlazada----\n\n");
        printf("1) Insertar valores en la lista\n");
        printf("2) Mostrar lista\n");
        printf("3) Eliminar valores de la lista\n");
        printf("\n");
        //Lectura de opción a ingresar.
        printf("Ingrese la opción: ");
        scanf("%d", &Opcion);

        //Switch que validara las opciónes.
        switch(Opcion)
        {
            case 1:
                printf("\n");
                printf("Ingrese el dato a insertar en la lista: ");
                scanf("%d", &Dato);
                insertar(ListaDob, Dato);
                printf("\n");

                break;

            case 2:
                printf("\n");
                printf("Visualizador de datos que posee la lista\n");
                printf("\n");
                mostrar(ListaDob);
                break;

            case 3:
                printf("\n");
                printf("Ingrese el dato que desea eliminar de la lista: ");
                scanf("%d", &Dato);
                eliminar(ListaDob, Dato);
                printf("\n");
                break;

            case 4:
                break;

            default:
                printf("\n");
                printf("La opción ingresada es incorrecta, vuelva a intentarlo!!!");
                printf("\n");
                break;
        }

    }while (Opcion !=4);
    return 0;
}

