using BusinessLogic.IRepository;
using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Repository
{
    public class SeminarRepository: ISeminarRepository
    {
        DarceiAvotContext _dbContext;

        public SeminarRepository(DarceiAvotContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<SeminarDetail> AddSeminar(SeminarDetail seminar)
        {
            try
            {
                _dbContext.SeminarDetails.Add(seminar);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Add Seminar" + ex.Message);
            }
            return seminar;
        }

        public async Task<SeminarDetail> UpdateSeminar(int id, SeminarDetail seminar)
        {
            try
            {
                SeminarDetail seminar1 = await _dbContext.SeminarDetails.FindAsync(id);
                if (seminar1 != null)
                {
                    seminar1.Title = seminar.Title;
                    seminar1.Date = seminar.Date;
                    seminar1.Place = seminar.Place;
                    seminar1.Lectures = seminar.Lectures;
                    seminar1.Crowed = seminar.Crowed;
                    seminar1.Program = seminar.Program;
                    _dbContext.SeminarDetails.Update(seminar1);
                    await _dbContext.SaveChangesAsync();
                }
                return seminar1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Update Seminar" + ex.Message);
            }
        }

        public async Task<List<SeminarParticipant>> GetParticipantsBySeminar(int seminarId)
        {
            try
            {
                List <SeminarParticipant> SeminarParticipant = await _dbContext.SeminarParticipants.Where(s => s.SeminarId == seminarId).ToListAsync();
                return SeminarParticipant;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Get Participants By Seminar" + ex.Message);
            }
        }

        public async Task<List<SeminarDetail>> GetSeminars()
        {
            try
            {

                return await _dbContext.SeminarDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error in GetSeminars" + ex.Message);
            }

        }

        public async Task<List<SeminarDetail>> GetSeminarDetailsByParams(int SeminarId = -1)
        {
            var seminars=await (from seminar in _dbContext.SeminarDetails
                                  where (seminar.SeminarId == SeminarId || SeminarId == -1) 
                                  select seminar).ToListAsync();
            return seminars;
        }
        public async Task GetEmail(string email,int id)
        {
            using (SmtpClient client = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Port = 587,
                UseDefaultCredentials = false, // This require to be before setting Credentials property
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("darceiavot@outlook.com", "Rg123!@#"), // you must give a full email address for authentication 
                TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
                EnableSsl = true // Set to avoid secure connection exception
            })
            {

                MailMessage message = new MailMessage()
                {
                    
                    From = new MailAddress("darceiavot@outlook.com"), // sender must be a full email address
                    Subject = "הרשמה ליום עיון",
                    IsBodyHtml = true,
                    Body = $"<h5>להרשמה לחצו על הלינק הבא:</h5><br><a href=\"http://localhost:3000/AddParticipantToSeminar/{id}\">להרשמה ליום העיון לחץ כאן</a>",
                    BodyEncoding = System.Text.Encoding.UTF8,
                    SubjectEncoding = System.Text.Encoding.UTF8,

                };

                message.To.Add(email);

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        public async Task SetProgram(int seminarId, string fileName)
        {
            try
            {
                SeminarDetail s = _dbContext.SeminarDetails.Find(seminarId);
                if (s != null)
                {
                    s.Program = fileName;
                    _dbContext.Update(s);
                    await _dbContext.SaveChangesAsync();
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error in SetProgram function " + ex.Message);
            }
        }
        //hi
        public async Task UploadFile(int seminarId, IFormFile userfile)
        {
            try
            {
                Image image = new Image() { FilePath = "images/" + userfile.FileName, FileName = userfile.FileName };
                await _dbContext.AddAsync(image);
                await _dbContext.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception("Error in SetProgram function " + ex.Message);
            }
        }

    }
}
