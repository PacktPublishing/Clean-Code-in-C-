using System;

namespace CH3.Encapsulation
{
    /// <summary>
    /// Car object.
    /// </summary>
    public class Car
    {
        private string _make;
        private string _model;
        private int _year;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="make">Car make.</param>
        /// <param name="model">Car model.</param>
        /// <param name="year">Year car make and model manufactured.</param>
        public Car(string make, string model, int year)
        {
            _make = ValidateMake(make);
            _model = ValidateModel(model);
            _year = ValidateYear(year);
        }

        private string ValidateMake(string make)
        {
            if (make.Length >= 3)
                return make;
            throw new ArgumentException("Make must be three characters or more.");
        }

        private string ValidateModel(string model)
        {
            if (model.Length >= 2)
                return model;
            throw new ArgumentException("Model must be three characters or more.");
        }

        private int ValidateYear(int year)
        {
            if (year > 1885 && year <= DateTime.Now.Year + 1)
                return year;
            throw new ArgumentException($"Year must be between 1885 and {DateTime.Now.Year + 1}");
        }

        /// <summary>
        /// Gets and sets the car make.
        /// </summary>
        public string Make
        {
            get { return _make; }
            set { _make = ValidateMake(value);  }
        }

        /// <summary>
        /// Gets and sets the car model.
        /// </summary>
        public string Model
        {
            get { return _model; }
            set { _model = ValidateModel(value); }
        }

        /// <summary>
        /// Gets and sets the year the car was manufactured.
        /// </summary>
        public int Year
        {
            get { return _year; }
            set { _year = ValidateYear(value); }
        }
    }
}
