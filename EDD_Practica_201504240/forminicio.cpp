#include "forminicio.h"
#include "ui_forminicio.h"
#include "QString"
#include <iostream>
#include "lista.h"
#include "colasimple.h"
#include "lista.h"

QString CantidadEscritorios;
QString cadena;

int CantidadAviones;
int ContadorAviones;
int CantidadEstaciones;
int Vrandom;
int TurnosDisponibles;
int ContadorTurnos;
int CantidadTurnos;
int TurnoDesabordaje;
int CantidadPasajeros;
int TurnosMantenimiento;

Cola PunteroCola;
NodoListaS *lista = 0;


FormInicio::FormInicio(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::FormInicio)
{
    ui->setupUi(this);
    ui->TextTurnos->setFocus();
    ui->LabelCTurnos->setVisible(false);
    ui->LabelCAviones->setVisible(false);
    ui->LabelCEscritorios->setVisible(false);
    ui->LabelCEstaciones->setVisible(false);
    ui->LabelAvionesEspera->setVisible(false);
    ui->LabelCantidadPasajeros->setVisible(false);
    ui->LabelConsola->setVisible(false);
    ui->LabelInformacionA->setVisible(false);
    ui->LabelTCantidadP->setVisible(false);
    ui->LabelTDesabordaje->setVisible(false);
    ui->LabelTTipoA->setVisible(false);
    ui->LabelTTurnoM->setVisible(false);
    ui->LabelTipoAvion->setVisible(false);
    ui->LabelVTurno->setVisible(false);
    ui->LabelTNombreA->setVisible(false);
    ui->LabelNombreAvion->setVisible(false);
    ui->LabelTurnoActual->setVisible(false);
    ui->LabelTurnoDesabordaje->setVisible(false);
    ui->LabelTurnosMantenimiento->setVisible(false);
    ui->BotonSiguiente->setVisible(false);
    ui->ListAvion->setVisible(false);
    ui->ListConsola->setVisible(false);
    ui->BotonGraficas->setVisible(false);

    PunteroCola.adelante = 0;
    PunteroCola.atras = 0;


    //ui->ListAvion->addItem("pepe: ");
    //ui->ListAvion->addItem("juan");

}

FormInicio::~FormInicio()
{
    delete ui;
}

void FormInicio::on_BotonMenuP_clicked()

{
    CantidadTurnos = ui->TextTurnos->text().toInt();
    CantidadAviones = ui->TextAviones->text().toInt();
    CantidadEscritorios = ui->TextEscritorios->text();
    CantidadEstaciones =  ui->TextEstaciones->text().toInt();

    TurnosDisponibles = CantidadTurnos - 1;
    ContadorTurnos = 1;

    ContadorAviones = CantidadAviones - 1;

    if ( (!ui->TextTurnos->text().isEmpty()) && (!ui->TextAviones->text().isEmpty()) && (!ui->TextEscritorios->text().isEmpty()) && (!ui->TextEstaciones->text().isEmpty())){
        ui->LabelTitulo->setText("Simulación iniciada!!!");
        ui->TextTurnos->setVisible(false);
        ui->TextAviones->setVisible(false);
        ui->TextEscritorios->setVisible(false);
        ui->TextEstaciones->setVisible(false);
        ui->LabelCTurnos->setText(QString::number(TurnosDisponibles));
        ui->LabelCAviones->setText(QString::number(ContadorAviones));
        ui->LabelCEscritorios->setText(CantidadEscritorios);
        ui->LabelCEstaciones->setText(QString::number(CantidadEstaciones));
        ui->LabelCTurnos->setVisible(true);
        ui->LabelCAviones->setVisible(true);
        ui->LabelCEscritorios->setVisible(true);
        ui->LabelCEstaciones->setVisible(true);
        ui->TextTurnos->clear();
        ui->TextAviones->clear();
        ui->TextEscritorios->clear();
        ui->TextEstaciones->clear();

        ui->LabelTurnoActual->setVisible(true);
        ui->LabelVTurno->setVisible(true);
        ui->LabelVTurno->setText(QString::number(ContadorTurnos));
        ui->LabelAvionesEspera->setVisible(true);
        ui->ListAvion->setVisible(true);

        ui->LabelInformacionA->setVisible(true);
        ui->LabelTDesabordaje->setVisible(true);
        ui->LabelTNombreA->setVisible(true);
        ui->LabelTTipoA->setVisible(true);
        ui->LabelTCantidadP->setVisible(true);
        ui->LabelTTurnoM->setVisible(true);
        ui->LabelTurnoDesabordaje->setVisible(true);
        ui->LabelNombreAvion->setVisible(true);
        ui->LabelTipoAvion->setVisible(true);
        ui->LabelCantidadPasajeros->setVisible(true);
        ui->LabelTurnosMantenimiento->setVisible(true);

        ui->LabelConsola->setVisible(true);
        ui->ListConsola->setVisible(true);
        ui->BotonSiguiente->setVisible(true);
        ui->BotonMenuP->setVisible(false);
        ui->BotonGraficas->setVisible(true);

        TurnoDesabordaje = 1 + rand() %3;
        switch (TurnoDesabordaje) {
            case 1:
                ui->LabelTurnoDesabordaje->setText(QString::number(TurnoDesabordaje));
                ui->LabelNombreAvion->setText("Avión " + QString::number(ContadorTurnos));
                Encolar(PunteroCola,ContadorTurnos);
                ui->LabelTipoAvion->setText("Pequeño");
                CantidadPasajeros = 5 + rand() %10;
                ui->LabelCantidadPasajeros->setText(QString::number(CantidadPasajeros));
                TurnosMantenimiento = 1 +  rand() %3;
                ui->LabelTurnosMantenimiento->setText(QString::number(TurnosMantenimiento));
                ui->ListAvion->addItem("Avion " + QString::number(ContadorTurnos));
                break;
            case 2:
                ui->LabelTurnoDesabordaje->setText(QString::number(TurnoDesabordaje));
                ui->LabelNombreAvion->setText("Avión " + QString::number(ContadorTurnos));
                Encolar(PunteroCola,ContadorTurnos);
                ui->LabelTipoAvion->setText("Mediano");
                CantidadPasajeros = 15 + rand() %25;
                ui->LabelCantidadPasajeros->setText(QString::number(CantidadPasajeros));
                TurnosMantenimiento = 2 +  rand() %4;
                ui->LabelTurnosMantenimiento->setText(QString::number(TurnosMantenimiento));
                ui->ListAvion->addItem("Avion " + QString::number(ContadorTurnos));
                break;
            case 3:
                ui->LabelTurnoDesabordaje->setText(QString::number(TurnoDesabordaje));
                ui->LabelNombreAvion->setText("Avión " + QString::number(ContadorTurnos));
                Encolar(PunteroCola,ContadorTurnos);
                ui->LabelTipoAvion->setText("Grande");
                CantidadPasajeros = 30 + rand() %40;
                ui->LabelCantidadPasajeros->setText(QString::number(CantidadPasajeros));
                TurnosMantenimiento = 3 +  rand() %6;
                ui->LabelTurnosMantenimiento->setText(QString::number(TurnosMantenimiento));
                ui->ListAvion->addItem("Avion " + QString::number(ContadorTurnos));
                break;
        }

        //MostrarCola(PunteroCola,"colaaviones");
        //system("dot -Tpng colaaviones.dot -o colaaviones.png");

        for (int i=1; i<=CantidadEstaciones; i++)
        {
            insertarLista(lista,i);
        }

        mostrarListaS(lista,"listaestaciones");
        system("dot -Tpng listaestaciones.dot -o listaestaciones.png");



    }
    else {
        QMessageBox::warning(this,"Error","Llene todos los campos para poder continuar!!!");
        ui->TextTurnos->clear();
        ui->TextAviones->clear();
        ui->TextEscritorios->clear();
        ui->TextEstaciones->clear();
        ui->TextTurnos->setFocus();
        ui->ListAvion->takeItem(0);
    }


}

