using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXS_CSHAP_Reflection {
    internal class ExceptionManipulacaoDados : Exception {
        public ExceptionManipulacaoDados() : base() {
        }

        public ExceptionManipulacaoDados(string message)
            : base(message) {
        }

        public ExceptionManipulacaoDados(string message, Exception inner)
            : base(message, inner) {
        }
    }
}
