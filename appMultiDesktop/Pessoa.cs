using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;

namespace appMultiDesktop
{
    public class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string idade { get; set; }
        public string cidade { get; set; }

        MySqlConnection conn = new MySqlConnection("server=sql.freedb.tech;port=3306;database=freedb_pietro_tds10;user id=freedb_pips96;password=Pv7NP7Y&qB%n!R3;charset=utf8");

        public List<Pessoa> listaPessoa() 
        { 
            List<Pessoa> li = new List<Pessoa>();
            string sql = "SELECT * FROM pessoa";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pessoa p = new Pessoa();
                p.id = (int)dr["id"];
                p.nome = dr["nome"].ToString();
                p.idade = dr["idade"].ToString();
                p.cidade = dr["cidade"].ToString();
                li.Add(p);
            }
            dr.Close();
            conn.Close();
            return li;
        }

        public void Inserir(string nome, string idade, string cidade)
        {
            string sql = "INSERT INTO pessoa(nome,idade,cidade) VALUES('" + nome + "','" + idade + "','" + cidade + "')";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }            
            MySqlCommand cmd = new MySqlCommand( sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Atualizar(int id, string nome, string idade, string cidade)
        {
            string sql = "UPDATE pessoa SET nome='"+nome+"',idade='"+idade +"',cidade='"+cidade+"' WHERE id='"+id+"'";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Excluir(int id)
        {
            string sql = "DELETE FROM pessoa WHERE id='"+id+"'";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Localizar(int id)
        {
            string sql = "SELECT * FROM pessoa WHERE id='"+id+"'";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read()) 
            {
                nome = dr["nome"].ToString();
                idade = dr["idade"].ToString();
                cidade = dr["cidade"].ToString();
            }
            dr.Close();
            conn.Close();
            
        }

        public bool RegistroRepetido(string nome, string idade,string cidade)
        {
            string sql = "SELECT * FROM pessoa WHERE nome='" + nome + "' AND idade='" + idade + "' AND cidade='" + cidade + "'";
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            MySqlCommand cmd = new MySqlCommand( sql, conn);
            cmd.ExecuteNonQuery();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return (int)result > 0;
            }
            conn.Close();
            return false;
        }
    }
}
