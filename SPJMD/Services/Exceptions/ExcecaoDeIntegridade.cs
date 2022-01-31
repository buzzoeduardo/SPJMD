using System;

namespace SPJMD.Services.Exceptions
{
    public class ExcecaoDeIntegridade : ApplicationException
    {
        public ExcecaoDeIntegridade(string mensagem) : base(mensagem)
        {

        }
    }
}
