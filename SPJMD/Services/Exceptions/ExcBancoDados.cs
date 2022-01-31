using System;


namespace SPJMD.Services.Exceptions
{
    public class ExcBancoDados : ApplicationException
    {
        public ExcBancoDados(string mensagem) : base(mensagem)
        {
        }
    }
}
