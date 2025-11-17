using BLL.Services;
using DAL;
using DAL.DataProvider;
using DAL.Entities;
using PL;
using PL.ModelsMenu;

class Program
{
    static void Main()
    {
        JSONProvider<StudentEntity> jss = new JSONProvider<StudentEntity>("Students.json");
        JSONProvider<GroupEntity> jgs = new JSONProvider<GroupEntity>("Groups.json");
        JSONProvider<DormitoryEntity> jds = new JSONProvider<DormitoryEntity>("Dormitories.json");
        
        EntityContext ec = new EntityContext(jss, jgs, jds);
        
        StudentService ss = new StudentService(ec);
        GroupService gs = new GroupService(ec);
        DormitoryService ds = new DormitoryService(ec);
        
        StudentMenu sm = new StudentMenu(ss);
        GroupMenu gm = new GroupMenu(gs);
        DormitoryMenu dm = new DormitoryMenu(ds);
        
        Menu menu = new Menu(sm, gm, dm);
        menu.Run();
    }
    
}

