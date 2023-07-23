import React, { useContext, useEffect, useState } from 'react';
import api from '../utils/axiosInstance';
import { OrdersContext } from '../context/StateContext';
import { OrderGetAllDto, ProductCrowlType } from '../types/OrderTypes';
import { Button, Modal, Table } from 'semantic-ui-react';
import { OrderEventGetAllDto, OrderEventGetAllQuery, OrderStatus } from '../types/OrderEventTypes';

function ListOrdersPage() {
  //const { orders, setOrders } = useContext(OrdersContext);

  const [orders, setOrders] = useState<OrderGetAllDto[]>([]);
  const [modalOpen, setModalOpen] = useState(false);
  const [orderEvents, setOrderEvents] = useState<OrderEventGetAllDto[]>([]);

  useEffect(() => {
    const fetchOrders = async () => {
      try {
        const response = await api.get<OrderGetAllDto[]>("/Orders/OrderList", {
          headers: {
            "Content-Type": "application/json",
          },
        });
        console.log(response.data);
        setOrders(response.data); // Set the fetched data in the OrdersContext state
        console.log("setorders", setOrders);
      } catch (error) {
        console.error("Error fetching orders:", error);
      }
    };

    fetchOrders();
  }, []);

  async function fetchOrderEvents(orderId:string) {
    try {
      const orderEventQuery: OrderEventGetAllQuery = {
        orderId: orderId,
      };
      const response = await api.post<OrderEventGetAllDto[]>("/OrderEvents/GetAll",orderEventQuery)
        setOrderEvents(response.data);
    } catch (error) {
      console.error('Error fetching order events:', error);
    }
  }

  function openModal(orderId:string) {
    fetchOrderEvents(orderId)
    setModalOpen(true);
  }

  function exportToExcel(orderid:string){

  }

  function closeModal() {
    setModalOpen(false);
  }

  
  function formatDate(dateString: string) {
    const options: Intl.DateTimeFormatOptions = {
      day: 'numeric',
      month: 'long',
      year: 'numeric',
      hour: 'numeric',
      minute: 'numeric',
    };
    const date = new Date(dateString);
    return date.toLocaleString('en-En', options);
  }

  return (
    <div style={{ marginTop: '75px' }}>
      <Table celled>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell>ID</Table.HeaderCell>
            <Table.HeaderCell>Requested Amount</Table.HeaderCell>
            <Table.HeaderCell>Total Founded Amount</Table.HeaderCell>
            <Table.HeaderCell>Product Crowl Type</Table.HeaderCell>
            <Table.HeaderCell>Products</Table.HeaderCell>
            <Table.HeaderCell>Order Events</Table.HeaderCell>

          </Table.Row>
        </Table.Header>
        <Table.Body>
          {orders.map((order) => (
            <Table.Row key={order.id}>
              <Table.Cell>{order.id}</Table.Cell>
              <Table.Cell>{order.requestedAmount}</Table.Cell>
              <Table.Cell>{order.totalFoundedAmount}</Table.Cell>
              <Table.Cell>{ProductCrowlType[order.productCrowlType]}</Table.Cell>
              <Table.Cell>
                {/* Detayları göster düğmesini ekleyin ve tıklamada OrderProductsPage component'ına order ID'sini geçirin */}
                <Button primary onClick={() => window.location.href = `/productListPage/${order.id}`}>Products</Button>
              </Table.Cell>
              <Table.Cell>
                {/* Detayları göster düğmesini ekleyin ve tıklamada OrderProductsPage component'ına order ID'sini geçirin */}
                <Button primary onClick={() => openModal(order.id)}>Order Events</Button>
              </Table.Cell>
          
            </Table.Row>

          ))}
        </Table.Body>
      </Table>
      <Modal open={modalOpen} onClose={closeModal}>
        <Modal.Header>Order Events</Modal.Header>
        <Modal.Content>
        <Table celled>
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell>Status</Table.HeaderCell>
            <Table.HeaderCell>Created On</Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {orderEvents.map((orderEvent) => (
            <Table.Row key={orderEvent.id}>
              <Table.Cell>{OrderStatus[orderEvent.status]}</Table.Cell>
              <Table.Cell>{formatDate(orderEvent.createdOn)}</Table.Cell>
            </Table.Row>

          ))}
        </Table.Body>
      </Table>
        </Modal.Content>
        <Modal.Actions>
          <Button onClick={closeModal}>Close</Button>
        </Modal.Actions>
      </Modal>
    </div>
  );
}

export default ListOrdersPage;

