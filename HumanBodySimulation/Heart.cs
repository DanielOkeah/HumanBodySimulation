using System;
using System.Collections.Generic;

namespace HumanBodySimulation
{
    // Define the Organ base class
    public abstract class Organ
    {
        public abstract void Update(int n);
    }

    // Define the interface for the heart
    public interface IHeart
    {
        double HeartRate { get; set; }
        double StrokeVolume { get; set; }
        double AverageSPO2 { get; set; }
        double MinSystolicPressure { get; set; }
        double MaxSystolicPressure { get; set; }
        double MinDiastolicPressure { get; set; }
        double MaxDiastolicPressure { get; set; }
        double BiggestO2Desaturation { get; set; }
        double AverageO2Desaturation { get; set; }
        double MaximumHR { get; set; }
        double MinimumHR { get; set; }

        double GetBloodPumped();
        double GetHeartRateVariability();
    }

    

    // Implement the Heart class
    public class Heart : Organ, IHeart, IOrgan
    {
        // Existing properties
        private double _heartRate;
        private double _strokeVolume;
        private double _lastBloodPumped;

        // New properties
        public double AverageSPO2 { get; set; }
        public double MinSystolicPressure { get; set; }
        public double MaxSystolicPressure { get; set; }
        public double MinDiastolicPressure { get; set; }
        public double MaxDiastolicPressure { get; set; }
        public double BiggestO2Desaturation { get; set; }
        public double AverageO2Desaturation { get; set; }
        public double MaximumHR { get; set; }
        public double MinimumHR { get; set; }

        // Existing methods
        public double HeartRate
        {
            get { return _heartRate; }
            set { _heartRate = value; }
        }

        public double StrokeVolume
        {
            get { return _strokeVolume; }
            set { _strokeVolume = value; }
        }

        public override void Update(int n)
        {
            double beatsSinceLastUpdate = (HeartRate / 60) * (n / 1000.0);
            _lastBloodPumped = beatsSinceLastUpdate * StrokeVolume;
        }

        public double GetBloodPumped()
        {
            return _lastBloodPumped;
        }

        // New method to calculate Heart Rate Variability (HRV)
        public double GetHeartRateVariability()
        {
            return MaximumHR - MinimumHR;
        }

        public void init(Dictionary<string, string> parameters)
        {
            // Initialize heart parameters here
            // Example: HeartRate = double.Parse(parameters["heartRate"]);
            // Add other initializations as needed
        }

        public void update(int n, Dictionary<string, string> parameters)
        {
            // Update heart based on simulation step size
            Update(n); // Use the existing Update method
        }
    }
}