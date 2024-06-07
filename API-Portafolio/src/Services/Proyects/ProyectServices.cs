
using ApplicationDb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectImages.Models;
using Proyects.Models;
using UserProyects.Models;

namespace Proyects.Services
{
    public interface IProyectService
    {
        List<ProyectDto> GetProyects(int page, int pageSize);
        ProyectDto AddProyect(AddProyectRequest request);
        ProyectDto GetProyect(Guid id);
        string AddManyProyects(NProyectsDTO exampleProyects);
        string AddImage(Guid id,ImagesRequest request);
        string UpdateProyect(Guid id,Proyect update);
        string DeleteProyect(Guid id);
        string ActiveProyect(Guid id);
    }

    public class ProyectService : IProyectService
    {
        private readonly ApplicationDbContext _context;

        public ProyectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string AddManyProyects(NProyectsDTO exampleProyects)
        {
            try
            {
                foreach (var Proyect in exampleProyects.ProyectList)
                {
                    var pExist = _context.Proyects.FirstOrDefault(p => p.Name == Proyect.Name);

                    if (pExist != null)
                    {
                        throw new Exception("El proyecto ya existe");
                    }

                    var p = new Proyect
                    {
                        Name = Proyect.Name,
                        Url = Proyect.Url,
                        Image = Proyect.Image,
                        Role = Proyect.Role,
                        Description = Proyect.Description,
                        isDeleted = false,
                    };

                    _context.Proyects.Add(p);

                    foreach (var userId in exampleProyects.UserProyects)
                    {
                        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

                        if (user == null)
                        {
                            throw new Exception($"El usuario con ID {userId} no existe");
                        }

                        var userProyect = new UserProyect
                        {
                            User = user,  
                            Proyects = p
                        };

                        _context.UserProyects.Add(userProyect);
                        user.UserProyects.Add(userProyect);
                        
                    }
                }

                _context.SaveChanges();

                return "Se subieron correctamente todos los proyectos";
            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
        public List<ProyectDto> GetProyects(int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;

            return _context.Proyects 
            .Skip(skip)
            .Take(pageSize)
            .Include(p => p.ImagesP)
            .Include(p => p.UserProyects)
            .Select(p => new ProyectDto
            {
                Id = p.Id,
                Name = p.Name ?? "Default",
                Image = p.Image ?? "Default",
                Url = p.Url ?? "Default",
                Role = p.Role ?? "Default",
                Description = p.Description ?? "Default",
                UsersID = p.UserProyects.Select(up => up.UserId).ToList(),
                Imgs = p.ImagesP ?? p.ImagesP.ToList(),
            })
            .ToList();
        }

        public ProyectDto AddProyect(AddProyectRequest request)
        {
            try
            {

                var pExist = _context.Proyects.FirstOrDefault(p => p.Name == request.Proyect.Name);

                if (pExist != null)
                {
                    throw new Exception("El proyecto ya existe");
                }

                var p = new Proyect
                {
                    Name = request.Proyect.Name,
                    Url = request.Proyect.Url,
                    Image = request.Proyect.Image,
                    Role = request.Proyect.Role,
                    Description = request.Proyect.Description,
                    isDeleted = false,
                };

                _context.Proyects.Add(p);

                foreach (var userId in request.UserProyects)
                {
                    var user = _context.Users.FirstOrDefault(u => u.Id == userId);

                    if (user == null)
                    {
                        throw new Exception($"El usuario con ID {userId} no existe");
                    }

                    var userProyect = new UserProyect
                    {
                        User = user,  
                        Proyects = p
                    };

                    _context.UserProyects.Add(userProyect);
                    user.UserProyects.Add(userProyect);
                    
                }

                _context.SaveChanges();

                return new ProyectDto {
                    Id = p.Id,
                    Description = p.Description,
                    Image = p.Image,
                    Imgs = p.ImagesP,
                    Name = p.Name,
                    Role = p.Role,
                    Url = p.Url,
                    UsersID=p.UserProyects.Select(up => up.UserId).ToList(),
                };

            }
            catch (System.Exception)
            {
                
                throw;
            }

        }
        public ProyectDto GetProyect(Guid id)
        {
            try
            {

                var p = _context.Proyects
                .Where(p => p.Id == id)
                .Select(p => new ProyectDto
                {
                    Id = p.Id,
                    Description = p.Description,
                    Image = p.Image,
                    Imgs = p.ImagesP,
                    Name = p.Name,
                    Role = p.Role,
                    Url = p.Url,
                    UsersID = p.UserProyects.Select(up => up.UserId).ToList(),
                })
                .FirstOrDefault();

                if(p == null)
                {
                    throw new Exception($"No se encontro el Proyecto con el id : {id}");
                }
                
                return p;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public string AddImage(Guid id,ImagesRequest request)
        {
            try
            {
                var entityProyect = _context.Proyects.Find(id);
                if (entityProyect != null)
                {
                    foreach (var img in request.Imgs)
                    {
                        var entityImage = _context.ProyectImages.Add(
                            new ProyectImage
                            {
                                Url = img
                            });

                        entityProyect.ImagesP.Add(entityImage.Entity);
                    }

                    _context.SaveChanges();

                    return $"Imagenes Agregadas Correctamente al id {id}";
                }
                else
                {
                    throw new Exception($"No se encontró el proyecto con el id: {id}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string UpdateProyect(Guid id,Proyect update)
        {
            try
            {
                var entity = _context.Proyects.Find(id);
                if (entity == null)
                {
                    throw new Exception($"No se encontró el proyecto con ID {id}");
                }

                entity.Name = update.Name ?? entity.Name;
                entity.Image = update.Image ?? entity.Image;
                entity.Url = update.Url ?? entity.Url;
                entity.Role = update.Role ?? entity.Role;
                entity.Description = update.Description ?? entity.Description;

                _context.SaveChanges();

                return $"Proyecto con ID {id} actualizado exitosamente";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Service : Error al borrar el proyecto: {ex.Message}");
                throw;
            }
        }

        public string DeleteProyect(Guid id)
        {
            try
            {
                var entity = _context.Proyects.Find(id);
            
                if (entity == null)
                {
                    throw new Exception($"No se encontró el proyecto con ID {id}");
                }

                entity.isDeleted = true;
                _context.SaveChanges();
                return $"{entity?.Name ?? "Proyecto"} borrado Exitosamente";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Service : Error al borrar el proyecto: {ex.Message}");
                throw;
            }
        }

        public string ActiveProyect(Guid id)
        {
            try
            {
                var entity = _context.Proyects.Find(id);
                if (entity != null)
                {
                    entity.isDeleted = false;
                    _context.SaveChanges();
                    return $"{entity.Name} activado exitosamente";
                }
                else
                {
                    throw new Exception($"No se encontró el proyecto con el id: {id}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Service : Error en el Service ",ex);
            }
        }
    }
}