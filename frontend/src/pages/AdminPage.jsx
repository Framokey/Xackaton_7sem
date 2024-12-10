import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { useEffect, useState } from 'react';
import { InputText } from 'primereact/inputtext';

const AdminPage = () => {
  //const [data, setData] = useState([]);
  const columns = [
    { field: 'KowName', header: 'Название коворкинга' },
    { field: 'RoomNum', header: 'Номер комнаты' },
    { field: 'UserName', header: 'Пользователь' },
    { field: 'Event', header: 'Занятость' }
  ];

  const datas = [
    {
      KowName: "Коворкинг1",
      RoomNum: "1",
      UserName: "IVAN",
      Event: "2024.12.11 08:00 - 2024.12.11 10:00"
    },
    {
      KowName: "Коворкинг1",
      RoomNum: "2",
      UserName: "ANDREY",
      Event: "2024.12.11 10:00 - 2024.12.11 12:00"
    },
    {
      KowName: "Коворкинг2",
      RoomNum: "1",
      UserName: "VITALYA",
      Event: "2024.12.11 08:00 - 2024.12.11 12:00"
    }
  ]

  // useEffect(() => {

  // }, [])

  const textEditor = (options) => {
    return <InputText type="text" value={options.value} onChange={(e) => options.editorCallback(e.target.value)} />;
  };

  const allowEdit = (rowData) => {
    return rowData.KowName !== 'Коворкинг2';
  };

  return (
    <>
      <DataTable value={datas} >
      <Column rowEditor={allowEdit} headerStyle={{ width: '10%', minWidth: '8rem' }} bodyStyle={{ textAlign: 'center' }} value={"X"}></Column>
        {columns.map((col, i) => (
          <Column key={col.field} field={col.field} header={col.header} editor={(options) => textEditor(options)} />
        ))}
        
      </DataTable>
    </>
  )
}

export default AdminPage;