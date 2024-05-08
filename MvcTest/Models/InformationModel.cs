using MvcTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace MvcTest.Models
{
    public class InformationModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Srno { get; set; }

        public string SaveInfo(InformationModel model)
        {
            string msg = "Data Save Successfully";

            MvcTestEntities Db = new MvcTestEntities();
            {
                var infoData = new tblDetail()
                {
                    Srno = Srno,
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DOB = model.DOB,
                    Email = model.Email,
                    Phone = model.Phone,
                };

                Db.tblDetails.Add(infoData);
                Db.SaveChanges();
                return msg;
            }
        }


        public List<InformationModel> GetInformationList()
        {
            MvcTestEntities Db = new MvcTestEntities();
            List<InformationModel> info = new List<InformationModel>();
            var AddInfo = Db.tblDetails.ToList();
            int Srno = 1;
            if (AddInfo != null)
            {
                foreach(var lstinfo in AddInfo)
                {
                    info.Add(new InformationModel()
                    {
                        Srno = Srno,
                        Id = lstinfo.Id,
                        FirstName = lstinfo.FirstName,
                        LastName = lstinfo.LastName,
                        DOB = lstinfo.DOB,
                        Email = lstinfo.Email,
                        Phone = lstinfo.Phone,
                    });
                    Srno++;
                }
            }
            return info;
        }
    }
}