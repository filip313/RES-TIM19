using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Writer
{
    public class WriterComponent
    {
        public virtual Dictionary<int, int> aktivniWriteri { get; set; }
        Connection connection;
        public int Id { get; set; }

        private static ReaderWriterLock locker = new ReaderWriterLock();
        private static object _readLock = new object();
        public WriterComponent(int id)
        {
            //NAPRAVITI KONEKCIJU
            aktivniWriteri = new Dictionary<int, int>();
            this.Id = id;

            using (StreamReader sr = new StreamReader("procesi.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int tmpPid = Int32.Parse(line.Split(' ')[0]);
                    int tmpId = Int32.Parse(line.Split(' ')[1]);

                    aktivniWriteri.Add(tmpId, tmpPid);
                }
            }

            int PID = Process.GetCurrentProcess().Id;

            using (StreamWriter sw = File.AppendText("procesi.txt"))
            {
                sw.WriteLine(PID + " " + Id);
            }
            aktivniWriteri.Add(Id, PID);

            Task.Factory.StartNew(Proveri);
            connection = new Connection(Id);
        }

        public WriterComponent()
        {

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
                //aktivniWriteri.Add(maxId, tmp.Id);
                string data = "";
                data += DateTime.Now.ToString();
                data += " Od: Writer " + Id + ": Pokrenuta nova instanca writer-a ID = " + maxId + "; PID = " + tmp.Id;
                connection.logerProxy.LogData(data);
            }
            catch (Exception )
            {
                Console.WriteLine("Nije moguce napraviti novu instancu Writer-a");
            }
        }

        [ExcludeFromCodeCoverage]
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

                    string output = "";
                    locker.AcquireWriterLock(100);
                    using (StreamReader sr = new StreamReader("procesi.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Split(' ')[1] != id.ToString())
                            {
                                output += line + "\n";
                            }
                        }
                    }
                    locker.ReleaseReaderLock();

                    using (StreamWriter sw = new StreamWriter("procesi.txt"))
                    {
                        sw.Write(output);
                    }

                    string data = "";
                    data += DateTime.Now.ToString();
                    data += " Od Writer " + Id + ": Ugasena instanca writer-a ID = " + id + "; PID = " + tmp.Id;
                    tmp.Kill();
                    Console.WriteLine("Proces uspesno ugasen");
                    connection.logerProxy.LogData(data);
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

        private void Proveri()
        {
            while (true)
            {
                Thread.Sleep((Id + 1) * 10);
                List<int> ids = new List<int>();
                List<int> Pids = new List<int>();
                string lines = "";

                locker.AcquireReaderLock(Id * 110);
                using (var file = new FileStream("procesi.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {

                    byte[] buffer = new byte[file.Length];
                    file.Read(buffer, 0, (int)file.Length);
                    lines = Encoding.UTF8.GetString(buffer);

                }

                foreach (string line in lines.Split('\n'))
                {
                    if (line.Length > 1)
                    {
                        ids.Add(Int32.Parse(line.Split(' ')[1]));
                        Pids.Add(Int32.Parse(line.Split(' ')[0]));
                    }
                }

                locker.ReleaseReaderLock();

                if (ids.Count > aktivniWriteri.Count)
                {
                    aktivniWriteri[ids.Max()] = Pids[ids.IndexOf(ids.Max())];
                }
                else if (ids.Count < aktivniWriteri.Count)
                {
                    foreach (int id in aktivniWriteri.Keys)
                    {
                        if (!ids.Contains(id))
                        {
                            aktivniWriteri.Remove(id);
                            break;
                        }
                    }
                }
            }
        }
    }
}
