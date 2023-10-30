using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoCliente
    {
        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public long Incluir(DML.Cliente cliente)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Incluir(cliente);
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public void Alterar(DML.Cliente cliente)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            cli.Alterar(cliente);
        }

        /// <summary>
        /// Consulta o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public DML.Cliente Consultar(long id)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Consultar(id);
        }

        /// <summary>
        /// Excluir o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            cli.Excluir(id);
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Listar()
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Listar();
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Pesquisa(iniciarEm,  quantidade, campoOrdenacao, crescente, out qtd);
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string CPF)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.VerificarExistencia(CPF);
        }

        /// <summary>
        /// VerificaValidade
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarValidade(string CPF)
        {
            List<int> digitos = new List<int>{};
            int primeiroDV, segundoDV, somaDV = 0, posicaoDV = 0, resto;

            // Separa os dígitos da string do CPF
            foreach (char i in CPF)
            {
                if (Char.IsDigit(i)) { digitos.Add(int.Parse(i.ToString())); }
            }

            // Cálculo do primeiro dígito verificador
            for (int i = 10; i >=2; i--)
            {
                somaDV += digitos[posicaoDV] * i;
                posicaoDV++;
            }

            resto = somaDV % 11;
            if (resto > 1)
            {
                primeiroDV = 11 - resto;

                // Digito verificador divergente
                if (primeiroDV != digitos[9]) { return false; }
            } 
            else
            {
                primeiroDV = 0;

                // Digito verificador divergente
                if (primeiroDV != digitos[9]) { return false; }
            }

            // Cálculo do segundo dígito verificador
            somaDV = 0;
            posicaoDV = 1;

            for (int i = 10; i >= 2; i--)
            {
                somaDV += digitos[posicaoDV] * i;
                posicaoDV++;
            }

            resto = somaDV % 11;
            if (resto > 1)
            {
                segundoDV = 11 - resto;

                // Digito verificador divergente
                if (segundoDV != digitos[10]) { return false; }
            }
            else
            {
                segundoDV = 0;

                // Digito verificador divergente
                if (segundoDV != digitos[10]) { return false; }
            }

            // Digitos verficadores corretos
            return true;
        }
    }
}
