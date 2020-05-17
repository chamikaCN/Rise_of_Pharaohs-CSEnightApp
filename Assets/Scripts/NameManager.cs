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
            // nameReferance.Add(180003, "MNuwan Abeynayake");
            // nameReferance.Add(180007, "MPasindu Abeysinghe");
            // nameReferance.Add(180009, "MNagitha Abeywickrema");
            // nameReferance.Add(180012, "MKavindu Adhikari");
            // nameReferance.Add(180022, "MLahiru Akmeemana");
            // nameReferance.Add(180029, "MChandima Amarasena");
            // nameReferance.Add(180030, "MYasith Amarasinghe");
            // nameReferance.Add(180044, "MIsuru Ariyarathne");
            // nameReferance.Add(180048, "MHaris Mohomed");
            // nameReferance.Add(180052, "MRahal Athukorala");
            // nameReferance.Add(180053, "MChamodya Attanayake");
            // nameReferance.Add(180059, "MShashika Bandara");
            // nameReferance.Add(180062, "MMeelan Bandra");
            // nameReferance.Add(180070, "MLakshan Banneheke");
            // nameReferance.Add(180071, "FMaathangi Baskaran");
            // nameReferance.Add(180094, "MVasantharajan Charangan");
            // nameReferance.Add(180108, "MDulaj Kavinda");
            // nameReferance.Add(180109, "MRuwan Dayananda");
            // nameReferance.Add(180114, "MHithru De Alwis");
            // nameReferance.Add(180117, "MShamila De Silva");
            // nameReferance.Add(180118, "MDevin De Silva");
            // nameReferance.Add(180123, "MKasun De Silva");
            // nameReferance.Add(180126, "FThushani Nirasha");
            // nameReferance.Add(180127, "MNipun Deelaka");
            // nameReferance.Add(180141, "MDilax Saswaran");
            // nameReferance.Add(180146, "MMahela Hennayake");
            // nameReferance.Add(180147, "MYasindu Dilshan");
            // nameReferance.Add(180148, "MKaveesha Dilshan");
            // nameReferance.Add(180162, "MDasith Edirisinghe");
            // nameReferance.Add(180167, "FAyodya Erandi");
            // nameReferance.Add(180176, "MNipuna Fernando");
            // nameReferance.Add(180183, "FRashmi Galappaththi");
            // nameReferance.Add(180186, "MLahiru Kumarasingha");
            // nameReferance.Add(180187, "MChathulanka Gamage");
            // nameReferance.Add(180192, "FMinoli Gamlath");
            // nameReferance.Add(180196, "MVasanth Godfrey");
            // nameReferance.Add(180211, "MChamod Gunathilaka");
            // nameReferance.Add(180212, "MPoorna Gunathilaka");
            // nameReferance.Add(180213, "MManeesha Gunathilaka");
            // nameReferance.Add(180234, "MDamindu Hettiarachchi");
            // nameReferance.Add(180239, "MNuvidu Hewapathirana");
            // nameReferance.Add(180240, "MPubudu Hewavithana");
            // nameReferance.Add(180244, "MRavindu Hirimuthugodage");
            // nameReferance.Add(180247, "MHusni Faiz");
            // nameReferance.Add(180255, "MUditha Isuranga");
            // nameReferance.Add(180257, "MPaul Janson");
            // nameReferance.Add(180259, "MDilith Jayakody");
            // nameReferance.Add(180269, "MNishan Jayasanka");
            // nameReferance.Add(180273, "FThushani Jayasekara");
            // nameReferance.Add(180276, "FSupuni Jayasinghe");
            // nameReferance.Add(180281, "FRoshinie Jayasundara");
            // nameReferance.Add(180286, "MMahesh Jayawardhana");
            // nameReferance.Add(180294, "MJusail Mohomed");
            // nameReferance.Add(180295, "MKajanan Srikumaran");
            // nameReferance.Add(180313, "MSandalu Karunasena");
            // nameReferance.Add(180321, "MSandaru Kaveesha");
            // nameReferance.Add(180322, "Mkavinda Geeth");
            // nameReferance.Add(180325, "MChalindu Kodikara");
            // nameReferance.Add(180335, "MSandaruwan Kumarasingha");
            // nameReferance.Add(180348, "FHashani Lakmali");
            // nameReferance.Add(180352, "FMalithi Lalanika");
            // nameReferance.Add(180364, "MPasan Madhushan");
            // nameReferance.Add(180369, "MKaveesh Madumal");
            // nameReferance.Add(180371, "MThilina Lakshan");
            // nameReferance.Add(180377, "MMusab Mahmoodh");
            // nameReferance.Add(180420, "FUthpala Nethmini");
            // nameReferance.Add(180424, "MWimukthi Nimalsiri");
            // nameReferance.Add(180431, "MNirun Muthukumaran");
            // nameReferance.Add(180449, "MDhaura Pathirana");
            // nameReferance.Add(180459, "MShehan Perera");
            // nameReferance.Add(180463, "MHirumal Perera");
            // nameReferance.Add(180471, "MBinoy Peries");
            // nameReferance.Add(180474, "FImaji Pietersz");
            // nameReferance.Add(180475, "MKamalanathan Pirathees");
            // nameReferance.Add(180476, "MPiraveen Sivakumar");
            // nameReferance.Add(180482, "FThujitha Ponnuthurai");
            // nameReferance.Add(180485, "FSoujanya Pradheepa");
            // nameReferance.Add(180486, "MDushan Pramod");
            // nameReferance.Add(180488, "MPranavan Jegatheeswaran");
            // nameReferance.Add(180492, "MPrapakaran Prathees");
            // nameReferance.Add(180509, "MKavinda Rajapakse");
            // nameReferance.Add(180524, "MAvishka Rathnavibushana");
            // nameReferance.Add(180525, "MKavishka Rathnaweera");
            // nameReferance.Add(180526, "MCharuka Rathnayaka");
            // nameReferance.Add(180527, "FCharitha Rathnayaka");
            // nameReferance.Add(180535, "MKasun Rathnayake");
            // nameReferance.Add(180536, "FKrishalika Rathnayake");
            // nameReferance.Add(180537, "FVinoja Rathnayake");
            // nameReferance.Add(180543, "FSaranya Raveendran");
            // nameReferance.Add(180552, "MTheekshana Madumal");
            // nameReferance.Add(180553, "MSahan Samarakoon");
            // nameReferance.Add(180555, "FJamini Samarathunga");
            // nameReferance.Add(180561, "MDarshana Sandaruwan");
            // nameReferance.Add(180562, "MDhanuka Sandaruwan");
            // nameReferance.Add(180565, "MSanjeepan Sivapiran");
            // nameReferance.Add(180568, "MSivapalan Sarankan");
            // nameReferance.Add(180572, "MSarveswarasarma Pathmanathasarma");
            // nameReferance.Add(180573, "MSathulakjan Thayaparan");
            // nameReferance.Add(180582, "MDilshan Senarath");
            // nameReferance.Add(180587, "FGayangi Seneviratne");
            // nameReferance.Add(180594, "MAvishka Shamendra");
            // nameReferance.Add(180596, "MShanmugakumar Shanmugabavan");
            // nameReferance.Add(180607, "MGowantha Silva");
            // nameReferance.Add(180610, "FSivashangari Sivakumaran");
            // nameReferance.Add(180626, "MDakshitha Suriyaaratchie");
            // nameReferance.Add(180629, "MUditha Kavinda");
            // nameReferance.Add(180630, "MThakshayan Thanabalasingan");
            // nameReferance.Add(180632, "MTharinda Thamaranga");
            // nameReferance.Add(180633, "MThanyaparan Thamanchseyan");
            // nameReferance.Add(180635, "MSanuja Tharinda");
            // nameReferance.Add(180638, "MThayaruban Thayalan");
            // nameReferance.Add(180643, "FRidmi Thilakarathna");
            // nameReferance.Add(180645, "FSirithirumagal Thiruchittampalam");
            // nameReferance.Add(180648, "MThuvarakan Sritharan");
            // nameReferance.Add(180652, "MPasindu Udawatta");
            // nameReferance.Add(180653, "MIndunil Udayangana");
            // nameReferance.Add(180659, "MChirath Vandabona");
            // nameReferance.Add(180660, "MSubramamiyam Varatharajan");
            // nameReferance.Add(180664, "FSakiny Vijayarasa");
            // nameReferance.Add(180668, "MVipooshan Vipulananthan");
            // nameReferance.Add(180670, "MMaduka Vishvajith");
            // nameReferance.Add(180704, "MNarada Wijerathne");
            // nameReferance.Add(180707, "FAdeesha Wijesinghe");
            // nameReferance.Add(180711, "MDineth Wijesooriya");
            // nameReferance.Add(180718, "FShashini Wimalaratne");
            // nameReferance.Add(180722, "MYathurshan Kalanantharasan");
            // nameReferance.Add(180725, "MAndrewson Croos");
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
