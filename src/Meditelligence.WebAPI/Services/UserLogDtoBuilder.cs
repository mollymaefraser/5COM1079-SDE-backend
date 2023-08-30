using Meditelligence.DataAccess.Context;
using Meditelligence.DTOs.Read;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Meditelligence.WebAPI.Services
{
    public class UserLogDtoBuilder
    {
        //private readonly MeditelligenceDBContext _context;

        //public UserLogDtoBuilder(MeditelligenceDBContext context) 
        //{
        //    _context = context;
        //}

        //public UserLogReadDto GenerateAllLogDto()
        //{
        //    var preProcessedLog = _context.UserLogs.Include("AssociatedUser").Include("AssociatedIllness").Include("AssociatedIllness.Name");


        //    var AllUserLoginformation = from ul in _context.UserLogs
        //                             join u in _context.Users on ul.UserID equals u.UserID
        //                             join i in _context.Illnesses on ul.PredictedDiagnosisID equals i.IllnessID
        //                             select new
        //                             {
        //                                 ul.LogID,
        //                                 ul.LogDate,
        //                                 i.Name,
        //                                 u.UserID,
        //                                 u.FirstName,
        //                                 u.LastName,
        //                             };

        //    foreach (var userlog in AllUserLoginformation)
        //    {

        //    }
        //}
    }
}
