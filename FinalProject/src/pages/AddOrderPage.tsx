import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import React, { useEffect, useState } from 'react';
import { Button, Input, Checkbox, Radio, Form, Dropdown } from 'semantic-ui-react';
import { LocalJwt } from '../types/AuthTypes';
import { OrderAddCommand, ProductCrowlType } from '../types/OrderTypes';
import { NotificationGetLastDto } from '../types/NotificationTypes';
import { toast } from 'react-toastify';




const BASE_SIGNALR_URL = import.meta.env.VITE_API_SIGNALR_URL;

const AddOrderPage: React.FC = () => {
  const [numProducts, setNumProducts] = useState<number | ''>('');
  const [selectedOption, setSelectedOption] = useState<string>('');
  const [orderHubConnection, setOrderHubConnection] = useState<HubConnection | undefined>(undefined);
  const [notifictionHubConnection, setNotifictionHubConnection] = useState<HubConnection | undefined>(undefined);
  const [notifiction, setNotifiction] = useState<NotificationGetLastDto>();
  const [isLoading, setIsLoading] = useState(false); // New state variable for loading



  useEffect(() => {


    const startConnection = async () => {

      const jwtJson = localStorage.getItem("upstorage_user");
      if (jwtJson) {
        const localJwt: LocalJwt = JSON.parse(jwtJson);

        const connection = new HubConnectionBuilder()
          .withUrl(`${BASE_SIGNALR_URL}Hubs/OrderHub?access_token=${localJwt.accessToken}`)
          .withAutomaticReconnect()
          .build();

        await connection.start();

        setOrderHubConnection(connection);

        const connectionNotification = new HubConnectionBuilder()
          .withUrl(`${BASE_SIGNALR_URL}Hubs/NotificationHub?access_token=${localJwt.accessToken}`)
          .withAutomaticReconnect()
          .build();

          await connectionNotification.start();

          connectionNotification.on('NewNotificationAdded', (notification: NotificationGetLastDto) => {
            setNotifiction(notification);
            showToast(notification.title); // Toast bildirimi göster
          });

        setNotifictionHubConnection(connectionNotification);

      }
    }
    if (!orderHubConnection) {
      startConnection();
    }
    if (!notifictionHubConnection) {
      startConnection();
    }

  }, [])

  const showToast = (updatedData: string) => {
    toast(`${updatedData}`);
  };

  const [order, setOrder] = useState<OrderAddCommand>({
    requestedAmount: 0,
    totalFoundedAmount: 0,
    productCrowlType: 0,
    userId: ""
  });
  const handleSubmit = async () => {
    try {
      setIsLoading(true); 
      const orderId = await orderHubConnection?.invoke<string>("AddANewOrder", order);
      console.log(orderId);
      setIsLoading(false); 
    } catch (error) {
      console.error("Error while invoking AddANewOrder:", error);
    }
  }
  const handleNumProductsChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const numProducts = parseInt(event.target.value, 10);
    setNumProducts(Number(event.target.value));
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

    setSelectedOption(selectedOption);
  };


  const handleScrapeButtonClick = () => {
    // Seçilen değerleri kullanarak ilgili işlemleri yapabilirsiniz
    console.log('Kazımak istediğiniz ürün sayısı:', numProducts);
    console.log('Seçilen ürün türü:', selectedOption);
  };
  
  return (
    <div style={{ marginTop: '300px' }}>
      {isLoading && <div>Loading...</div>} {/* Show "Loading..." when isLoading is true */}
      <Form>
        <Form.Field>
          <label style={{ color: '#2185D0', fontSize: '20px', fontWeight: 'bold', marginBottom: '10px' }}>
          How many products do you want to crawl?
          </label>
          <Input
            type="number"
            value={numProducts}
            onChange={handleNumProductsChange}
            placeholder={`Product quantity (${numProducts} )`}
            style={{ fontSize: '16px', width: '350px', height: '40px' }}

          />
        </Form.Field>
        <Form.Field>
          <div>
            <Dropdown
              selection
              options={[
                { key: ProductCrowlType.All, value: ProductCrowlType.All, text: 'All' },
                { key: ProductCrowlType.OnDiscount, value: ProductCrowlType.OnDiscount, text: 'On Discount' },
                { key: ProductCrowlType.NonDiscount, value: ProductCrowlType.NonDiscount, text: 'Non Discount' },
              ]}
              value={selectedOption}
              onChange={handleOptionChange2}
              placeholder={`Selected value: ${selectedOption}`}
              className='custom-navbar'
              style={{ fontSize: '16px', width: '350px', height: '40px' }}

            />
          </div>
        </Form.Field>
        <Button primary onClick={handleSubmit}>
        Start crawling
        </Button>
      </Form>
     
    </div>
    
  );
};

export default AddOrderPage;
