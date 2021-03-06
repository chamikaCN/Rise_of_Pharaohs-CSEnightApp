﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    static class GameManager
    {
        static God[] GodList;
        static int GroupID;
        static string IndexNo;
        static bool completed = false;
        static int initial = 0;
        static notificationManager NM = new notificationManager();
        static NameManager NameM = new NameManager();

        public static void createGods()
        {
            GodList = new God[4];

            //HORUS-11045
            God Horus = new God();
            Horus.groupID = 1;
            Horus.GodName = "horus";
            Horus.GodPronoun1 = "god";
            Horus.GodPronoun2 = "him";
            Horus.GodTitle = "protector of egypt";
            Horus.GodVenue = "goda uda";
            Horus.GodDescription = "Horus was the god of the sky and also the God of war. The pharaoh ruling at any given time of Egypt was always the living image of Horus ";
            GodList[0] = Horus;

            //BASTET
            God Bastet = new God();
            Bastet.groupID = 2;
            Bastet.GodName = "bastet";
            Bastet.GodPronoun1 = "goddess";
            Bastet.GodPronoun2 = "her";
            Bastet.GodTitle = "protector of people";
            Bastet.GodVenue = "goda yata";
            Bastet.GodDescription = "Bast is the goddess of protection and blessing,and was the protectress of women, children, and domestic cats";
            GodList[1] = Bastet;

            //OSIRIS
            God Osiris = new God();
            Osiris.groupID = 3;
            Osiris.GodName = "osiris";
            Osiris.GodPronoun1 = "god";
            Osiris.GodPronoun2 = "him";
            Osiris.GodTitle = "lord of the underworld";
            Osiris.GodVenue = "food court";
            Osiris.GodDescription = "Osiris is the Egyptian Lord of the Underworld and Judge of the Dead, brother - husband to Isis, and one of the most important gods of ancient Egypt.";
            GodList[2] = Osiris;

            //ANUBIS
            God Anubis = new God();
            Anubis.groupID = 4;
            Anubis.GodName = "anubis";
            Anubis.GodPronoun1 = "god";
            Anubis.GodPronoun2 = "him";
            Anubis.GodTitle = "god of death";
            Anubis.GodVenue = "sumanadasa gr.floor";
            Anubis.GodDescription = "Anubis, as the god of death and the afterlife, was closely associated with mummification and burial rites.";
            GodList[3] = Anubis;
        }

        public static God getGodInfo(int groupid)
        {
            return GodList[groupid - 1];
        }

        public static void ReceiveSavedData()
        {
            initial = PlayerPrefs.GetInt("Initial",0);
            NameM = new NameManager();
            NameM.addItems();
            GroupID = PlayerPrefs.GetInt("Group ID",1);
            IndexNo = PlayerPrefs.GetString("IndexNo","180996");
            completed = false;
        }

        public static void SaveData()
        {
            if (initial == 0)
            {
                initial = 1;
                PlayerPrefs.SetInt("Initial", initial);
            }
            PlayerPrefs.SetInt("Group ID", GroupID);
            PlayerPrefs.SetString("IndexNo", IndexNo);
        }

        public static string getName(int index)
        {
            return NameM.getName(index);
        }

        public static char getGender(int index)
        {
            return NameM.getGender(index);
        }

        public static int getGroupID()
        {
            return GroupID;
        }

        public static string getIndexNo()
        {
            return IndexNo;
        }

        public static void setGroupID(int id)
        {
            GroupID = id;
        }

        public static void setIndexNo(string no)
        {
            IndexNo = no;
        }

        public static void setComplete()
        {
            completed = true;
        }

        public static bool getIsCompleted()
        {
            return completed;
        }

        public static int getInitial()
        {
            return initial;
        }

        public static bool getNameAvailable(int index)
        {
            return NameM.isInNameReferance(index);
        }

        public static void sendTesting()
        {
            // NM.sendRemindNotification(new DateTime(2019, 10, 2, 23, 50, 00));
            // NM.sendRemindNotification(new DateTime(2019, 10, 2, 23, 55, 00));
            // NM.sendRemindNotification(new DateTime(2019, 10, 3, 00, 00, 00));
            // NM.sendRemindNotification(new DateTime(2019, 10, 3, 00, 05, 00));
        }
    }
}
