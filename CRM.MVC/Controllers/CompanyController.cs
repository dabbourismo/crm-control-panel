using CRM.MVC.ViewModels;
using CRM.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using CRM.Models;
using System;

namespace CRM.MVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CompanyController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }


        public ActionResult ViewCompanyExpenses()
        {
            return View();
        }

        public JsonResult ViewAllCompanyExpenses()
        {
            //List<CompanyExpensesDto> companyExpenses = unitOfWork.CompanyExpensesRepository
            //                    .GetAll().Where(x => x.ExpenseDate.Month == DateTime.Now.Month)
            //                    .ProjectTo<CompanyExpensesDto>()
            //                    .OrderByDescending(x => x.ExpenseDate)
            //                    .ToList();

            List<CompanyExpensesDto> companyExpenses = unitOfWork.CompanyExpensesRepository
                    .GetAll()
                    .ProjectTo<CompanyExpensesDto>()
                    .OrderByDescending(x => x.ExpenseDate)
                    .ToList();
            return Json(new { data = companyExpenses }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddEditCompanyExpense(int id = 0)
        {
            var compExpenseDto = new CompanyExpensesDto();
            //Add operation
            if (id == 0)
            {
                return View(compExpenseDto);
            }
            //edit operation
            else
            {
                var compExpense = new CompanyExpense();
                compExpense = unitOfWork.CompanyExpensesRepository.GetOneBy(x => x.Id == id);
                Mapper.Map(compExpense, compExpenseDto);
                return View(compExpenseDto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditCompanyExpense(CompanyExpensesDto comExpensesDto)
        {
            var compExpense = new CompanyExpense();
            Mapper.Map(comExpensesDto, compExpense);
            //add operation
            switch (comExpensesDto.Id)
            {
                case 0:
                    unitOfWork.CompanyExpensesRepository.Insert(compExpense);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم اضافة المصروف بنجاح" }, JsonRequestBehavior.AllowGet);
                default:
                    unitOfWork.CompanyExpensesRepository.Update(compExpense);
                    unitOfWork.Complete();
                    return Json(new { success = true, message = "تم تعديل المصروف بنجاح" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult DeleteExpense(int Id)
        {
            unitOfWork.CompanyExpensesRepository.Delete(Id);
            unitOfWork.Complete();
            return Json(new { success = true, message = "تم حذف المصروف بنجاح" }, JsonRequestBehavior.AllowGet);
        }
    }
}