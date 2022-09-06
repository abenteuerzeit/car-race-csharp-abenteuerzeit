using Codecool.CarRace.Util;

namespace Codecool.CarRace.Vehicles
{
    public class Car : Vehicle
    {
        protected const int YELLOW_FLAG_SPEED = 75;
        private static readonly string[] POSSIBLE_NAMES =
        {
        "Epiphany",
        "Parallel",
        "Blitz",
        "Eos",
        "Evolution",
        "Wolf",
        "Union",
        "Empyrean",
        "Curiosity",
        "Gallop",
        };

        public Car() : base(CalculateNormalSpeed())
        { }

        private static int CalculateNormalSpeed()
        {
            return RandomHelper.NextInt(80, 110 + 1);
        }

        protected override string GenerateName()
        {
            return $"{GetName()} {GetName()}";
        }
        private string GetName() => RandomHelper.ChooseOne(POSSIBLE_NAMES);

        public override void PrepareForLap(Race race)
        {
            if (race.IsThereABrokenTruck)
            {
                ActualSpeed = YELLOW_FLAG_SPEED;
            }
            else
            {
                ActualSpeed = NormalSpeed;
            }
        }
    }
}
