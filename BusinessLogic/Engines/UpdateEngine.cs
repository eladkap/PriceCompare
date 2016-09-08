using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalLab.Engines
{
    public class UpdateEngine
    {
        // this engine gets database entities from the xmlDecoder as objects,
        // and insert them into db.

        // test it
        public void InsertChain(Chain chain)
        {
            using (CatalogContext context=new CatalogContext())
            {
                if (!context.Chains.Contains(chain))
                {
                    context.Chains.Add(chain);
                    context.SaveChangesAsync();
                }
            }
        }

        private void InsertStore(Store store)
        {

        }

        public void InsertStoresOfChain(Chain chain)
        {
            using (CatalogContext context = new CatalogContext())
            {

            }
        } 



    }
}
