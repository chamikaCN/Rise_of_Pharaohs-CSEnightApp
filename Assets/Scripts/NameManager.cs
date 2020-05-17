using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;

namespace Assets.Scripts
{
    public class NameManager
    {
        Dictionary<int, string> nameReferance;

        public void addItems()
        {
            nameReferance = new Dictionary<int, string>();

			nameReferance.Add(180996, "MTesting Name1");
			nameReferance.Add(180997, "FTesting Name2");
			nameReferance.Add(180998, "MTesting Name3");
			nameReferance.Add(180999, "FTesting Name4");

        }

        public string getName(int index)
        {
            string sender = "";
            if (nameReferance.ContainsKey(index))
            {
                string newsender = nameReferance[index];
                sender = newsender.Substring(1); 
            }
            return sender;
        }

        public char getGender(int index)
        {
            char sender1 = ' ';
            if (nameReferance.ContainsKey(index))
            {
                string newsender = nameReferance[index];
                sender1 = newsender[0]; 
            }
            return sender1;
        }

        public bool isInNameReferance(int index){
            return nameReferance.ContainsKey(index);
        }

    }
}
