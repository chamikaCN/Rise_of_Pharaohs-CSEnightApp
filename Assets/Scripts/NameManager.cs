using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;

namespace Assets.Scripts
{
    public class NameManager : MonoBehaviour
    {
        Dictionary<int, string> nameReferance;

        public void addItems()
        {
            nameReferance = new Dictionary<int, string>();
            nameReferance.Add(180396, "diCyanide iurghjn");
            nameReferance.Add(180285, "dgavafabe anetRSNRAERGEAR");
            nameReferance.Add(180112, "ADSfAEGAW isgrgregjn");
        }

        public string getName(int index)
        {
            string sender = "";
            if (nameReferance.ContainsKey(index))
            {
                sender = nameReferance[index];
            }
            return sender;
        }

    }
}
