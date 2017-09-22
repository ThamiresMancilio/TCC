using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAgropec.Class
{
    public class Upload_Image
    {
        public void upload()
        {
            string diretorio = null;

            if (System.Diagnostics.Debugger.IsAttached)
            {
                //diretorio = "C:\\Users\\Acer\\Source\\Workspaces\\PainelControleNoticias\\images_resultados\\"
                diretorio = "C:\\\\Users\\\\Acer\\\\Source\\\\Workspaces\\\\PainelControleNoticias\\\\temp_images\\\\";
            }
            else
            {
                //diretorio = "e:\home\brastexel\Web\aspnet_client\ferramenta\images_resultados\"
                diretorio = "e:\\home\\brastexel\\Web\\aspnet_client\\ferramenta\\temp_images\\";
            }
            string pasta = "images_resultados\\\\";

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = "";
            string[] imagens = new string[11];
            string[] imagensenviadas = new string[11];
            //string acao = Request.QueryString("acao");
            //for (int i = 0; i <= Request.Files.Count - 1; i++)
            //{
            //    dynamic file = Request.Files(i);
            //    file.SaveAs(diretorio + file.FileName);
            //    imagens[i] = "caption:" + file.FileName + " height:120px url:deleteimage.aspx key:" + file.FileName;

            //    imagensenviadas[i] = "<img  height='120px' , src='" + pasta + file.FileName + "' class='file-preview-image'>";
            //    json = "{file_id:0 , overwriteInitial:" + true + ", initialPreviewConfig" + imagens[0] + " , initialPreview:" + imagensenviadas(0);

            //}
            //Console.Write(serializer.Serialize(json));

           
        }

    }
}