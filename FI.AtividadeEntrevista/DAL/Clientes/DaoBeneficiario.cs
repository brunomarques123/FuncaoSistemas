using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FI.AtividadeEntrevista.DAL
{
    internal class DaoBeneficiario : AcessoDados
    {
        /// <summary>
        /// Inclui um novo beneficiário
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiário</param>
        internal long Incluir(DML.Beneficiario beneficiario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Nome", beneficiario.Nome));
            parametros.Add(new SqlParameter("CPF", beneficiario.CPF));
            parametros.Add(new SqlParameter("IdCliente", beneficiario.IdCliente));

            DataSet ds = base.Consultar("FI_SP_IncBeneficiario", parametros);
            long ret = 0;

            if (ds.Tables[0].Rows.Count > 0)
                long.TryParse(ds.Tables[0].Rows[0][0].ToString(), out ret);

            return ret;
        }

        /// <summary>
        /// Altera um beneficiário existente
        /// </summary>
        /// <param name="beneficiario">Objeto de beneficiário</param>
        internal void Alterar(DML.Beneficiario beneficiario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("Id", beneficiario.Id));
            parametros.Add(new SqlParameter("Nome", beneficiario.Nome));
            parametros.Add(new SqlParameter("CPF", beneficiario.CPF));
            parametros.Add(new SqlParameter("IdCliente", beneficiario.IdCliente));

            base.Executar("FI_SP_AltBeneficiario", parametros);
        }

        /// <summary>
        /// Exclui um beneficiário pelo ID
        /// </summary>
        /// <param name="id">ID do beneficiário</param>
        internal void Excluir(long id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
    {
        new SqlParameter("Id", id)
    };

            base.Executar("FI_SP_ExcBeneficiario", parametros);
        }

        /// <summary>
        /// Lista todos os beneficiários
        /// </summary>
        /// <returns>Lista de beneficiários</returns>
        internal List<DML.Beneficiario> Listar()
        {
            List<DML.Beneficiario> beneficiarios = new List<DML.Beneficiario>();

            DataSet ds = base.Consultar("FI_SP_ListBeneficiarios", null);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                beneficiarios.Add(new DML.Beneficiario
                {
                    Id = Convert.ToInt64(row["Id"]),
                    Nome = row["Nome"].ToString(),
                    CPF = row["CPF"].ToString(),
                    IdCliente = Convert.ToInt64(row["IdCliente"])
                });
            }

            return beneficiarios;
        }

        /// <summary>
        /// Verifica se um beneficiário com o CPF já existe
        /// </summary>
        /// <param name="cpf">CPF do beneficiário</param>
        /// <returns>True se existir, false caso contrário</returns>
        internal bool VerificarExistencia(string cpf)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
    {
        new SqlParameter("CPF", cpf)
    };

            DataSet ds = base.Consultar("FI_SP_VerificarExistenciaBeneficiario", parametros);

            // Assume-se que a stored procedure retorna um valor booleano indicando a existência
            return ds.Tables[0].Rows.Count > 0 && Convert.ToBoolean(ds.Tables[0].Rows[0][0]);
        }


    }
}
