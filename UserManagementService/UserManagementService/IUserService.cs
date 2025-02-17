using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace UserManagementService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<UserDTO> GetUsers();

        [OperationContract]
        UserDTO GetUser(int id);

        [OperationContract]
        void AddUser(UserDTO user);

        [OperationContract]
        void UpdateUser(UserDTO user);

        [OperationContract]
        void DeleteUser(int id);
    }
}
