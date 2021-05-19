using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public class WriterComponent
    {
        public Dictionary<int, int> aktivniWriteri;
        Connection connection;
        public int Id { get; set; }
        public WriterComponent(int id)
        {
            //NAPRAVITI KONEKCIJU
            aktivniWriteri = new Dictionary<int, int>();
            this.Id = id;
            connection = new Connection(Id);
        }

        public void KreirajWriter()
        {
            int maxId;
            if(aktivniWriteri.Count == 0)
            {
                maxId = Id;
            }
            else
            {
                maxId = aktivniWriteri.Keys.Max();
            }
            maxId++;
            try
            {
                Process tmp = Process.Start("Writer.exe", maxId.ToString());
                aktivniWriteri.Add(maxId, tmp.Id);
                string data = "";
                data += DateTime.Now.ToString();
                data += " Od Writer " + Id + ": Pokrenuta nova instanca writer-a ID = " + maxId + "; PID = " + tmp.Id;
                connection.logerProxy.LogData(data);
            }
            catch (Exception )
            {
                Console.WriteLine("Nije moguce napraviti novu instancu Writer-a");
            }
        }

        public void ListWriter()
        {
            foreach(int id in aktivniWriteri.Keys)
            {
                Console.WriteLine(id + ") Writer " + id );
            }
            Console.WriteLine();
        }

        public void UgasiWritera(int id)
        {
            if (aktivniWriteri.ContainsKey(id))
            {
                try
                {
                    Process tmp = Process.GetProcessById(aktivniWriteri[id]);
                    aktivniWriteri.Remove(id);
                    Console.WriteLine("Proces uspesno ugasen");

                    string data = "";
                    data += DateTime.Now.ToString();
                    data += " Od Writer " + Id + ": Ugasena instanca writer-a ID = " + id + "; PID = " + tmp.Id;
                    connection.logerProxy.LogData(data);

                    tmp.Kill();

                }
                catch(Exception)
                {
                    Console.WriteLine("Proces je vec ugasen");
                    aktivniWriteri.Remove(id);
                }
                
            }
            else
            {
                Console.WriteLine("Odabran nepostojeci proces");
            }
        }

        public bool Ugasi()
        {
            if(aktivniWriteri.Count == 0)
            {
                return true;
            }
            Console.WriteLine("Nije moguce ugasiti glavnog Writer-a dok su aktivne druge instance:");
            ListWriter();
            return false;
        }
    }
}
