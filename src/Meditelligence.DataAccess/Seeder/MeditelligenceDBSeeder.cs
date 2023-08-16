using Meditelligence.DataAccess.Context;
using Meditelligence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Seeder
{
    /// <summary>
    /// A seeder class used to populate the database with records.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MeditelligenceDBSeeder : IMeditelligenceDBSeeder
    {
        public IEnumerable<Illness> SeedIllnesses()
        {
            return new List<Illness>()
            {
                new Illness()
                {
                    IllnessID = 1,
                    Name = "test disease 1",
                    Description = "This is a test disease that will be later removed",
                    Advice = "Speak to your GP for further information regarding this"
                },
                new Illness()
                {
                    IllnessID = 2,
                    Name = "test disease 2",
                    Description = "This is another test disease that will be later removed",
                    Advice = "Speak to a specialist re. this condition, as it could be severe"
                }
            };
        }

        public IEnumerable<Symptom> SeedSymptoms()
        {
            return new List<Symptom>()
            {
                new Symptom()
                {
                    SymptomID = 1,
                    Name = "symptom 1",
                    Description = "High fever",
                },
                new Symptom()
                {
                    SymptomID = 2,
                    Name = "symptom 2",
                    Description = "Short bursts of giggling",
                },
                new Symptom()
                {
                    SymptomID = 3,
                    Name = "symptom 3",
                    Description = "Seeing hallucinations",
                },
                new Symptom()
                {
                    SymptomID = 4,
                    Name = "symptom 4",
                    Description = "Extreme fits of anger",
                },
                new Symptom()
                {
                    SymptomID = 5,
                    Name = "symptom 5",
                    Description = "No description",
                }
            };
        }

        public IEnumerable<IllnessToSymptom> SeedIllnessToSymptoms()
        {
            return new List<IllnessToSymptom>()
            {
                new IllnessToSymptom()
                {
                    IllnessRefID = 1,
                    SymptomRefID = 1,
                },
                new IllnessToSymptom()
                {
                    IllnessRefID = 1,
                    SymptomRefID = 2,
                },
                new IllnessToSymptom()
                {
                    IllnessRefID = 1,
                    SymptomRefID = 3,
                },
                new IllnessToSymptom()
                {
                    IllnessRefID = 2,
                    SymptomRefID = 3,
                },
                new IllnessToSymptom()
                {
                    IllnessRefID = 2,
                    SymptomRefID = 4,
                },
                new IllnessToSymptom()
                {
                    IllnessRefID = 2,
                    SymptomRefID = 5,
                },
            };
        }

        public IEnumerable<Location> SeedLocations()
        {
            return new List<Location>()
            {
                new Location()
                {
                    LocationID = 1,
                    Latitude = 52.41603480972924,
                    Longitude = 0.3038958153514904,
                    Address = "11, Ely, England",
                    EmailAddress = "ElyHospital@MIC.com",
                    Telephone = "017373432732",
                    NameOfFacility = "Ely East Hospital",
                },
                new Location()
                {
                    LocationID = 2,
                    Latitude = 52.195169205297645,
                    Longitude = -1.725015876497877,
                    Address = "Alcester Rd, Stratford-upon-Avon CV37 9DD",
                    EmailAddress = "StratfordPractice@MIC.com",
                    Telephone = "017373434563",
                    NameOfFacility = "Stratford Practice",
                },
                new Location()
                {
                    LocationID = 3,
                    Latitude = 52.63389695822069,
                    Longitude = -1.1555297596794039,
                    Address = "59 Kirby Rd, Leicester LE3 6BD",
                    EmailAddress = "KirbyCareLeicester@MIC.com",
                    Telephone = "017373437632",
                    NameOfFacility = "Kirby Care Leicester",
                },
                new Location()
                {
                    LocationID = 4,
                    Latitude = 52.65556167747363,
                    Longitude = -1.1058214758058622,
                    Address = "37-1 Rosedale Ave, Leicester LE4 7AW",
                    EmailAddress = "MeditechOrthoLeicester@MIC.com",
                    Telephone = "01737368576",
                    NameOfFacility = "Meditech Orthopaedics Leicester",
                },
                new Location()
                {
                    LocationID = 5,
                    Latitude = 52.98443684698942,
                    Longitude = -1.1159675166183596,
                    Address = "Mapperley, Nottingham NG3 6AR",
                    EmailAddress = "MediTechNotts@MIC.com",
                    Telephone = "017373437656",
                    NameOfFacility = "Meditech Notts Facility",
                },
                new Location()
                {
                    LocationID = 6,
                    Latitude = 54.97737938332135, 
                    Longitude = -1.6091152090172132,
                    Address = "2 Ellison Pl, Newcastle upon Tyne NE1 8ST",
                    EmailAddress = "MediTechNewcastle@MIC.com",
                    Telephone = "017373432002",
                    NameOfFacility = "Meditech Newcastle Hospital",
                },
                new Location()
                {
                    LocationID = 7,
                    Latitude = 53.80612396608913, 
                    Longitude = -1.5704154834281872,
                    Address = "53 Cardigan Ln, Burley, Leeds LS4 2LE",
                    EmailAddress = "MediTechLeeds@MIC.com",
                    Telephone = "017373431001",
                    NameOfFacility = "Meditech Leeds Facility",
                },

            };
        }

        public IEnumerable<LocationToService> SeedLocationToServices()
        {
            return new List<LocationToService>
            {
                new LocationToService
                {
                    RefServiceID = 2,
                    RefLocationID = 1,
                },
                new LocationToService
                {
                    RefServiceID = 1,
                    RefLocationID = 1,
                },
                new LocationToService
                {
                    RefServiceID = 3,
                    RefLocationID = 1,
                },
                new LocationToService
                {
                    RefServiceID = 1,
                    RefLocationID = 2,
                },
                new LocationToService
                {
                    RefServiceID = 2,
                    RefLocationID = 2,
                },
                new LocationToService
                {
                    RefServiceID = 4,
                    RefLocationID = 2,
                },
                new LocationToService
                {
                    RefServiceID = 5,
                    RefLocationID = 5,
                },
                new LocationToService
                {
                    RefServiceID = 4,
                    RefLocationID = 6,
                },
            };
        }

        public IEnumerable<Service> SeedServices()
        {
            return new List<Service>()
            {
                new Service()
                {
                    ServiceID = 1,
                    Name = "GP",
                    Description = "GP facilities are available at this location.",
                },
                new Service()
                {
                    ServiceID = 2,
                    Name = "Plastic Surgery",
                    Description = "Cosmetic and functional plastic surgeries performed here",
                },
                new Service()
                {
                    ServiceID = 3,
                    Name = "Cardiology",
                    Description = "Services related to those of cardiovascular conditions",
                },
                new Service()
                {
                    ServiceID = 4,
                    Name = "A&E",
                    Description = "Urgent services for accidents and emergencies",
                },
                new Service()
                {
                    ServiceID = 5,
                    Name = "Physiotherapy",
                    Description = "MSK services for issues relating to muscular and skeletel co-ordination",
                },
            };
        }

        public IEnumerable<User> SeedUsers() 
        {
            return new List<User>()
            {
                new User()
                {
                    UserID = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    IsAdmin = true,
                    Email = "admin@testAdmin.com",
                    Password = "password",
                }
            };
        }


    }
}
