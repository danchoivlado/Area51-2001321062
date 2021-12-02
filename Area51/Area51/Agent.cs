using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Area51
{
    public class Agent
    {
        public string name { get; set; }
        public Base @base { get; set; }
        public Credential credential { get; set; }
        enum Acitity { VisitFloor, Leave }
        Random random = new Random();
        private Floor currentFloor;

        public Agent(string name, Credential credential, Base @base)
        {
            this.name = name;
            this.credential = credential;
            this.@base = @base;
        }

        private Acitity GetRandomAcivity()
        {
            int n = random.Next(10);
            if (n < 8) return Acitity.VisitFloor;
            return Acitity.Leave;
        }

        private Floor GetRandomFloor()
        {
            var floors = this.@base.floors;
            return floors[random.Next(0, floors.Count())];
        }

        public void InvadeBuilding()
        {
            bool isInTheBuilding = true;
            this.currentFloor = this.@base.floors.First(x => x.name == "G");
            while (isInTheBuilding)
            {
                var nextActivity = GetRandomAcivity();

                switch (nextActivity)
                {
                    case Acitity.VisitFloor:
                        Floor destinationFloor = this.GetRandomFloor();
                        this.CallElevator(destinationFloor);
                        var result = this.@base.elevator.Enter(this.credential, destinationFloor);
                        if (result)
                        {
                            Console.WriteLine($"Agent with name {this.name} is on floor ${destinationFloor.name}");
                            this.currentFloor = destinationFloor;
                        }
                        else
                        {
                            Console.WriteLine($"Agent with name {this.name} dont have the credential to go on floor ${destinationFloor.name}");
                        }
                        break;
                    case Acitity.Leave:
                        Console.WriteLine($"$Agent with name {this.name} is leaving the building");
                        isInTheBuilding = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void CallElevator(Floor destinationFloor)
        {
            while (this.@base.elevator.currentFloor.name != destinationFloor.name)
            {
                Wait();
                this.@base.elevator.CallElevatorOnFloor(destinationFloor);
            }
        }

        private void Wait()
        {
            Thread.Sleep(1000);
        }
    }
}
