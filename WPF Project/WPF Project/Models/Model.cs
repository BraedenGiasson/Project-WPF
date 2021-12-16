using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using WPF_Project.Interfaces;

namespace WPF_Project.Models
{
    public class Model : IQuantity
    {
        private string name;
        private string colour;
        private int horsepower;
        private int torque;
        private int numberOfSeats;
        private double height;
        private double width;
        private double length;
        private string fuelType;
        private string bodyType;
        //private string engineOption;                          MIGHT HAVE TO BE IMPLEMENTED LATER!!!

        private static readonly string makeName = "Audi";
        private static readonly string makeCountry = "Germany";
        private static readonly string makeCategory = "luxury";

        private List<Regex> listForConstructorWith2Arguments; // delete maybe

        public Model(string name, string colour)        //SAME ENGINE AND ONE BODYTYPE
        {
            Regex a3 = new Regex("A3", RegexOptions.IgnoreCase);
            Regex a7 = new Regex("A7", RegexOptions.IgnoreCase);
            Regex a8 = new Regex("A8", RegexOptions.IgnoreCase);
            Regex Q5 = new Regex("Q5", RegexOptions.IgnoreCase);
            Regex Q8 = new Regex("Q8", RegexOptions.IgnoreCase);
            Regex etronGT = new Regex("e-tron GT", RegexOptions.IgnoreCase);

            listForConstructorWith2Arguments = new List<Regex>()
            { a3, a7, a8, Q5, Q8 };

            if (a3.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 201;
                Torque = 221;
                NumberOfSeats = 5;
                Height = 1415;
                Width = 1796;
                Length = 4458;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(Models.Body.Limousine);
            }
            else if (a7.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 335;
                Torque = 369;
                NumberOfSeats = 5;
                Height = 1422;
                Width = 1908;
                Length = 4969;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(Models.Body.Limousine);
            }
            else if (a8.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 335;
                Torque = 369;
                NumberOfSeats = 5;
                Height = 1485;
                Width = 1945;
                Length = 5302;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(Models.Body.Limousine);
            }
            else if (Q5.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 228;
                Torque = 258;
                NumberOfSeats = 5;
                Height = 1657;
                Width = 1898;
                Length = 4663;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(Models.Body.SUV);
            }
            else if (Q8.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 335;
                Torque = 369;
                NumberOfSeats = 5;
                Height = 1749;
                Width = 1995;
                Length = 5005;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(Models.Body.SUV);
            }
            else if (etronGT.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 469;
                Torque = 465;
                NumberOfSeats = 5;
                Height = 1413;
                Width = 1964;
                Length = 4989;
                FuelType = "Electric";
                BodyType = Convert.ToString(Models.Body.Limousine);
            }
        }

        public List<Regex> ListForConstructorWith2Arguments
        {
            get { return listForConstructorWith2Arguments; }
        }

        public Model(string name, string colour, Body bodyType)     //SAME ENGINE DIFFERENT BODY TYPE
        {
            Regex a4 = new Regex("A4", RegexOptions.IgnoreCase);
            Regex a5 = new Regex("A5", RegexOptions.IgnoreCase);
            Regex R8 = new Regex("R8", RegexOptions.IgnoreCase);
            Regex TT = new Regex("TT", RegexOptions.IgnoreCase);
            Regex etron = new Regex("e-tron", RegexOptions.IgnoreCase);
            Regex Q4etron = new Regex("Q4 e-tron", RegexOptions.IgnoreCase);

            if (a4.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 201;
                Torque = 236;
                NumberOfSeats = 5;
                Height = 1493;
                Width = 1847;
                Length = 4762;
                FuelType = "Gasoline";
                //BodyType = Convert.ToString(bodyType);

                if (bodyType == Body.Limousine)
                    BodyType = Convert.ToString(bodyType);
                else if (bodyType == Body.Wagon)
                    BodyType = Convert.ToString(bodyType);
                else
                    throw new ArgumentException($"Error: That option is invalid for model name of type {Name}");
            }
            else if (a5.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 261;
                Torque = 273;
                if (bodyType == Models.Body.Convertible || bodyType == Models.Body.Coupe)
                    NumberOfSeats = 4;
                else
                    NumberOfSeats = 5;
                Height = 1387;
                Width = 1844;
                Length = 4755;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(bodyType);
            }
            else if (R8.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 602;
                Torque = 413;
                NumberOfSeats = 2;
                Height = 1252;
                Width = 1940;
                Length = 4429;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(bodyType);
            }
            else if (TT.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 602;
                Torque = 413;
                NumberOfSeats = 2;
                Height = 1252;
                Width = 1940;
                Length = 4429;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(bodyType);
            }
            else if (etron.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 355;
                Torque = 414;
                NumberOfSeats = 5;
                Height = 1632;
                Width = 1935;
                Length = 4901;
                FuelType = "Electric";
                BodyType = Convert.ToString(bodyType);
            }
            else if (Q4etron.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 295;
                Torque = 339;
                NumberOfSeats = 5;
                Height = 1643;
                Width = 1865;
                Length = 4588;
                FuelType = "Electric";
                BodyType = Convert.ToString(bodyType);
            }
        }


