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
        // Backing fields
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
        private int modelQuantity;
        private string engineOption;
        private string information;
        private int quantityFromName;
        private const int MIN_QUANTITY = 2;

        /// <summary>
        /// Default constructor for a model
        /// </summary>
        public Model()
        {

        }
        /// <summary>
        /// Constructor 4 for a model
        /// </summary>
        /// <param name="name"> Name of the model </param>
        /// <param name="colour"> Colour of the model </param>
        /// <param name="quantity"> Number of this type of models </param>
        public Model(string name, string colour, int quantity)        //SAME ENGINE AND ONE BODYTYPE
        {
            Regex a3 = new Regex("A3", RegexOptions.IgnoreCase);
            Regex a7 = new Regex("A7", RegexOptions.IgnoreCase);
            Regex a8 = new Regex("A8", RegexOptions.IgnoreCase);
            Regex Q5 = new Regex("Q5", RegexOptions.IgnoreCase);
            Regex Q8 = new Regex("Q8", RegexOptions.IgnoreCase);
            Regex etronGT = new Regex("e-tron GT", RegexOptions.IgnoreCase);


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
                EngineOption = Convert.ToString(Models.Engine.Fourty);
                ModelQuantity = quantity;
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
                EngineOption = Convert.ToString(Models.Engine.FiftyFive);
                ModelQuantity = quantity;
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
                EngineOption = Convert.ToString(Models.Engine.FiftyFive);
                ModelQuantity = quantity;
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
                EngineOption = Convert.ToString(Models.Engine.FourtyFive);
                ModelQuantity = quantity;
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
                EngineOption = Convert.ToString(Models.Engine.FiftyFive);
                ModelQuantity = quantity;
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
                EngineOption = Convert.ToString(Models.Engine.Electric);
                ModelQuantity = quantity;
            }
        }
        /// <summary>
        /// Constructor 2 for a model
        /// </summary>
        /// <param name="name"> Name of the model </param>
        /// <param name="colour"> Colour of the model </param>
        /// <param name="bodyType"> Body Type for the model </param>
        /// <param name="quantity"> Number of this type of models </param>
        public Model(string name, string colour, Body bodyType, int quantity)     //SAME ENGINE DIFFERENT BODY TYPE
        {
            Regex a5 = new Regex("A5", RegexOptions.IgnoreCase);
            Regex R8 = new Regex("R8", RegexOptions.IgnoreCase);
            Regex TT = new Regex("TT", RegexOptions.IgnoreCase);
            Regex etron = new Regex("^e-tron$", RegexOptions.IgnoreCase);
            Regex Q4etron = new Regex("Q4 e-tron", RegexOptions.IgnoreCase);

            
            if (a5.IsMatch(name))
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
                EngineOption = Convert.ToString(Models.Engine.FourtyFive);
                ModelQuantity = quantity;
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
                EngineOption = Convert.ToString(Models.Engine.V10);
                ModelQuantity = quantity;
            }
            else if (TT.IsMatch(name))
            {
                Name = name;
                Colour = colour;
                Horsepower = 228;
                Torque = 258;
                NumberOfSeats = 2;
                Height = 1354;
                Width = 1831;
                Length = 4191;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(bodyType);
                EngineOption = Convert.ToString(Models.Engine.FourtyFive);
                ModelQuantity = quantity;
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
                EngineOption = Convert.ToString(Models.Engine.Electric);
                ModelQuantity = quantity;
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
                EngineOption = Convert.ToString(Models.Engine.Electric);
                ModelQuantity = quantity;
            }
        }
        /// <summary>
        /// Constructor 3 for a model
        /// </summary>
        /// <param name="name"> Name of the model </param>
        /// <param name="colour"> Colour of the model </param>
        /// <param name="engineOption"> Engine option for the model </param>
        /// <param name="quantity"> Number of this type of models </param>
        public Model(string name, string colour, Engine engineOption, int quantity)      //DIFFERENT ENGINE BUT ONE BODY TYPE
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
                EngineOption = Convert.ToString(engineOption);
                ModelQuantity = quantity;
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
                EngineOption = Convert.ToString(engineOption);
                ModelQuantity = quantity;
            }
        }
        /// <summary>
        /// Constructor 4 for a model
        /// </summary>
        /// <param name="name"> Name of the model </param>
        /// <param name="colour"> Colour of the model </param>
        /// <param name="engineOption"> Engine option for the model </param>
        /// <param name="bodyType"> Body Type for the model </param>
        /// <param name="quantity"> Number of this type of models </param>
        public Model(string name, string colour, Engine engineOption, Body bodyType, int quantity)        //DIFFERENT ENGINE AND DIFFERENT BODY TYPE
        {
            Regex a4 = new Regex("A4", RegexOptions.IgnoreCase);
            Regex a6 = new Regex("A6", RegexOptions.IgnoreCase);

            if (a4.IsMatch(name)) 
            {
                Name = name;
                Colour = colour;
                if (engineOption == Engine.Fourty)
                {
                    Horsepower = 201;
                    Torque = 236;
                }
                else if (engineOption == Engine.FourtyFive)
                {
                    Horsepower = 261;
                    Torque = 273;
                }
                NumberOfSeats = 5;
                Height = 1493;
                Width = 1847;
                Length = 4762;
                FuelType = "Gasoline";
                BodyType = Convert.ToString(bodyType);
                EngineOption = Convert.ToString(engineOption);
                ModelQuantity = quantity;
            }
            else if (a6.IsMatch(name))
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
                EngineOption = Convert.ToString(engineOption);
                ModelQuantity = quantity;
            }
        }
        /// <summary>
        /// Property for the name of the model
        /// </summary>
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

                // Making sure the name is an appropriate name for an audi model
                if (!(cars.IsMatch(value) || suv.IsMatch(value) || r8.IsMatch(value) || tt.IsMatch(value) 
                    || etron.IsMatch(value) || etronGT.IsMatch(value) || Q4etron.IsMatch(value)))
                    throw new ArgumentException("Provided name is a not a valid Model name", "Name");

                name = value;
            }
        }
        /// <summary>
        /// Property for the colour of the model
        /// </summary>
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
        /// <summary>
        /// Property for the horsepower of the model
        /// </summary>
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
        /// <summary>
        /// Property for the torque of the model
        /// </summary>
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
        /// <summary>
        /// Property for number of seats of the model
        /// </summary>
        public int NumberOfSeats        //int validation might have to be implemented
        {
            get { return numberOfSeats; }
            set
            {
                // Making sure the number is an actual number of seats in an audi model
                if (value == 2 || value == 4 || value == 5 || value == 7)
                    numberOfSeats = value;
                else
                    throw new ArgumentException("Value is Invalid. Audis have only 2, 4, 5 or 7 seats.", "NumberOfSeats");
            }
        }
        /// <summary>
        /// Property for the height of the model
        /// </summary>
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
        /// <summary>
        /// Property for the width of the model
        /// </summary>
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
        /// <summary>
        /// Property for the length of the model
        /// </summary>
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
        /// <summary>
        /// Property for the fuel type for the model
        /// </summary>
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
        /// <summary>
        /// Property for the body type for the model
        /// </summary>
        public string BodyType
        {
            get { return bodyType; }
            set
            {
                if (!(value == Convert.ToString(Body.Convertible) || value == Convert.ToString(Body.Coupe) || value == Convert.ToString(Models.Body.Limousine) 
                    || value == Convert.ToString(Models.Body.SUV) || value == Convert.ToString(Models.Body.Wagon)))
                    throw new ArgumentException("Body type does not exist", "BodyType");
                bodyType = value;
            }
        }
        /// <summary>
        /// Property for the engine option for the model
        /// </summary>
        public string EngineOption
        {
            get { return engineOption; }
            set
            {
                if (!(value == Convert.ToString(Engine.FiftyFive) || value == Convert.ToString(Engine.Fourty) || value == Convert.ToString(Engine.FourtyFive)
                    || value == Convert.ToString(Engine.Electric) || (value == Convert.ToString(Engine.V10))))
                    throw new ArgumentException("Engine option does not exist", "EngineOption");
                engineOption = value;
            }
        }
        /// <summary>
        /// Property for the model quantity
        /// </summary>
        public int ModelQuantity
        {
            get { return modelQuantity; }
            set
            {
                if (value < 0) // change to constant
                    throw new ArgumentException("Quantity cannot be negative", "ModelQuantity");
                //if (value > Inventory.MaxInventorySpace || ModelQuantity + value > Inventory.MaxInventorySpace)
                    //throw new ArgumentException($"Quantity cannot exceed {Inventory.MaxInventorySpace}", "ModelQuantity");
                //if (value  > Inventory.MaxInventorySpace)
                //    throw new ArgumentException($"Quantity in Inventory List cannot exceed {Inventory.MaxInventorySpace}.", "ModelQuantity");
                modelQuantity = value;
            }
        }
        /// <summary>
        /// Data from CSV file when loading files
        /// </summary>
        public string CSVData
        {
            get
            {
                return string.Format($"{Name}, {Colour}, {EngineOption}, {BodyType}, {ModelQuantity}");
            }
            set
            {
                //string comma separated and set the fields of the visitor
                string[] allData = value.Split(',');
                try
                {
                    /*Name = allData[0];
                    Colour = allData[1];
                    EngineOption = allData[2];
                    BodyType = allData[3];
                    ModelQuantity = Convert.ToInt32(allData[4]);*/

                    Regex a4 = new Regex("A4", RegexOptions.IgnoreCase);
                    Regex a6 = new Regex("A6", RegexOptions.IgnoreCase);
                    Regex Q3 = new Regex("Q3", RegexOptions.IgnoreCase);
                    Regex Q7 = new Regex("Q7", RegexOptions.IgnoreCase);
                    Regex a5 = new Regex("A5", RegexOptions.IgnoreCase);
                    Regex R8 = new Regex("R8", RegexOptions.IgnoreCase);
                    Regex TT = new Regex("TT", RegexOptions.IgnoreCase);
                    Regex etron = new Regex("^e-tron$", RegexOptions.IgnoreCase);
                    Regex Q4etron = new Regex("Q4 e-tron", RegexOptions.IgnoreCase);
                    Regex a3 = new Regex("A3", RegexOptions.IgnoreCase);
                    Regex a7 = new Regex("A7", RegexOptions.IgnoreCase);
                    Regex a8 = new Regex("A8", RegexOptions.IgnoreCase);
                    Regex Q5 = new Regex("Q5", RegexOptions.IgnoreCase);
                    Regex Q8 = new Regex("Q8", RegexOptions.IgnoreCase);
                    Regex etronGT = new Regex("^e-tron GT$", RegexOptions.IgnoreCase);

                    Model model = null;

                    // For constructor 4
                    if (a6.IsMatch(allData[0]) || a4.IsMatch(allData[0]))
                    {
                        Enum.TryParse<Engine>(allData[2], out Engine resultEngine);
                        Enum.TryParse<Body>(allData[3], out Body resultBody);
                        model = new Model(allData[0], allData[1], resultEngine, resultBody, Convert.ToInt32(allData[4]));
                    }
                    // For constructor 3
                    else if (Q3.IsMatch(allData[0]) || Q7.IsMatch(allData[0]))
                    {
                        Enum.TryParse<Engine>(allData[2], out Engine resultEngine);
                        model = new Model(allData[0], allData[1], resultEngine, Convert.ToInt32(allData[4]));
                    }
                    // For constructor 2
                    else if (a5.IsMatch(allData[0]) || R8.IsMatch(allData[0]) || TT.IsMatch(allData[0]) 
                        || etron.IsMatch(allData[0]) || Q4etron.IsMatch(allData[0]))
                    {
                        Enum.TryParse<Body>(allData[3], out Body resultBody);
                        model = new Model(allData[0], allData[1], resultBody, Convert.ToInt32(allData[4]));
                    }
                    // For constructor 1
                    else if (a3.IsMatch(allData[0]) || a7.IsMatch(allData[0]) || a8.IsMatch(allData[0]) 
                        || Q5.IsMatch(allData[0]) || Q8.IsMatch(allData[0]) || etronGT.IsMatch(allData[0]))
                    {
                        model = new Model(allData[0], allData[1], Convert.ToInt32(allData[4]));
                    }
                    else if (string.IsNullOrEmpty(allData[0]))
                        return;

                    Inventory.AddItem(model, true);


                    /*if (a6.IsMatch(allData[0]))
                    {
                        Model model = new Model();
                    }*/

                    /*Engine tryParseResult1;
                    Body tryParseResult2;

                    Name = allData[0];
                    Colour = allData[1];
                    if (Enum.TryParse<Engine>(allData[2], out tryParseResult1) && tryParseResult1 == Engine.FourtyFive)
                    {
                        Horsepower = 261;
                        Torque = 273;
                    }
                    else if (Enum.TryParse<Engine>(allData[2], out tryParseResult1) && tryParseResult1 == Engine.FiftyFive)
                    {
                        Horsepower = 335;
                        Torque = 369;
                    }
                    NumberOfSeats = 5;
                    if (Enum.TryParse<Body>(allData[3], out tryParseResult2) && tryParseResult2 == Body.Limousine)
                    {
                        Height = 1457;
                        Width = 1886;
                        Length = 4939;
                    }
                    else if (Enum.TryParse<Body>(allData[3], out tryParseResult2) && tryParseResult2 == Body.Wagon)
                    {
                        Height = 1497;
                        Width = 1902;
                        Length = 4951;
                    }
                    FuelType = "Gasoline";
                    BodyType = Convert.ToString(tryParseResult2);
                    EngineOption = Convert.ToString(tryParseResult1);
                    ModelQuantity = Convert.ToInt32(allData[4]);*/

                }
                catch (Exception ex)
                {
                    throw new Exception("All Data Property value not valid " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Displaying full info for the model
        /// </summary>
        public string FullInfo
        {
            get
            {
                return string.Format(
                "{0,-20}" + Name + "\n" +
                "{1,-21}" + Colour + "\n" +
                "{2,-21}" + Horsepower + "\n" +
                "{3,-21}" + Torque + "\n" +
                "{4,-20}" + NumberOfSeats + "\n" +
                "{5,-21}" + Height + "\n" +
                "{6,-20}" + Width + "\n" +
                "{7,-20}" + Length,
                "{8,-20}" + FuelType,
                "{9,-20}" + BodyType,
                "{10,-20}" + EngineOption,
                "{11,-20}" + ModelQuantity,
                "Name:", "Colour:", "Horsepower:", "Torque:", "NumberOfSeats:", "Height:",
                "Width:", "Length:", "FuelType:", "BodyType:", "EngineOption:", "ModelQuantity:");
            }
        }
        public string Information
        {
            get { return information; }
            set { information = value;  }
        }
        public int QuantityFromName
        {
            get { return quantityFromName; }
            set { quantityFromName = value; }
        }

        public int AvailableQuantity()
        {
            return ModelQuantity;
        }

        public bool MinimumQuanitity(Model model)
        {
            int counter = GetMinimumQuantity(model);

            if (counter >= 2) //constant
                return true;
            else
                return false;
        }
        public static int GetMinimumQuantity(Model model)
        {
            int counter = 0;
            for (int i = 0; i < Inventory.InventoryList.Count; i++)
            {
                if (Inventory.InventoryList[i].Name == model.Name)
                {
                    counter++;
                }
            }
            return counter;
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
        FiftyFive,
        V10,
        Electric
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
