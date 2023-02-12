 using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace AccessModifiers_CourseTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course();
            byte opt = 0;
            string optInput;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1.Qrup elave et.");//Hazirdi
                Console.WriteLine("2.Bütün qruplara bax.");//Hazirdi
                Console.WriteLine("3.Verilmiş point araligindaki qruplara bax.");//Hazirdi
                Console.WriteLine("4.Verilmiş nomresi qrupa bax.");//Hazirdi
                Console.WriteLine("5.Verilmiş qruplar üzre axtariş et.");//hazirdi
                Console.WriteLine("\n0.Menudan cix!\n");
                optInput = Console.ReadLine();
                if (checkEmptyEnter(optInput))
                {
                    opt = Convert.ToByte(optInput);
                    switch (opt)
                    {
                        case 1:
                            string groupNum;
                            byte count = 0;
                            Group newGroup = new Group();
                            do
                            {
                                Console.WriteLine("Qrup adi daxil et:  misal:P138");
                                 groupNum = Console.ReadLine();


                                Console.WriteLine("Qrupun averagePoint daxil edin:");
                                string avgP = Console.ReadLine();
                                if (checkStr(avgP))
                                {
                                    var avgPoint = Convert.ToByte(avgP);
                                    if (newGroup.CheckGroupNo(groupNum))
                                    {
                                        if (course.Grups.Length == 0)
                                        {
                                            course.AddGroup(new Group { No = groupNum, AvgPoint = avgPoint });
                                        }
                                        else
                                        {
                                            for (int i = 0; i < course.Grups.Length; i++)
                                            {
                                                if (groupNum != course.Grups[i].No)
                                                {
                                                    count++;
                                                }
                                            }
                                            if (count == course.Grups.Length)
                                            {
                                                course.AddGroup(new Group { No = groupNum, AvgPoint = avgPoint });
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Group:{groupNum} artiq movcuddur!!");
                                            }
                                        }
                                    }
                                }

                            } while (!newGroup.CheckGroupNo(groupNum));
                            break;
                        case 2:
                            Console.WriteLine("Butun qruplar:");
                            for (int i = 0; i < course.Grups.Length; i++)
                            {
                                Console.WriteLine($"Group:{course.Grups[i].No}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Zehmet olmasa minumPoint daxil edin:");
                            string input = Console.ReadLine();
                            if (checkStr(input))
                            {
                                byte minumPoint = Convert.ToByte(input);

                                Console.WriteLine("Zehmet olmasa maxPoint daxil edin:");
                                string input2 = Console.ReadLine();
                                if (checkStr(input2))
                                {
                                    byte maxPoint = Convert.ToByte(input2);
                                    {
                                        if (minumPoint != 0 || maxPoint != 0)
                                        {
                                            var grups = course.GetGroupsByPointRange(minumPoint, maxPoint);
                                            if (grups != null)
                                            {
                                                for (int i = 0; i < grups.Length; i++)
                                                {
                                                    Console.WriteLine($"Group:{grups[i].No} and AveragePoint:{grups[i].AvgPoint}");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"{minumPoint}-{maxPoint} Bu araliqda Qrup tapilmadi.");
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Grup nomresi daxil edin:");
                            string groupNoInput = Console.ReadLine();
                            byte j = 0;
                            if (checkStr(groupNoInput) && groupNoInput.Length == 3)
                            {
                                if (groupNoInput.All(char.IsDigit))
                                {
                                    if (course.Grups.Length == 0)
                                    {
                                        Console.WriteLine("Siyahi bosdur.");
                                    }
                                    int groupNom = Convert.ToInt32(groupNoInput);
                                    course.GetGroupByNo(groupNom);
                                }
                                else
                                    Console.WriteLine("Duzgun eded daxil edin!");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Zehmet olmasa axtardiginiz qrupun ilk herfini daxil edin:");
                            string groupStringInput = Console.ReadLine();
                            if (checkStr(groupStringInput) && groupStringInput.Length == 1)
                                if (char.IsLetter(groupStringInput, 0))
                                {
                                    if (course.Grups.Length != 0)
                                    {
                                        var firstLetterGroup = course.Search(groupStringInput.ToUpper());
                                        for (int i = 0; i < firstLetterGroup.Length; i++)
                                        {
                                            Console.WriteLine($"Group: {firstLetterGroup[i].No}");
                                        }
                                    }
                                    else
                                        Console.WriteLine("Grup siyahisi bosdur");

                                }
                                else
                                {
                                    Console.WriteLine("Qrupun ilk herfini duzgun daxil edin!!");
                                }
                            break;
                        default:
                            if (opt != 0)
                            {
                                Console.WriteLine("Duzgun eded daxil edin!\n");
                            }
                            break;
                    }
                }
            } while (opt != 0 || !checkEmptyEnter(optInput));
        }


        static bool checkStr(string words)
        {
            if (words!=" " && words!="")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Zehmet olmasa kecerli deyer daxil edin!!\n");
            }
            return false;
        }

        static bool checkEmptyEnter(string str)
        {
            if (str!=""&& str.Length == 1)
                if(char.IsDigit(str,0))
                return true;

            return false;
        }
    }
}
