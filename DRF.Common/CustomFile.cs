using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DRF.Common
{
    public static class CustomFile
    {
        public static string SaveImageFile(HttpPostedFileBase file, string name, int id = 0, string type = "Patient")
        {
            string url = "";

            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var fileExtensions = Path.GetExtension(file.FileName);

                    if (allowedExtensions.Contains(fileExtensions.ToLower()))
                    {
                        DateTime date = DateTime.Now;
                        string dateStr = date.Year.ToString("D4") + date.Month.ToString("D2") + date.Day.ToString("D2") + 
                                         date.Hour.ToString("D2") + date.Minute.ToString("D2") + date.Second.ToString("D2");
                        fileName = name.Replace(" ", "_") + "_" + id.ToString("D5") + "_" + dateStr;
                        url = "~/Uploads/Images/" + type + "/" + fileName + fileExtensions;
                        file.SaveAs(HttpContext.Current.Server.MapPath(url));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return url;
        }
    }
}
