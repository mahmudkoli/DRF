﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Common;
using DRF.Entities;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class AppointmentService
    {
        private AppointmentUnitOfWork _appointmentUnitOfWork;

        public AppointmentService()
        {
            _appointmentUnitOfWork = new AppointmentUnitOfWork(new DRFDbContext());
        }

        public bool Add(Appointment appointment)
        {
            try
            {
                var newAppointment = new Appointment()
                {
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    ChamberId = appointment.ChamberId,
                    AppointmentDate = appointment.AppointmentDate,
                    AppointmentTime = appointment.AppointmentTime,
                    AppointmentType = appointment.AppointmentType,
                    AppointmentFees = appointment.AppointmentFees,
                    AppointmentStatus = (int)CustomEnum.AppointmentStatus.Requested,
                    Disease = appointment.Disease
                };

                _appointmentUnitOfWork.AppointmentRepository.Add(newAppointment);
                return _appointmentUnitOfWork.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public IEnumerable<Appointment> GetAllByDoctorId(int id, int? status, int? lastDays)
        {
            var data = _appointmentUnitOfWork.AppointmentRepository.GetAllByDoctorId(id);
            data = status == null ? data : data.Where(x => x.AppointmentStatus == status);
            data = lastDays == null ? data : data.Where(x => x.CreatedAt != null && x.CreatedAt.Value.AddDays(1) >= DateTime.Now.AddDays(-lastDays.Value));
            return data;
        }

        public bool ApprovedAppointmentById(int id)
        {
            try
            {
                var appointment = _appointmentUnitOfWork.AppointmentRepository.GetById(id);
                appointment.AppointmentStatus = (int)CustomEnum.AppointmentStatus.Approved;
                appointment.UpdatedAt = DateTime.Now;

                return _appointmentUnitOfWork.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool RejectedAppointmentById(int id)
        {
            try
            {
                var appointment = _appointmentUnitOfWork.AppointmentRepository.GetById(id);
                appointment.AppointmentStatus = (int)CustomEnum.AppointmentStatus.Rejected;
                appointment.UpdatedAt = DateTime.Now;

                return _appointmentUnitOfWork.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public Appointment GetRecentConfirmAppointmentInfoByPatientId(int patientId)
        {
            var entity = _appointmentUnitOfWork.AppointmentRepository.GetAllByPatientIdWithStatus(patientId, 
                (int)CustomEnum.AppointmentStatus.Approved).FirstOrDefault();
            return entity;
        }

        public IEnumerable<Appointment> GetAllByPatientId(int id, int? status, int? lastDays)
        {
            var data = _appointmentUnitOfWork.AppointmentRepository.GetAllByPatientId(id);
            data = status == null ? data : data.Where(x => x.AppointmentStatus == status);
            data = lastDays == null ? data : data.Where(x => x.CreatedAt != null && x.CreatedAt.Value.AddDays(1) >= DateTime.Now.AddDays(-lastDays.Value));
            return data;
        }
    }
}
