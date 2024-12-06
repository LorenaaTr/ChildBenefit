using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Tema.DataAccess.Repository.IRepository;
using System.IO;
using System.Linq;

namespace Tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  // Dependency injection to get the UnitOfWork
        }

        [HttpGet]
        public IActionResult GenerateReportForMonth()
        {
            return View();
        }

        // POST method to generate the Excel report
        [HttpPost]
        public IActionResult GenerateReportForMonth(int month, int year)
        {
            // Step 1: Retrieve the data for the selected month and year
            var payments = _unitOfWork.Payment.GetAll(p =>
                p.PaymentDate.Year == year &&  // Check if the year matches
                p.PaymentDate.Month == month)  // Check if the month matches
                .ToList();

            // Check if there is no data for the selected month
            if (payments == null || payments.Count == 0)
            {
                return NotFound("No data found for the selected month.");
            }

            // Step 2: Create the Excel file using EPPlus
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Payments Report");

                // Step 3: Add headers to the Excel sheet in Albanian
                worksheet.Cells[1, 1].Value = "Emri i Prindit";  // Parent Name
                worksheet.Cells[1, 2].Value = "Mbiemri i Prindit";  // Parent Surname
                worksheet.Cells[1, 3].Value = "Shuma";    // Amount
                worksheet.Cells[1, 4].Value = "Data e Pagesës";  // Payment Date
                worksheet.Cells[1, 5].Value = "Numri i Fëmijëve"; // Number of Children
                worksheet.Cells[1, 7].Value = "Email i Prindit";  // Parent Email
                worksheet.Cells[1, 8].Value = "Numri i Kontaktit të Prindit";  // Parent Contact Number
                worksheet.Cells[1, 9].Value = "Mbiemri i Vajzërisë i Prindit";  // Parent Maiden Name
                worksheet.Cells[1, 10].Value = "Numri Personal i Prindit";  // Parent Personal No
                worksheet.Cells[1, 11].Value = "Data e Lindjes së Prindit";  // Parent Date Of Birth
                worksheet.Cells[1, 12].Value = "Adresa e Prindit";  // Parent Address
                worksheet.Cells[1, 13].Value = "Numri i Llogarisë Bankare të Prindit";  // Parent Bank Account Number

                // Step 4: Populate data starting from row 2
                int row = 2;  // Data starts from row 2 (row 1 is for headers)
                foreach (var payment in payments)
                {
                    // Get the parent data
                    var parent = _unitOfWork.Parent.GetAll(p => p.IdParent == payment.IdParent).FirstOrDefault();
                    var childrenCount = _unitOfWork.Child.GetAll(c => c.ParentId == payment.IdParent).Count();  // Get number of children for the parent

                    // Populate the columns with the additional data
                    worksheet.Cells[row, 1].Value = parent.Name;  // Parent Name
                    worksheet.Cells[row, 2].Value = parent.Surname;  // Parent Surname
                    worksheet.Cells[row, 3].Value = payment.Amount;  // Amount
                    worksheet.Cells[row, 4].Value = payment.PaymentDate.ToString("yyyy-MM-dd");  // Payment Date
                    worksheet.Cells[row, 5].Value = childrenCount;  // Number of Children
                    worksheet.Cells[row, 7].Value = parent.Email;  // Parent Email
                    worksheet.Cells[row, 8].Value = parent.ContactNumber;  // Parent Contact Number
                    worksheet.Cells[row, 9].Value = parent.MaidenName;  // Parent Maiden Name
                    worksheet.Cells[row, 10].Value = parent.PersonalNo;  // Parent Personal No
                    worksheet.Cells[row, 11].Value = parent.DateOfBirth;  // Parent Date Of Birth
                    worksheet.Cells[row, 12].Value = parent.Address;  // Parent Address
                    worksheet.Cells[row, 13].Value = parent.BankAccountNumber;  // Parent Bank Account Number

                    row++;
                }

                // Step 5: Save the Excel file to a memory stream
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                // Step 6: Return the Excel file to the user as a downloadable file
                string fileName = $"Payments_Report_{month}_{year}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);  // File method comes from Controller
            }
        }
    }
}
