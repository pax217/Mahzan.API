using System;
using System.IO;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.BarCodes;
using Mahzan.Business.Resources.Business.BarCodes;
using Mahzan.Business.Results.BarCodes;
using Mahzan.DataAccess.DTO.BarCodes;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;

namespace Mahzan.Business.Implementations.Business.BarCodes
{
    public class BarCodesBusiness: IBarCodesBusiness
    {
        public BarCodesBusiness()
        {
        }

        public async Task<PostBarCodesResult> Create(CreateBarCodesDto createBarCodesDto)
        {
            PostBarCodesResult result = new PostBarCodesResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = CreateBarCodesResources.ResourceManager.GetString("Create_Title"),
                Message = CreateBarCodesResources.ResourceManager.GetString("Create_200_SUCCESS_Message")
            };

            try
            {
                //Creating new PDF Document

                PdfDocument doc = new PdfDocument();

                //Adding new page to PDF document

                PdfPage page = doc.Pages.Add();

                //Drawing Code39 barcode 

                PdfCode39Barcode barcode = new PdfCode39Barcode();

                //Setting height of the barcode 

                barcode.BarHeight = 45;

                barcode.Text = "CODE39$";

                //Printing barcode on to the Pdf. 

                barcode.Draw(page, new PointF(25, 70));

                //Saving the PDF to the MemoryStream
                MemoryStream stream = new MemoryStream();

                doc.Save(stream);

                //Set the position as '0'.
                stream.Position = 0;

                result.FileStream = stream;
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }


            return result;
        }
    }
}
