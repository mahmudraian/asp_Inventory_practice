using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OST_Inventory.Models
{
    public class Equipment:Member
    {
          public int EquipmentId { get; set; }
          public string Name { get; set; }
          public int Count {  get; set; }
          public DateTime EntryDate { get; set; }

          public Member Member { get; set; }

        public Equipment() { 
        Member = new Member();
        }  

        public static List<Equipment>  LSTEquipment()
        {
          List<Equipment> list =new List<Equipment>();

            for(int i = 0; i < 30; i++)
            {
                Equipment equipment = new Equipment();
                equipment.EquipmentId = i;
                equipment.Name = "Raian";
                equipment.Count = i * 6;
                equipment.EntryDate = DateTime.Now.Date;


                list.Add(equipment);





            }
         

            return list;

        }


        public static List<Equipment> LSTAssignEquipment()
        {
            List<Equipment> list = new List<Equipment>();

            for (int i = 0; i < 30; i++)
            {
                Equipment equipment = new Equipment();
                equipment.EquipmentId = i;
                equipment.Name = "Raian";
                equipment.Count = i * 6;
                equipment.EntryDate = DateTime.Now.Date;

                equipment.Member.MemberName = "Raian" + i.ToString();
                equipment.Member.MemberDesignation = " SSC 202" + i.ToString();
                equipment.Member.MobileNumber = "001221" + i.ToString();



                list.Add(equipment);

            }


            return list;

        }

    }
}