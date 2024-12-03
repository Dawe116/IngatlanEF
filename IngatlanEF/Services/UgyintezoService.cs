using IngatlanEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngatlanEF.Services
{
    internal class UgyintezoService
    {
        public static List<Ugyintezo> GetallUgyintezo()
        {
            using (var context = new MiskolcingatlanContext())
            {
                try
                {
                    List<Ugyintezo> result = context.Ugyintezos.ToList();
                    return result;
                }
                catch (Exception ex)
                {
                    List<Ugyintezo> hibasok = new List<Ugyintezo>();
                    hibasok.Add(new Ugyintezo()
                    {
                        Id = -1,
                        Nev = ex.Message
                    });
                    return hibasok;
                }
            }
        }

        public static void Insert(Ugyintezo ujUgyintezo)
        {
            using (var context = new MiskolcingatlanContext())
            {
                try
                {
                    context.Ugyintezos.Add(ujUgyintezo);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                }

            }
        }
    }
}
