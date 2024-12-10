import React, { useState } from "react";
import { Calendar } from "primereact/calendar";
import "primereact/resources/themes/saga-blue/theme.css";
import "primereact/resources/primereact.min.css";
import "primeicons/primeicons.css";
import "primeflex/primeflex.css";

const BookingBoard = () => {
  const [selectedDate, setSelectedDate] = useState(new Date());
  const [bookings, setBookings] = useState([
    { room: "Room 1", time: "09:00", booked: false },
    { room: "Room 1", time: "10:00", booked: true },
    { room: "Room 2", time: "09:00", booked: false },
    { room: "Room 2", time: "10:00", booked: false },
  ]);

  // Генерация временных интервалов
  const generateTimeSlots = () => {
    const slots = [];
    for (let hour = 9; hour < 18; hour++) {
      slots.push(`${hour}:00`);
    }
    return slots;
  };

  // Обработчик бронирования
  const handleBooking = (room, time) => {
    setBookings((prevBookings) =>
      prevBookings.map((booking) =>
        booking.room === room && booking.time === time
          ? { ...booking, booked: !booking.booked }
          : booking
      )
    );
  };

  // Генерация строк для таблицы
  const generateRows = () => {
    const timeSlots = generateTimeSlots();
    return timeSlots.map((time) => (
      <tr key={time}>
        <td className="p-text-center">{time}</td>
        {["Room 1", "Room 2"].map((room) => {
          const booking = bookings.find(
            (b) => b.room === room && b.time === time
          );
          return (
            <td
              key={room}
              className={`p-text-center ${
                booking?.booked ? "p-bg-danger p-text-white" : "p-bg-success"
              }`}
              onClick={() => handleBooking(room, time)}
            >
              {booking?.booked ? "Забронировано" : "Свободно"}
            </td>
          );
        })}
      </tr>
    ));
  };

  return (
    <div className="p-grid p-justify-center p-align-center p-mt-4">
      <div className="p-col-12 p-md-8 p-lg-6">
        <div className="p-card">
          <h2 className="p-card-title p-text-center">
            Доска бронирования комнат
          </h2>
          <div className="p-card-content p-text-center p-mb-3">
            <Calendar
              value={selectedDate}
              onChange={(e) => setSelectedDate(e.value)}
              showIcon
              dateFormat="dd.mm.yy"
            />
          </div>
          <div className="p-card-content">
            <table className="p-table p-table-striped">
              <thead>
                <tr>
                  <th className="p-text-center">Время</th>
                  <th className="p-text-center">Room 1</th>
                  <th className="p-text-center">Room 2</th>
                </tr>
              </thead>
              <tbody>{generateRows()}</tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  );
};

export default BookingBoard;