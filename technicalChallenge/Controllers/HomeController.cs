using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fare;
using technicalChallenge.Models;
using System.Text.RegularExpressions;

namespace technicalChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Simplify()
        {
            NumberModel model = new NumberModel();
            model.Number1 = 0;
            model.Number2 = 0;
            ViewBag.Message1 = "";
            ViewBag.Message2 = "";
            ViewBag.Message3 = "";

            return View(model);
        }
        [HttpPost]
        public ActionResult Simplify(NumberModel model)
        {
            //No puedo simplificar números divididos por 0.
            if (model.Number2==0)
            {
                ViewBag.Message1 = "No se puede simplificar numero dividido por 0.";
                ViewBag.Message2 = "";
                ViewBag.Message3 = "";
                return View(model);
            }
            //Verifico si no es una división exacta.
            if (model.Number1 % model.Number2 == 0) {
                ViewBag.Message1 = "";
                ViewBag.Message2 = (model.Number1 / model.Number2).ToString(); ;
                ViewBag.Message3 = "";
                return View(model);
            }
            //inicializar variables del proceso de simplificación
            int mandatoryValue = 1;
            int number1 = model.Number1;
            int number2 = model.Number2;
            //Determinar variable mandatoria
            if (model.Number1 > model.Number2)
            {
                mandatoryValue = model.Number2;
            }
            else {
                mandatoryValue = model.Number1;
            }
            //Simplificación
            for (int i = mandatoryValue;  i>1; i--) {
                if (number1 % i == 0 && number2 % i == 0) {
                    number1 = number1 / i;
                    number2 = number2 / i;
                }
            }
            ViewBag.Message1 = "";
            ViewBag.Message2 = number1.ToString();
            ViewBag.Message3 = number2.ToString();
            return View(model);
        }

        public ActionResult ValidateName()
        {
            NameModel model= new NameModel();
            model.NameText = "";
            ViewBag.Message = "";

            return View(model);
        }
        [HttpPost]
        public ActionResult ValidateName(NameModel model)
        {

            ViewBag.Message = (ValidName(model.NameText.ToString().Trim()))? "Válido" : "No Válido";
           
            return View(model);
           
        }

        public bool ValidName(string Name)
        {
            string pattern = @"^[A-Z]";
            string[] words = Name.Split(' ');

            foreach (var word in words)
            {
                if (word.Length == 2) //Iniciales
                {
                    //Solo se permiten iniciales con un solo un caracter más un punto.
                    if (word.IndexOf(".") != 1)
                    {
                       return false;
                    }
                }
                else if (word.Length > 2)
                {//Palabras
                    //Solo se permiten palabras sin punto.
                    if (word.IndexOf(".") >= 0)
                    {
                        return false;
                    }
                }
                else
                {//invalido
                    //Solo se permiten palabras se comprendan de 2 o mas caracteres.
                    return false;
                }
                //Solo se permiten términos capitalizados(la primera letra en mayúsculas)
                MatchCollection matches = Regex.Matches(word, pattern);
                if (matches.Count == 0)
                {
                    return false;
                }
            }
            //Solo se permiten 2 o 3 términos en el ingreso. Es decir, o dos nombres y un apellido o solo un nombre y un apellido.
            if (!(words.Count() == 2 || words.Count() == 3))
            {
                return false;
            }
            
            if (words.Count() == 3)
            {
                //Los apellidos no pueden ser iniciales, para 3 términos.
                if (words[2].Length == 2)
                {
                    return false;
                }
                //Si el primer termino es inicial el segundo no puede ser palabra, para 3 términos.
                if (words[0].Length == 2 && words[1].Length > 2)
                {
                    return false;
                }
            }
            //Los apellidos no pueden ser iniciales, para 2 términos.
            if (words.Count() == 2)
            {  
                if (words[1].Length == 2)
                {
                    return false;
                }
            }
            
            //En caso de pasar todas las validaciones.
            return true;
        }
    }
}