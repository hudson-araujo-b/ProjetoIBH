using BCrypt.Net;
using ProjetoIBH.Interfaces
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System.IO.Pipelines;
using System.Security.Cryptography.X509Certificates;

namespace ProjetoIBH.Repository
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        // variavel somente leitura e privada para receber a conexao do banco
        private readonly string _connectionString;
        // construtor tem sempre o nome da class cabeça
        public UsuarioRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conexao");

        }

        public void CriarConta(CriarContaViewModel usuario)
        {

            using (var conn = new MySqlConnection(_connectionString))
            {
                //Criptografando a senha antes de enviar ao mysql(Banco)
                conn.Open();
                string senhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

                var sql = "Insert into tb_Usuario(Nome,Email,Senha,Nivel) VALUES(@nome,@email,@senha,@nivel)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@senha", senhaHash);
                cmd.Parameters.AddWithValue("@nivel", "Usuario");
                cmd.ExecuteNonQuery();

            }
        }
    }
}
