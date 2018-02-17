//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="None">
//     Copyright (c) Allow to distribute this code.
// </copyright>
// <author>Asma Khalid</author>
//-----------------------------------------------------------------------

namespace BootstrapStyleDropdown.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using Models;

    /// <summary>
    /// Home Controller class.
    /// </summary>
    public class HomeController : Controller
    {
        #region Index method

        /// <summary>
        /// GET: Index method.
        /// </summary>
        /// <returns>Returns - index view page</returns> 
        public ActionResult Index()
        {
            // Initialization.
            DropdownViewModel model = new DropdownViewModel();

            // Settings.
            model.SelectedCountryId = 0;

            // Loading drop down lists.
            this.ViewBag.CountryList = this.GetCountryList();

            // Info.
            return this.View(model);
        }

        #endregion

        #region Helpers

        #region Load Data

        /// <summary>
        /// Load data method.
        /// </summary>
        /// <returns>Returns - Data</returns>
        private List<CountryObj> LoadData()
        {
            // Initialization.
            List<CountryObj> lst = new List<CountryObj>();

            try
            {
                // Initialization.
                string line = string.Empty;
                string srcFilePath = "content/files/country_list.txt";
                var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var fullPath = Path.Combine(rootPath, srcFilePath);
                string filePath = new Uri(fullPath).LocalPath;
                StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read));

                // Read file.
                while ((line = sr.ReadLine()) != null)
                {
                    // Initialization.
                    CountryObj infoObj = new CountryObj();
                    string[] info = line.Split(',');

                    // Setting.
                    infoObj.Country_Id = Convert.ToInt32(info[0].ToString());
                    infoObj.Country_Name = info[1].ToString();

                    // Adding.
                    lst.Add(infoObj);
                }

                // Closing.
                sr.Dispose();
                sr.Close();
            }
            catch (Exception ex)
            {
                // info.
                Console.Write(ex);
            }

            // info.
            return lst;
        }

        #endregion

        #region Get country method.

        /// <summary>
        /// Get country method.
        /// </summary>
        /// <returns>Return country for drop down list.</returns>
        private IEnumerable<SelectListItem> GetCountryList()
        {
            // Initialization.
            SelectList lstobj = null;

            try
            {
                // Loading.
                var list = this.LoadData()
                                  .Select(p =>
                                            new SelectListItem
                                            {
                                                Value = p.Country_Id.ToString(),
                                                Text = p.Country_Name
                                            });

                // Setting.
                lstobj = new SelectList(list, "Value", "Text");
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }

            // info.
            return lstobj;
        }

        #endregion

        #endregion
    }
}