using PlatformService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlatformService.Data
{
    public class PlatformRepo:IPlatformRepo 
    {
        private readonly AppDbContext _context;
        public PlatformRepo(AppDbContext context) => _context = context;
        public void CreatePlatform(Platform objPlatForm){
          if (objPlatForm==null){
              throw new System.ArgumentNullException(nameof(objPlatForm));
          }
          _context.Platforms.Add(objPlatForm);

       }

       public bool  SaveChanges(){
           return (_context.SaveChanges()>=0);
       }

       public IEnumerable<Platform>GetAllPlatform(){
           return _context.Platforms.ToList();
       }

       public Platform GetPlatformById(int id){

           return _context.Platforms.FirstOrDefault(p=>p.Id==id);

       }
    }

}