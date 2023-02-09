using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace CSVhelperAndJSON
{
    class CSVHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = "C:\\Users\\Aniket\\Desktop\\Thrid party\\CSV-helper-and-JSON-classwork\\CSVhelperAndJSON\\Utility\\Addresses.csv";
            string exportFilePath = "C:\\Users\\Aniket\\Desktop\\Thrid party\\CSV-helper-and-JSON-classwork\\CSVhelperAndJSON\\Utility\\Export.csv";

            //reading csv file
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from addresses csv.");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.firstname);
                    Console.Write("\t" + addressData.lastname);
                    Console.Write("\t" + addressData.address);
                    Console.Write("\t" + addressData.city);
                    Console.Write("\t" + addressData.state);
                    Console.Write("\t" + addressData.code);
                    Console.WriteLine();

                }
                Console.WriteLine("**********************Reading fromcsv file and Write to csv file **************************");
                //Writing csv file

                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
            //Console.WriteLine(reader);
        }


    }



}


