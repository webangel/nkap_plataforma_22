using Common.MyExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Auth
{
    public static class UsersExtensions
    {

        public static void GeneratePass(this Usuarios model)
        {

            var passbefore = string.Format("{0}{1}{2}", model.Nombres, model.Sexo, model.Apellidos).ToUpper();
            model.Password = ExtensionsHelpers
                .Hash(passbefore);
        }

    }
}
