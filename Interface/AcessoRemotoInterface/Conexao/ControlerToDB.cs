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
    static class ControlerToDB
    {
        private static string stringConexao;
        private static MySqlConnection ConexaoToDb;
        private static MySqlCommand query;
        private static MySqlDataReader resultadoSql;
        private static int ID = 0;

        static public ConnectionState GetEstado()
        {
            return ConexaoToDb == null ? ConnectionState.Closed : ConexaoToDb.State;
        }
        static public void CriarStringConexao()
        {
            var confs = CarregarConfiguracaoConexao(0);

            stringConexao = $"Server={confs.Dequeue()};" +
                $"Port={confs.Dequeue()};" +
                $"Database={confs.Dequeue()};" +
                $"Uid={confs.Dequeue()};" +
                $"Pwd={confs.Dequeue().Replace(" ","")}";
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

        static public void EnviarComando(string comando)
        {
            query.CommandText = $"INSERT INTO `comando` VALUES({ID},'{comando}')";
            query.ExecuteNonQuery();
            ID++;
        }

        static public byte[] ReceberCaptura()
        {
            byte[] imagem = null;

            query.CommandText = "SELECT * FROM `capturatela`";

            resultadoSql = query.ExecuteReader();

            while (resultadoSql.Read())
            {
                imagem = (byte[])resultadoSql["imagem"];
            }
            resultadoSql.Close();

            return imagem;
        }

    }
}
