using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonDomain
{
    public enum EnumComportamentoDaExcecao
    {
        deslogaUsuario = 0,
        mantemEstado = 1,
        estadoAnterior = 2,
        estadoPosterior = 3,
        reiniciaFluxo = 4
    }
}
