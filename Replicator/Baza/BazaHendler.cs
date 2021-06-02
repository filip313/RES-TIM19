using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Baza
{
    public class BazaHendler : IBazaHendler
    {
        public IDbConnection connection;
        public IDbCommand cmd;
        CultureInfo ci = new CultureInfo("en-US");

        [ExcludeFromCodeCoverage]
        public BazaHendler()
        {
            var current = new DirectoryInfo(Directory.GetCurrentDirectory());
            string path = current.Parent.Parent.FullName;

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\Database1.mdf;Integrated Security=True";
            connection = new SqlConnection(con);
            connection.Open();

        }

        //KONSTRUKTOR ZA TEST
        public BazaHendler(IDbConnection connection)
        {
            this.connection = connection;
        }
        public Tuple<int, CODE, double> ProveraBaze(int id,string tabela)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {

                string q = "SELECT * from " + tabela + " where id=" + id.ToString();
                cmd = connection.CreateCommand();
                cmd.CommandText = q;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                        while (reader.Read())
                        {
                            int iD = (int)reader.GetValue(0);
                            Decimal value = (Decimal)reader.GetValue(1);
                            int code = (int)reader.GetValue(2);
                           
                            return new Tuple<int, CODE, double>(iD, (CODE)code, (double)value);
                        }
                } 

            }
            return null;
        }

        public void Upis(int id ,int code,double value,Common.DataSet dataset,string dt)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                value = Math.Round(value, 5);
                

                string q = "insert into " +dataset.ToString() + " (Id, Code ,Value, Vreme)values ('" + id.ToString() + "','" + code.ToString() + "','" + value.ToString(ci) + "','" + dt + "')";
                cmd = connection.CreateCommand();
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
            }

        }

        public void Upadate(int id, double value, Common.DataSet dataSet, string dt)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                string q = "update " + dataSet.ToString() + " set Value=" + value.ToString(ci) + " , Vreme='" + dt + "' where id=" + id.ToString() + ";";
                cmd = connection.CreateCommand();
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
            }    
        }
    }
}
