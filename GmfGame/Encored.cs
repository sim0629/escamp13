using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace GmfGame
{
    public class Encored
    {
        private BackgroundWorker worker = new BackgroundWorker();
        private Stopwatch watch = new Stopwatch();

        private Object lock_obj = new Object();
        private Regex regex_timestamp = new Regex(@"""timestamp""\s*:\s*(\d+)\s*[,]");
        private Regex regex_power = new Regex(@"""active_power""\s*:\s*(\d+)\s*[,]");

        private long prev_timestamp;
        private long prev_power;
        private long current_timestamp;
        private long current_power;

        public bool IsOn
        {
            get
            {
                lock (lock_obj)
                {
                    return current_power > 250000;
                }
            }
        }

        private Encored()
        {
            worker.DoWork += Worker_DoWork;
            watch.Start();
        }

        public void Start()
        {
            if (worker.IsBusy) return;
            worker.RunWorkerAsync();
        }

        private void Request()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://escamp.ongetit.com/1.1/sites/e9e19b9a70c3bd580f42a2f8b595c44e795f9151/realtime/info/appliances");
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://escamp.ongetit.com");
            request.Proxy = null;
            request.Headers.Add("Authorization", "Basic ZDE4NjMwYmQyZjI5NGY1ZTg1OGU4M2Q3YmNkMjViYzk=");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var body = reader.ReadToEnd();
                var match1 = regex_timestamp.Match(body);
                var timestamp = long.Parse(match1.Groups[1].Value);
                var match2 = regex_power.Match(body);
                var power = long.Parse(match2.Groups[1].Value);

                lock (lock_obj)
                {
                    if (timestamp == current_timestamp) return;
                    prev_timestamp = current_timestamp;
                    prev_power = current_power;
                    current_timestamp = timestamp;
                    current_power = power;
                    Debug.WriteLine("prev: {0}, current: {1}", prev_power, current_power);
                }
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (watch.ElapsedMilliseconds < 800)
                    {
                        Thread.Sleep(1);
                        continue;
                    }
                    watch.Restart();

                    Request();
                }
                catch { }
            }
        }

        public static Encored Instance = new Encored();
    }
}
