using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_API_Consummer.Classes
{
    class Resultados
    {
        private short ra;

        public short RA
        {
            get
            {
                return ra;
            }
            set
            {
                if (value < 0 || value.ToString().Length != 5)
                {
                    throw new Exception("O RA deve ser válido.");
                }
                ra = value;
            }
        }

        private int cod;

        public int Cod
        {
            get
            {
                return cod;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("O RA deve ser positivo.");
                }
                cod = value;
            }
        }

        private float nota;

        public float Nota
        {
            get
            {
                return nota;
            }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new Exception("A nota deve estar entre 0 e 10.");
                }
                nota = value;
            }
        }

        private float frequencia;

        public float Frequencia
        {
            get
            {
                return frequencia;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("A porcentagem de frequencia deve estar entre 0 e 100.");
                }
                frequencia = value;
            }
        }

        public Resultados(short RA, int cod, float nota, float frequencia)
        {
            this.RA = RA;
            Cod = cod;
            Nota = nota;
            Frequencia = frequencia;
        }

        public override bool Equals(object obj)
        {
            return obj is Resultados resultados &&
                   obj != null &&
                   ra == resultados.ra &&
                   RA == resultados.RA &&
                   cod == resultados.cod &&
                   Cod == resultados.Cod &&
                   nota == resultados.nota &&
                   Nota == resultados.Nota &&
                   frequencia == resultados.frequencia &&
                   Frequencia == resultados.Frequencia;
        }

        public override int GetHashCode()
        {
            var hashCode = 1398195996;
            hashCode = hashCode * -1521134295 + ra.GetHashCode();
            hashCode = hashCode * -1521134295 + RA.GetHashCode();
            hashCode = hashCode * -1521134295 + cod.GetHashCode();
            hashCode = hashCode * -1521134295 + Cod.GetHashCode();
            hashCode = hashCode * -1521134295 + nota.GetHashCode();
            hashCode = hashCode * -1521134295 + Nota.GetHashCode();
            hashCode = hashCode * -1521134295 + frequencia.GetHashCode();
            hashCode = hashCode * -1521134295 + Frequencia.GetHashCode();

            if (hashCode < 0)
                hashCode = -hashCode;

            return hashCode;
        }

        public override string ToString()
        {
            return
                "RA............" + RA +
                "\nCod..........." + Cod +
                "\nNota.........." + Nota +
                "\nFrequencia...." + Frequencia;
        }

        public Resultados Clone(Resultados obj)
        {
            return new Resultados(RA, Cod, Nota, Frequencia);
        }

        public Resultados(Resultados modelo)
        {
		    RA = modelo.RA;
		    Cod = modelo.Cod;
		    Nota = modelo.Nota;
            Frequencia = modelo.Frequencia;
        }
    }
}