void FormInicio::on_BotonSiguiente_clicked()
{
    TurnosDisponibles--;
    ui->LabelCTurnos->setText(QString::number(TurnosDisponibles));

    ContadorTurnos++;
    ui->LabelVTurno->setText(QString::number(ContadorTurnos));

    if (ContadorAviones != 0)
    {
        ContadorAviones--;
        ui->LabelCAviones->setText(QString::number(ContadorAviones));
    }
    else{
        ContadorAviones=0;
        ui->LabelCAviones->setText(QString::number(ContadorAviones));
    }


    switch (TurnoDesabordaje) {
        case 1:
            ui->LabelTurnoDesabordaje->setText(QString::number(TurnoDesabordaje));
            ui->LabelNombreAvion->setText("Avión " + QString::number(ContadorTurnos));
            Encolar(PunteroCola,ContadorTurnos);
            ui->LabelTipoAvion->setText("Pequeño");
            CantidadPasajeros = 5 + rand() %10;
            ui->LabelCantidadPasajeros->setText(QString::number(CantidadPasajeros));
            TurnosMantenimiento = 1 +  rand() %3;
            ui->LabelTurnosMantenimiento->setText(QString::number(TurnosMantenimiento));
            ui->ListAvion->addItem("Avion " + QString::number(ContadorTurnos));
            break;
        case 2:
            ui->LabelTurnoDesabordaje->setText(QString::number(TurnoDesabordaje));
            ui->LabelNombreAvion->setText("Avión " + QString::number(ContadorTurnos));
            Encolar(PunteroCola,ContadorTurnos);
            ui->LabelTipoAvion->setText("Mediano");
            CantidadPasajeros = 15 + rand() %25;
            ui->LabelCantidadPasajeros->setText(QString::number(CantidadPasajeros));
            TurnosMantenimiento = 2 +  rand() %4;
            ui->LabelTurnosMantenimiento->setText(QString::number(TurnosMantenimiento));
            ui->ListAvion->addItem("Avion " + QString::number(ContadorTurnos));
            break;
        case 3:
            ui->LabelTurnoDesabordaje->setText(QString::number(TurnoDesabordaje));
            ui->LabelNombreAvion->setText("Avión " + QString::number(ContadorTurnos));
            Encolar(PunteroCola,ContadorTurnos);
            ui->LabelTipoAvion->setText("Grande");
            CantidadPasajeros = 30 + rand() %40;
            ui->LabelCantidadPasajeros->setText(QString::number(CantidadPasajeros));
            TurnosMantenimiento = 3 +  rand() %6;
            ui->LabelTurnosMantenimiento->setText(QString::number(TurnosMantenimiento));
            ui->ListAvion->addItem("Avion " + QString::number(ContadorTurnos));
            break;
    }
    MostrarCola(PunteroCola,"colaaviones");
    system("dot -Tpng colaaviones.dot -o colaaviones.png");



}

void FormInicio::on_BotonGraficas_clicked()
{
    system("viewnior listaestaciones.png");
    system("viewnior colaaviones.png");
}
