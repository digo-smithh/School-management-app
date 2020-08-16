using System;

namespace School_API_Consummer.Classes
{
    public class Lista<X>
    {
        protected class No
        {
            private No ante;
            private X info;
            private No prox;

            public No(No a, X i, No p)
            {
                this.ante = a;
                this.info = i;
                this.prox = p;
            }

            public No(X i)
            {
                this.ante = null;
                this.info = i;
                this.prox = null;
            }

            public No GetAnte()
            {
                return this.ante;
            }

            public X GetInfo()
            {
                return this.info;
            }

            public No GetProx()
            {
                return this.prox;
            }

            public void SetAnte(No a)
            {
                this.ante = a;
            }

            public void SetInfo(X i)
            {
                this.info = i;
            }

            public void SetProx(No p)
            {
                this.prox = p;
            }
        }

        protected No primeiro, ultimo;

        public Lista()
        {
            this.primeiro = this.ultimo = null;
        }

        public void InsiraNoInicio(X i)
        {
            if (i == null)
                throw new Exception("Informacao ausente");

            X inserir = i;

            this.primeiro = new No(null, inserir, this.primeiro);

            if (this.primeiro.GetProx() != null)
                this.primeiro.GetProx().SetAnte(this.primeiro);

            this.primeiro.SetAnte(null);

            if (this.ultimo == null)
                this.ultimo = this.primeiro;
        }

        public void InsiraNoFim(X i)
        {
            if (i == null)
                throw new Exception("Informacao ausente");

            X inserir = i;

            if (this.ultimo == null) 
            {
                this.ultimo = new No(inserir);
                this.primeiro = this.ultimo;
            }
            else
            {
                this.ultimo.SetProx(new No(this.ultimo, inserir, null));
                this.ultimo = this.ultimo.GetProx();
            }
        }

        public void RemovaDoInicio()
        {
            if (this.primeiro == null)
                throw new Exception("Nada a remover");

            this.primeiro = this.primeiro.GetProx();

            if (this.primeiro == null)
                this.ultimo = null;
            else
                this.primeiro.SetAnte(null);
        }

        public void RemovaDoFim()
        {
            if (this.primeiro == null)
                throw new Exception("Nada a remover");

            this.ultimo = this.ultimo.GetAnte();

            if (this.ultimo == null)
                this.primeiro = null;
            else
                this.ultimo.SetProx(null);
        }

        public void Remova(X i)
        {
            if (i == null)
                throw new Exception("Informacao ausente");

            if (this.primeiro == null)
                throw new Exception("Lista vazia");

            if (i.Equals(this.primeiro.GetInfo()))
            {
                this.primeiro = this.primeiro.GetProx();

                if (this.primeiro == null)
                    this.ultimo = null;
                else
                    this.primeiro.SetAnte(null);

                return;
            }

            No atual = this.primeiro;

            for (;;)
            {
                if (atual == null)
                    throw new Exception("Informacao inexistente");

                if (i.Equals(atual.GetInfo()))
                {
                    if (atual == this.primeiro)
                    {
                        this.primeiro = this.primeiro.GetProx();

                        if (this.primeiro == null) 
                            this.ultimo = null;
                        else
                            this.primeiro.SetAnte(null);

                        return;
                    }

                    if (atual == this.ultimo)
                    {
                        this.ultimo = this.ultimo.GetAnte();

                        if (this.ultimo == null)
                            this.primeiro = null;
                        else
                            this.ultimo.SetProx(null);

                        return;
                    }

                    atual.GetAnte().SetProx(atual.GetProx());
                    atual.GetProx().SetAnte(atual.GetAnte());
                    return;
                }

                atual = atual.GetProx();
            }
        }

        public bool Tem(X i)
        {
            if (i == null)
                throw new Exception("Informacao ausente");

            No atual = this.primeiro;

            while (atual != null)
            {
                if (i.Equals(atual.GetInfo()))
                    return true;

                atual = atual.GetProx();
            }

            return false;
        }

