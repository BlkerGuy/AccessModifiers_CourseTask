using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AccessModifiers_CourseTask
{
     class Course
    {
        public string Groups;


        public Group[] Grups = new Group[0];


        public void AddGroup(Group newGroup)
         {
            
            Array.Resize(ref Grups, Grups.Length + 1);
            Grups[Grups.Length - 1] =newGroup;

            Console.WriteLine("Congratulation! group created.\n");
        }

        public string GetGroupByNo(int no)
        {
            if (no!=0)
            {
                for (int i = 0; i < Grups.Length; i++)
                {
                    if (Grups[i].No.Substring(1,3).Contains(no.ToString()))
                    {
                        Console.WriteLine($"Group:{Grups[i].No}");
                        return Grups[i].No;
                    }
                }
                if (Grups.Length==0)
                {
                    Console.WriteLine("Grup siyahisi bosdur.");
                    return null;
                }
                Console.WriteLine("Axtardiginiz qrup tapilmadi.");
               
            }
            return null;
        }


        public Group[] GetGroupsByPointRange(byte minPoint, byte maxPoint)
        {
            Group[] groups = new Group[0];
            for (int i = 0; i < Grups.Length; i++)
            {

                if (Grups[i].AvgPoint>=minPoint && Grups[i].AvgPoint <= maxPoint)
                {
                    Array.Resize(ref groups,groups.Length+1);
                    groups[groups.Length - 1] = Grups[i];
                    return groups;
                }
            }

            return null;
        }

        public Group[] Search(string str)
        {
            Group[] groups = new Group[0];
            if (str!=null || str!=" ")
            {
                for (int i = 0; i < Grups.Length; i++)
                {
                    if (Grups[i].No.Substring(0).Contains(str[0]))
                    {
                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = Grups[i];
                    }
                }
                if (Grups.Length==0)
                {
                    Console.WriteLine("Grup siyahisi bosdur.");
                }
            }
            return groups;
        }




















    }
}
