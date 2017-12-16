#include "formprincipal.h"
#include "ui_formprincipal.h"
QString Aviones;
QString Escritorios;
QString Estaciones;

int resta;

formprincipal::formprincipal(QString AvionesDisponibles,QString EscritoriosDisponibles,QString EstacionesDisponibles,QWidget *parent) :
    QWidget(parent),
    ui(new Ui::formprincipal)
{
    ui->setupUi(this);
    Aviones = AvionesDisponibles;
    Escritorios = EscritoriosDisponibles;
    Estaciones = EstacionesDisponibles;
    ui->LabelAviones->setText(Aviones);
    ui->LabelEscritorios->setText(Escritorios);
    ui->LabelEstaciones->setText(Estaciones);
}

formprincipal::~formprincipal()
{
    delete ui;
}

void formprincipal::on_pushButton_clicked()
{
 resta = Aviones.toInt() - 1;
 Aviones = QString::number(resta);
 ui->setupUi(this);


}
