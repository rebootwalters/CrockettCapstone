using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace CrockettCapstone
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ContextDAL ctx = new ContextDAL())
            {
                ctx.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Crockett;Integrated Security=True";

                int RoleID = ctx.RoleCreateIDReturned("XXX");
                Console.WriteLine($"Created Role {RoleID}");

                Console.WriteLine(ctx.RoleFindByID(1));

                var a = ctx.RoleGetAll(0, 100);
                

                foreach (var i in a)
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine(ctx.RolesObtainCount());

                ctx.RoleUpdateJust(2, "Changed");
                Console.WriteLine(ctx.RoleUpdateSafe(20, "XXX", "ZZZ"));
                
            }
            

        }
    }
}
