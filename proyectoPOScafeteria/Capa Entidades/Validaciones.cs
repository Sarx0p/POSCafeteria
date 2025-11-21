using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proyectoPOScafeteria.Capa_Entidades
{
    
        public static class Validaciones
        {
            //valida que el dato sea entero
            public static bool EsEntero(string s)
            {
                int numero;
                return int.TryParse(s, out numero);
            }
            //valida que el dato sea decimal
            public static bool EsDecimal(string s)
            {
                decimal numero;
                return decimal.TryParse(s, out numero);
            }
            //valida direccion de correo electronico
            public static bool EsCorreoValido(string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;
                //expresion regular para validar correo
                var patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, patron);
            }
        public static bool Sololetrayespacios(string texto)
        {
            return texto.All(c => char.IsLetter(c) || c == ' ');
        }

        // Solo números
        public static bool SoloNumeros(string texto)
        {
            return texto.All(char.IsDigit);
        }

        
      

    }
    }
