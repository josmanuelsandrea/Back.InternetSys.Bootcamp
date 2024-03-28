using BackendBootcamp.DBModels;

namespace BackendBootcamp.Repository
{
    public class MenuRepository
    {
        private BackendbootcampContext _Context;
        public MenuRepository(BackendbootcampContext ctx)
        {
            _Context = ctx;
        }
        public List<Menu> GetMenus()
        {
            var menusFound = _Context.Menus.ToList();
            return menusFound;
        }

        public List<Menu> GetMenu(int id)
        {
            var menuFound = _Context.Menus.Where(x => x.RolRolid == id).ToList();

            return menuFound;
        }

    }
}
