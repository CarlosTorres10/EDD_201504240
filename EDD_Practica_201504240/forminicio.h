#ifndef FORMINICIO_H
#define FORMINICIO_H

#include <QMainWindow>
#include <formprincipal.h>
#include "QString"
#include <QMessageBox>

namespace Ui {
class FormInicio;
}

class FormInicio : public QMainWindow
{
    Q_OBJECT

public:
    explicit FormInicio(QWidget *parent = 0);
    ~FormInicio();

private slots:
    void on_BotonMenuP_clicked();

    void on_BotonSiguiente_clicked();

    void on_BotonGraficas_clicked();

private:
    Ui::FormInicio *ui;
};

#endif // FORMINICIO_H