        public Model(string name, string colour, Engine engineOption)      //DIFFERENT ENGINE BUT ONE BODY TYPE
        {

            Regex Q3 = new Regex("Q3", RegexOptions.IgnoreCase);
            Regex Q7 = new Regex("Q7", RegexOptions.IgnoreCase);


            if (Q3.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                if (engineOption == Engine.Fourty)
                {
                    Horsepower = 184;
                    Torque = 221;
                }
                else if (engineOption == Engine.FourtyFive)
                {
                    Horsepower = 228;
                    Torque = 258;
                }
                NumberOfSeats = 5;
                Height = 1640;
                Width = 1849;
                Length = 4485;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(Models.Body.SUV);
            }
            else if (Q7.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                if (engineOption == Engine.FourtyFive)
                {
                    Horsepower = 248;
                    Torque = 273;
                }
                else if (engineOption == Engine.FiftyFive)
                {
                    Horsepower = 335;
                    Torque = 369;
                }
                NumberOfSeats = 7;
                Height = 1781;
                Width = 1970;
                Length = 5067;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(Models.Body.SUV);
            }
        }




        public Model(string name, string colour, Engine engineOption, Body bodyType)        //DIFFERENT ENGINE AND DIFFERENT BODY TYPE
        {
            Regex a6 = new Regex("A6", RegexOptions.IgnoreCase);
            
            if (a6.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                if (engineOption == Engine.FourtyFive)
                {
                    Horsepower = 261;
                    Torque = 273;
                }
                else if (engineOption == Engine.FiftyFive)
                {
                    Horsepower = 335;
                    Torque = 369;
                }
                NumberOfSeats = 5;
                if (bodyType == Models.Body.Limousine)
                {
                    Height = 1457;
                    Width = 1886;
                    Length = 4939;
                }
                else if (bodyType == Models.Body.Wagon)
                {
                    Height = 1497;
                    Width = 1902;
                    Length = 4951;
                }
                FuelType = "Gasoline";
                BodyType = Convert.ToString(bodyType);
            }
        }



        public string Name
        {
            get { return name; }
            set
            {
                Regex cars = new Regex("^[A][3-8]{1}$", RegexOptions.IgnoreCase);
                Regex suv = new Regex("^[Q][3,5,7,8]", RegexOptions.IgnoreCase);
                Regex r8 = new Regex("^[R][8]$", RegexOptions.IgnoreCase);
                Regex tt = new Regex("^[T]{2}$", RegexOptions.IgnoreCase);
                Regex etron = new Regex("e-tron", RegexOptions.IgnoreCase);
                Regex etronGT = new Regex("e-tron GT", RegexOptions.IgnoreCase);
                Regex Q4etron = new Regex("Q4 e-tron", RegexOptions.IgnoreCase);


                if (!(cars.IsMatch(value) || suv.IsMatch(value) || r8.IsMatch(value) || tt.IsMatch(value) || etron.IsMatch(value) || etronGT.IsMatch(value) || Q4etron.IsMatch(value)))
                    throw new ArgumentException("Provided name is a not a valid Model name", "Name");

                name = value;
            }
        }

        public string Colour
        {
            get { return colour; }
            set
            {
                if (value.ToString().Any(char.IsDigit) || string.IsNullOrWhiteSpace(value.ToString()))
                    throw new ArgumentException("Value has to be a string of letters", "Colour");
                colour = value;
            }
        }

