using Codecool.CarRace.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CarRace
{
    /// <summary>
    /// This class has methods with different forms of greetings.
    /// </summary>
    public class Race
    {
        private readonly List<Vehicle> _vehicles = new();
        private Weather _weather = new Weather();
        private static readonly int NUM_OF_LAPS = 50;
        public bool IsRaining => _weather.IsRaining;
        public bool IsThereABrokenTruck { get; private set; }
        /// <summary>
        /// Simulates the passing of time by advancing the weather and
        /// moving the vehicles for the duration of a whole race.
        /// </summary>
        public void SimulateRace()
        {
            for (int i = 0; i < NUM_OF_LAPS; i++)
            {
                foreach (Vehicle vehicle in _vehicles)
                {
                    vehicle.PrepareForLap(this);
                    vehicle.MoveForAnHour();
                }

                // change weather and update broken truck status after the movement done
                _weather.Randomize();
                IsThereABrokenTruck = GetBrokenTruckStatus();
                // TODO: check if a yellow flag should be active
            }
        }

        private bool GetBrokenTruckStatus()
        {
            foreach (Vehicle vehicle in _vehicles)
            {
                if (vehicle is Truck)
                {
                    Truck truck = (Truck)vehicle;
                    if (truck.IsBrokenDown)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //private bool GetBrokenTruckStatusLINQ()
        //{
        //    return _vehicles
        //        .FindAll(v => v.GetType() == typeof(Truck))
        //        .Select(v => (Truck)v)
        //        .Any(t => t.IsBrokenDown);
        //}

        //private bool GetBrokenTruckStatusLINQ()
        //{
        //    return _vehicles.OfType<Truck>().Any(truck => truck.IsBrokenDown);
        //}



        /// <summary>
        /// Prints the state of all vehicles. Called at the end of the
        /// race.
        /// </summary>
        public void PrintRaceResults()
        {
            foreach (var vehicle in _vehicles.OrderByDescending(x => x.DistanceTravelled))
                Console.WriteLine(vehicle);
        }

        internal void RegisterRacer(Vehicle racer)
        {
            _vehicles.Add(racer);
        }
    }
}
