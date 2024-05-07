using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Web;
using MvcDemo;
using MvcDemo.Data;



namespace MvcDemo.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile_No { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int srno { get; set; }

        public string SaveReg(RegistrationModel model)
        {
            string msg = "save";
            mvcdemoEntities Db = new mvcdemoEntities();
            var reg = Db.tblregistrations.Where(p => p.Id == model.Id).FirstOrDefault();
            if (model.Id == 0)
            {

                var regData = new tblregistration()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Mobile_No = model.Mobile_No,
                    Address = model.Address,
                    City = model.City,
                };
                Db.tblregistrations.Add(regData);
                Db.SaveChanges();
            }
            else
            {
                reg.Id = model.Id;
                reg.Name = model.Name;
                reg.Mobile_No = model.Mobile_No;
                reg.Address = model.Address;
                reg.City = model.City;


                Db.SaveChanges();
                msg = "update successfully!";
            }
            return msg;
        }
           
        
        public List<RegistrationModel> GetRegistrationList()
        {
            mvcdemoEntities Db = new mvcdemoEntities();
            List<RegistrationModel>lstRegistrations = new List<RegistrationModel>();
            var AddRegistrationList = Db.tblregistrations.ToList();
            int srno = 1;
            if (AddRegistrationList !=null)
            {
                foreach (var registration in AddRegistrationList)
                {
                    lstRegistrations.Add(new RegistrationModel()
                    {   srno=srno,
                        Id = registration.Id,
                        Name = registration.Name,
                        Mobile_No = registration.Mobile_No,
                        Address = registration.Address,
                        City = registration.City
                    });
                    srno++;
                }
                
            }
            return lstRegistrations;

        }
        public string deleteregistration(int Id)
        {
            var massage = " delete successful";
            mvcdemoEntities Db = new mvcdemoEntities();
            var data = Db.tblregistrations.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                Db.tblregistrations.Remove(data);
                Db.SaveChanges();

            }
            return massage;

        }
        public RegistrationModel  GetRegisterbyId(int Id)
        {
            
            RegistrationModel model = new RegistrationModel();
            mvcdemoEntities Db = new mvcdemoEntities();
            var data = Db.tblregistrations.Where(p =>p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                model.Id = data.Id;
                model.Name = data.Name;
                model.Mobile_No = data.Mobile_No;
                model.Address = data.Address;
                model.City = data.City;


            }
            return model;

        }

    }

}