        public int GetQtd()
        {
            No atual = this.primeiro;
            int ret = 0;

            while (atual != null)
            {
                ret++;
                atual = atual.GetProx();
            }

            return ret;
        }

        public X GetDoInicio()
        {
            if (this.primeiro == null)
                throw new Exception("Nada a obter");

            X ret = this.primeiro.GetInfo();

            return ret;
        }

        public X GetPos(int pos)
        {
            if (this.primeiro == null)
                throw new Exception("Nada a obter");

            No atual = this.primeiro;
            int ret = 1;

            while (atual != null && ret <= pos)
            {
                ret++;
                atual = atual.GetProx();
            }

            return atual.GetInfo();
        }

        public X GetDoFim()
        {
            if (this.primeiro == null)
                throw new Exception("Nada a obter");

            X ret = this.ultimo.GetInfo();

            return ret;
        }

        public bool IsVazia()
        {
            return this.primeiro == null;
        }

        public void InvertaSe()
        {
            if (this.primeiro == null)
                return;

            if (this.primeiro.GetProx() == null)
                return; 

            No backup, atual = this.primeiro;
            while (atual != null)
            {
                backup = atual.GetProx();
                atual.SetProx(atual.GetAnte());
                atual.SetAnte(backup);
                atual = backup;
            }

            backup = this.primeiro;
            this.primeiro = this.ultimo;
            this.ultimo = backup;
        }

        public Lista<X> Inversao()
        {
            Lista<X> ret = new Lista<X>();

            for (No atual = this.primeiro; atual != null; atual = atual.GetProx())
            {
                ret.primeiro = new No(null, atual.GetInfo(), ret.primeiro);

                if (ret.primeiro.GetProx() != null)
                    ret.primeiro.GetProx().SetAnte(ret.primeiro);

                ret.primeiro.SetAnte(null);

                if (ret.ultimo == null)
                    ret.ultimo = ret.primeiro;
            }

            return ret;
        }

        public override string ToString()
        {
            string ret = "[";

            No atual = this.primeiro;

            while (atual != null)
            {
                ret = ret + atual.GetInfo();

                if (atual != this.ultimo)
                    ret = ret + ",";

                atual = atual.GetProx();
            }

            return ret + "]";
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null)
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            Lista<X> lista = (Lista<X>)obj;

            No atualThis = this.primeiro;
            No atualLista = lista.primeiro;

            while (atualThis != null && atualLista != null)
            {
                if (!atualThis.GetInfo().Equals(atualLista.GetInfo()))
                    return false;

                atualThis = atualThis.GetProx();
                atualLista = atualLista.GetProx();
            }

            if (atualThis != null)
                return false;

            if (atualLista != null)
                return false;

            return true;
        }
        public override int GetHashCode()
        {

            int ret = 797; 

            for (No atual = this.primeiro; atual != null; atual = atual.GetProx())
                ret = 5 * ret + atual.GetInfo().GetHashCode();

            if (ret < 0) 
                ret = -ret;

            return ret;
        }


        public Lista(Lista<X> modelo)
        {
            if (modelo == null)
                throw new Exception("Modelo ausente");

            if (modelo.primeiro == null)
                return; // sai do construtor, pq this.primeiro ja é null

            this.primeiro = new No(modelo.primeiro.GetInfo());

            No atualDoThis = this.primeiro;
            No atualDoModelo = modelo.primeiro.GetProx();

            while (atualDoModelo != null)
            {
                atualDoThis.SetProx(new No(atualDoThis, atualDoModelo.GetInfo(), null));
                atualDoThis = atualDoThis.GetProx();
                atualDoModelo = atualDoModelo.GetProx();
            }

            this.ultimo = atualDoThis;
        }
        public Object clone()
        {
            return new Lista<X>(this);
        }
    }

}
