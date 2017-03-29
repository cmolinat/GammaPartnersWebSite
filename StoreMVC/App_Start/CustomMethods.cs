using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StoreMVC.App_Start
{
    public class CustomMethods
    {
        public static Resp ValidateImage(HttpPostedFileBase fileName)
        {
            Resp resp = new Resp();
            var allowed = new[] { ".jpg", ".png" };
            if (fileName != null)
            {
                var ext = Path.GetExtension(fileName.FileName);
                if (!allowed.Contains(ext))
                {
                    resp.Error = true;
                    resp.Message = "Invalid file extension";
                }
                else
                {
                    resp.Error = false;
                }
               
            }
            else {
                resp.Error = true;
                resp.Message = "Select a image. ";
            }
            return resp;
        }
        //public static double convertToMb(long bytes)
        //{
        //    return (bytes / 1024f) / 1024f;
        //}
    }
}