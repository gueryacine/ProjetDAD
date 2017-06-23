using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Server_WCF_IIS
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        string LoginByPassword(string username, string password, string tokenApp);
        [OperationContract]
        string LoginByToken(string tokenApp, string tokenUser, List<string> files);
        [OperationContract]
        MSG Dispatching(MSG msg);

    }

}
