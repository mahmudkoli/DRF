using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class ScheduleService
    {
        private ScheduleUnitOfWork _scheduleUnitOfWork;

        public ScheduleService()
        {
            _scheduleUnitOfWork = new ScheduleUnitOfWork(new DRFDbContext());
        }

        public bool Add(Schedule entity)
        {
            try
            {
                var newEntity = new Schedule()
                {
                    ChamberId = entity.ChamberId,
                    DoctorId = entity.DoctorId,
                    Day = entity.Day,
                    StartTime = entity.StartTime,
                    EndTime = entity.EndTime,
                    DurationTime = entity.DurationTime
                };

                _scheduleUnitOfWork.ScheduleRepository.Add(newEntity);
                return _scheduleUnitOfWork.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool AddRange(IEnumerable<Schedule> entities)
        {
            try
            {
                var newEntities = entities.Select(x => new Schedule()
                {
                    ChamberId = x.ChamberId,
                    DoctorId = x.DoctorId,
                    Day = x.Day,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    DurationTime = x.DurationTime
                });

                _scheduleUnitOfWork.ScheduleRepository.AddRange(newEntities);
                return _scheduleUnitOfWork.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public IEnumerable<Schedule> GetAllByDoctorId(int doctorId)
        {
            return _scheduleUnitOfWork.ScheduleRepository.GetAllByDoctorId(doctorId);
        }

        public IEnumerable<Schedule> GetDoctorAvailableDay(int doctorId, int chamberId)
        {
            return _scheduleUnitOfWork.ScheduleRepository.GetDoctorAvailableDay(doctorId, chamberId);
        }

        public IEnumerable<Schedule> GetDoctorAvailableTime(int doctorId, int chamberId, int day)
        {
            return _scheduleUnitOfWork.ScheduleRepository.GetDoctorAvailableTime(doctorId, chamberId, day);
        }
    }
}
