import { Button } from "primereact/button";
import { Card } from "primereact/card";
import { Column } from "primereact/column";
import { DataTable } from "primereact/datatable";
import { InputText } from "primereact/inputtext";


const ProfilePage = () => {
    return (
        <>
          <h1>ProfilePage</h1>
          <div className="h-full mx-5">
            <div className="w-full h-full flex flex-row">
                <Card className="flex-1 m-2 border-round-lg" title="Профиль">
                    <div className="flex flex-column">
                        <InputText className="m-2 border-round-md" placeholder="email"/>
                        <InputText className="m-2 border-round-md" placeholder="Имя"/>
                        <InputText className="m-2 mb-8 border-round-md" placeholder="Telegram"/>
                    </div>
                    <div>
                        <Button>Смена пароля</Button>
                        <Button>Сохранить</Button>
                    </div>
                </Card>
                <Card className="flex-1 m-2 border-round-lg" title="История бронирований">
                    <div className="w-full h-full">
                        <DataTable value={[{'code': 1, 'name': 'Vitaliy'}]} tableStyle={{ flex: "1 1 0%" }}>
                            <Column field="code" header="Code"></Column>
                            <Column field="name" header="Name"></Column>
                        </DataTable>
                    </div>
                </Card>
            </div>
          </div>

        </>
    )
};

export default ProfilePage;