using System.Text;

namespace Codecool.CarRace.Vehicles
{
    public abstract class Vehicle
    {
        protected string Name { get; } = "Vehicle";
        protected int NormalSpeed { get; } = 100;
        protected int ActualSpeed { get; set; }

        public int DistanceTravelled { get; set; }
        protected Vehicle(int normalSpeed)
        {
            Name = GenerateName();
            NormalSpeed = normalSpeed;
        }

        protected abstract string GenerateName();
        public abstract void PrepareForLap(Race race);
        public void MoveForAnHour()
        {
            DistanceTravelled += ActualSpeed * 1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("{type: ")
            .Append(GetType().Name)
            .Append(", ")
            .Append("name: ")
            .Append(Name)
            .Append(", ")
            .Append("distance travelled: ")
            .Append(DistanceTravelled)
            .Append("}");
            return sb.ToString();


        }
    }
}
