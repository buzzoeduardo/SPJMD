using SPJMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPJMD.Models.Enums;

namespace SPJMD.Data
{
    public class PopularService
    {

        //Injeção de dependência
        //Quando um "Popular" for criado, automaticamente ele vai receber uma instância do SPJMDContext também.
        private SPJMDContext _context;

        public PopularService(SPJMDContext context)
        {
            _context = context;
        }

        //Operação para pupular a base de dados
        public void Popular()
        {
            /* Teste para ver se já existe algum dado na base de dados. 
             Se tiver algum dado a operação é interrompida.
             A operação "Any()" verifica se existe registro na tabela.*/
            if (_context.Policial.Any() || _context.Oficial.Any() || _context.Procedimento.Any())
            {
                return; //Apenas o return sem argumentos já corta a operação.
            }

            Policial p1 = new Policial(default, "123456", "1", PostGrad.PrimTen, "Buzzo", QualificacaoEnvolvido.Envolvido);
            Policial p2 = new Policial(default, "147483", "9", PostGrad.Cel, "Pedro", QualificacaoEnvolvido.Testemunha);

            Oficial o1 = new Oficial(default, "159753", "a", Posto.PrimTen, "Adriana", "adriana@gmail.com", FuncaoOficial.Presidente);
            Oficial o2 = new Oficial(default, "147852", "x", Posto.Cap, "Maria", "maria@gmail.com", FuncaoOficial.Encarregado);

            Procedimento pc1 = new Procedimento(default, TiposProcedimentos.IPM, "9BPMI", 012, "13", new DateTime(2022, 01, 10), Origem.Cmt, o2);
            Procedimento pc2 = new Procedimento(default, TiposProcedimentos.IP, "9BPMI", 004, "300", new DateTime(2022, 01, 01), Origem.Corregedoria, o1);

            //Adicionando os objetos acima no Banco de Dados usando o EntitieFramework.

            _context.Policial.AddRange(p1, p2); //O "AddRange()" permite que se adicione vários objetos ao mesmo tempo.

            _context.Oficial.AddRange(o1, o2);

            _context.Procedimento.AddRange(pc1, pc2);

            //Efetivando as alterações feitas

            _context.SaveChanges(); // "SaveChanges()" salva e confirma as alterações no Banco de Dados.
        }
    }
}
