#ifndef FORMPRINCIPAL_H
#define FORMPRINCIPAL_H

#include <QWidget>
#include <forminicio.h>
#include <QMessageBox>
#include <QString>

namespace Ui {
class formprincipal;
}

class formprincipal : public QWidget
{
    Q_OBJECT

public:
    explicit formprincipal(QString Cadena,QString EscritoriosDisponibles,QString EstacionesDisponibles,QWidget *parent = 0);
    ~formprincipal();

private slots:
    void on_pushButton_clicked();

private:
    Ui::formprincipal *ui;
};

#endif // FORMPRINCIPAL_H
