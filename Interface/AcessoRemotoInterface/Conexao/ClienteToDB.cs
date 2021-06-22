using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static AcessoRemotoInterface.Configuracao.Configuracao;


namespace AcessoRemotoInterface.Conexao
{
    static class ClienteToDB
    {
        private static MySqlConnection ConexaoToDb;
        private static MySqlCommand query;
        private static MySqlDataReader resultadoSql;

        private static string stringConexao;

        static public ConnectionState GetEstado()
        {
            return ConexaoToDb == null ? ConnectionState.Closed : ConexaoToDb.State;
        }
        static public void CriarStringConexao()
        {
            var confs = CarregarConfiguracaoConexao(1);

            stringConexao = $"Server={confs.Dequeue()};" +
                $"Port={confs.Dequeue()};" +
                $"Database={confs.Dequeue()};" +
                $"Uid={confs.Dequeue()};" +
                $"Pwd={confs.Dequeue().Replace(" ", "")}";
        }

        static public void Conectar()
        {
            CriarStringConexao();
            ConexaoToDb = new MySqlConnection(stringConexao);
            ConexaoToDb.Open();
            query = ConexaoToDb.CreateCommand();

        }
        static public void Desconectar()
        {
            ConexaoToDb.Close();
        }

        static public void EnviarCaptura(byte[] imagem)
        {
            query.CommandText = "UPDATE `capturatela` SET `imagem`=@imagem";

            query.Parameters.Clear();
            query.Parameters.Add(new MySqlParameter("@imagem", imagem));
        
            query.ExecuteNonQuery();
        }

        static public Queue<string> ReceberComando()
        {
            var comandosResultado = new Queue<string>();
            var ids = new Queue<int>();

            query.CommandText = "SELECT * FROM `comando`";
            resultadoSql = query.ExecuteReader();

            while(resultadoSql.Read())
            {
                comandosResultado.Enqueue(resultadoSql["command"].ToString());
                ids.Enqueue(Convert.ToInt32(resultadoSql["id"]));
            }
            resultadoSql.Close();
            DeletarComandosRecebidos(ids);

            return comandosResultado;
        }

        static public void DeletarComandosRecebidos(Queue<int> ids)
        {
            while (ids.Any())
            {
                query.CommandText = $"DELETE FROM `comando` WHERE id = {ids.Dequeue()}";
                query.ExecuteNonQuery();
            }
        }
    }
}
