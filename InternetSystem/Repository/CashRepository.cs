﻿
using BackendBootcamp.DBModels;
using BackendBootcamp.Models;

namespace BackendBootcamp.Repository
{
    public class CashRepository
    {
        private BackendbootcampContext _Context;
        public CashRepository(BackendbootcampContext ctx)
        {
            _Context = ctx;
        }
        public List<Cash?> GetCashes()
        {
            var listCash = _Context.Cashes.ToList();
            return listCash;
        }
        public Cash? GetCash(int id)
        {
            var cashFind = _Context.Cashes.Where(x => x.Cashid == id).FirstOrDefault();

            return cashFind;
        }
        // se necesita el context para conectar a la bd, el modelo para insertar los datos
        public Cash CreatedCash(BackendbootcampContext Context, CashModelReq cash)
        {

            try
            {
                Cash Cash = new Cash
                {
                    Cashdescription = cash.Description,
                    Active = cash.Active,
                    // Otras propiedades aquí si las hay
                };

                Context.Cashes.Add(Cash);
                Context.SaveChanges();

                return Cash;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Cash UpdatedCash(BackendbootcampContext Context, CashModelReq cash, int IdCash)
        {

            try
            {

                Cash CashFind = Context.Cashes.Where(x => x.Cashid == IdCash).FirstOrDefault();

                if (CashFind != null)
                {
                    CashFind.Cashdescription = cash.Description;
                    CashFind.Active = cash.Active;


                    Context.SaveChanges();
                   

                    return CashFind;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)    
            {


                return null;

            }


        }

    }

}
