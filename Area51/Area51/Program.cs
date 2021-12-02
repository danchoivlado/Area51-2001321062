using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Area51
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            Button gButton = new Button("G");
            Button sButton = new Button("S");
            Button t1Button = new Button("T1");
            Button t2Button = new Button("T2");

            Floor groundFloor = new Floor("G",gButton);
            Floor nuclearWeaponsFloor = new Floor("S",sButton);
            Floor experimentalWeaponsFloor = new Floor("T1",t1Button);
            Floor alienRemainsFloor = new Floor("T2",t2Button);

            Credential confidential = new Credential("Confidential", new List<Floor>() {
                groundFloor 
            });
            Credential secret = new Credential("Secret", new List<Floor>() {
                groundFloor, 
                nuclearWeaponsFloor 
            });
            Credential top_secret = new Credential("Top-secret", new List<Floor>() 
            { 
                groundFloor, 
                nuclearWeaponsFloor,
                experimentalWeaponsFloor,
                alienRemainsFloor,
            });

            
            Elevator elevator = new Elevator(new List<Button>() {
                gButton,
                sButton,
                t1Button,
                t2Button
            },groundFloor);

            Base @base = new Base(new List<Floor>() {
                groundFloor,
                nuclearWeaponsFloor,
                experimentalWeaponsFloor,
                alienRemainsFloor
            }, elevator);


            List<Thread> studentThreads = new List<Thread>();
                var agent1 = new Agent($"Alfredo",confidential, @base);
            var agent2 = new Agent($"Mernando", secret, @base);
            var agent3 = new Agent($"Almir", top_secret, @base);
            var thread1 = new Thread(agent1.InvadeBuilding);
            var thread2 = new Thread(agent2.InvadeBuilding);
            var thread3 = new Thread(agent3.InvadeBuilding);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            studentThreads.AddRange(new List<Thread>() { thread1,thread3});

            foreach (var t in studentThreads) t.Join();
        }
    }
}
