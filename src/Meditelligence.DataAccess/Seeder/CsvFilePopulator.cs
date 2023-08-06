using CsvHelper;
using Meditelligence.DataAccess.Context;
using Meditelligence.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Seeder
{
    public static class CsvFilePopulator
    {
        public static List<FileRecord> ReadFileRecords()
        {
            using (var reader = new StreamReader("../../docs/dataset.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<FileRecord>();

                return records.ToList();
            }
        }

        public static void PopulateDatabaseRecords(this MeditelligenceDBContext context, List<FileRecord> records)
        {
            if (records is not null && records.Any())
            {
                foreach (var record in records) 
                {
                    // add illness
                    if (!context.Illnesses.Any(i => i.Name == record.Illnesses))
                    {
                        context.Illnesses.Add(new Illness { Name = record.Illnesses, Description = record.Description, Advice = record.Advice });
                        context.SaveChanges();
                    }

                    // add symptoms and linkages to database
                    var symptoms = record.Symptoms.Split('|');
                    var illnessID = context.Illnesses.First(i => i.Name == record.Illnesses).IllnessID;

                    foreach (var symptom in symptoms) 
                    {
                        // strip characters from dataset
                        var processedSymptom = symptom.Replace("\r","").Replace("\n","");
                        if (!context.Symptoms.Any(i => i.Name == processedSymptom))
                        {
                            context.Symptoms.Add(new Symptom { Name = processedSymptom });
                            context.SaveChanges();
                        }

                        var symptomID = context.Symptoms.First(i => i.Name == processedSymptom).SymptomID;
                        if (!context.IllnessToSymptoms.Any(i => i.IllnessRefID == illnessID && i.SymptomRefID == symptomID))
                        {
                            context.IllnessToSymptoms.Add(new IllnessToSymptom { IllnessRefID = illnessID, SymptomRefID = symptomID });
                            context.SaveChanges();
                        } 
                    }
                }
            }
        }
    }


    public class FileRecord
    {
        public string Illnesses { get; set; }
        public string Description { get; set; }
        public string Symptoms { get; set; }
        public string Advice { get; set; }
    }
}
