import React, { useState, useRef } from 'react';
import FullCalendar from '@fullcalendar/react';
import resourceTimelinePlugin from '@fullcalendar/resource-timeline';
import interactionPlugin from '@fullcalendar/interaction';
import { Button } from 'primereact/button';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Toast } from 'primereact/toast';
import "./MainPage.css";
import { InputNumber } from 'primereact/inputnumber';
import { Dropdown } from 'primereact/dropdown';
import { Calendar } from 'primereact/calendar';

const BookingBoard = () => {
  const [eventDetailsDialogVisible, setEventDetailsDialogVisible] = useState(false);
  const [selectedEvent, setSelectedEvent] = useState(null);
  const [temporaryBlocks, setTemporaryBlocks] = useState([]);
  const [events, setEvents] = useState([
    {
      userId: '1',
      resourceId: 'coworking1',
      title: 'Петров Д.А\n@telegram\n+7(999)-999-99-99',
      start: '2024-12-10T06:00:00',
      end: '2024-12-10T08:00:00',
    },
  ]);
  const [selectedSlots, setSelectedSlots] = useState([]);
  const [dialogVisible, setDialogVisible] = useState(false);
  const [bookingDetails, setBookingDetails] = useState({ name: '', phone: '', telegram: '' });
  const toast = useRef(null);

  const handleEventClick = (info) => {
    setSelectedEvent(info.event);
    setEventDetailsDialogVisible(true);
  };

  const handleSelect = (info) => {
    const newSlot = {
      resourceId: info.resource.id,
      start: info.startStr,
      end: info.endStr,
    };

    // Если слот уже выбран, не добавляем его повторно
    const isAlreadySelected = selectedSlots.some(
      (slot) =>
        slot.resourceId === newSlot.resourceId &&
        slot.start === newSlot.start &&
        slot.end === newSlot.end
    );

    if (!isAlreadySelected) {
      setSelectedSlots([...selectedSlots, newSlot]);
      setTemporaryBlocks([...temporaryBlocks, newSlot]);
    }
  };

  const confirmBooking = () => {
    setDialogVisible(true);
  };

  const saveBooking = () => {
    const groupedSlots = groupSlotsByRow(selectedSlots);

    const newEvents = groupedSlots.map((group) => ({
      id: Date.now().toString() + Math.random(),
      resourceId: group.resourceId,
      title: `${bookingDetails.name}\n${bookingDetails.telegram}\n${bookingDetails.phone}`,
      start: group.start,
      end: group.end,
    }));

    setEvents((prevEvents) => [...prevEvents, ...newEvents]);
    setSelectedSlots([]);
    setTemporaryBlocks([]);
    setDialogVisible(false);
    setBookingDetails({ name: '', phone: '', telegram: '' });

    toast.current.show({
      severity: 'success',
      summary: 'Успешно',
      detail: 'Бронирование добавлено',
      life: 3000,
    });
  };

  const groupSlotsByRow = (slots) => {
    const sortedSlots = slots.sort((a, b) => new Date(a.start) - new Date(b.start));
    const grouped = [];

    sortedSlots.forEach((slot) => {
      if (
        grouped.length > 0 &&
        grouped[grouped.length - 1].resourceId === slot.resourceId &&
        new Date(grouped[grouped.length - 1].end).getTime() === new Date(slot.start).getTime()
      ) {
        // Объединяем слоты
        grouped[grouped.length - 1].end = slot.end;
      } else {
        grouped.push({ ...slot });
      }
    });

    return grouped;
  };

  const cancelBooking = () => {
    setSelectedSlots([]);
    setTemporaryBlocks([]);
  };

  const renderEventContent = (arg) => (
    <div style={{ overflow: 'hidden', textOverflow: 'ellipsis' }}>
      {arg.event.title.split('\n')[0]}
    </div>
  );

  const test = () => {
    console.log("UNSELECTED")
  }

  return (
    <div style={{ height: '100vh', display: 'flex', flexDirection: 'column', color: 'black' }}>
      <Toast ref={toast} />
      <div style={{ height: '50px' }}></div>
      <div style={{width: '400px'}}>
        <div style={{display: 'flex', justifyContent: 'center'}}>Укажите необходимые параметры</div>
        <div>
          <Dropdown type="text" placeholder='Коворкинг' name="CowName" id="CowName" style={{ width: '200px' }} />
          <InputNumber placeholder='Кол-во человек' name="Capacity" id="Capacity" style={{ width: '200px' }} />
          <Calendar />
        </div>
      </div>

      <h2 style={{ textAlign: 'center' }}>Доска бронирования</h2>
      <FullCalendar
        plugins={[resourceTimelinePlugin, interactionPlugin]}
        initialView="resourceTimelineDay"
        selectable={true}
        selectMirror={true}
        resources={[
          { id: 'coworking1', title: 'Коворкинг 1' },
          { id: 'coworking2', title: 'Коворкинг 2' },
          { id: 'coworking3', title: 'Коворкинг 3' },
          { id: 'coworking4', title: 'Коворкинг 4' },
          { id: 'coworking5', title: 'Коворкинг 5' },
        ]}
        slotMinTime="06:00:00"
        slotMaxTime="24:00:00"
        slotDuration="01:00:00"
        height="auto"
        contentHeight="auto"
        expandRows={true}
        locale="ru"
        events={events}
        select={handleSelect}
        unselect={() => test}
        eventContent={renderEventContent}
        selectOverlap={false}
        eventClick={handleEventClick}
        eventBackgroundColor="#ffcccc"
        dayHeaderFormat={{ weekday: 'long', day: 'numeric', month: 'short' }}
        eventClassNames={(eventInfo) => {
          const isSlotSelected = selectedSlots.some(
            (slot) =>
              slot.resourceId === eventInfo.event.extendedProps.resourceId &&
              slot.start === eventInfo.event.startStr &&
              slot.end === eventInfo.event.endStr
          );
          return isSlotSelected ? 'selected-slot' : '';
        }}
        eventDidMount={(info) => {
          const isTemporaryBlock = temporaryBlocks.some(
            (block) =>
              block.resourceId === info.event.extendedProps.resourceId &&
              block.start === info.event.startStr &&
              block.end === info.event.endStr
          );
          if (isTemporaryBlock) {
            info.el.style.backgroundColor = 'lightblue';
          }
        }}
      />
      <div
        style={{
          display: 'flex',
          justifyContent: 'center',
          gap: '10px',
          padding: '10px',
        }}
      >
        <Button
          label="Подтвердить бронирование"
          icon="pi pi-check"
          className="p-button-success"
          disabled={selectedSlots.length === 0}
          onClick={confirmBooking}
        />
        <Button
          label="Отменить"
          icon="pi pi-times"
          className="p-button-danger"
          disabled={selectedSlots.length === 0}
          onClick={cancelBooking}
        />
      </div>

      <Dialog
        header="Детали бронирования"
        visible={eventDetailsDialogVisible}
        style={{ width: '360px' }}
        onHide={() => setEventDetailsDialogVisible(false)}
        footer={
          <div style={{ display: 'flex', justifyContent: 'center' }}>
            <Button
              label="Закрыть"
              icon="pi pi-times"
              onClick={() => setEventDetailsDialogVisible(false)}
              className="p-button-text"
            />
          </div>
        }
      >
        {selectedEvent && (
          <div className="p-fluid">
            <div className="field" style={{ display: 'flex', width: '301px', justifyContent: 'space-between' }}>
              <div>Имя</div>
              <div>{selectedEvent.title.split('\n')[0]}</div>
            </div>
            <div className="field" style={{ display: 'flex', width: '301px', justifyContent: 'space-between' }}>
              <div>Telegram</div>
              <div>{selectedEvent.title.split('\n')[1]}</div>
            </div>
            <div className="field" style={{ display: 'flex', width: '301px', justifyContent: 'space-between' }}>
              <div>Телефон</div>
              <div>{selectedEvent.title.split('\n')[2]}</div>
            </div>
            <div className="field" style={{ display: 'flex', width: '301px', flexDirection: 'column' }}>
              <div style={{ display: 'flex', justifyContent: 'center', marginBottom: '10px' }}>Время</div>
              <div>
                {new Date(selectedEvent.start).toLocaleString()} -{' '}
                {new Date(selectedEvent.end).toLocaleString()}
              </div>
            </div>
          </div>
        )}
      </Dialog>
      <Dialog
        header="Введите данные для бронирования"
        visible={dialogVisible}
        style={{ width: '400px' }}
        onHide={() => setDialogVisible(false)}
        footer={
          <div>
            <Button label="Сохранить" icon="pi pi-check" onClick={saveBooking} />
            <Button label="Отмена" icon="pi pi-times" onClick={() => setDialogVisible(false)} className="p-button-text" />
          </div>
        }
      >
        <div className="p-fluid">
          <div className="field">
            <label htmlFor="name">Имя</label>
            <InputText
              id="name"
              value={bookingDetails.name}
              onChange={(e) => setBookingDetails({ ...bookingDetails, name: e.target.value })}
            />
          </div>
          <div className="field">
            <label htmlFor="phone">Телефон</label>
            <InputText
              id="phone"
              value={bookingDetails.phone}
              onChange={(e) => setBookingDetails({ ...bookingDetails, phone: e.target.value })}
            />
          </div>
          <div className="field">
            <label htmlFor="telegram">Telegram</label>
            <InputText
              id="telegram"
              value={bookingDetails.telegram}
              onChange={(e) => setBookingDetails({ ...bookingDetails, telegram: e.target.value })}
            />
          </div>
        </div>
      </Dialog>
    </div>
  );
};

export default BookingBoard;