﻿using iRTVO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRTVO.Data
{
    public class DriverInfo : IDriverInfo
    {
        string name;
        string initials;
        string shortname;

        string club;
        string sr;
        string numberPlate;
        string carclassname;

        int irating;
        int caridx;
        int userId;
        int teamId;        // KJ:
        string teamName;   // KJ:
        int carId;
        int carclass;

        public DriverInfo()
        {
            name = "";
            initials = "";
            shortname = "";

            club = "";
            sr = "";
            carclass = 0;
            carclassname = "";

            caridx = -1;
            userId = 0;
            carId = 0;
            numberPlate = "0";
            // KJ: teamid and teamname
            teamId = 0;
            teamName = "";
        }

        public string Name { get { return name; } set { name = value; } }
        public string Initials { get { return initials; } set { initials = value; } }
        public string Shortname { get { return shortname; } set { shortname = value; } }

        public string Club { get { return club; } set { club = value; } }
        public string SR { get { return sr; } set { sr = value; } }
        public int iRating { get { return irating; } set { irating = value; } }
        public string NumberPlate { get { return numberPlate; } set { numberPlate = value; } }
        public int NumberPlateInt { get { if (numberPlate != null) return Int32.Parse(numberPlate); else return 0; } }
        public int NumberPlatePadded { get { if (numberPlate != null) return Utils.padCarNum(numberPlate); else return -1; } }

        public int CarIdx { get { return caridx; } set { caridx = value; } }
        public int UserId { get { return userId; } set { userId = value; } }
        public int CarId { get { return carId; } set { carId = value; } }
        public int CarClass { get { return carclass; } set { carclass = value; } }
        public string CarClassName { get { return carclassname; } set { carclassname = value; } }
        // KJ: teamid and teamname
        public int TeamId { get { return teamId; } set { teamId = value; } }
        public string TeamName { get { return teamName; } set { teamName = value; } }

        public string[] ExternalData
        {
            get
            {
                if (SharedData.externalData.ContainsKey(UserId))
                    return SharedData.externalData[UserId];
                return new string[20]; // Should be enough
            }
        }

        public int CarClassOrder
        {
            get
            {
                if (SharedData.ClassOrder.ContainsKey(carclassname))
                    return SharedData.ClassOrder[carclassname] * 100;
                else
                    return 100;
            }
            set { }
        }

        

    }
}
