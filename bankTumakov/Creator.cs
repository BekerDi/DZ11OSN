using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankTumakov
{
    internal class Creator
    {

        private static Dictionary<int, Building> buildingList = new Dictionary<int, Building>();

        private Creator() { }

        public static Building CreateBuilding(int number, string name)
        {
            Building building = new Building
            {
                BuildingNumber = number,
                BuildingName = name
            };
            buildingList.Add(number, building);
            return building;
        }

        public static Building CreateBuilding(int number)
        {
            Building building = new Building
            {
                BuildingNumber = number,
                BuildingName = "Имя"
            };
            buildingList.Add(number, building);
            return building;
        }

        public static void RemoveBuilding(int number)
        {
            if (buildingList.ContainsKey(number))
            {
                buildingList.Remove(number);
            }
        }
    }
}
