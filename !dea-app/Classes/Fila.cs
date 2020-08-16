using System;
using System.Collections.Generic;

namespace School_API_Consummer.Classes
{
    public class Fila<X> 
    {
        private Lista<X> lista;
        public Fila()
        {
            lista = new Lista<X>();
        }              
        
        public bool Tem(X obj)
        {
            return lista.Tem(obj);
        }
        public X Get(int i)
        {
            return lista.GetPos(i);
        }
        public int GetQtd()
        {
            return lista.GetQtd();
        }
        public bool EstaVazia() 
        { 
          return (lista.GetQtd() == 0); 
        }
        public X Inicio()
        {
            return lista.GetDoInicio();
        }
        public X Fim()
        {
            return lista.GetDoFim();
        }
        public void Enfileirar(X obj) 
        {
            if (obj == null)
                throw new Exception("O objeto a ser enfileirado não pode ser nulo.");

            lista.InsiraNoFim(obj);
        }
        public void Retirar() 
        {
            if (EstaVazia())
                throw new Exception("A fila está vazia. Não há nada para ser retirado.");

            lista.RemovaDoInicio();
        }
        public void Retirar(X obj)
        {
            if (EstaVazia())
                throw new Exception("A fila está vazia. Não há nada para ser retirado.");

            List<X> aux = new List<X>();

            int max = lista.GetQtd();

            for (int i = 0; i < max; i++)
            {
                if (lista.GetPos(i).Equals(obj))
                {
                    for(int i2 = i + 1; i2 < lista.GetQtd(); i2++)
                    {
                        aux.Add(lista.GetPos(i2));
                    }

                    var lista2 = new Lista<X>();

                    for (int i3 = 0; i3 < aux.Count; i3++)
                    {
                        lista2.InsiraNoFim(aux[i3]);
                    }

                    for (int i4 = 0; i4 < lista.GetQtd(); i4++)
                    {
                        lista.RemovaDoInicio();
                    }

                    lista = lista2;

                    return;
                }

                aux.Add(lista.GetPos(i));
            }
        }
    }
}
