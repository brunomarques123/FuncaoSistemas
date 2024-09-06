using FI.AtividadeEntrevista.DAL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Inclui um novo beneficiário
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiário</param>
        public long Incluir(Beneficiario beneficiario)
        {
            DaoBeneficiario dao = new DaoBeneficiario();

            // Verificar se o CPF já existe
            if (VerificarExistencia(beneficiario.CPF))
            {
                throw new Exception("CPF do beneficiário já cadastrado.");
            }

            return dao.Incluir(beneficiario);
        }

        /// <summary>
        /// Altera um beneficiário
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiário</param>
        public void Alterar(Beneficiario beneficiario)
        {
            DaoBeneficiario dao = new DaoBeneficiario();
            dao.Alterar(beneficiario);
        }

        /// <summary>
        /// Exclui um beneficiário pelo id
        /// </summary>
        /// <param name="id">id do beneficiário</param>
        public void Excluir(long id)
        {
            DaoBeneficiario dao = new DaoBeneficiario();
            dao.Excluir(id);
        }

        /// <summary>
        /// Lista os beneficiários para um cliente específico
        /// </summary>
        /// <param name="idCliente">id do cliente</param>
        /// <returns>Lista de beneficiários</returns>
        public List<Beneficiario> Listar(long idCliente)
        {
            DaoBeneficiario dao = new DaoBeneficiario();
            return dao.Listar(idCliente);
        }

        /// <summary>
        /// Verifica se o CPF do beneficiário já existe
        /// </summary>
        /// <param name="CPF">CPF do beneficiário</param>
        /// <returns>True se existir, false caso contrário</returns>
        public bool VerificarExistencia(string CPF)
        {
            DaoBeneficiario dao = new DaoBeneficiario();
            return dao.VerificarExistencia(CPF);
        }
    }
}
