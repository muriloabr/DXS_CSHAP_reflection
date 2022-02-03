using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXS_CSHAP_Reflection {
    abstract class Pessoa : LimparObjeto {
        //ATRIBUTOS
        private int _id;
        //PROPRIEDADES
        public int Id {
            get { return _id; }
            set {_id = (value >= 0) ? _id = value : throw new ExceptionManipulacaoDados("Número invãlido para o ID!"); } //linha de regra para set com operador condicional ternary, liberando valores positivos
        }
        public string Nome { get; set; }
        //METODOS
        public void Limpar() {
            this.Id = 0;
            this.Nome = "";
        }
        override
        public string ToString() {  //metodo sobrescrito da classe object base
            return $"ID: {this.Id} | NOME: {this.Nome}";  //cadeia de caracteres interpolada
        }
        public static Pessoa operator ++(Pessoa a) // Sobrecarga de operador ++
        {
            a.Id = a.Id++;
            return a;
        }
        public static Pessoa operator --(Pessoa a) // Sobrecarga de operador --
        {
            a.Id = a.Id--;
            return a;
        }
    }
}
