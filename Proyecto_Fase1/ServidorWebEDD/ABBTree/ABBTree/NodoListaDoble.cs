using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ABBTree
{
    public class NodoListaDoble
    {
        private String Nickname;
        private String NicknameOponente;
        private int UnidadesDesplegadas;
        private int UnidadesSobrevivientes;
        private int UnidadesDestruidas;
        private int EstadoVictoria;
        private NodoListaDoble Siguiente;
        private NodoListaDoble Anterior;

        public NodoListaDoble(String Nickname, String NicknameOponente, int UnidadesDesplegadas, int UnidadesSobrevivientes, int UnidadesDestruidas, int EstadoVictoria)
        {
            this.Nickname = Nickname;
            this.NicknameOponente = NicknameOponente;
            this.UnidadesDesplegadas = UnidadesDesplegadas;
            this.UnidadesSobrevivientes = UnidadesSobrevivientes;
            this.UnidadesDestruidas = UnidadesDestruidas;
            this.EstadoVictoria = EstadoVictoria;
            this.Siguiente = null;
            this.Anterior = null;
        }

        public string getNickname()
        {
            return Nickname;
        }
        public void setNickname(String Nickname)
        {
            this.Nickname = Nickname;
        }

        public string getNicknameOponente()
        {
            return NicknameOponente;
        }
        public void setNicknameOponente(String NicknameOponente)
        {
            this.NicknameOponente = NicknameOponente;
        }

        public int getUnidadesDesplegadas()
        {
            return UnidadesDesplegadas;
        }
        public void setUnidadesDesplegadas(int UnidadesDesplegadas)
        {
            this.UnidadesDesplegadas = UnidadesDesplegadas;
        }

        public int getUnidadesSobrevivientes()
        {
            return UnidadesSobrevivientes;
        }
        public void setUnidadesSobrevivientes(int UnidadesSobrevivientes)
        {
            this.UnidadesSobrevivientes = UnidadesSobrevivientes;
        }

        public int getUnidadesDestruidas()
        {
            return UnidadesDestruidas;
        }
        public void setUnidadesDestruidas(int UnidadesDestruidas)
        {
            this.UnidadesDestruidas = UnidadesDestruidas;
        }

        public int getEstadoVictoria()
        {
            return EstadoVictoria;
        }
        public void setEstadoVictoria(int EstadoVictoria)
        {
            this.EstadoVictoria = EstadoVictoria;
        }

        public NodoListaDoble getSiguiente()
        {
            return Siguiente;
        }
        public void setSiguiente(NodoListaDoble Siguiente)
        {
            this.Siguiente = Siguiente;
        }

        public NodoListaDoble getAnterior()
        {
            return Anterior;
        }
        public void setAnterior(NodoListaDoble Anterior)
        {
            this.Anterior = Anterior;
        }


}
}
