#include "forminicio.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    FormInicio w;
    w.show();

    return a.exec();
}
