using IngatlanEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IngatlanEF.Services
{
    internal class IngatlanService
    {
        public static List<Ingatlan> GetAllIngatlans() { 
            using(var context = new MiskolcingatlanContext()) {
                try
                {
                    List<Ingatlan> result = context.Ingatlans.ToList();
                    return result;
                }
                catch (Exception ex)
                {
                    List<Ingatlan> hibasok = new List<Ingatlan>();
                    hibasok.Add(new Ingatlan()
                    {
                        Id = -1,
                        Település = ex.Message
                    });
                    return hibasok;
                }
            }

        }

        public static void Insert(Ingatlan ujUngatlan)
        {
            using (var context = new MiskolcingatlanContext())
            {
                try
                {
                    context.Ingatlans.Add(ujUngatlan);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                }
                
            }
        }
    }
}
