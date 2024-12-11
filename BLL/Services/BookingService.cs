using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Domains.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly EmailService _emailService;
        public BookingService(IBookingRepository bookingRepository, EmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _emailService = emailService;
        }

        public async Task<IEnumerable<Bookings>> GetRoomsByFilter(DateTime date, int capacity, int workspace)
        {
            var freeRooms = await _bookingRepository.GetRoomsByFilter(date, capacity, workspace);
            return freeRooms;
        }

        public async Task<IEnumerable<Bookings>> GetHistoryByUser(int userId)
        {
            var history = await _bookingRepository.GetUserHistory(userId);
            return history;
        }
        public async Task CreateBooking(BookingDto bookingDto)
        {
            var newBooking = new Bookings
            {
                UserId = bookingDto.UserId,
                RoomId = bookingDto.RoomId,
                WorkspaceId = bookingDto.WorkspaceId,
                Description = bookingDto.Description,
                BookingTime = DateTime.UtcNow,
                StartTime = bookingDto.StartTime,
                EndTime = bookingDto.EndTime
            };

            await _bookingRepository.CreateBooking(newBooking);

            var toEmail = "a.evdochenko@mail.ru";
            var subject = "Подтверждение бронирования";
            var body = $@"
        <h2>Ваше бронирование успешно создано</h2>
        <p><strong>Пользователь: Andrey</strong></p>
        <p><strong>Коворкинг: Сибкодинг</strong></p>
        <p><strong>Помещение: 1</strong></p>
        <p><strong>Описание: </strong> {bookingDto.Description}</p>
        <p><strong>Время начала:</strong> {bookingDto.StartTime:dd.MM.yyyy HH:mm}</p>
        <p><strong>Время окончания:</strong> {bookingDto.EndTime:dd.MM.yyyy HH:mm}</p>
        <p>Спасибо за бронирование!</p>";

            await _emailService.SendEmailAsync(toEmail, subject, body);
        }
    }
}
