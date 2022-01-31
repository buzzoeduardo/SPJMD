using System;


namespace SPJMD.Services.Exceptions
{
    public class ExceNaoEncontrada : ApplicationException
    {
        public ExceNaoEncontrada(string mensagem) : base(mensagem)
        {
        }
    }
}
