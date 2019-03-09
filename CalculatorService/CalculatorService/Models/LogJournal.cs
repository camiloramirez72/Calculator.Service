using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Models
{
    public class LogJournal
    {
        private string Path = Directory.GetCurrentDirectory() + "/Log";
        private string SufName = "";

        public LogJournal(string SufName)
        {
            this.SufName = SufName;
        }

        public void Add(string sLog)
        {
            CreateDirectory();
            string nombre = GetNameFile();
            string cadena = "";

            cadena += sLog + Environment.NewLine;

            StreamWriter sw = new StreamWriter(Path + "/" + nombre, true);
            sw.Write(cadena);
            sw.Close();

        }

        public List<Journal> Read(string nombre)
        {
            nombre = GetNameFile();
            StreamReader objReader = new StreamReader(Path + "/" + nombre);
            string sLine = "";
            List<Journal> Operations = new List<Journal>();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    JObject json = JObject.Parse(sLine);
                    Log log = new Log();
                    Journal journal = new Journal();
                    journal.Operation = (string)json["Operation"];
                    journal.Calculation = (string)json["Calculation"];
                    journal.Date = (string)json["Date"];
                    Operations.Add(journal);
                }
                    
            }
            objReader.Close();
            return Operations;
        }

        #region HELPER
        private string GetNameFile()
        {
            string nombre = "";

            nombre = SufName + ".txt";

            return nombre;
        }

        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);


            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);

            }
        }
        #endregion

    }
}
