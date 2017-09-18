using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDoors.Model
{
    public class ModelDoor
    {
        private string name;
        private double price;
        private string picture;

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return String.Format($"{name} {price} {picture}");
        }
    }
}
