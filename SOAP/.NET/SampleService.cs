using AutoMapper;
using Models;
using SOAP.Dtos;
using SOAP.Models;
using System;
using System.Linq;
using System.Xml.Linq;
public class SampleService : ISampleService
{
    private readonly hospital_rnwaContext _context;
    private readonly IMapper _mapper;

    public SampleService(hospital_rnwaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public string Test(string s)
    {
        Console.WriteLine("Test Method Executed!");
        return s;
    }
    public PhysicianReadDto GetPhysician(int employeeId)
    {
        var physician = _context.Physician.Where(x => x.EmployeeId == employeeId).FirstOrDefault();

        return _mapper.Map<PhysicianReadDto>(physician);
    }
    public void XmlMethod(XElement xml)
    {
        Console.WriteLine(xml.ToString());
    }
    public Physician TestPhysician(Physician physician)
    {
        return physician;
    }
}