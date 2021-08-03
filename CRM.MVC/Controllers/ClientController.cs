using CRM.MVC.ViewModels;
using CRM.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CRM.Models;

namespace CRM.MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public ClientController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ViewAllClients()
        {
            List<ClientDto> clientDto = unitOfWork.ClientsRepository.GetAll().ProjectTo<ClientDto>().ToList();
            return Json(new { data = clientDto }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEditClient(int id = 0)
        {
            var clientDto = new ClientDto();
            //Add operation
            switch (id)
            {
                case 0:
                    return View(clientDto);
                default:
                    {
                        var client = new Client();
                        client = unitOfWork.ClientsRepository.GetOneBy(x => x.Id == id);
                        Mapper.Map(client, clientDto);
                        return View(clientDto);
                    }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditClient(ClientDto clientDto)
        {
            var client = Mapper.Map<ClientDto, Client>(clientDto);
            //add operation
            switch (clientDto.Id)
            {
                case 0:
                    unitOfWork.ClientsRepository.Insert(client);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة العميل بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.ClientsRepository.Update(client);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل العميل بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult DeleteClient(int Id)
        {
            unitOfWork.ClientsRepository.Delete(Id);            
           unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف العميل بنجاح" }, JsonRequestBehavior.AllowGet);
        }
    }
}