        public int Horsepower
        {
            get { return horsepower; }
            set
            {
                if (value.ToString().Any(char.IsLetter))
                    throw new ArgumentException("Value has to be an integer", "Horsepower");
                horsepower = value;
            }
        }

        public int Torque
        {
            get { return torque; }
            set
            {
                if (value.ToString().Any(char.IsLetter))
                    throw new ArgumentException("Value has to be an integer", "Torque");
                torque = value;
            }
        }

        public int NumberOfSeats        //int validation might have to be implemented
        {
            get { return numberOfSeats; }
            set
            {
                if (value == 2 || value == 4 || value == 5 || value == 7)
                    numberOfSeats = value;
                else
                    throw new ArgumentException("Value is Invalid. Audis have 2, 4, 5 or 7 seats.", "NumberOfSeats");
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value.ToString().Any(char.IsLetter))
                    throw new ArgumentException("Height has to be a numeric value", "Height");
                height = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value.ToString().Any(char.IsLetter))
                    throw new ArgumentException("Width has to be a numeric value", "Width");
                width = value;
            }
        }

        public double Length
        {
            get { return length; }
            set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value.ToString().Any(char.IsLetter))
                    throw new ArgumentException("Length has to be a numeric value", "Length");
                length = value;
            }
        }

        public string FuelType
        {
            get { return fuelType; }
            set
            {
                if (!(value.ToString() == "Gasoline" || value.ToString() == "Electric"))
                    throw new ArgumentException("FuelType has to be either 'Gasoline' or 'Electric'", "FuelType");
                fuelType = value;
            }
        }

        public string BodyType
        {
            get { return bodyType; }
            set
            {
                if (!(value == Convert.ToString(Body.Convertible) || value == Convert.ToString(Body.Coupe) || value == Convert.ToString(Models.Body.Limousine) || value == Convert.ToString(Models.Body.SUV) || value == Convert.ToString(Models.Body.Wagon)))
                    throw new ArgumentException("Body type does not exist", "BodyType");
                bodyType = value;
            }
        }
        //ALSO IMPLEMEMENT LATER
        /*public string EngineOption
        {
            set
            {
                if (!(value == Convert.ToString(Engine.FiftyFive) || value == Convert.ToString(Engine.Fourty) || value == Convert.ToString(Engine.FourtyFive)))
                    throw new ArgumentException("Engine option does not exist", "EngineOption");
                engineOption = value;
            }
        }*/

        public static string MakeName
        {
            get { return makeName; }
        }

        public static string MakeCountry
        {
            get { return makeCountry; }
        }

        public static string MakeCategory
        {
            get { return makeCategory; }
        }


        /*private string name;
        private string colour;
        private int horsepower;
        private int torque;
        private int numberOfSeats;
        private double height;
        private double width;
        private double length;
        private string fuelType;
        private string bodyType;*/





        //Might be needed for reading and writing to file

        /*public string CSVData
        {
            get
            {
                return string.Format($"{Name}, {Colour}, {EngineOption}, {BodyType}");
            }
            set
            {
                //string comma separated and set the fields of the visitor
                string[] allData = value.Split(',');
                try
                {
                    Name = allData[0];
                    Colour = allData[1];
                    EngineOption = allData[2];
                    BodyType = allData[3];
                }
                catch (Exception ex)
                {
                    throw new Exception("All Data Property value not valid " + ex.Message);
                }
            }
        }*/

        public int AvailableQuantity()
        {
            throw new NotImplementedException();
        }

        public int MinimumQuanitity()
        {
            throw new NotImplementedException();
        }

        public bool QuantityIsValid()
        {
            throw new NotImplementedException();
        }
    }



    /// <summary>
    /// Enum options for the car Body Type
    /// </summary>
    public enum Body
    {
        Convertible,
        SUV,
        Coupe,
        Limousine,
        Wagon
    }

    /// <summary>
    /// Enum options for the car Engine Type
    /// </summary>
    public enum Engine
    {
        Fourty,
        FourtyFive,
        FiftyFive
    }


    /// <summary>
    /// Enum options for Colour of vehicle
    /// </summary>
    public enum Colour
    {
        Black,
        White,
        Blue,
        Red,
        Grey,
        Yellow
    }
}
