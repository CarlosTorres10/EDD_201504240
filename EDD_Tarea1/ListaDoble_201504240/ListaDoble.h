//Estructura que compone el nodo (atributos y punteros)
typedef struct Nodo
{
    int valor;
    struct Nodo *siguiente;
    struct Nodo *anterior;
}Nodo;

//Estructura que componen la lista (punteros)
typedef struct ListaDoble
{
    Nodo *primero;
    Nodo *ultimo;
}ListaDoble;


Nodo *NodoNuevo(int valor);
ListaDoble *ListaNueva();
void insertar(ListaDoble *lista, int valor);
void eliminar(ListaDoble *lista, int valor);
void mostrar(ListaDoble *lista);



