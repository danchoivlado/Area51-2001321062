using System;
using System.Collections.Generic;
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


        }
    }
}
