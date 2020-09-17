using System.ServiceModel;
using SOAP.Dtos;
using SOAP.Models;

namespace Models
{
   [ServiceContract]
   public interface ISampleService
   {
      [OperationContract]
      string Test(string s);
      [OperationContract]
      PhysicianReadDto GetPhysician(int employeeId);
      [OperationContract]
      void XmlMethod(System.Xml.Linq.XElement xml);
      [OperationContract]
      Physician TestPhysician(Physician physician);
  }
}