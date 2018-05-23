using Common;
using Common.MyExtensions;
using Model.Auth;
using Model.Custom;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Service
{
    public interface IUsuarioService
    {
        ResponseHelper InsertOrUpdate(Usuarios model, HttpPostedFileBase foto);
        ResponseHelper DeleteUser(int id);
        Usuarios Get(int id);
        ResponseHelper Acceder(LoginViewModel model, bool includes);
    }

    public class UsuarioService : IUsuarioService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Usuarios> _usuariosRepository;

        public UsuarioService(
             IDbContextScopeFactory dbContextScopeFactory,
             IRepository<Usuarios> usuariosRepository
            )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _usuariosRepository = usuariosRepository;

        }

        public ResponseHelper Acceder(LoginViewModel model, bool includes)
        {
            var rm = new ResponseHelper();
            try
            {
                using (var ctx= _dbContextScopeFactory.Create())
                {
                    //string rol = "";
                    model.Password = ExtensionsHelpers.Hash(model.Password);
                    var usuario = _usuariosRepository .SingleOrDefault(x => x.Email.Equals(model.username) && x.Password.Equals(model.Password),x => x.Rol);
               

                    if (includes)
                    {
                        if (usuario != null)
                        {
                            UserSessionHelper.AddUserToSession(usuario.Id.ToString());
                            UserSessionHelper.AddTipeUser(
                            ExtensionsHelpers.Hash( usuario.Rol.Rol[0].ToString().ToUpper()));

                            rm.SetResponse(true);
                            rm.Result = usuario.Nombres;

                        }
                        else
                        {
                            rm.SetResponse(false, "Correo o contraseña incorrecta");
                        }
                    }
                    else
                    {
                        if (usuario != null)
                        {

                            rm.SetResponse(true);
                            rm.Result = usuario.Nombres;
                        }
                        else
                        {
                            rm.SetResponse(false, "Correo o contraseña incorrecta");
                        }
                    }
                }
               


            }
            catch (Exception)
            {

                throw;
            }


            return rm;
        }

        public ResponseHelper DeleteUser(int id)
        {
            var rh = new ResponseHelper();
            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _usuariosRepository
                        .Find(x => x.Id == id)
                        .SingleOrDefault();
                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex.Message);
            }
            return rh;
        }

        public Usuarios Get(int id)
        {
            var user = new Usuarios();
            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    user = _usuariosRepository.Find(x => x.Id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex.Message);
            }
            return user;
        }

        public ResponseHelper InsertOrUpdate(Usuarios model, HttpPostedFileBase picture)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    if (model.Id == 0)
                    {
                        model.GeneratePass();
                        _usuariosRepository.Insert(model);
                    }
                    else
                    {
                        _usuariosRepository.Update(model);

                    }
                    string fileName = Parameters.UploadPathUsersGeneral + "profile-" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(picture.FileName);
                    picture.SaveAs(HttpContext.Current.Server.MapPath("~/" + fileName));

                    //Delete old picture
                    //if (!string.IsNullOrEmpty(oldUser.Picture))
                    //{
                    //    try
                    //    {
                    //        File.Delete(HttpContext.Current.Server.MapPath("~/" + oldUser.Picture));
                    //    }
                    //    catch (Exception e)
                    //    {
                    //    }
                    //}

                   // Replace for new picture
                    model.Foto = fileName;
                   model.Foto = fileName;


                   ctx.SaveChanges();
                    rh.SetResponse(true);
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return rh;
        }
    }
}
