import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import React, { useEffect, useState } from 'react';
import { Button, Input, Checkbox, Radio, Form, Dropdown } from 'semantic-ui-react';
import { LocalJwt } from '../types/AuthTypes';
import { OrderAddCommand } from '../types/OrderTypes';

const BASE_SIGNALR_URL = import.meta.env.VITE_API_SIGNALR_URL;

const AddOrderPage: React.FC = () => {
  const [numProducts, setNumProducts] = useState<number | ''>('');
  const [selectedOption, setSelectedOption] = useState<string>('');
  const [orderHubConnection,setOrderHubConnection] = useState<HubConnection | undefined>(undefined);

  useEffect(() => {


    const startConnection = async () => {

        const jwtJson = localStorage.getItem("upstorage_user");
        if(jwtJson){
            const localJwt:LocalJwt =JSON.parse(jwtJson);

            const connection = new HubConnectionBuilder()
                .withUrl(`${BASE_SIGNALR_URL}Hubs/OrderHub?access_token=${localJwt.accessToken}`)
                .withAutomaticReconnect()
                .build();

            await connection.start();

            setOrderHubConnection(connection);
        }
    }
    if(!orderHubConnection){
        startConnection();
    }

},[])
const [order, setOrder] = useState<OrderAddCommand>({
    requestedAmount: 0,
    totalFoundedAmount: 0,
    productCrowlType: 0,
    userId: ""
});
const handleSubmit = async () => {
    console.log("order",order)

        const orderId = await orderHubConnection?.invoke<string>("AddANewOrder",order);

        console.log(orderId)
        /*   const response = await api.post<ApiResponse<string>>("/Accounts", account);
           if(response.data) {
               console.log(`Account with ID: ${response.data.data} added successfully.`);
               // You can redirect to accounts page or show success message here.
           }*/
    }
    const handleNumProductsChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const numProducts = parseInt(event.target.value, 10);
        setOrder(prevOrder => ({
          ...prevOrder,
          requestedAmount: numProducts,
        }));
      };
    
      const handleOptionChange2 = (event: React.SyntheticEvent<HTMLElement, Event>, data: any) => {
        const selectedOption = data.value;
        setOrder(prevOrder => ({
          ...prevOrder,
          productCrowlType: selectedOption,
        }));
      };

 
  const handleScrapeButtonClick = () => {
    // Seçilen değerleri kullanarak ilgili işlemleri yapabilirsiniz
    console.log('Kazımak istediğiniz ürün sayısı:', numProducts);
    console.log('Seçilen ürün türü:', selectedOption);
  };
  enum ProductCrowlType {
    All = 0,
    OnDiscount = 1,
    NonDiscount = 2
  }
  return (
    <div style={{ marginTop: '300px' }}>
    <Form>
      <Form.Field>
        <label>Kaç ürün kazımak istiyorsunuz?</label>
        <Input
          type="number"
          value={numProducts}
          onChange={handleNumProductsChange}
          placeholder="Tüm ürünler"
        />
      </Form.Field>
      <Form.Field>
      <div>
      <Dropdown
        selection
        options={[
          { key: ProductCrowlType.All, value: ProductCrowlType.All, text: 'Hepsi' },
          { key: ProductCrowlType.OnDiscount, value: ProductCrowlType.OnDiscount, text: 'İndirimdeki Ürünler' },
          { key: ProductCrowlType.NonDiscount, value: ProductCrowlType.NonDiscount, text: 'Normal Fiyatlı Ürünler' },
        ]}
        value={selectedOption}
        onChange={handleOptionChange2}
      />
      <p>Seçili değer: {selectedOption}</p>
    </div>
      </Form.Field>
      <Button primary onClick={handleSubmit}>
        Kazımayı Başlat
      </Button>
    </Form>
  </div>
  );
};

export default AddOrderPage;
